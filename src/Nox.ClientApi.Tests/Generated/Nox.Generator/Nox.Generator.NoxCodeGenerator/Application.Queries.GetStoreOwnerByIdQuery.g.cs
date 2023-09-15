// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using ClientApi.Application.Dto;
using ClientApi.Infrastructure.Persistence;

namespace ClientApi.Application.Queries;

public record GetStoreOwnerByIdQuery(System.String keyId) : IRequest <StoreOwnerDto?>;

public partial class GetStoreOwnerByIdQueryHandler:  QueryBase<StoreOwnerDto?>, IRequestHandler<GetStoreOwnerByIdQuery, StoreOwnerDto?>
{
    public  GetStoreOwnerByIdQueryHandler(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public Task<StoreOwnerDto?> Handle(GetStoreOwnerByIdQuery request, CancellationToken cancellationToken)
    {    
        var item = DataDbContext.StoreOwners
            .AsNoTracking()
            .Include(r => r.Stores)
            .SingleOrDefault(r =>
                r.Id.Equals(request.keyId) &&
                r.DeletedAtUtc == null);
        return Task.FromResult(OnResponse(item));
    }
}