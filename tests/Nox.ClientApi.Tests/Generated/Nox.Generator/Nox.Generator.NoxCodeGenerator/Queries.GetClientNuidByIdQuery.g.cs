// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using ClientApi.Application.Dto;
using ClientApi.Presentation.Api.OData;

namespace ClientApi.Application.Queries;

public record GetClientNuidByIdQuery(System.UInt32 keyId) : IRequest<ClientNuidDto?>;

public class GetClientNuidByIdQueryHandler: IRequestHandler<GetClientNuidByIdQuery, ClientNuidDto?>
{
    public  GetClientNuidByIdQueryHandler(ODataDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public ODataDbContext DataDbContext { get; }

    public Task<ClientNuidDto?> Handle(GetClientNuidByIdQuery request, CancellationToken cancellationToken)
    {    
        var item = DataDbContext.ClientNuids
            .AsNoTracking()
            .SingleOrDefault(r =>
                r.Id.Equals(request.keyId) &&
                !(r.Deleted == true));
        return Task.FromResult(item);
    }
}