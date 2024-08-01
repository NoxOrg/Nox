// Generated

namespace Cryptocash.Ui.Services;

public interface IEndpointsProvider
{
    public string BaseUrl { get; }
    public string BaseUrlWithRoutePrefix { get; }
    public string BookingsUrl { get; }
    public string CashStockOrdersUrl { get; }
    public string CommissionsUrl { get; }
    public string CountriesUrl { get; }
    public string CurrenciesUrl { get; }
    public string CustomersUrl { get; }
    public string EmployeesUrl { get; }
    public string LandLordsUrl { get; }
    public string MinimumCashStocksUrl { get; }
    public string PaymentDetailsUrl { get; }
    public string PaymentProvidersUrl { get; }
    public string TransactionsUrl { get; }
    public string VendingMachinesUrl { get; }
}

internal class EndpointsProvider : IEndpointsProvider
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