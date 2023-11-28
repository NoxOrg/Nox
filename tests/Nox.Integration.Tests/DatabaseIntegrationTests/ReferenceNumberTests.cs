using Nox.Integration.Tests.Fixtures;

using TestWebApp.Infrastructure.Persistence;
using TestWebApp.Domain;
using Microsoft.EntityFrameworkCore;
using FluentAssertions;
using Nox.Types;

namespace Nox.Integration.Tests.DatabaseIntegrationTests
{
    public class ReferenceNumberTests
    {
        private readonly INoxTestDataContextFixture _dbContextFixture;
        private AppDbContext DataContext => (AppDbContext)_dbContextFixture.DataContext;

        public ReferenceNumberTests(INoxTestDataContextFixture dbContextFixture)
        {
            _dbContextFixture = dbContextFixture;
        }

        public async Task WhenGetSequenceNextValue_ShouldSucceed()
        {
            await Task.Delay(10);
            //Act 
            var nextIdNumber = await DataContext.GetSequenceNextValueAsync(_dbContextFixture.NoxCodeGenConventions.GetDatabaseSequenceName(nameof(ForReferenceNumber), nameof(ForReferenceNumber.Id)));
            var nextIdNumber2 = await DataContext.GetSequenceNextValueAsync(_dbContextFixture.NoxCodeGenConventions.GetDatabaseSequenceName(nameof(ForReferenceNumber), nameof(ForReferenceNumber.Id)));

            var nextWorkplaceNumber = await DataContext.GetSequenceNextValueAsync(_dbContextFixture.NoxCodeGenConventions.GetDatabaseSequenceName(nameof(ForReferenceNumber), nameof(ForReferenceNumber.WorkplaceNumber)));            
            var nextWorkplaceNumber2 = await DataContext.GetSequenceNextValueAsync(_dbContextFixture.NoxCodeGenConventions.GetDatabaseSequenceName(nameof(ForReferenceNumber), nameof(ForReferenceNumber.WorkplaceNumber)));

            // Assert
            nextIdNumber.Should().Be(10);
            nextIdNumber2.Should().Be(15);

            nextWorkplaceNumber.Should().Be(100);
            nextWorkplaceNumber2.Should().Be(101);
         
        }
        public async Task WhenCreateReferenceNumberAttribute_ShouldBeUnique()
        {
            //Arrange

            DataContext.ForReferenceNumbers.Add(new ForReferenceNumber()
            {
                Id = ReferenceNumber.FromDatabase("1"),
                WorkplaceNumber = ReferenceNumber.FromDatabase("1"),
            });
            DataContext.ForReferenceNumbers.Add(new ForReferenceNumber()
            {
                Id = ReferenceNumber.FromDatabase("2"),
                WorkplaceNumber = ReferenceNumber.FromDatabase("2"),
            });
            await DataContext.SaveChangesAsync();
            DataContext.ForReferenceNumbers.Add(new ForReferenceNumber()
            {
                Id = ReferenceNumber.FromDatabase("3"),
                //Duplicated 
                WorkplaceNumber = ReferenceNumber.FromDatabase("2"),
            });

            // Act //Assert
            Action action =() => DataContext.SaveChanges();
            action.Should().Throw<DbUpdateException>();
        }
    }
}
