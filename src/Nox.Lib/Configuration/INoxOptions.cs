using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Serilog;

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
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="D"></typeparam>
    INoxOptions WithDatabaseContexts<T, D>() where T : DbContext where D : DbContext;

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
    ///
    /// </summary>
    INoxOptions WithSwagger();
}