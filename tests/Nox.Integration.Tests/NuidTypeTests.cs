using FluentAssertions;
using Nox.Integration.Tests.DatabaseIntegrationTests;
using Nox.Integration.Tests.Fixtures;
using Nox.Types;
using TestWebApp.Domain;
using TestWebApp.Infrastructure.Persistence;

namespace Nox.Integration.Tests;

[Collection("Sequential")]
public class NuidTypeTests : NoxIntegrationContainerTestBase<NoxTestSqliteFixture>
{
    private readonly TestWebAppDbContext _dbContext;

    public NuidTypeTests(NoxTestSqliteFixture fixture) : base(fixture)
    {
        _dbContext = GetDataContext<TestWebAppDbContext>();
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

        var dbEntity = _dbContext.TestEntityWithNuids
            .AsEnumerable()
            .First(x => x.Id.Value == entity.Id.Value);
        dbEntity.Name = Text.From("Should not be changed");

        var action = entity.EnsureId;
        action.Should().Throw<NoxNuidTypeException>();
    }
}