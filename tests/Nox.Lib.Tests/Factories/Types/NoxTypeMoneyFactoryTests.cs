using FluentAssertions;
using Moq;
using Nox.Factories.Types;
using Nox.Lib.Tests.FixtureConfig;
using Nox.Solution;
using Nox.Types;

namespace Nox.Lib.Tests.Factories.Types
{
    public record MoneyDto(decimal Amount, CurrencyCode CurrencyCode);
    public class NoxTypeMoneyFactoryTests
    {
                [Theory, AutoMoqData]
        public void CreateNoxType_FromDto_IsValid(NoxSolution noxSolution, EntityDefinitionFixture fixture)
        {
            // Arrange            
            NoxTypeMoneyFactory sut = new NoxTypeMoneyFactory(noxSolution);
            var amount = 100M;
            var currencyCode = CurrencyCode.AFN;
            var dto = new MoneyDto(amount, currencyCode);

            // Act
            var entity = sut.CreateNoxType(fixture.EntityDefinition, fixture.PropertyName, dto);

            // Assert
            entity.Should().NotBeNull();
            entity!.Amount.Should().Be(amount);
            entity!.CurrencyCode.Should().Be(currencyCode);
        }
    }

    
}
