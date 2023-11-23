using FluentAssertions;


namespace Nox.Solution.Tests.Models.Domain.Entities.Persistence
{
    public class EntityPersistenceTests
    {
        [Fact]
        public void WhenTableNameIsSet_ShouldNotHaveDefault()
        {
            var solution = new NoxSolutionBuilder()
                .WithFile("./files/entitypersistence.tablename.solution.nox.yaml")
                .Build();

            solution.Domain!.Entities.Single(e=>e.Name == "Country").Persistence.TableName.Should().Be("SpecialCountry");
            solution.Domain!.Entities.Single(e => e.Name == "Person").Persistence.TableName.Should().Be("People");
        }
    }
}
