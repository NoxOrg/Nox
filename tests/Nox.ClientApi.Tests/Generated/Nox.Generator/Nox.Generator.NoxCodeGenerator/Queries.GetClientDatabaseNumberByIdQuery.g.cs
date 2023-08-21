// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using ClientApi.Application.Dto;
using ClientApi.Presentation.Api.OData;

namespace ClientApi.Application.Queries;

public record GetClientDatabaseNumberByIdQuery(System.Int64 keyId) : IRequest<ClientDatabaseNumberDto?>;

public class GetClientDatabaseNumberByIdQueryHandler: IRequestHandler<GetClientDatabaseNumberByIdQuery, ClientDatabaseNumberDto?>
{
    public  GetClientDatabaseNumberByIdQueryHandler(ODataDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public ODataDbContext DataDbContext { get; }

    public Task<ClientDatabaseNumberDto?> Handle(GetClientDatabaseNumberByIdQuery request, CancellationToken cancellationToken)
    {    
        var item = DataDbContext.ClientDatabaseNumbers
            .AsNoTracking()
            .SingleOrDefault(r =>
                r.Id.Equals(request.keyId) &&
                r.DeletedAtUtc == null);
        return Task.FromResult(item);
    }
}