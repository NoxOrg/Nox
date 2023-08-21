namespace Nox.Types;

public interface IMoney
{
    decimal Amount { get; }
    CurrencyCode CurrencyCode { get; }
}