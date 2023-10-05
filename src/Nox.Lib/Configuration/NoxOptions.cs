using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.CodeAnalysis;
using Microsoft.AspNetCore.Builder;

using MassTransit;
using Serilog;

using Nox.Secrets;
using Nox.Secrets.Abstractions;
using Nox.Solution;
using Nox.Messaging.AzureServiceBus;
using Nox.Messaging;
using Nox.Types.EntityFramework.Abstractions;
using Nox.EntityFramework.Sqlite;
using Nox.EntityFramework.Postgres;
using Nox.EntityFramework.SqlServer;
using Nox.Messaging.InMemoryBus;
using Nox.OData;

namespace Nox.Configuration
{
    internal sealed class NoxOptions : INoxOptions
    {
        private Assembly? _clientAssembly;
        private NoxSolution? _noxSolution;
        private Action<IBusRegistrationConfigurator, DatabaseServerProvider>? _configureMassTransitTransactionalOutbox;
        private Action<IServiceCollection>? _configureDatabaseContext;
        private Action<LoggerConfiguration>? _loggerConfigurationAction;
        private Action<IServiceCollection>? _configureSwagger;

        private bool _withNoxLogging = true;

        public INoxOptions WithoutNoxLogging()
        {
            _withNoxLogging = false;
            _loggerConfigurationAction = null;

            return this;
        }

        public INoxOptions WithNoxLogging(Action<LoggerConfiguration> loggerConfiguration)
        {
            _loggerConfigurationAction = loggerConfiguration;
            _withNoxLogging = true;

            return this;
        }

        public INoxOptions WithDatabaseContexts<T, D>() where T : DbContext where D : DbContext
        {
            _configureDatabaseContext = (services) =>
            {
                services.AddSingleton<DbContextOptions<T>>();
                services.AddDbContext<T>();
                services.AddDbContext<D>();
            };

            return this;
        }

        public INoxOptions WithoutMessagingTransactionalOutbox()
        {
            _configureMassTransitTransactionalOutbox = null;

            return this;
        }

        public INoxOptions WithMessagingTransactionalOutbox<T>(bool disableDeliveryService = false) where T : DbContext
        {
            _configureMassTransitTransactionalOutbox = (_serviceCollectionBusConfigurator, databaseProvider) =>
            {
                _serviceCollectionBusConfigurator.AddEntityFrameworkOutbox<T>(o =>
                {
                    switch (databaseProvider)
                    {
                        case DatabaseServerProvider.MySql:
                            o.UseMySql();
                            break;

                        case DatabaseServerProvider.SqlServer:
                            o.UseSqlServer();
                            break;

                        case DatabaseServerProvider.Postgres:
                            o.UsePostgres();
                            break;

                        case DatabaseServerProvider.SqLite:
                            o.UseSqlite();
                            break;

                        default:
                            throw new NotImplementedException();
                    }

                    //We do not need to clean up the inbox, not being used
                    o.DisableInboxCleanupService();

                    //Disable message delivery
                    if (disableDeliveryService)
                    {
                        o.UseBusOutbox(c => c.DisableDeliveryService());
                    }
                    else
                    {
                        // enable the bus outbox
                        o.UseBusOutbox();
                    }
                });
            };

            return this;
        }

        public INoxOptions WithClientAssembly(Assembly clientAssembly)
        {
            if (clientAssembly is null)
            {
                throw new ArgumentNullException(nameof(clientAssembly));
            }
            _clientAssembly = clientAssembly;

            return this;
        }

        public INoxOptions WithSwagger()
        {
            _configureSwagger = services =>
                services.AddSwaggerGen(opts =>
                {
                    opts.SchemaFilter<DeltaSchemaFilter>();
                });

            return this;
        }

        public void Configure(IServiceCollection services, WebApplicationBuilder? webApplicationBuilder)
        {
            var referencedAssemblies = _clientAssembly!.GetReferencedAssemblies();

            // Nox + Entry Assembly
            var noxAndEntryAssemblies = referencedAssemblies
                .Where(a => a.Name != null && a.Name.StartsWith("Nox"))
                .Select(Assembly.Load)
                .Union(new[] { _clientAssembly! }).ToArray();

            _noxSolution = CreateSolution(services.BuildServiceProvider());

            services
                .AddSingleton(typeof(NoxSolution), _noxSolution)
                .AddSingleton(typeof(INoxClientAssemblyProvider), serviceProvider => new NoxClientAssemblyProvider(_clientAssembly))
                .AddNoxHttpDefaults()
                .AddSecretsResolver()
                .AddNoxMediatR(_clientAssembly)
                .AddNoxFactories(noxAndEntryAssemblies)
                .AddNoxProviders()
                .AddNoxDtos();

            TryAddNoxMessaging(services, _noxSolution, noxAndEntryAssemblies);
            TryAddNoxDatabase(services, _noxSolution, noxAndEntryAssemblies);

            TryAddLogging(webApplicationBuilder);
            TryAddSwagger(services);
        }

