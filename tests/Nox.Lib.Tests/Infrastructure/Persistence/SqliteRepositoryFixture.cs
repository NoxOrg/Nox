using AutoFixture;
using AutoFixture.AutoMoq;
using Microsoft.EntityFrameworkCore;
using Nox.Domain;

namespace Nox.Lib.Tests.Infrastructure.Persistence
{
    public sealed class SqliteRepositoryFixture : Fixture, IDisposable
    {
        private bool _disposed = false;
        public FakeAppDbContext AppDbContext { get; }
        public IRepository Repository => AppDbContext;
        private readonly string _fileName;
        public SqliteRepositoryFixture()
        {
            Customize(new AutoMoqCustomization());
            _fileName = $"{Guid.NewGuid()}.db";
            this.Register(() => new DbContextOptionsBuilder().UseSqlite($"Data Source={_fileName}").Options);

            SeedData();

            AppDbContext = this.Create<FakeAppDbContext>();
        }

        private void SeedData()
        {
            var seedAppDbContext = this.Create<FakeAppDbContext>();

            seedAppDbContext.Database.EnsureCreated();

            seedAppDbContext.AddRange(
            new FakeAppDbContext.Order { Name = "Order1" },
            new FakeAppDbContext.Order { Name = "Order2" },
            new FakeAppDbContext.Order
            {
                Name = "Order3",
                Items = new() {
                new() { Name = "Item1_3" },new() { Name = "Item2_3" }}
            }
            );

            var result = seedAppDbContext.SaveChanges();
            seedAppDbContext.Dispose();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (_disposed)
                return;
            if (disposing)
            {
                AppDbContext?.Dispose();
                try
                {
                    //Ensure all connections are closed
#pragma warning disable S1215
                    GC.Collect();
#pragma warning restore S1215
                    GC.WaitForPendingFinalizers();
                    File.Delete(_fileName);
                }
                catch (Exception)
                {
                    // ignored
                }
                
            }
            _disposed = true;
        }
    }
}
