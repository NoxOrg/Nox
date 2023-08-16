using FluentAssertions;
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
            var nameValue = System.Guid.NewGuid().ToString();
            var entity = new TestEntityWithNuid
            {
                Name = Text.From(nameValue)
            };

            entity.EnsureId();

            _dbContext.TestEntityWithNuids.Add(entity);
            _dbContext.SaveChanges();

            var dbEntity = _dbContext.TestEntityWithNuids.First(x => x.Name == Text.From(nameValue));

            entity.Should().Be(dbEntity);
            entity.Id.Should().Be(dbEntity.Id);
        }

        [Fact]
        public void NuidTypeImmutable_TryChangeImmutableProperty_ShouldThrow()
        {
            var nameValue = System.Guid.NewGuid().ToString();
            var entity = new TestEntityWithNuid
            {
                Name = Text.From(nameValue)
            };

            entity.EnsureId();

            _dbContext.TestEntityWithNuids.Add(entity);
            _dbContext.SaveChanges();

            var dbEntity = _dbContext.TestEntityWithNuids.First(x => x.Id.Value == entity.Id.Value);
            dbEntity.Name = Text.From("Should not be changed");

            Assert.Throws<NoxNuidTypeException>(() => entity.EnsureId());
        }
    }
}