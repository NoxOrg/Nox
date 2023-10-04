﻿
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Serilog;

namespace Nox.Configuration
{
    public interface INoxOptions
    {
        /// <summary>
        /// Enable  Transactional Outbox for Messaging Integration Server
        /// Using the same DbContext to whare Domain Changes are saved
        /// </summary>
        /// <typeparam name="T">DbContext associated</typeparam>
        /// <param name="disableDeliveryService">All messages will be kept in Outbox and will not be sent until enabled</param>
        void WithMessagingTransactionalOutbox<T>(bool disableDeliveryService = false) where T : DbContext;
        /// <summary>
        /// Disable Transactional Outbox for Messaging Integration Server
        /// </summary>
        void WithoutMessagingTransactionalOutbox();

        /// <summary>
        /// Defines the client assembly, used for testing purposes mainly
        /// </summary>
        void WithClientAssembly(Assembly clientAssembly);

        /// <summary>
        /// Set the generated DbContext for Dto and Entities
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="D"></typeparam>
        void WithDatabaseContexts<T, D>() where T : DbContext where D : DbContext;

        /// <summary>
        /// Disable default Nox Logging
        /// </summary>
        void WithoutNoxLogging();

        /// <summary>
        /// Get Nox Serilog Configuration to add custom configuration
        /// This will enable default Nox Logging
        /// </summary>
        /// <param name="loggerConfiguration"></param>
        void WithNoxLogging(Action<LoggerConfiguration> loggerConfiguration);
    }
}