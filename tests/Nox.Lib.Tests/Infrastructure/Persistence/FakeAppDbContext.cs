using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Nox.Abstractions;
using Nox.Domain;
using Nox.Infrastructure.Persistence;
using Nox.Types.EntityFramework.Abstractions;

namespace Nox.Lib.Tests.Infrastructure.Persistence
{
    public class FakeAppDbContext : EntityDbContextBase
    {
        public FakeAppDbContext(IPublisher publisher,
            IUserProvider userProvider,
            ISystemProvider systemProvider,
            INoxDatabaseProvider databaseProvider,
            ILogger<EntityDbContextBase> logger,
            DbContextOptions options) : base(publisher, userProvider, systemProvider, databaseProvider, logger, options)
        {
        }
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<Item> Items { get; set; } = null!;

        public class Order : IEntity
        {
            public int Id { get; set; }
            public string Name { get; set; } = null!;

            public List<Item> Items { get; set; } = null!;
        }
        public class Item : IEntity
        {
            public int Id { get; set; }
            public string Name { get; set; } = null!;
        }
    }
}
