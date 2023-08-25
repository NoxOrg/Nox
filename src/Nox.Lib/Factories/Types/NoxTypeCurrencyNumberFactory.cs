using Nox.Solution;
using Nox.Types;

namespace Nox.Factories.Types;

/// <summary>
/// Factory class for creating instances of the <see cref="CurrencyNumber"/> class based on provided simple type definitions and values.
/// </summary>
public class NoxTypeCurrencyNumberFactory : NoxTypeFactoryBase<CurrencyNumber>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="NoxTypeCurrencyNumberFactory"/> class with the specified <see cref="NoxSolution"/>.
    /// </summary>
    /// <param name="solution">The <see cref="NoxSolution"/> instance to use.</param>
    public NoxTypeCurrencyNumberFactory(NoxSolution solution) : base(solution)
    {
    }
    
    /// <summary>
    /// Creates a <see cref="CurrencyNumber"/> instance from the provided <paramref name="value"/> and a corresponding <see cref="NoxSimpleTypeDefinition"/>.
    /// </summary>
    /// <param name="simpleTypeDefinition">The <see cref="NoxSimpleTypeDefinition"/> for the nox type.</param>
    /// <param name="value">The dynamic value to create the <see cref="CurrencyNumber"/> from.</param>
    /// <returns>A <see cref="CurrencyNumber"/> instance or null if the value is null.</returns>
    public override CurrencyNumber? CreateNoxType(NoxSimpleTypeDefinition simpleTypeDefinition, dynamic? value)
        => value is null ? null : CurrencyNumber.From(value);
}
