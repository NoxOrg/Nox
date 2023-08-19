// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using ClientApi.Application.Dto;
using ClientApi.Presentation.Api.OData;

namespace ClientApi.Application.Queries;

public record GetClientNuidsQuery() : IRequest<IQueryable<ClientNuidDto>>;

public class GetClientNuidsQueryHandler : IRequestHandler<GetClientNuidsQuery, IQueryable<ClientNuidDto>>
{
    public  GetClientNuidsQueryHandler(ODataDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public ODataDbContext DataDbContext { get; }

    public Task<IQueryable<ClientNuidDto>> Handle(GetClientNuidsQuery request, CancellationToken cancellationToken)
    {
        var item = (IQueryable<ClientNuidDto>)DataDbContext.ClientNuids
            .Where(r => !(r.Deleted == true))
            .AsNoTracking();
        return Task.FromResult(item);
    }
}