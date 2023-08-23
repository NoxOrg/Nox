// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using ClientApi.Application.Dto;
using ClientApi.Infrastructure.Persistence;

namespace ClientApi.Application.Queries;

public record GetClientNuidsQuery() : IRequest<IQueryable<ClientNuidDto>>;

public class GetClientNuidsQueryHandler : IRequestHandler<GetClientNuidsQuery, IQueryable<ClientNuidDto>>
{
    public  GetClientNuidsQueryHandler(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public Task<IQueryable<ClientNuidDto>> Handle(GetClientNuidsQuery request, CancellationToken cancellationToken)
    {
        var item = (IQueryable<ClientNuidDto>)DataDbContext.ClientNuids
            .Where(r => r.DeletedAtUtc == null)
            .AsNoTracking();
        return Task.FromResult(item);
    }
}