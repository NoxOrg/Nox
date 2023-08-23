// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using SampleWebApp.Application.Dto;
using SampleWebApp.Infrastructure.Persistence;

namespace SampleWebApp.Application.Queries;

public record GetStoresQuery() : IRequest<IQueryable<StoreDto>>;

public class GetStoresQueryHandler : IRequestHandler<GetStoresQuery, IQueryable<StoreDto>>
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
        return Task.FromResult(item);
    }
}