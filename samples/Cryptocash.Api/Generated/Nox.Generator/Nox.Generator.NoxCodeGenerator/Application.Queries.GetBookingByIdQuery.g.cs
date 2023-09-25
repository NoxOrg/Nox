// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using Cryptocash.Application.Dto;
using Cryptocash.Infrastructure.Persistence;

namespace Cryptocash.Application.Queries;

public record GetBookingByIdQuery(System.Guid keyId) : IRequest <IQueryable<BookingDto>>;

internal partial class GetBookingByIdQueryHandler:GetBookingByIdQueryHandlerBase
{
    public  GetBookingByIdQueryHandler(DtoDbContext dataDbContext): base(dataDbContext)
    {
    
    }
}

internal abstract class GetBookingByIdQueryHandlerBase:  QueryBase<IQueryable<BookingDto>>, IRequestHandler<GetBookingByIdQuery, IQueryable<BookingDto>>
{
    public  GetBookingByIdQueryHandlerBase(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public virtual Task<IQueryable<BookingDto>> Handle(GetBookingByIdQuery request, CancellationToken cancellationToken)
    {    
        var query = DataDbContext.Bookings
            .AsNoTracking()
            .Where(r =>
                r.Id.Equals(request.keyId) &&
                r.DeletedAtUtc == null);
        return Task.FromResult(OnResponse(query));
    }
}