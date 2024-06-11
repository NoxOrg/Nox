// Generated

#nullable enable

using Nox.Extensions;
using Nox.Ui.Blazor.Lib.Contracts;

using Cryptocash.Application.Dto;
using Cryptocash.Ui.Models;

namespace Cryptocash.Ui.Services;

public interface IBookingsService
{
    public Task<List<BookingModel>> GetAllAsync();
    public Task<BookingModel?> GetByIdAsync(string id);
    public Task<BookingModel?> CreateAsync(BookingModel booking);
    public Task<BookingModel?> UpdateAsync(BookingModel booking);
    public Task DeleteAsync(BookingModel booking);
}

internal partial class BookingsService : BookingsServiceBase
{
    public BookingsService(HttpClient httpClient, 
        IEndpointsProvider endpointsProvider,
        IModelConverter<BookingModel, BookingDto> dtoConverter,
        IModelConverter<BookingModel, BookingCreateDto> createDtoConverter,
        IModelConverter<BookingModel, BookingUpdateDto> updateDtoConverter)
        : base(httpClient, endpointsProvider, dtoConverter, createDtoConverter, updateDtoConverter)
    {
    }
}

internal abstract partial class BookingsServiceBase : IBookingsService
{
    private readonly HttpClient _httpClient;
    private readonly string _apiBaseUrl;
    private readonly IModelConverter<BookingModel, BookingDto> _dtoConverter;
    private readonly IModelConverter<BookingModel, BookingCreateDto> _createDtoConverter;
    private readonly IModelConverter<BookingModel, BookingUpdateDto> _updateDtoConverter;

    protected BookingsServiceBase(HttpClient httpClient, 
        IEndpointsProvider endpointsProvider,
        IModelConverter<BookingModel, BookingDto> dtoConverter,
        IModelConverter<BookingModel, BookingCreateDto> createDtoConverter,
        IModelConverter<BookingModel, BookingUpdateDto> updateDtoConverter)
    {
        _httpClient = httpClient;
        _apiBaseUrl = endpointsProvider.BookingsUrl;
        _dtoConverter = dtoConverter;
        _createDtoConverter = createDtoConverter;
        _updateDtoConverter = updateDtoConverter;
    }

    public async Task<List<BookingModel>> GetAllAsync()
    {
        var items = await _httpClient.GetODataCollectionResponseAsync<List<BookingDto>>(_apiBaseUrl);
        return items?.Select(i => _dtoConverter.ConvertToModel(i)).ToList() ?? new List<BookingModel>();
    }

    public async Task<BookingModel?> GetByIdAsync(string id)
    {
        var item = await _httpClient.GetODataSimpleResponseAsync<BookingDto>($"{_apiBaseUrl}/{id}");
        return item != null ? _dtoConverter.ConvertToModel(item) : null;
    }

    public async Task<BookingModel?> CreateAsync(BookingModel booking)
    {
        var item = await _httpClient.PostAsync<BookingCreateDto, BookingDto>(_apiBaseUrl, _createDtoConverter.ConvertToDto(booking));
        return item != null ? _dtoConverter.ConvertToModel(item) : null;
    }

    public async Task<BookingModel?> UpdateAsync(BookingModel booking)
    {
        if (booking.Etag != Guid.Empty)
        {
            string currentEtag = booking.Etag.ToString();

            Dictionary<string, IEnumerable<string>> headers = new()
            {
                { "If-Match", new List<string> { $"\"{currentEtag}\"" } }
            };
            _httpClient.DefaultRequestHeaders.Clear();
            foreach (var header in headers)
            {
                _httpClient.DefaultRequestHeaders.Add(header.Key, header.Value);
            }
        }

        string? currentID = string.Empty;
        if (booking.Id != null)
        {
            currentID = booking.Id.ToString();
        }

        var item = await _httpClient.PutAsync<BookingUpdateDto, BookingDto>(_apiBaseUrl + $"/{currentID}", _updateDtoConverter.ConvertToDto(booking));

        return item != null ? _dtoConverter.ConvertToModel(item) : null;
    }

    public async Task DeleteAsync(BookingModel booking)
    {
        if (booking.Etag != Guid.Empty)
        {
            string currentEtag = booking.Etag.ToString();

            Dictionary<string, IEnumerable<string>> headers = new()
            {
                { "If-Match", new List<string> { $"\"{currentEtag}\"" } }
            };
            _httpClient.DefaultRequestHeaders.Clear();
            foreach (var header in headers)
            {
                _httpClient.DefaultRequestHeaders.Add(header.Key, header.Value);
            }
        }

        string? currentID = string.Empty;
        if (booking.Id != null)
        {
            currentID = booking.Id.ToString();
        }

        await _httpClient.DeleteAsync($"{_apiBaseUrl}/{currentID}");
    }
}