// Generated

#nullable enable

using Cryptocash.Application.Dto;
using Nox.Ui.Blazor.Lib.Extensions;

namespace Cryptocash.Ui.Services;

public interface IPaymentDetailsService
{
    public Task<List<PaymentDetailDto>> GetAllAsync();
    public Task<PaymentDetailDto?> GetByIdAsync(string id);
    public Task<PaymentDetailDto?> CreateAsync(PaymentDetailCreateDto paymentDetail);
    public Task<PaymentDetailDto?> UpdateAsync(PaymentDetailUpdateDto paymentDetail);
    public Task DeleteAsync(string id);
}

internal partial class PaymentDetailsService : PaymentDetailsServiceBase
{
    public PaymentDetailsService(HttpClient httpClient, IEndpointsProvider endpointsProvider)
        : base(httpClient, endpointsProvider)
    {
    }
}

internal abstract partial class PaymentDetailsServiceBase : IPaymentDetailsService
{
    private readonly HttpClient _httpClient;
    private readonly string _apiBaseUrl;

    protected PaymentDetailsServiceBase(HttpClient httpClient, IEndpointsProvider endpointsProvider)
    {
        _httpClient = httpClient;
        _apiBaseUrl = endpointsProvider.PaymentDetailsUrl;
    }

    public async Task<List<PaymentDetailDto>> GetAllAsync()
    {
        var items = await _httpClient.GetODataCollectionResponseAsync<List<PaymentDetailDto>>(_apiBaseUrl);
        return items ?? new List<PaymentDetailDto>();
    }

    public async Task<PaymentDetailDto?> GetByIdAsync(string id)
    {
        return await _httpClient.GetODataSimpleResponseAsync<PaymentDetailDto>($"{_apiBaseUrl}/{id}");
    }

    public async Task<PaymentDetailDto?> CreateAsync(PaymentDetailCreateDto paymentDetail)
    {
        return await _httpClient.PostAsync<PaymentDetailCreateDto, PaymentDetailDto>(_apiBaseUrl, paymentDetail);
    }

    public async Task<PaymentDetailDto?> UpdateAsync(PaymentDetailUpdateDto paymentDetail)
    {
        return await _httpClient.PutAsync<PaymentDetailUpdateDto, PaymentDetailDto>(_apiBaseUrl, paymentDetail);
    }

    public async Task DeleteAsync(string id)
    {
        await _httpClient.DeleteAsync($"{_apiBaseUrl}/{id}");
    }
}