// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using ClientApi.Application.Dto;
using ClientApi.Presentation.Api.OData;

namespace ClientApi.Application.Queries;

public record GetClientDatabaseNumbersQuery() : IRequest<IQueryable<ClientDatabaseNumberDto>>;

public class GetClientDatabaseNumbersQueryHandler : IRequestHandler<GetClientDatabaseNumbersQuery, IQueryable<ClientDatabaseNumberDto>>
{
    public  GetClientDatabaseNumbersQueryHandler(ODataDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public ODataDbContext DataDbContext { get; }

    public Task<IQueryable<ClientDatabaseNumberDto>> Handle(GetClientDatabaseNumbersQuery request, CancellationToken cancellationToken)
    {
        var item = (IQueryable<ClientDatabaseNumberDto>)DataDbContext.ClientDatabaseNumbers
            .Where(r => r.DeletedAtUtc == null)
            .AsNoTracking();
        return Task.FromResult(item);
    }
}