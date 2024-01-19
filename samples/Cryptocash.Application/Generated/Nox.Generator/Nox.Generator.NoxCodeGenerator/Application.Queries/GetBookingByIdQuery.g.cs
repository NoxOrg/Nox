// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Queries;
using Nox.Application.Repositories;

using Cryptocash.Application.Dto;
using Cryptocash.Infrastructure.Persistence;

namespace Cryptocash.Application.Queries;

public partial record GetBookingByIdQuery(System.Guid keyId) : IRequest <IQueryable<BookingDto>>;

internal partial class GetBookingByIdQueryHandler:GetBookingByIdQueryHandlerBase
{
    public GetBookingByIdQueryHandler(IReadOnlyRepository readOnlyRepository): base(readOnlyRepository){}
}

internal abstract class GetBookingByIdQueryHandlerBase:  QueryBase<IQueryable<BookingDto>>, IRequestHandler<GetBookingByIdQuery, IQueryable<BookingDto>>
{
    public  GetBookingByIdQueryHandlerBase(IReadOnlyRepository readOnlyRepository)
    {
        ReadOnlyRepository = readOnlyRepository;
    }

    public IReadOnlyRepository ReadOnlyRepository { get; }

    public virtual Task<IQueryable<BookingDto>> Handle(GetBookingByIdQuery request, CancellationToken cancellationToken)
    {    
        var query = ReadOnlyRepository.Query<BookingDto >()
            .Where(r =>
                r.Id.Equals(request.keyId));
        return Task.FromResult(OnResponse(query));
    }
}