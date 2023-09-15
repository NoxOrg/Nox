// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using Cryptocash.Application.Dto;
using Cryptocash.Infrastructure.Persistence;

namespace Cryptocash.Application.Queries;

public record GetBookingByIdQuery(System.Guid keyId) : IRequest <IQueryable<BookingDto>>;

public partial class GetBookingByIdQueryHandler:  QueryBase<IQueryable<BookingDto>>, IRequestHandler<GetBookingByIdQuery, IQueryable<BookingDto>>
{
    public  GetBookingByIdQueryHandler(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public Task<IQueryable<BookingDto>> Handle(GetBookingByIdQuery request, CancellationToken cancellationToken)
    {    
        var query = DataDbContext.Bookings
            .AsNoTracking()
            .Where(r =>
                r.Id.Equals(request.keyId) &&
                r.DeletedAtUtc == null);
        return Task.FromResult(OnResponse(query));
    }
}