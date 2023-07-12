namespace Nox.Types;

/// <summary>
/// Represents a Nox <see cref="Color"/> type and value object. 
/// </summary>
public sealed class Color : ValueObject<(byte Alpha, byte Red, byte Green, byte Blue), Color>
{
}
