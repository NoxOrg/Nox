// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using ClientApi.Application.Dto;
using ClientApi.Presentation.Api.OData;

namespace ClientApi.Application.Queries;

public record GetClientDatabaseGuidByIdQuery(System.Int64 keyId) : IRequest<ClientDatabaseGuidDto?>;

public class GetClientDatabaseGuidByIdQueryHandler: IRequestHandler<GetClientDatabaseGuidByIdQuery, ClientDatabaseGuidDto?>
{
    public  GetClientDatabaseGuidByIdQueryHandler(ODataDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public ODataDbContext DataDbContext { get; }

    public Task<ClientDatabaseGuidDto?> Handle(GetClientDatabaseGuidByIdQuery request, CancellationToken cancellationToken)
    {    
        var item = DataDbContext.ClientDatabaseGuids
            .AsNoTracking()
            .SingleOrDefault(r =>
                r.Id.Equals(request.keyId) &&
                true
            );
        return Task.FromResult(item);
    }
}