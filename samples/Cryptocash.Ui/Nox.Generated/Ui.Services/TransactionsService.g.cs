// Generated

#nullable enable

using Nox.Ui.Blazor.Lib.Contracts;
using Nox.Ui.Blazor.Lib.Extensions;

using Cryptocash.Application.Dto;
using Cryptocash.Ui.Models;

namespace Cryptocash.Ui.Services;

public interface ITransactionsService
{
    public Task<List<TransactionModel>> GetAllAsync();
    public Task<TransactionModel?> GetByIdAsync(string id);
    public Task<TransactionModel?> CreateAsync(TransactionModel transaction);
    public Task<TransactionModel?> UpdateAsync(TransactionModel transaction);
    public Task DeleteAsync(string id);
}

internal partial class TransactionsService : TransactionsServiceBase
{
    public TransactionsService(HttpClient httpClient, 
        IEndpointsProvider endpointsProvider,
        IModelConverter<TransactionModel, TransactionDto> dtoConverter,
        IModelConverter<TransactionModel, TransactionCreateDto> createDtoConverter,
        IModelConverter<TransactionModel, TransactionUpdateDto> updateDtoConverter)
        : base(httpClient, endpointsProvider, dtoConverter, createDtoConverter, updateDtoConverter)
    {
    }
}

internal abstract partial class TransactionsServiceBase : ITransactionsService
{
    private readonly HttpClient _httpClient;
    private readonly string _apiBaseUrl;
    private readonly IModelConverter<TransactionModel, TransactionDto> _dtoConverter;
    private readonly IModelConverter<TransactionModel, TransactionCreateDto> _createDtoConverter;
    private readonly IModelConverter<TransactionModel, TransactionUpdateDto> _updateDtoConverter;

    protected TransactionsServiceBase(HttpClient httpClient, 
        IEndpointsProvider endpointsProvider,
        IModelConverter<TransactionModel, TransactionDto> dtoConverter,
        IModelConverter<TransactionModel, TransactionCreateDto> createDtoConverter,
        IModelConverter<TransactionModel, TransactionUpdateDto> updateDtoConverter)
    {
        _httpClient = httpClient;
        _apiBaseUrl = endpointsProvider.TransactionsUrl;
        _dtoConverter = dtoConverter;
        _createDtoConverter = createDtoConverter;
        _updateDtoConverter = updateDtoConverter;
    }

    public async Task<List<TransactionModel>> GetAllAsync()
    {
        var items = await _httpClient.GetODataCollectionResponseAsync<List<TransactionDto>>(_apiBaseUrl);
        return items?.Select(i => _dtoConverter.ConvertToModel(i)).ToList() ?? new List<TransactionModel>();
    }

    public async Task<TransactionModel?> GetByIdAsync(string id)
    {
        var item = await _httpClient.GetODataSimpleResponseAsync<TransactionDto>($"{_apiBaseUrl}/{id}");
        return item != null ? _dtoConverter.ConvertToModel(item) : null;
    }

    public async Task<TransactionModel?> CreateAsync(TransactionModel transaction)
    {
        var item = await _httpClient.PostAsync<TransactionCreateDto, TransactionDto>(_apiBaseUrl, _createDtoConverter.ConvertToDto(transaction));
        return item != null ? _dtoConverter.ConvertToModel(item) : null;
    }

    public async Task<TransactionModel?> UpdateAsync(TransactionModel transaction)
    {
        var item = await _httpClient.PutAsync<TransactionUpdateDto, TransactionDto>(_apiBaseUrl, _updateDtoConverter.ConvertToDto(transaction));
        return item != null ? _dtoConverter.ConvertToModel(item) : null;
    }

    public async Task DeleteAsync(string id)
    {
        await _httpClient.DeleteAsync($"{_apiBaseUrl}/{id}");
    }
}