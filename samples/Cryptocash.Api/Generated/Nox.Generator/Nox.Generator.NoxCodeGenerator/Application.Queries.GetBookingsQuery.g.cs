// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using Cryptocash.Application.Dto;
using Cryptocash.Infrastructure.Persistence;

namespace Cryptocash.Application.Queries;

public record GetBookingsQuery() : IRequest<IQueryable<BookingDto>>;

internal partial class GetBookingsQueryHandler: GetBookingsQueryHandlerBase
{
    public GetBookingsQueryHandler(DtoDbContext dataDbContext): base(dataDbContext)
    {
    
    }
}

internal abstract class GetBookingsQueryHandlerBase : QueryBase<IQueryable<BookingDto>>, IRequestHandler<GetBookingsQuery, IQueryable<BookingDto>>
{
    public  GetBookingsQueryHandlerBase(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public virtual Task<IQueryable<BookingDto>> Handle(GetBookingsQuery request, CancellationToken cancellationToken)
    {
        var item = (IQueryable<BookingDto>)DataDbContext.Bookings
            .AsNoTracking();
       return Task.FromResult(OnResponse(item));
    }
}