// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using Cryptocash.Application.Dto;
using Cryptocash.Infrastructure.Persistence;

namespace Cryptocash.Application.Queries;

public record GetBookingsQuery() : IRequest<IQueryable<BookingDto>>;

public partial class GetBookingsQueryHandler: GetBookingsQueryHandlerBase
{
    public GetBookingsQueryHandler(DtoDbContext dataDbContext): base(dataDbContext)
    {
    
    }
}

public abstract class GetBookingsQueryHandlerBase : QueryBase<IQueryable<BookingDto>>, IRequestHandler<GetBookingsQuery, IQueryable<BookingDto>>
{
    public  GetBookingsQueryHandlerBase(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public virtual Task<IQueryable<BookingDto>> Handle(GetBookingsQuery request, CancellationToken cancellationToken)
    {
        var item = (IQueryable<BookingDto>)DataDbContext.Bookings
            .Where(r => r.DeletedAtUtc == null)
            .AsNoTracking();
       return Task.FromResult(OnResponse(item));
    }
}