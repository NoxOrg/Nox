// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using SampleWebApp.Application.Dto;
using SampleWebApp.Infrastructure.Persistence;

namespace SampleWebApp.Application.Queries;

public record GetStoreOwnersQuery() : IRequest<IQueryable<StoreOwnerDto>>;

public partial class GetStoreOwnersQueryHandler : QueryBase<IQueryable<StoreOwnerDto>>, IRequestHandler<GetStoreOwnersQuery, IQueryable<StoreOwnerDto>>
{
    public  GetStoreOwnersQueryHandler(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public Task<IQueryable<StoreOwnerDto>> Handle(GetStoreOwnersQuery request, CancellationToken cancellationToken)
    {
        var item = (IQueryable<StoreOwnerDto>)DataDbContext.StoreOwners
            .Where(r => r.DeletedAtUtc == null)
            .AsNoTracking();
       return Task.FromResult(OnResponse(item));
    }
}