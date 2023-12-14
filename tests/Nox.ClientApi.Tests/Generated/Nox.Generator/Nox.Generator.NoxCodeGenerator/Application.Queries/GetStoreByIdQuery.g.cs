// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using ClientApi.Application.Dto;
using ClientApi.Infrastructure.Persistence;

namespace ClientApi.Application.Queries;

public partial record GetStoreByIdQuery(System.Guid keyId) : IRequest <IQueryable<StoreDto>>;

internal partial class GetStoreByIdQueryHandler:GetStoreByIdQueryHandlerBase
{
    public  GetStoreByIdQueryHandler(DtoDbContext dataDbContext): base(dataDbContext)
    {
    
    }
}

internal abstract class GetStoreByIdQueryHandlerBase:  QueryBase<IQueryable<StoreDto>>, IRequestHandler<GetStoreByIdQuery, IQueryable<StoreDto>>
{
    public  GetStoreByIdQueryHandlerBase(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public virtual Task<IQueryable<StoreDto>> Handle(GetStoreByIdQuery request, CancellationToken cancellationToken)
    {    
        var query = DataDbContext.Stores
            .AsNoTracking()
            .Include(e => e.EmailAddress)
            .Where(r =>
                r.Id.Equals(request.keyId));
        return Task.FromResult(OnResponse(query));
    }
}