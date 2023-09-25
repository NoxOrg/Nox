using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.CodeAnalysis;

using MassTransit;

using Nox.Secrets;
using Nox.Secrets.Abstractions;
using Nox.Solution;
using Nox.Messaging.AzureServiceBus;
using Nox.Messaging;
using Nox.Types.EntityFramework.Abstractions;
using Nox.EntityFramework.Sqlite;
using Nox.EntityFramework.Postgres;
using Nox.EntityFramework.SqlServer;

namespace Nox.Configuration
{
    internal sealed class NoxBuilderConfigurator : INoxBuilderConfigurator
    {
        private Assembly? _clientAssembly;
        private NoxSolution? _noxSolution;
        private Action<IBusRegistrationConfigurator, DatabaseServerProvider>? _configureMassTransitTransactionalOutbox;
        private Action<IServiceCollection>? _configureDatabaseContext;


        public void WithDatabaseContexts<T, D>() where T : DbContext where D : DbContext
        {
            _configureDatabaseContext = (services) =>
            {
                services.AddSingleton<DbContextOptions<T>>();
                services.AddDbContext<T>();
                services.AddDbContext<D>();

            };
        }
        public void WithoutMessagingTransactionalOutbox()
        {
            _configureMassTransitTransactionalOutbox = null;
        }
        public void WithMessagingTransactionalOutbox<T>() where T : DbContext
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
                    };

                    //We do not need to clean up the inbox, not being used
                    o.DisableInboxCleanupService();

                    //Disable message delivery
                    //o.UseBusOutbox(c=>c.DisableDeliveryService());
                    // enable the bus outbox
                    o.UseBusOutbox();
                });
            };
        }

        public void SetClientAssembly(Assembly serviceAssembly)
        {
            if (serviceAssembly is null)
            {
                throw new ArgumentNullException(nameof(serviceAssembly));
            }
            _clientAssembly = serviceAssembly;
        }

        public void Configure(IServiceCollection services)
        {
            var allAssemblies = _clientAssembly!.GetReferencedAssemblies();

            // Nox + Entry Assembly
            var noxAssemblies = allAssemblies
                .Where(a => a.Name != null && a.Name.StartsWith("Nox"))
                .Select(Assembly.Load)
                .Union(new[] { _clientAssembly! }).ToArray();

            _noxSolution = CreateSolution(services.BuildServiceProvider());

            services
                .AddSingleton(typeof(NoxSolution), _noxSolution)
                .AddSingleton(typeof(INoxClientAssemblyProvider), serviceProvider => new NoxClientAssemblyProvider(_clientAssembly))
                .AddSecretsResolver()
                .AddNoxMediatR(_clientAssembly)
                .AddNoxFactories(noxAssemblies)
                .AddNoxProviders()
                .AddNoxDtos();


            TryAddNoxMessaging(services, _noxSolution);
            TryAddNoxDatabase(services, _noxSolution, noxAssemblies);
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
        private bool TryAddNoxMessaging(IServiceCollection services, NoxSolution noxSolution)
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
