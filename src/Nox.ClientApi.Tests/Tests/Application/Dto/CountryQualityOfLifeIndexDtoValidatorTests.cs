using FluentAssertions;
using Xunit.Abstractions;
using ClientApi.Application.Dto;
using AutoFixture;
using Nox.Types;

namespace ClientApi.Tests.Application.Dto
{
    [Collection("Sequential")]
    public class CountryQualityOfLifeIndexDtoValidatorTests : NoxWebApiTestBase
    {
        public CountryQualityOfLifeIndexDtoValidatorTests(ITestOutputHelper testOutput,
            TestDatabaseContainerService containerService)
            : base(testOutput, containerService)
        {
        }

        [Fact]
        public void CountryQualityOfLifeIndexDto_RequiredFields_ShouldValidate()
        {
            //Arrange
            var indexDto = new CountryQualityOfLifeIndexDto();
            
            //Act
            var validationResult = indexDto.Validate();

            //Assert
            validationResult.Should().NotBeNull();
            validationResult.Should().ContainKey(nameof(indexDto.CountryId));
        }

        [Fact]
        public void CountryQualityOfLifeIndexDto_InvalidFields_ShouldValidate()
        {
            //Arrange
            var indexDto = new CountryQualityOfLifeIndexDto()
            {
                IndexRating = 0
            };

            //Act
            var validationResult = indexDto.Validate();

            //Assert
            validationResult.Should().NotBeNull();
            validationResult.Should().ContainKey(nameof(indexDto.CountryId));
            validationResult.Should().ContainKey(nameof(indexDto.IndexRating));
        }

        [Fact(Skip = "System.InvalidOperationException : AutoNumber can only be created with FromDatabase.")]
        public void CountryQualityOfLifeIndexDto_ValidFields_ShouldValidate()
        {
            //Arrange
            var indexDto = new CountryQualityOfLifeIndexDto()
            {
                CountryId = _fixture.Create<int>(),
                IndexRating = 100
            };

            //Act
            var validationResult = indexDto.Validate();

            //Assert
            validationResult.Should().NotBeNull();
            validationResult.Should().BeEmpty();
        }
    }
}