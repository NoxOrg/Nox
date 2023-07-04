using Json.Schema.Generation;
using Nox.Types;

namespace Nox.Solution
{

    [AdditionalProperties(false)]
    public class MoneyTypeOptions : DefinitionBase
    {
        public int DecimalDigits { get; internal set; } = 4;

        public int IntegerDigits { get; internal set; } = 9;

        public decimal MinValue { get; internal set; } = -999999999.9999M;

        public decimal MaxValue { get; internal set; } = 999999999.9999M;

        public CurrencyCode DefaultCurrency { get; internal set; } = CurrencyCode.USD;
    }
}