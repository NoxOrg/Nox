// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using ClientApi.Application.Dto;
using ClientApi.Infrastructure.Persistence;

namespace ClientApi.Application.Queries;

public partial record GetStoreOwnersQuery() : IRequest<IQueryable<StoreOwnerDto>>;

internal partial class GetStoreOwnersQueryHandler: GetStoreOwnersQueryHandlerBase
{
    public GetStoreOwnersQueryHandler(DtoDbContext dataDbContext): base(dataDbContext)
    {
    
    }
}

internal abstract class GetStoreOwnersQueryHandlerBase : QueryBase<IQueryable<StoreOwnerDto>>, IRequestHandler<GetStoreOwnersQuery, IQueryable<StoreOwnerDto>>
{
    public  GetStoreOwnersQueryHandlerBase(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public virtual Task<IQueryable<StoreOwnerDto>> Handle(GetStoreOwnersQuery request, CancellationToken cancellationToken)
    {
        var item = (IQueryable<StoreOwnerDto>)DataDbContext.StoreOwners
            .AsNoTracking();
       return Task.FromResult(OnResponse(item));
    }
}