// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using CryptocashApi.Application.Dto;
using CryptocashApi.Infrastructure.Persistence;

namespace CryptocashApi.Application.Queries;

public record GetBookingByIdQuery(System.Guid keyId) : IRequest <BookingDto?>;

public partial class GetBookingByIdQueryHandler:  QueryBase<BookingDto?>, IRequestHandler<GetBookingByIdQuery, BookingDto?>
{
    public  GetBookingByIdQueryHandler(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public Task<BookingDto?> Handle(GetBookingByIdQuery request, CancellationToken cancellationToken)
    {    
        var item = DataDbContext.Bookings
            .AsNoTracking()
            .SingleOrDefault(r =>
                r.Id.Equals(request.keyId) &&
                r.DeletedAtUtc == null);
        return Task.FromResult(OnResponse(item));
    }
}