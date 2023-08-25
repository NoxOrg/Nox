// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using CryptocashApi.Application.Dto;
using CryptocashApi.Infrastructure.Persistence;

namespace CryptocashApi.Application.Queries;

public record GetCountryHolidaysQuery() : IRequest<IQueryable<CountryHolidayDto>>;

public class GetCountryHolidaysQueryHandler : IRequestHandler<GetCountryHolidaysQuery, IQueryable<CountryHolidayDto>>
{
    public  GetCountryHolidaysQueryHandler(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public Task<IQueryable<CountryHolidayDto>> Handle(GetCountryHolidaysQuery request, CancellationToken cancellationToken)
    {
        var item = (IQueryable<CountryHolidayDto>)DataDbContext.CountryHolidays
            .Where(r => r.DeletedAtUtc == null)
            .AsNoTracking();
        return Task.FromResult(item);
    }
}