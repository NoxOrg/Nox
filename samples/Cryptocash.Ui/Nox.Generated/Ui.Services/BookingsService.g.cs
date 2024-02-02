// Generated

#nullable enable

using Nox.Ui.Blazor.Lib.Contracts;
using Nox.Ui.Blazor.Lib.Extensions;

using Cryptocash.Application.Dto;
using Cryptocash.Ui.Models;

namespace Cryptocash.Ui.Services;

public interface IBookingsService
{
    public Task<List<BookingModel>> GetAllAsync();
    public Task<BookingDto?> GetByIdAsync(string id);
    public Task<BookingDto?> CreateAsync(BookingCreateDto booking);
    public Task<BookingDto?> UpdateAsync(BookingUpdateDto booking);
    public Task DeleteAsync(string id);
}

internal partial class BookingsService : BookingsServiceBase
{
    public BookingsService(HttpClient httpClient, 
        IEndpointsProvider endpointsProvider,
        IModelConverter<BookingModel, BookingDto> modelConverter)
        : base(httpClient, endpointsProvider, modelConverter)
    {
    }
}

internal abstract partial class BookingsServiceBase : IBookingsService
{
    private readonly HttpClient _httpClient;
    private readonly string _apiBaseUrl;
    private readonly IModelConverter<BookingModel, BookingDto> _modelConverter;

    protected BookingsServiceBase(HttpClient httpClient, 
        IEndpointsProvider endpointsProvider,
        IModelConverter<BookingModel, BookingDto> modelConverter)
    {
        _httpClient = httpClient;
        _apiBaseUrl = endpointsProvider.BookingsUrl;
        _modelConverter = modelConverter;
    }

    public async Task<List<BookingModel>> GetAllAsync()
    {
        var items = await _httpClient.GetODataCollectionResponseAsync<List<BookingDto>>(_apiBaseUrl);
        if (items is null)
            return new List<BookingModel>();

        return items.Select(i => _modelConverter.ConvertToModel(i)).ToList();
    }

    public async Task<BookingDto?> GetByIdAsync(string id)
    {
        return await _httpClient.GetODataSimpleResponseAsync<BookingDto>($"{_apiBaseUrl}/{id}");
    }

    public async Task<BookingDto?> CreateAsync(BookingCreateDto booking)
    {
        return await _httpClient.PostAsync<BookingCreateDto, BookingDto>(_apiBaseUrl, booking);
    }

    public async Task<BookingDto?> UpdateAsync(BookingUpdateDto booking)
    {
        return await _httpClient.PutAsync<BookingUpdateDto, BookingDto>(_apiBaseUrl, booking);
    }

    public async Task DeleteAsync(string id)
    {
        await _httpClient.DeleteAsync($"{_apiBaseUrl}/{id}");
    }
}