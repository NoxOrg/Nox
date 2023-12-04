namespace Nox.Types;

public interface IVatNumber
{
    string Number { get; }
    CountryCode CountryCode { get; }
}
public interface IWritableVatNumber
{
    string Number { set; }
    CountryCode CountryCode { set; }
}