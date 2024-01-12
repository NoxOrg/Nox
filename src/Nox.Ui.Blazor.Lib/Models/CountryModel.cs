using Nox.Types;
namespace Nox.Ui.Blazor.Lib.Models;

public class CountryModel
{
    public CountryModel(string? id, string? name, string? currencyCodeStr)
    {
        Id = id;
        Name = name;
        CurrencyCodeStr = currencyCodeStr;
    }

    public string? Id { get; set; }

    public string? Name { get; set; }

    public string? CurrencyCodeStr { get; set; }
}
