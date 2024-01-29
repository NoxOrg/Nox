// Generated

#nullable enable

using Cryptocash.Application.Dto;
using Nox.Ui.Blazor.Lib.Extensions;

namespace Cryptocash.Ui.Services;

public partial class BookingsService : BookingsServiceBase
{
    public BookingsService(HttpClient httpClient, EndpointsProvider endpointsProvider)
        : base(httpClient, endpointsProvider)
    {
    }
}

public abstract partial class BookingsServiceBase
{
    private readonly HttpClient _httpClient;
    private readonly string _apiBaseUrl;

    protected BookingsServiceBase(HttpClient httpClient, EndpointsProvider endpointsProvider)
    {
        _httpClient = httpClient;
        _apiBaseUrl = endpointsProvider.BookingsUrl;
    }

    public async Task<List<BookingDto>> GetAllAsync()
    {
        var items = await _httpClient.GetODataCollectionResponseAsync<List<BookingDto>>(_apiBaseUrl);
        return items ?? new List<BookingDto>();
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