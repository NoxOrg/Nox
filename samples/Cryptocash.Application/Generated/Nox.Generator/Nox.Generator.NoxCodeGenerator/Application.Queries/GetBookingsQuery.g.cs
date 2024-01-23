// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Queries;
using Nox.Application.Repositories;
using Cryptocash.Application.Dto;
using Cryptocash.Infrastructure.Persistence;

namespace Cryptocash.Application.Queries;

public partial record GetBookingsQuery() : IRequest<IQueryable<BookingDto>>;

internal partial class GetBookingsQueryHandler: GetBookingsQueryHandlerBase
{
    public GetBookingsQueryHandler(IReadOnlyRepository readOnlyRepository): base(readOnlyRepository){}
}

internal abstract class GetBookingsQueryHandlerBase : QueryBase<IQueryable<BookingDto>>, IRequestHandler<GetBookingsQuery, IQueryable<BookingDto>>
{
    public  GetBookingsQueryHandlerBase(IReadOnlyRepository readOnlyRepository)
    {
        ReadOnlyRepository = readOnlyRepository;
    }

    public IReadOnlyRepository ReadOnlyRepository { get; }

    public virtual Task<IQueryable<BookingDto>> Handle(GetBookingsQuery request, CancellationToken cancellationToken)
    {
        var query = ReadOnlyRepository.Query<BookingDto>();
       return Task.FromResult(OnResponse(query));
    }
}