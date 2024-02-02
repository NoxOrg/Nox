// Generated

#nullable enable

using Nox.Ui.Blazor.Lib.Contracts;
using Nox.Ui.Blazor.Lib.Extensions;

using Cryptocash.Application.Dto;
using Cryptocash.Ui.Models;

namespace Cryptocash.Ui.Services;

public interface IPaymentDetailsService
{
    public Task<List<PaymentDetailModel>> GetAllAsync();
    public Task<PaymentDetailDto?> GetByIdAsync(string id);
    public Task<PaymentDetailDto?> CreateAsync(PaymentDetailCreateDto paymentDetail);
    public Task<PaymentDetailDto?> UpdateAsync(PaymentDetailUpdateDto paymentDetail);
    public Task DeleteAsync(string id);
}

internal partial class PaymentDetailsService : PaymentDetailsServiceBase
{
    public PaymentDetailsService(HttpClient httpClient, 
        IEndpointsProvider endpointsProvider,
        IModelConverter<PaymentDetailModel, PaymentDetailDto> modelConverter)
        : base(httpClient, endpointsProvider, modelConverter)
    {
    }
}

internal abstract partial class PaymentDetailsServiceBase : IPaymentDetailsService
{
    private readonly HttpClient _httpClient;
    private readonly string _apiBaseUrl;
    private readonly IModelConverter<PaymentDetailModel, PaymentDetailDto> _modelConverter;

    protected PaymentDetailsServiceBase(HttpClient httpClient, 
        IEndpointsProvider endpointsProvider,
        IModelConverter<PaymentDetailModel, PaymentDetailDto> modelConverter)
    {
        _httpClient = httpClient;
        _apiBaseUrl = endpointsProvider.PaymentDetailsUrl;
        _modelConverter = modelConverter;
    }

    public async Task<List<PaymentDetailModel>> GetAllAsync()
    {
        var items = await _httpClient.GetODataCollectionResponseAsync<List<PaymentDetailDto>>(_apiBaseUrl);
        if (items is null)
            return new List<PaymentDetailModel>();

        return items.Select(i => _modelConverter.ConvertToModel(i)).ToList();
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