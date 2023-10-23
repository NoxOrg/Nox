using FluentAssertions;
using Xunit.Abstractions;
using ClientApi.Application.Dto;
using AutoFixture;
using Nox.Types;

namespace ClientApi.Tests.Application.Dto
{
    [Collection("Sequential")]
    public class RatingProgramDtoValidatorTests : NoxWebApiTestBase
    {
        public RatingProgramDtoValidatorTests(ITestOutputHelper testOutput,
            TestDatabaseContainerService containerService)
            : base(testOutput, containerService)
        {
        }

        [Fact]
        public void RatingProgramDto_RequiredFields_ShouldValidate()
        {
            //Arrange
            var ratingDto = new RatingProgramDto();
            
            //Act
            var validationResult = ratingDto.Validate();

            //Assert
            validationResult.Should().NotBeNull();
            validationResult.Should().ContainKey(nameof(ratingDto.StoreId));
        }

        [Fact]
        public void RatingProgramDto_InvalidFields_ShouldValidate()
        {
            //Arrange
            var ratingDto = new RatingProgramDto()
            {
                Name = _fixture.Create<string>().Substring(0, 1)
            };

            //Act
            var validationResult = ratingDto.Validate();

            //Assert
            validationResult.Should().NotBeNull();
            validationResult.Should().ContainKey(nameof(ratingDto.Name));
            validationResult.Should().ContainKey(nameof(ratingDto.StoreId));
        }

        [Fact]
        public void RatingProgramDto_ValidFields_ShouldValidate()
        {
            //Arrange
            var ratingDto = new RatingProgramDto()
            {
                Name = _fixture.Create<string>().Substring(0, 10),
                StoreId = _fixture.Create<System.Guid>()
            };

            //Act
            var validationResult = ratingDto.Validate();

            //Assert
            validationResult.Should().NotBeNull();
            validationResult.Should().BeEmpty();
        }
    }
}