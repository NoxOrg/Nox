// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Queries;
using Nox.Application.Repositories;
using ClientApi.Application.Dto;
using ClientApi.Infrastructure.Persistence;

namespace ClientApi.Application.Queries;

public partial record GetStoresQuery() : IRequest<IQueryable<StoreDto>>;

internal partial class GetStoresQueryHandler: GetStoresQueryHandlerBase
{
    public GetStoresQueryHandler(IReadOnlyRepository readOnlyRepository): base(readOnlyRepository){}
}

internal abstract class GetStoresQueryHandlerBase : QueryBase<IQueryable<StoreDto>>, IRequestHandler<GetStoresQuery, IQueryable<StoreDto>>
{
    public  GetStoresQueryHandlerBase(IReadOnlyRepository readOnlyRepository)
    {
        ReadOnlyRepository = readOnlyRepository;
    }

    public IReadOnlyRepository ReadOnlyRepository { get; }

    public virtual Task<IQueryable<StoreDto>> Handle(GetStoresQuery request, CancellationToken cancellationToken)
    {
        var query = ReadOnlyRepository.Query<StoreDto>()
            .Include(e => e.EmailAddress);
       return Task.FromResult(OnResponse(query));
    }
}