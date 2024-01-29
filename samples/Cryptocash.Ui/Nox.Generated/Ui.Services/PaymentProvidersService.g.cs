// Generated

#nullable enable

using Cryptocash.Application.Dto;
using Nox.Ui.Blazor.Lib.Extensions;

namespace Cryptocash.Ui.Services;

public partial class PaymentProvidersService : PaymentProvidersServiceBase
{
    public PaymentProvidersService(HttpClient httpClient, EndpointsProvider endpointsProvider)
        : base(httpClient, endpointsProvider)
    {
    }
}

public abstract partial class PaymentProvidersServiceBase
{
    private readonly HttpClient _httpClient;
    private readonly string _apiBaseUrl;

    protected PaymentProvidersServiceBase(HttpClient httpClient, EndpointsProvider endpointsProvider)
    {
        _httpClient = httpClient;
        _apiBaseUrl = endpointsProvider.PaymentProvidersUrl;
    }

    public async Task<List<PaymentProviderDto>> GetAllAsync()
    {
        var items = await _httpClient.GetODataCollectionResponseAsync<List<PaymentProviderDto>>(_apiBaseUrl);
        return items ?? new List<PaymentProviderDto>();
    }

    public async Task<PaymentProviderDto?> GetByIdAsync(string id)
    {
        return await _httpClient.GetODataSimpleResponseAsync<PaymentProviderDto>($"{_apiBaseUrl}/{id}");
    }

    public async Task<PaymentProviderDto?> CreateAsync(PaymentProviderCreateDto paymentProvider)
    {
        return await _httpClient.PostAsync<PaymentProviderCreateDto, PaymentProviderDto>(_apiBaseUrl, paymentProvider);
    }

    public async Task<PaymentProviderDto?> UpdateAsync(PaymentProviderUpdateDto paymentProvider)
    {
        return await _httpClient.PutAsync<PaymentProviderUpdateDto, PaymentProviderDto>(_apiBaseUrl, paymentProvider);
    }

    public async Task DeleteAsync(string id)
    {
        await _httpClient.DeleteAsync($"{_apiBaseUrl}/{id}");
    }
}