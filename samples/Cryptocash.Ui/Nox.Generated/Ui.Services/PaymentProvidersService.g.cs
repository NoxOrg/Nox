// Generated

#nullable enable

using Nox.Ui.Blazor.Lib.Contracts;
using Nox.Ui.Blazor.Lib.Extensions;

using Cryptocash.Application.Dto;
using Cryptocash.Ui.Models;

namespace Cryptocash.Ui.Services;

public interface IPaymentProvidersService
{
    public Task<List<PaymentProviderModel>> GetAllAsync();
    public Task<PaymentProviderDto?> GetByIdAsync(string id);
    public Task<PaymentProviderDto?> CreateAsync(PaymentProviderCreateDto paymentProvider);
    public Task<PaymentProviderDto?> UpdateAsync(PaymentProviderUpdateDto paymentProvider);
    public Task DeleteAsync(string id);
}

internal partial class PaymentProvidersService : PaymentProvidersServiceBase
{
    public PaymentProvidersService(HttpClient httpClient, 
        IEndpointsProvider endpointsProvider,
        IModelConverter<PaymentProviderModel, PaymentProviderDto> modelConverter)
        : base(httpClient, endpointsProvider, modelConverter)
    {
    }
}

internal abstract partial class PaymentProvidersServiceBase : IPaymentProvidersService
{
    private readonly HttpClient _httpClient;
    private readonly string _apiBaseUrl;
    private readonly IModelConverter<PaymentProviderModel, PaymentProviderDto> _modelConverter;

    protected PaymentProvidersServiceBase(HttpClient httpClient, 
        IEndpointsProvider endpointsProvider,
        IModelConverter<PaymentProviderModel, PaymentProviderDto> modelConverter)
    {
        _httpClient = httpClient;
        _apiBaseUrl = endpointsProvider.PaymentProvidersUrl;
        _modelConverter = modelConverter;
    }

    public async Task<List<PaymentProviderModel>> GetAllAsync()
    {
        var items = await _httpClient.GetODataCollectionResponseAsync<List<PaymentProviderDto>>(_apiBaseUrl);
        if (items is null)
            return new List<PaymentProviderModel>();

        return items.Select(i => _modelConverter.ConvertToModel(i)).ToList();
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