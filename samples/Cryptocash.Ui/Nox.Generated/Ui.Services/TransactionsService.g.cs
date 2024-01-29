// Generated

#nullable enable

using Cryptocash.Application.Dto;
using Nox.Ui.Blazor.Lib.Extensions;

namespace Cryptocash.Ui.Services;

public partial class TransactionsService : TransactionsServiceBase
{
    public TransactionsService(HttpClient httpClient, EndpointsProvider endpointsProvider)
        : base(httpClient, endpointsProvider)
    {
    }
}

public abstract partial class TransactionsServiceBase
{
    private readonly HttpClient _httpClient;
    private readonly string _apiBaseUrl;

    protected TransactionsServiceBase(HttpClient httpClient, EndpointsProvider endpointsProvider)
    {
        _httpClient = httpClient;
        _apiBaseUrl = endpointsProvider.TransactionsUrl;
    }

    public async Task<List<TransactionDto>> GetAllAsync()
    {
        var items = await _httpClient.GetODataCollectionResponseAsync<List<TransactionDto>>(_apiBaseUrl);
        return items ?? new List<TransactionDto>();
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