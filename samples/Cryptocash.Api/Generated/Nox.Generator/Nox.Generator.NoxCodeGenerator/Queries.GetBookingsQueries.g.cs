// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using CryptocashApi.Application.Dto;
using CryptocashApi.Infrastructure.Persistence;

namespace CryptocashApi.Application.Queries;

public record GetBookingsQuery() : IRequest<IQueryable<BookingDto>>;

public class GetBookingsQueryHandler : IRequestHandler<GetBookingsQuery, IQueryable<BookingDto>>
{
    public  GetBookingsQueryHandler(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public Task<IQueryable<BookingDto>> Handle(GetBookingsQuery request, CancellationToken cancellationToken)
    {
        var item = (IQueryable<BookingDto>)DataDbContext.Bookings
            .Where(r => r.DeletedAtUtc == null)
            .AsNoTracking();
        return Task.FromResult(item);
    }
}