// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using Cryptocash.Application.Dto;
using Cryptocash.Infrastructure.Persistence;

namespace Cryptocash.Application.Queries;

public record GetHolidaysByIdQuery(System.Int64 keyId) : IRequest <HolidaysDto?>;

public partial class GetHolidaysByIdQueryHandler:  QueryBase<HolidaysDto?>, IRequestHandler<GetHolidaysByIdQuery, HolidaysDto?>
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
        return Task.FromResult(OnResponse(item));
    }
}