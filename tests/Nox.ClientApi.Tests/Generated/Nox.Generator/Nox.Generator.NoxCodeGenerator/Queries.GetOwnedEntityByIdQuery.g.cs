// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using ClientApi.Application.Dto;
using ClientApi.Presentation.Api.OData;

namespace ClientApi.Application.Queries;

public record GetOwnedEntityByIdQuery(System.Int64 keyId) : IRequest<OwnedEntityDto?>;

public class GetOwnedEntityByIdQueryHandler: IRequestHandler<GetOwnedEntityByIdQuery, OwnedEntityDto?>
{
    public  GetOwnedEntityByIdQueryHandler(ODataDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public ODataDbContext DataDbContext { get; }

    public Task<OwnedEntityDto?> Handle(GetOwnedEntityByIdQuery request, CancellationToken cancellationToken)
    {    
        var item = DataDbContext.OwnedEntities
            .AsNoTracking()
            .SingleOrDefault(r =>
                r.Id.Equals(request.keyId) &&
                r.DeletedAtUtc == null);
        return Task.FromResult(item);
    }
}