using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Serilog;
using Nox.Domain;
using Microsoft.Extensions.DependencyInjection;

namespace Nox.Configuration;

public interface INoxOptions
{
    /// <summary>
    /// Enable  Transactional Outbox for Messaging Integration Server
    /// Using the same DbContext to whare Domain Changes are saved
    /// </summary>
    /// <typeparam name="T">DbContext associated</typeparam>
    /// <param name="disableDeliveryService">All messages will be kept in Outbox and will not be sent until enabled</param>
    INoxOptions WithMessagingTransactionalOutbox<T>(bool disableDeliveryService = false) where T : DbContext;

    /// <summary>
    /// Disable Transactional Outbox for Messaging Integration Server
    /// </summary>
    INoxOptions WithoutMessagingTransactionalOutbox();

    /// <summary>
    /// Defines the client assembly, used for testing purposes mainly
    /// </summary>
    INoxOptions WithClientAssembly(Assembly clientAssembly);

    /// <summary>
    /// Set the generated DbContext for Dto and Entities
    /// </summary>
    /// <typeparam name="T">DbContext for the Application Domain, <see cref="Infrastructure.Persistence.IAppDbContext"/></typeparam>
    /// <typeparam name="D"></typeparam>
    INoxOptions WithDatabaseContexts<T, D>() where T : DbContext, Infrastructure.Persistence.IAppDbContext where D : DbContext;

    /// <summary>
    /// Set the IRepository instance type
    /// </summary>
    /// <typeparam name="R">Repository Type</typeparam>    
    INoxOptions WithRepository<R>() where R : class, IRepository;
    

    /// <summary>
    /// Disable default Nox Logging
    /// </summary>
    INoxOptions WithoutNoxLogging();

    /// <summary>
    /// Get Nox Serilog Configuration to add custom configuration
    /// This will enable default Nox Logging
    /// </summary>
    /// <param name="loggerConfiguration"></param>
    INoxOptions WithNoxLogging(Action<LoggerConfiguration> loggerConfiguration);


    /// <summary>
    /// Enable HealthChecks (true by default)
    /// </summary>
    INoxOptions WithHealthChecks(Action<IHealthChecksBuilder> healthChecksBuilder);

    /// <summary>
    /// Disable HealthChecks
    /// </summary>
    INoxOptions WithoutHealthChecks();

    /// <summary>
    /// Disable Swagger which is enabled by default.
    /// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    /// </summary>
    INoxOptions WithoutSwagger();
}