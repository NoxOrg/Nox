// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using Cryptocash.Application.Dto;
using Cryptocash.Infrastructure.Persistence;

namespace Cryptocash.Application.Queries;

public record GetHolidaysQuery() : IRequest<IQueryable<HolidaysDto>>;

public partial class GetHolidaysQueryHandler : QueryBase<IQueryable<HolidaysDto>>, IRequestHandler<GetHolidaysQuery, IQueryable<HolidaysDto>>
{
    public  GetHolidaysQueryHandler(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public Task<IQueryable<HolidaysDto>> Handle(GetHolidaysQuery request, CancellationToken cancellationToken)
    {
        var item = (IQueryable<HolidaysDto>)DataDbContext.Holidays
            .Where(r => r.DeletedAtUtc == null)
            .AsNoTracking();
       return Task.FromResult(OnResponse(item));
    }
}