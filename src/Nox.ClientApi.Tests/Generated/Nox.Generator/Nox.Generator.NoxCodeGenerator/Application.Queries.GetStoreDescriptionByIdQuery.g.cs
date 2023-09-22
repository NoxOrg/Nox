// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using ClientApi.Application.Dto;
using ClientApi.Infrastructure.Persistence;

namespace ClientApi.Application.Queries;

public record GetStoreDescriptionByIdQuery(System.Guid keyStoreId, System.Int64 keyId) : IRequest <IQueryable<StoreDescriptionDto>>;

public partial class GetStoreDescriptionByIdQueryHandler:GetStoreDescriptionByIdQueryHandlerBase
{
    public  GetStoreDescriptionByIdQueryHandler(DtoDbContext dataDbContext): base(dataDbContext)
    {
    
    }
}

public abstract class GetStoreDescriptionByIdQueryHandlerBase:  QueryBase<IQueryable<StoreDescriptionDto>>, IRequestHandler<GetStoreDescriptionByIdQuery, IQueryable<StoreDescriptionDto>>
{
    public  GetStoreDescriptionByIdQueryHandlerBase(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public virtual Task<IQueryable<StoreDescriptionDto>> Handle(GetStoreDescriptionByIdQuery request, CancellationToken cancellationToken)
    {    
        var query = DataDbContext.StoreDescriptions
            .AsNoTracking()
            .Where(r =>
                r.StoreId.Equals(request.keyStoreId) &&
                r.Id.Equals(request.keyId) &&
                true
            );
        return Task.FromResult(OnResponse(query));
    }
}