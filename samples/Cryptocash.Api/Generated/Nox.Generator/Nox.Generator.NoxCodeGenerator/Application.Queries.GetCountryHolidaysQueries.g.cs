// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using Cryptocash.Application.Dto;
using Cryptocash.Infrastructure.Persistence;

namespace Cryptocash.Application.Queries;

public record GetCountryHolidaysQuery() : IRequest<IQueryable<CountryHolidayDto>>;

public partial class GetCountryHolidaysQueryHandler : QueryBase<IQueryable<CountryHolidayDto>>, IRequestHandler<GetCountryHolidaysQuery, IQueryable<CountryHolidayDto>>
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
       return Task.FromResult(OnResponse(item));
    }
}