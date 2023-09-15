// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using ClientApi.Application.Dto;
using ClientApi.Infrastructure.Persistence;

namespace ClientApi.Application.Queries;

public record GetStoreOwnerByIdQuery(System.String keyId) : IRequest <IQueryable<StoreOwnerDto>>;

public partial class GetStoreOwnerByIdQueryHandler:  QueryBase<IQueryable<StoreOwnerDto>>, IRequestHandler<GetStoreOwnerByIdQuery, IQueryable<StoreOwnerDto>>
{
    public  GetStoreOwnerByIdQueryHandler(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public Task<IQueryable<StoreOwnerDto>> Handle(GetStoreOwnerByIdQuery request, CancellationToken cancellationToken)
    {    
        var query = DataDbContext.StoreOwners
            .AsNoTracking()
            .Where(r =>
                r.Id.Equals(request.keyId) &&
                r.DeletedAtUtc == null);
        return Task.FromResult(OnResponse(query));
    }
}