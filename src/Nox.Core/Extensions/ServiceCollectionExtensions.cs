using Hangfire;
using Microsoft.Extensions.DependencyInjection;
using Nox.Application.Jobs;
using Nox.EntityFramework.SqlServer;
using Nox.Solution;
using System.Collections.Immutable;
using System.Reflection;
using MassTransit;

namespace Nox.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddNoxJobs(this IServiceCollection services,
            Assembly[] noxEntryAssemblies,
            NoxSolution noxSolution
            )
        {
            if (noxSolution.Infrastructure?.Persistence is { DatabaseServer: null })
                return services;

            var connectionString = noxSolution.Infrastructure!.Persistence!.DatabaseServer.Provider switch
            {
                DatabaseServerProvider.SqlServer => SqlServerDatabaseProvider.GetConnectionString(noxSolution.Infrastructure!.Persistence.DatabaseServer, "HangFire"),
                DatabaseServerProvider.Postgres => throw new NotImplementedException(),
                DatabaseServerProvider.SqLite => throw new NotImplementedException(),
                _ => throw new NotImplementedException()
            };

            services.AddNoxJobs(noxEntryAssemblies, noxSolution, connectionString);

            return services;
        }
        public static IServiceCollection AddNoxJobs(this IServiceCollection services,
            Assembly[] noxEntryAssemblies,
            NoxSolution solution,
            string databaseConnectionString)
        {
            var registrations = new List<JobRegistration>()
                .AddApplicationJobs(noxEntryAssemblies)
                .AddIntegrationJobs(solution);

            if (registrations.Any())
            {
                RegisterJobs(services, registrations, noxEntryAssemblies);
                RegisterHangFire(services, solution.Infrastructure.Persistence!.DatabaseServer.Provider, databaseConnectionString);    
            }

            return services;
        }

        private static void RegisterHangFire(IServiceCollection services, DatabaseServerProvider databaseProvider, string connectionString)
        {
            if(databaseProvider != DatabaseServerProvider.SqlServer)
                throw new NotImplementedException("Nox Jobs only support DatabaseServerProvider.SqlServer");

            //https://docs.hangfire.io/en/latest/getting-started/index.html
            services.AddHangfire(configuration => configuration
            .SetDataCompatibilityLevel(CompatibilityLevel.Version_180)
            .UseSimpleAssemblyNameTypeSerializer()
            .UseRecommendedSerializerSettings()
            // TODO Add support to other providers
            .UseSqlServerStorage(connectionString));

            // Add the processing server as IHostedService
            services.AddHangfireServer();
        }

        private static void RegisterJobs(IServiceCollection services, List<JobRegistration> registrations, Assembly[] noxEntryAssemblies)
        {
            services.Scan(scan => scan
            .FromAssemblies(noxEntryAssemblies)
            .AddClasses(classes => classes.AssignableTo<IJob>())
            .AsSelf()
            .WithTransientLifetime());

            services.AddSingleton<IJobRegistry>(serviceProvider => new JobRegistry(serviceProvider, registrations));
            services.AddTransient<IJobScheduler, JobScheduler>();
        }

        private static List<JobRegistration> AddApplicationJobs(this List<JobRegistration> registrations, Assembly[] noxEntryAssemblies)
        {
            registrations.AddRange(noxEntryAssemblies.SelectMany(assembly => assembly.GetTypes())
                .Where(type => !type.IsAbstract && type.GetInterfaces().Contains(typeof(IJob)))
                .Where(job => job.GetCustomAttributes(typeof(NoxJobAttribute), false).Length == 1)
                .Select(job => {
                    var jobAttribute = job.GetCustomAttributes(typeof(NoxJobAttribute), false).Cast<NoxJobAttribute>().Single();
                    return new JobRegistration(jobAttribute.Name,jobAttribute.CronExpression, job);
                }).ToList());
            return registrations;
        }
        
        private static List<JobRegistration> AddIntegrationJobs(this List<JobRegistration> registrations, NoxSolution solution)
        {
            
            return registrations;
        }
    }
}
