// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using CryptocashApi.Application.Dto;
using CryptocashApi.Infrastructure.Persistence;

namespace CryptocashApi.Application.Queries;

public record GetHolidaysByIdQuery(System.Int64 keyId) : IRequest<HolidaysDto?>;

public class GetHolidaysByIdQueryHandler: IRequestHandler<GetHolidaysByIdQuery, HolidaysDto?>
{
    public  GetHolidaysByIdQueryHandler(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public Task<HolidaysDto?> Handle(GetHolidaysByIdQuery request, CancellationToken cancellationToken)
    {    
        var item = DataDbContext.Holidays
            .AsNoTracking()
            .SingleOrDefault(r =>
                r.Id.Equals(request.keyId) &&
                r.DeletedAtUtc == null);
        return Task.FromResult(item);
    }
}