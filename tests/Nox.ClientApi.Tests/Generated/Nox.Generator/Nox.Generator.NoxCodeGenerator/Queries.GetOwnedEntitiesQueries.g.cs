// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using ClientApi.Application.Dto;
using ClientApi.Presentation.Api.OData;

namespace ClientApi.Application.Queries;

public record GetOwnedEntitiesQuery() : IRequest<IQueryable<OwnedEntityDto>>;

public class GetOwnedEntitiesQueryHandler : IRequestHandler<GetOwnedEntitiesQuery, IQueryable<OwnedEntityDto>>
{
    public  GetOwnedEntitiesQueryHandler(ODataDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public ODataDbContext DataDbContext { get; }

    public Task<IQueryable<OwnedEntityDto>> Handle(GetOwnedEntitiesQuery request, CancellationToken cancellationToken)
    {
        var item = (IQueryable<OwnedEntityDto>)DataDbContext.OwnedEntities
            .Where(r => r.DeletedAtUtc == null)
            .AsNoTracking();
        return Task.FromResult(item);
    }
}