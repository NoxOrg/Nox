using Elastic.Apm.Api;
using FluentAssertions;

namespace Nox.Lib.Tests.Infrastructure.Persistence
{
    public class EntityDbContextBaseTests : IClassFixture<SqliteRepositoryFixture>
    {
        private readonly SqliteRepositoryFixture _fixture;

        public EntityDbContextBaseTests(SqliteRepositoryFixture fixture)
        {
            _fixture = fixture;
        }
        //#pragma warning restore xUnit1041
        [Fact]
        public void WhenQueryShouldNotReturnIncluded()
        {
            // Act
            var data = _fixture.Repository.Query<FakeAppDbContext.Order>().ToList();

            //Assert
            data.Should().HaveCount(3);
            data.All(x => x.Items is null).Should().BeTrue();
        }

        [Fact]
        public void WhenQueryWithIncludeShouldReturnIncluded()
        {
            // Act
            var data = _fixture.Repository.Query<FakeAppDbContext.Order>((order) => order.Items).ToList();

            //Assert
            data.Should().HaveCount(3);
            data.Any(x => x.Items is not null).Should().BeTrue();
        }

    }
}
