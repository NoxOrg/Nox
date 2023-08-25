// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using CryptocashApi.Application.Dto;
using CryptocashApi.Infrastructure.Persistence;

namespace CryptocashApi.Application.Queries;

public record GetCountryHolidayByIdQuery(System.Int64 keyId) : IRequest<CountryHolidayDto?>;

public class GetCountryHolidayByIdQueryHandler: IRequestHandler<GetCountryHolidayByIdQuery, CountryHolidayDto?>
{
    public  GetCountryHolidayByIdQueryHandler(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public Task<CountryHolidayDto?> Handle(GetCountryHolidayByIdQuery request, CancellationToken cancellationToken)
    {    
        var item = DataDbContext.CountryHolidays
            .AsNoTracking()
            .SingleOrDefault(r =>
                r.Id.Equals(request.keyId) &&
                r.DeletedAtUtc == null);
        return Task.FromResult(item);
    }
}