namespace Nox.Types;

public interface IMoney
{
    decimal Amount { get; }
    CurrencyCode CurrencyCode { get; }
}
public interface IWritableMoney
{
    decimal Amount { set; }
    CurrencyCode CurrencyCode { set; }
}