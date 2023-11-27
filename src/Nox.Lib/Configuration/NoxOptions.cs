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
using Nox.Infrastructure.Messaging;
using Nox.Types.EntityFramework.Abstractions;
using Nox.EntityFramework.Sqlite;
using Nox.EntityFramework.Postgres;
using Nox.EntityFramework.SqlServer;
using Nox.OData;
using Nox.Infrastructure.Messaging.InMemoryBus;
using Nox.Infrastructure.Messaging.AzureServiceBus;
using Nox.Infrastructure;
using Nox.Integration;
using Nox.Integration.Extensions;
using Nox.Yaml.VariableProviders.Environment;

namespace Nox.Configuration
{
    internal sealed class NoxOptions : INoxOptions
    {
        private Assembly? _clientAssembly;
        private Action<IBusRegistrationConfigurator, DatabaseServerProvider>? _configureMassTransitTransactionalOutbox;
        private Action<IServiceCollection>? _configureDatabaseContext;
        private Action<LoggerConfiguration>? _loggerConfigurationAction;

        private bool _withNoxLogging = true;
        private bool _withSwagger = true;

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

        public INoxOptions WithoutSwagger()
        {
            _withSwagger = false;

            return this;
        }

        public void Configure(IServiceCollection services, WebApplicationBuilder? webApplicationBuilder)
        {
            var referencedAssemblies = _clientAssembly!
                .GetReferencedAssemblies()
                .Union(Assembly.GetExecutingAssembly()!.GetReferencedAssemblies())
                .Distinct();

            // Nox + Entry Assembly
            var noxAndEntryAssemblies = referencedAssemblies
                .Where(a => a.Name != null && a.Name.StartsWith("Nox"))
                .Select(Assembly.Load)
                .Union(new[] { _clientAssembly! }).ToArray();

            var noxSolution = CreateSolution(services.BuildServiceProvider());

            services
                .AddSingleton(typeof(NoxSolution), noxSolution)
                .AddSingleton(typeof(INoxClientAssemblyProvider), serviceProvider => new NoxClientAssemblyProvider(_clientAssembly))
                .AddSingleton(typeof(NoxCodeGenConventions), serviceProvider => new NoxCodeGenConventions(serviceProvider.GetRequiredService<NoxSolution>()))
                .AddNoxHttpDefaults()
                .AddSecretsResolver()
                .AddNoxMediatR(_clientAssembly)
                .AddNoxFactories(noxAndEntryAssemblies)
                .AddEtlBox()
                .AddNoxIntegrations(noxSolution)
                .AddNoxProviders()
                .AddNoxDtos();

            AddNoxMessaging(services, noxSolution);
            AddNoxDatabase(services, noxSolution, noxAndEntryAssemblies);

            AddLogging(webApplicationBuilder);
            AddSwagger(services);
        }

        private void AddLogging(WebApplicationBuilder? webApplicationBuilder)
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
            }
        }

        private void AddNoxDatabase(IServiceCollection services, NoxSolution noxSolution, Assembly[] noxAssemblies)
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
            }
        }

        private void AddNoxMessaging(IServiceCollection services, NoxSolution noxSolution)
        {
            if (noxSolution.Infrastructure?.Messaging?.IntegrationEventServer is null)
            {
                return;
            }

            var messagingConfig = noxSolution.Infrastructure!.Messaging!.IntegrationEventServer!;

            services.AddScoped<IOutboxRepository, OutboxRepository>();
            services.AddMassTransit(x =>
            {
                IMessageBrokerProvider messageBrokerProvider = messagingConfig.Provider switch
                {
                    MessageBrokerProvider.AzureServiceBus => new AzureServiceBusBrokerProvider(noxSolution),
                    MessageBrokerProvider.InMemory => new InMemoryBrokerProvider(noxSolution),
                    //MessageBrokerProvider.RabbitMq => throw new NotImplementedException(),
                    //MessageBrokerProvider.AmazonSqs => throw new NotImplementedException(),
                    _ => throw new NotImplementedException()
                };
                messageBrokerProvider.ConfigureMassTransit(messagingConfig, x);

                _configureMassTransitTransactionalOutbox?.Invoke(x, noxSolution.Infrastructure.Persistence!.DatabaseServer.Provider);
            });
        }

        private void AddSwagger(IServiceCollection services)
        {
            if (!_withSwagger) return;

            services.AddSwaggerGen(opts =>
            {
                opts.SchemaFilter<DeltaSchemaFilter>();
            });
        }

        private static NoxSolution CreateSolution(IServiceProvider serviceProvider)
        {
            var secretsProvider = new SecretsVariableValueProvider<NoxSolutionBasicsOnly>( (s, v) =>
            {
                var secretsConfig = s.Infrastructure?.Security?.Secrets;
                if (secretsConfig is not null)
                {
                    var resolver = serviceProvider.GetRequiredService<INoxSecretsResolver>();
                    resolver.Configure(secretsConfig, Assembly.GetEntryAssembly());
                    return resolver.Resolve(v);
                }
                return new Dictionary<string,string?>();
            });

            return new NoxSolutionBuilder()
                .WithSecretsVariableValueProvider(secretsProvider)
                .Build();
        }
    }
}