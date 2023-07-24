using Nox.Tests.Fixtures;
using Nox.Types;
using TestWebApp.Domain;
using TestWebApp.Infrastructure.Persistence;

namespace Nox.Tests
{
    public class NuidTypeTests : IClassFixture<DataContextTestFixture>
    {
        private readonly TestWebAppDbContext _dbContext;

        public NuidTypeTests(DataContextTestFixture fixture)
        {
            _dbContext = fixture.DbContext;
        }

        [Fact]
        public void NuidTypeImmutable_OnceSet_ShouldBeUnchanged()
        {
            var entity = new TestEntityWithNuid
            {
                Name = Text.From("Test")
            };

            entity.EnsureId();

            _dbContext.TestEntityWithNuids.Add(entity);
            _dbContext.SaveChanges();

            var dbEntity = _dbContext.TestEntityWithNuids.First();

            Assert.Equal(entity.Id, dbEntity.Id);
        }

        [Fact]
        public void NuidTypeImmutable_TryChangeImmutableProperty_ShouldThrow()
        {
            var entity = new TestEntityWithNuid
            {
                Name = Text.From("Test")
            };

            entity.EnsureId();

            _dbContext.TestEntityWithNuids.Add(entity);
            _dbContext.SaveChanges();

            var dbEntity = _dbContext.TestEntityWithNuids.First();
            dbEntity.Name = Text.From("Should not be changed");

            Assert.Throws<ApplicationException>(() => entity.EnsureId());
        }
    }
}