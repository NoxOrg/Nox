using FluentAssertions;
using Nox.Integration.Tests.DatabaseIntegrationTests;
using Nox.Integration.Tests.Fixtures;
using Nox.Types;
using TestWebApp.Domain;

namespace Nox.Integration.Tests
{
    public class NuidTypeTests : NoxIntegrationTestBase<NoxTestSqliteFixture>
    {
        public NuidTypeTests(NoxTestSqliteFixture fixture) : base(fixture)
        {
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
            DataContext.Database.EnsureCreated();
            DataContext.TestEntityWithNuids.Add(entity);
            DataContext.SaveChanges();

            var dbEntity = DataContext.TestEntityWithNuids.First(x => x.Name == Text.From(nameValue));

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

            DataContext.TestEntityWithNuids.Add(entity);
            DataContext.SaveChanges();

            var dbEntity = DataContext.TestEntityWithNuids
                .AsEnumerable()
                .First(x => x.Id.Value == entity.Id.Value);
            dbEntity.Name = Text.From("Should not be changed");

            var action = entity.EnsureId;
            action.Should().Throw<NoxNuidTypeException>();
        }
    }
}