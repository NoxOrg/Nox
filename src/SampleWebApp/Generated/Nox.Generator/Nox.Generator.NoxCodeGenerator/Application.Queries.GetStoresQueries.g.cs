// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using SampleWebApp.Application.Dto;
using SampleWebApp.Infrastructure.Persistence;

namespace SampleWebApp.Application.Queries;

public record GetStoresQuery() : IRequest<IQueryable<StoreDto>>;

public partial class GetStoresQueryHandler : QueryBase<IQueryable<StoreDto>>, IRequestHandler<GetStoresQuery, IQueryable<StoreDto>>
{
    public  GetStoresQueryHandler(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public Task<IQueryable<StoreDto>> Handle(GetStoresQuery request, CancellationToken cancellationToken)
    {
        var item = (IQueryable<StoreDto>)DataDbContext.Stores
            .Where(r => r.DeletedAtUtc == null)
            .AsNoTracking();
       return Task.FromResult(OnResponse(item));
    }
}