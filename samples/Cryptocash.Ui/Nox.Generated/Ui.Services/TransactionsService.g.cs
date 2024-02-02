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
    public Task<TransactionDto?> GetByIdAsync(string id);
    public Task<TransactionDto?> CreateAsync(TransactionCreateDto transaction);
    public Task<TransactionDto?> UpdateAsync(TransactionUpdateDto transaction);
    public Task DeleteAsync(string id);
}

internal partial class TransactionsService : TransactionsServiceBase
{
    public TransactionsService(HttpClient httpClient, 
        IEndpointsProvider endpointsProvider,
        IModelConverter<TransactionModel, TransactionDto> modelConverter)
        : base(httpClient, endpointsProvider, modelConverter)
    {
    }
}

internal abstract partial class TransactionsServiceBase : ITransactionsService
{
    private readonly HttpClient _httpClient;
    private readonly string _apiBaseUrl;
    private readonly IModelConverter<TransactionModel, TransactionDto> _modelConverter;

    protected TransactionsServiceBase(HttpClient httpClient, 
        IEndpointsProvider endpointsProvider,
        IModelConverter<TransactionModel, TransactionDto> modelConverter)
    {
        _httpClient = httpClient;
        _apiBaseUrl = endpointsProvider.TransactionsUrl;
        _modelConverter = modelConverter;
    }

    public async Task<List<TransactionModel>> GetAllAsync()
    {
        var items = await _httpClient.GetODataCollectionResponseAsync<List<TransactionDto>>(_apiBaseUrl);
        if (items is null)
            return new List<TransactionModel>();

        return items.Select(i => _modelConverter.ConvertToModel(i)).ToList();
    }

    public async Task<TransactionDto?> GetByIdAsync(string id)
    {
        return await _httpClient.GetODataSimpleResponseAsync<TransactionDto>($"{_apiBaseUrl}/{id}");
    }

    public async Task<TransactionDto?> CreateAsync(TransactionCreateDto transaction)
    {
        return await _httpClient.PostAsync<TransactionCreateDto, TransactionDto>(_apiBaseUrl, transaction);
    }

    public async Task<TransactionDto?> UpdateAsync(TransactionUpdateDto transaction)
    {
        return await _httpClient.PutAsync<TransactionUpdateDto, TransactionDto>(_apiBaseUrl, transaction);
    }

    public async Task DeleteAsync(string id)
    {
        await _httpClient.DeleteAsync($"{_apiBaseUrl}/{id}");
    }
}