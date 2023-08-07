namespace SampleWebApp.Application.Command
{
    public record DeleteCountryContactCommand(string countryId, int currencyId)
    {
    }
}