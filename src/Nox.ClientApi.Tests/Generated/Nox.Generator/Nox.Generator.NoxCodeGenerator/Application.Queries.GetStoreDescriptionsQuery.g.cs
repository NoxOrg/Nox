// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using ClientApi.Application.Dto;
using ClientApi.Infrastructure.Persistence;

namespace ClientApi.Application.Queries;

public record GetStoreDescriptionsQuery() : IRequest<IQueryable<StoreDescriptionDto>>;

public partial class GetStoreDescriptionsQueryHandler: GetStoreDescriptionsQueryHandlerBase
{
    public GetStoreDescriptionsQueryHandler(DtoDbContext dataDbContext): base(dataDbContext)
    {
    
    }
}

public abstract class GetStoreDescriptionsQueryHandlerBase : QueryBase<IQueryable<StoreDescriptionDto>>, IRequestHandler<GetStoreDescriptionsQuery, IQueryable<StoreDescriptionDto>>
{
    public  GetStoreDescriptionsQueryHandlerBase(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public virtual Task<IQueryable<StoreDescriptionDto>> Handle(GetStoreDescriptionsQuery request, CancellationToken cancellationToken)
    {
        var item = (IQueryable<StoreDescriptionDto>)DataDbContext.StoreDescriptions
            .AsNoTracking();
       return Task.FromResult(OnResponse(item));
    }
}