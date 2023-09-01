// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using SampleWebApp.Application.Dto;
using SampleWebApp.Infrastructure.Persistence;

namespace SampleWebApp.Application.Queries;

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
            .SingleOrDefault(r =>
                r.Id.Equals(request.keyId) &&
                r.DeletedAtUtc == null);
        return Task.FromResult(OnResponse(item));
    }
}