// Generated

namespace Cryptocash.Ui.Services;

public class EndpointsProvider
{
    private readonly string _baseUrl;

    public EndpointsProvider(IConfiguration configuration)
    {
        var baseUrl = configuration?["BaseApiUrl"] ?? string.Empty;
        _baseUrl = baseUrl.TrimEnd('/');
    }

    public string BaseUrl
    {
        get { return _baseUrl; }
    }

    public string BaseUrlWithRoutePrefix
    {
        get { return $"{BaseUrl}/api"; }
    }
    public string BookingsUrl
    {
        get { return $"{BaseUrlWithRoutePrefix}/Bookings"; }
    }
    public string CashStockOrdersUrl
    {
        get { return $"{BaseUrlWithRoutePrefix}/CashStockOrders"; }
    }
    public string CommissionsUrl
    {
        get { return $"{BaseUrlWithRoutePrefix}/Commissions"; }
    }
    public string CountriesUrl
    {
        get { return $"{BaseUrlWithRoutePrefix}/Countries"; }
    }
    public string CurrenciesUrl
    {
        get { return $"{BaseUrlWithRoutePrefix}/Currencies"; }
    }
    public string CustomersUrl
    {
        get { return $"{BaseUrlWithRoutePrefix}/Customers"; }
    }
    public string EmployeesUrl
    {
        get { return $"{BaseUrlWithRoutePrefix}/Employees"; }
    }
    public string LandLordsUrl
    {
        get { return $"{BaseUrlWithRoutePrefix}/LandLords"; }
    }
    public string MinimumCashStocksUrl
    {
        get { return $"{BaseUrlWithRoutePrefix}/MinimumCashStocks"; }
    }
    public string PaymentDetailsUrl
    {
        get { return $"{BaseUrlWithRoutePrefix}/PaymentDetails"; }
    }
    public string PaymentProvidersUrl
    {
        get { return $"{BaseUrlWithRoutePrefix}/PaymentProviders"; }
    }
    public string TransactionsUrl
    {
        get { return $"{BaseUrlWithRoutePrefix}/Transactions"; }
    }
    public string VendingMachinesUrl
    {
        get { return $"{BaseUrlWithRoutePrefix}/VendingMachines"; }
    }
}