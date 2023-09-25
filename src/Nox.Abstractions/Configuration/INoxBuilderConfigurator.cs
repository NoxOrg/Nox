
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Nox.Configuration
{
    public interface INoxBuilderConfigurator
    {
        /// <summary>
        /// Enable  Transactional Outbox for Messaging Integration Server
        /// Using the same DbContext to whare Domain Changes are saved
        /// </summary>
        /// <typeparam name="T"></typeparam>
        void WithMessagingTransactionalOutbox<T>() where T : DbContext;

        /// <summary>
        /// Disable Transactional Outbox for Messaging Integration Server
        /// </summary>
        void WithoutMessagingTransactionalOutbox();

        /// <summary>
        /// Defines the client assembly, used for testing purposes mainly
        /// </summary>
        void SetClientAssembly(Assembly clientAssembly);

        /// <summary>
        /// Set the generated DbContext for Dto and Entities
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="D"></typeparam>
        void WithDatabaseContexts<T, D>() where T : DbContext where D : DbContext;

    }
}
