// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using ClientApi.Application.Dto;
using ClientApi.Infrastructure.Persistence;

namespace ClientApi.Application.Queries;

public record GetClientDatabaseGuidsQuery() : IRequest<IQueryable<ClientDatabaseGuidDto>>;

public partial class GetClientDatabaseGuidsQueryHandler : QueryBase<IQueryable<ClientDatabaseGuidDto>>, IRequestHandler<GetClientDatabaseGuidsQuery, IQueryable<ClientDatabaseGuidDto>>
{
    public  GetClientDatabaseGuidsQueryHandler(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public Task<IQueryable<ClientDatabaseGuidDto>> Handle(GetClientDatabaseGuidsQuery request, CancellationToken cancellationToken)
    {
        var item = (IQueryable<ClientDatabaseGuidDto>)DataDbContext.ClientDatabaseGuids
            .AsNoTracking();
       return Task.FromResult(OnResponse(item));
    }
}