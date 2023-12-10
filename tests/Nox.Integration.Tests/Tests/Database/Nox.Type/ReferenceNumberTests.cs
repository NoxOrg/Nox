using Nox.Integration.Tests.Fixtures;

using TestWebApp.Infrastructure.Persistence;
using TestWebApp.Domain;
using Microsoft.EntityFrameworkCore;
using FluentAssertions;
using Nox.Types;
using Nox.Solution;

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
            //Act 
            var nextIdNumber = await DataContext.GetSequenceNextValueAsync(NoxCodeGenConventions.GetDatabaseSequenceName(nameof(ForReferenceNumber), nameof(ForReferenceNumber.Id)));
            var nextIdNumber2 = await DataContext.GetSequenceNextValueAsync(NoxCodeGenConventions.GetDatabaseSequenceName(nameof(ForReferenceNumber), nameof(ForReferenceNumber.Id)));

            var nextWorkplaceNumber = await DataContext.GetSequenceNextValueAsync(NoxCodeGenConventions.GetDatabaseSequenceName(nameof(ForReferenceNumber), nameof(ForReferenceNumber.WorkplaceNumber)));            
            var nextWorkplaceNumber2 = await DataContext.GetSequenceNextValueAsync(NoxCodeGenConventions.GetDatabaseSequenceName(nameof(ForReferenceNumber), nameof(ForReferenceNumber.WorkplaceNumber)));

            // Assert
            nextIdNumber.Should().Be(10);
            nextIdNumber2.Should().Be(15);

            nextWorkplaceNumber.Should().Be(100);
            nextWorkplaceNumber2.Should().Be(101);
         
        }
        public async Task WhenCreateReferenceNumberAttribute_ShouldBeUnique()
        {
            //Arrange
            DataContext.ForReferenceNumbers.Add(CreateForReferenceNumber(1,1));
            DataContext.ForReferenceNumbers.Add(CreateForReferenceNumber(2, 2));
            
            await DataContext.SaveChangesAsync();

            //Duplicated workplace number
            DataContext.ForReferenceNumbers.Add(CreateForReferenceNumber(3, 2));
            // Act //Assert
            Action action = () => DataContext.SaveChanges();
            action.Should().Throw<DbUpdateException>();
        }

        private static ForReferenceNumber CreateForReferenceNumber(long id, long workplaceNumber)
        {
            var referenceNumber = new ForReferenceNumber();
            referenceNumber.EnsureId(id, new ReferenceNumberTypeOptions { Prefix = "R-" });
            referenceNumber.EnsureWorkplaceNumber(workplaceNumber, new ReferenceNumberTypeOptions { Prefix = "R-" });

            return referenceNumber;
        }
    }
}
