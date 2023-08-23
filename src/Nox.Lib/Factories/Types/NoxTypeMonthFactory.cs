using Nox.Solution;
using Nox.Types;

namespace Nox.Factories.Types;

/// <summary>
/// Factory class for creating instances of the <see cref="Month"/> class
/// based on provided simple type definitions and values.
/// </summary>
public class NoxTypeMonthFactory : NoxTypeFactoryBase<Month>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="NoxTypeMonthFactory"/> class with the specified <see cref="NoxSolution"/>.
    /// </summary>
    /// <param name="solution">The <see cref="NoxSolution"/> instance to use.</param>
    public NoxTypeMonthFactory(NoxSolution solution) : base(solution)
    {
    }

    /// <summary>
    /// Creates a <see cref="Month"/> instance from the provided <paramref name="value"/> and a corresponding <see cref="NoxSimpleTypeDefinition"/>.
    /// </summary>
    /// <param name="simpleTypeDefinition">The <see cref="NoxSimpleTypeDefinition"/> for nox types.</param>
    /// <param name="value">The dynamic value to create the <see cref="Month"/> from.</param>
    /// <returns>A <see cref="Month"/> instance or null if the value is null.</returns>
    public override Month? CreateNoxType(NoxSimpleTypeDefinition simpleTypeDefinition, dynamic? value)
        => value is null ? null : Month.From(value);
}
