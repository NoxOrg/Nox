// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using ClientApi.Application.Dto;
using ClientApi.Infrastructure.Persistence;

namespace ClientApi.Application.Queries;

public record GetClientDatabaseGuidByIdQuery(System.Guid keyId) : IRequest<ClientDatabaseGuidDto?>;

public class GetClientDatabaseGuidByIdQueryHandler: IRequestHandler<GetClientDatabaseGuidByIdQuery, ClientDatabaseGuidDto?>
{
    public  GetClientDatabaseGuidByIdQueryHandler(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

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