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
    public Task<PaymentDetailModel?> GetByIdAsync(string id);
    public Task<PaymentDetailModel?> CreateAsync(PaymentDetailModel paymentDetail);
    public Task<PaymentDetailModel?> UpdateAsync(PaymentDetailModel paymentDetail);
    public Task DeleteAsync(string id);
}

internal partial class PaymentDetailsService : PaymentDetailsServiceBase
{
    public PaymentDetailsService(HttpClient httpClient, 
        IEndpointsProvider endpointsProvider,
        IModelConverter<PaymentDetailModel, PaymentDetailDto> dtoConverter,
        IModelConverter<PaymentDetailModel, PaymentDetailCreateDto> createDtoConverter,
        IModelConverter<PaymentDetailModel, PaymentDetailUpdateDto> updateDtoConverter)
        : base(httpClient, endpointsProvider, dtoConverter, createDtoConverter, updateDtoConverter)
    {
    }
}

internal abstract partial class PaymentDetailsServiceBase : IPaymentDetailsService
{
    private readonly HttpClient _httpClient;
    private readonly string _apiBaseUrl;
    private readonly IModelConverter<PaymentDetailModel, PaymentDetailDto> _dtoConverter;
    private readonly IModelConverter<PaymentDetailModel, PaymentDetailCreateDto> _createDtoConverter;
    private readonly IModelConverter<PaymentDetailModel, PaymentDetailUpdateDto> _updateDtoConverter;

    protected PaymentDetailsServiceBase(HttpClient httpClient, 
        IEndpointsProvider endpointsProvider,
        IModelConverter<PaymentDetailModel, PaymentDetailDto> dtoConverter,
        IModelConverter<PaymentDetailModel, PaymentDetailCreateDto> createDtoConverter,
        IModelConverter<PaymentDetailModel, PaymentDetailUpdateDto> updateDtoConverter)
    {
        _httpClient = httpClient;
        _apiBaseUrl = endpointsProvider.PaymentDetailsUrl;
        _dtoConverter = dtoConverter;
        _createDtoConverter = createDtoConverter;
        _updateDtoConverter = updateDtoConverter;
    }

    public async Task<List<PaymentDetailModel>> GetAllAsync()
    {
        var items = await _httpClient.GetODataCollectionResponseAsync<List<PaymentDetailDto>>(_apiBaseUrl);
        return items?.Select(i => _dtoConverter.ConvertToModel(i)).ToList() ?? new List<PaymentDetailModel>();
    }

    public async Task<PaymentDetailModel?> GetByIdAsync(string id)
    {
        var item = await _httpClient.GetODataSimpleResponseAsync<PaymentDetailDto>($"{_apiBaseUrl}/{id}");
        return item != null ? _dtoConverter.ConvertToModel(item) : null;
    }

    public async Task<PaymentDetailModel?> CreateAsync(PaymentDetailModel paymentDetail)
    {
        var item = await _httpClient.PostAsync<PaymentDetailCreateDto, PaymentDetailDto>(_apiBaseUrl, _createDtoConverter.ConvertToDto(paymentDetail));
        return item != null ? _dtoConverter.ConvertToModel(item) : null;
    }

    public async Task<PaymentDetailModel?> UpdateAsync(PaymentDetailModel paymentDetail)
    {
        var item = await _httpClient.PutAsync<PaymentDetailUpdateDto, PaymentDetailDto>(_apiBaseUrl, _updateDtoConverter.ConvertToDto(paymentDetail));
        return item != null ? _dtoConverter.ConvertToModel(item) : null;
    }

    public async Task DeleteAsync(string id)
    {
        await _httpClient.DeleteAsync($"{_apiBaseUrl}/{id}");
    }
}