        private bool TryAddLogging(WebApplicationBuilder? webApplicationBuilder)
        {
            if (webApplicationBuilder != null && _withNoxLogging)
            {
                webApplicationBuilder.Host.UseSerilog((context, services, loggerConfig) =>
                {
                    loggerConfig
                    .ReadFrom.Configuration(context.Configuration)
                    .ReadFrom.Services(services)
                    .Enrich.FromLogContext()
                    .WriteTo.Debug()
                    .WriteTo.Console();

                    _loggerConfigurationAction?.Invoke(loggerConfig);
                });
                return true;
            }
            return false;
        }

        private bool TryAddNoxDatabase(IServiceCollection services, NoxSolution noxSolution, Assembly[] noxAssemblies)
        {
            if (noxSolution.Infrastructure?.Persistence is { DatabaseServer: not null })
            {
                services.Scan(scan => scan
                    .FromAssemblies(noxAssemblies)
                    .AddClasses(classes => classes.AssignableTo<INoxTypeDatabaseConfigurator>())
                    .As<INoxTypeDatabaseConfigurator>()
                    .WithSingletonLifetime()
                );

                // Add Providers
                var dbProviderType = noxSolution.Infrastructure.Persistence.DatabaseServer.Provider switch
                {
                    DatabaseServerProvider.SqlServer => typeof(SqlServerDatabaseProvider),
                    DatabaseServerProvider.Postgres => typeof(PostgresDatabaseProvider),
                    DatabaseServerProvider.SqLite => typeof(SqliteDatabaseProvider),
                    _ => throw new NotImplementedException()
                };

                services.AddSingleton(typeof(INoxDatabaseConfigurator), dbProviderType);
                services.AddSingleton(typeof(INoxDatabaseProvider), dbProviderType);

                // Add DbContexts
                _configureDatabaseContext?.Invoke(services);

                return true;
            }
            return false;
        }

        private bool TryAddNoxMessaging(IServiceCollection services, NoxSolution noxSolution, Assembly[] noxAssemblies)
        {
            if (noxSolution.Infrastructure?.Messaging?.IntegrationEventServer is null)
            {
                return false;
            }

            MessagingServer messagingConfig = noxSolution.Infrastructure!.Messaging!.IntegrationEventServer!;

            services.AddScoped<IOutboxRepository, OutboxRepository>();
            services.AddMassTransit(x =>
            {
                IMessageBrokerProvider messageBrokerProvider = messagingConfig.Provider switch
                {
                    MessageBrokerProvider.AzureServiceBus => new AzureServiceBusBrokerProvider(),
                    MessageBrokerProvider.InMemory => new InMemoryBrokerProvider(),
                    //MessageBrokerProvider.RabbitMq => throw new NotImplementedException(),
                    //MessageBrokerProvider.AmazonSqs => throw new NotImplementedException(),
                    _ => throw new NotImplementedException()
                };
                messageBrokerProvider.ConfigureMassTransit(messagingConfig, x);

                _configureMassTransitTransactionalOutbox?.Invoke(x, noxSolution.Infrastructure.Persistence.DatabaseServer.Provider);
            });

            return true;
        }

        private bool TryAddSwagger(IServiceCollection services)
        {
            if (_configureSwagger != null)
            {
                _configureSwagger(services);
                return true;
            }
            return false;
        }

        private static NoxSolution CreateSolution(IServiceProvider serviceProvider)
        {
            return new NoxSolutionBuilder()
                .OnResolveSecrets((_, args) =>
                {
                    var secretsConfig = args.SecretsConfig;
                    var secretKeys = args.Variables;
                    // TODO Create Nox Solution withou using the container
                    // This is configuration and is needed in service configuration
                    var resolver = serviceProvider.GetRequiredService<INoxSecretsResolver>();
                    resolver.Configure(secretsConfig!, Assembly.GetEntryAssembly());
                    args.Secrets = resolver.Resolve(secretKeys!);
                })
                .Build();
        }
    }
}