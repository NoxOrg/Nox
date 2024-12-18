using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
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
using Nox.Infrastructure.Messaging.InMemoryBus;
using Nox.Infrastructure.Messaging.AzureServiceBus;
using Nox.Infrastructure;
using Nox.Integration.Extensions;
using Nox.Yaml.VariableProviders.Environment;
using Nox.Domain;
using Nox.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore.Diagnostics;
using SqlKata.Compilers;
using Nox.Presentation.Api.Swagger;
using Elastic.Apm.SerilogEnricher;
using Elastic.CommonSchema.Serilog;
using Microsoft.AspNetCore.Http;
using Nox.Application.Repositories;
using Nox.Exceptions;
using System.Collections.Immutable;
using Microsoft.Extensions.Hosting;
using Nox.Extensions;
using Nox.Integration.Adapters;
using Nox.Integration.Adapters.SqlServer;
using Serilog.Events;
using Serilog.Sinks.SystemConsole.Themes;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Nox.Configuration
{
    internal sealed class NoxOptions : INoxOptions
    {
        private Assembly? _clientAssembly;
        private Action<IBusRegistrationConfigurator, DatabaseServerProvider>? _configureMassTransitTransactionalOutbox;
        private Action<IServiceCollection>? _configureRepositories;
        private Action<LoggerConfiguration>? _loggerConfigurationAction;
        private Action<IHealthChecksBuilder>? _healthChecksBuilderAction;
        private Action<HstsOptions>? _hstsConfiguration;

        private bool _withNoxLogging = true;
        private bool _withHealthChecks = true;
        private bool _withNoxJobs = true;
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
        public INoxOptions WithHealthChecks(Action<IHealthChecksBuilder> healthChecksBuilder)
        {
            _healthChecksBuilderAction = healthChecksBuilder;
            _withHealthChecks = true;
            return this;
        }

        public INoxOptions WithoutHealthChecks()
        {
            _withHealthChecks = false;
            _healthChecksBuilderAction = null;
            return this;
        }

        public INoxOptions WithoutNoxJobs()
        {
            _withNoxJobs = false;
            return this;
        }

        public INoxOptions WithRepositories<T, D>() where T : DbContext where D : DbContext
        {
            if (typeof(T).IsAssignableFrom(typeof(IRepository)))
            {
                throw new InvalidConfigurationException($"{nameof(T)} is not of type {typeof(IRepository)}");
            }
            if (typeof(D).IsAssignableFrom(typeof(IReadOnlyRepository)))
            {
                throw new InvalidConfigurationException($"{nameof(D)} is not {typeof(IReadOnlyRepository)}");
            }

            _configureRepositories = (services) =>
            {
                services.AddSingleton<DbContextOptions<T>>();
                services.AddDbContext<T>();
                services.AddScoped(typeof(IRepository), serviceProvider => serviceProvider.GetRequiredService<T>());

                services.AddDbContext<D>();
                services.AddScoped(typeof(IReadOnlyRepository), serviceProvider => serviceProvider.GetRequiredService<D>());
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
            ArgumentNullException.ThrowIfNull(clientAssembly);

            _clientAssembly = clientAssembly;

            return this;
        }

        public INoxOptions WithoutSwagger()
        {
            _withSwagger = false;

            return this;
        }

        public INoxOptions WithHsts(Action<HstsOptions> hstsConfiguration)
        {
            _hstsConfiguration = hstsConfiguration;

            return this;
        }

        public void Configure(IServiceCollection services, WebApplicationBuilder? webApplicationBuilder)
        {
            InvalidConfigurationException.ThrowIfNull(NoxAssemblyConfiguration.DomainAssembly, "Domain is not being generated in any client assembly. Review the generator.nox.yaml configuration");
            InvalidConfigurationException.ThrowIfNull(NoxAssemblyConfiguration.ApplicationAssembly, "Application is not being generated in any client assembly. Review the generator.nox.yaml configuration");
            InvalidConfigurationException.ThrowIfNull(NoxAssemblyConfiguration.DtoAssembly, "Dto is not being generated in any client assembly. Review the generator.nox.yaml configuration");
            InvalidConfigurationException.ThrowIfNull(NoxAssemblyConfiguration.InfrastructureAssembly, "Infrastreucture is not being generated in any client assembly. Review the generator.nox.yaml configuration");

            var referencedAssemblyNames = _clientAssembly!
                .GetReferencedAssemblies()
                .Union(Assembly.GetExecutingAssembly()!.GetReferencedAssemblies())
                .Distinct().ToImmutableArray();
                      

            // Nox + Entry Assembly
            var noxAndEntryAssemblies = referencedAssemblyNames
                .Where(a => a.Name != null && a.Name.StartsWith("Nox"))
                .Select(Assembly.Load)
                .Union(new[] { 
                    _clientAssembly!, 
                    NoxAssemblyConfiguration.DomainAssembly,
                    NoxAssemblyConfiguration.DtoAssembly,
                    NoxAssemblyConfiguration.ApplicationAssembly,
                    NoxAssemblyConfiguration.InfrastructureAssembly
                })
                .Distinct()
                .ToArray();

            var noxSolution = CreateSolution(services.BuildServiceProvider());

            services
                .AddSingleton(typeof(NoxSolution), noxSolution)
                .AddSingleton(typeof(INoxClientAssemblyProvider), serviceProvider =>
                        new NoxClientAssemblyProvider(
                            _clientAssembly,
                            NoxAssemblyConfiguration.DomainAssembly,
                            NoxAssemblyConfiguration.DtoAssembly,
                            NoxAssemblyConfiguration.ApplicationAssembly,
                            NoxAssemblyConfiguration.InfrastructureAssembly))
                .AddSingleton(typeof(NoxCodeGenConventions), serviceProvider => new NoxCodeGenConventions(serviceProvider.GetRequiredService<NoxSolution>(), string.Empty))
                .AddNoxHttpDefaults()
                .AddSecretsResolver()
                .AddNoxMediatR(noxAndEntryAssemblies)
                .AddNoxFactories(noxAndEntryAssemblies)
                .AddEtlBox()
                .AddNoxProviders()
                .AddNoxDtos();

            AddNoxMessaging(services, noxSolution, webApplicationBuilder?.Environment?.EnvironmentName ?? Environments.Development);
            AddNoxDatabase(services, noxSolution, noxAndEntryAssemblies);
            AddIntegrations(services);

            AddLogging(webApplicationBuilder);
            AddSwagger(services);

            if (_hstsConfiguration is not null) services.AddHsts(_hstsConfiguration!);

            if (_withNoxJobs) services.AddNoxJobs(noxAndEntryAssemblies, noxSolution);

            if (_withHealthChecks)
            {
                var healthCheckBuilder = services.AddHealthChecks();
                _healthChecksBuilderAction?.Invoke(healthCheckBuilder);
            }
        }

        private void AddLogging(WebApplicationBuilder? webApplicationBuilder)
        {
            if (webApplicationBuilder != null && _withNoxLogging)
            {
                webApplicationBuilder.Host.UseSerilog((context, services, loggerConfig) =>
                {
                    var httpAccessor = services.GetService<HttpContextAccessor>();

                    loggerConfig
                    .ReadFrom.Configuration(context.Configuration)
                    .ReadFrom.Services(services)
                    .Enrich.FromLogContext()
                    .Enrich.WithElasticApmCorrelationInfo()
                    .Enrich.WithProperty("HttpContext", httpAccessor?.HttpContext)
                    .WriteTo.Debug()
                    .WriteTo.Console(new EcsTextFormatter());
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


                _configureRepositories?.Invoke(services);

                services.AddScoped<IInterceptor, LangParamDbCommandInterceptor>();

                services.AddSingleton<Compiler>(x =>
                {
                    return noxSolution.Infrastructure.Persistence!.DatabaseServer.Provider switch
                    {
                        DatabaseServerProvider.SqlServer => new SqlServerCompiler(),
                        DatabaseServerProvider.Postgres => new PostgresCompiler(),
                        DatabaseServerProvider.SqLite => new SqliteCompiler(),
                        _ => throw new NotImplementedException()
                    };
                });

                services.AddSingleton<IEntityDtoSqlQueryBuilderProvider, EntityDtoSqlQueryBuilderProvider>();
                services.Scan(scan => scan
                    .FromAssemblies(noxAssemblies)
                    .AddClasses(classes => classes.AssignableTo<IEntityDtoSqlQueryBuilder>())
                    .As<IEntityDtoSqlQueryBuilder>()
                    .WithSingletonLifetime());
            }
        }

        private void AddNoxMessaging(IServiceCollection services, NoxSolution noxSolution, string environmentName)
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
                messageBrokerProvider.ConfigureMassTransit(messagingConfig, x, environmentName);

                _configureMassTransitTransactionalOutbox?.Invoke(x, noxSolution.Infrastructure.Persistence!.DatabaseServer.Provider);
            });
        }

        private void AddSwagger(IServiceCollection services)
        {
            if (!_withSwagger) return;

            services.AddSwaggerGen(opts =>
            {
                opts.EnableAnnotations();
                //OData makes operation Ids to be the sane name
                opts.CustomOperationIds(e => $"{e.HttpMethod}_{e.RelativePath}");
                opts.SchemaFilter<DeltaSchemaFilter>();
                opts.DocumentFilter<ApiRouteMappingDocumentFilter>();
                opts.DocumentFilter<RelatedEntityRoutingDocumentFilter>();
                opts.OperationFilter<EtagHeaderOperationFilter>();
                opts.OperationFilter<LanguageQueryParameterOperationFilter>();
            });
        }

        private static NoxSolution CreateSolution(IServiceProvider serviceProvider)
        {
            var secretsProvider = new SecretsVariableValueProvider<NoxSolutionBasicsOnly>((s, v) =>
            {
                var secretsConfig = s.Infrastructure?.Security?.Secrets;
                if (secretsConfig is not null)
                {
                    var resolver = serviceProvider.GetRequiredService<INoxSecretsResolver>();
                    resolver.Configure(secretsConfig, Assembly.GetEntryAssembly());
                    return resolver.Resolve(v);
                }
                return new Dictionary<string, string?>();
            });

            return new NoxSolutionBuilder()
                .WithSecretsVariableValueProvider(secretsProvider)
                .Build();
        }

        private static void AddIntegrations(IServiceCollection services)
        {
            services.AddNoxIntegrations(options =>
            {
                options.WithSqlServerStore();
            });
        }       
    }
}