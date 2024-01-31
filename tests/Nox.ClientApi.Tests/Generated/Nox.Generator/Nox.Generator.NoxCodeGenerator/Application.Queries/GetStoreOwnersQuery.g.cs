// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Queries;
using Nox.Application.Repositories;
using ClientApi.Application.Dto;

namespace ClientApi.Application.Queries;

public partial record GetStoreOwnersQuery() : IRequest<IQueryable<StoreOwnerDto>>;

internal partial class GetStoreOwnersQueryHandler: GetStoreOwnersQueryHandlerBase
{
    public GetStoreOwnersQueryHandler(IReadOnlyRepository readOnlyRepository): base(readOnlyRepository){}
}

internal abstract class GetStoreOwnersQueryHandlerBase : QueryBase<IQueryable<StoreOwnerDto>>, IRequestHandler<GetStoreOwnersQuery, IQueryable<StoreOwnerDto>>
{
    public  GetStoreOwnersQueryHandlerBase(IReadOnlyRepository readOnlyRepository)
    {
        ReadOnlyRepository = readOnlyRepository;
    }

    public IReadOnlyRepository ReadOnlyRepository { get; }

    public virtual Task<IQueryable<StoreOwnerDto>> Handle(GetStoreOwnersQuery request, CancellationToken cancellationToken)
    {
        var query = ReadOnlyRepository.Query<StoreOwnerDto>();
       return Task.FromResult(OnResponse(query));
    }
}