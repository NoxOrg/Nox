// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using ClientApi.Application.Dto;
using ClientApi.Infrastructure.Persistence;

namespace ClientApi.Application.Queries;

public record GetClientNuidByIdQuery(System.UInt32 keyId) : IRequest <ClientNuidDto?>;

public partial class GetClientNuidByIdQueryHandler:  QueryBase<ClientNuidDto?>, IRequestHandler<GetClientNuidByIdQuery, ClientNuidDto?>
{
    public  GetClientNuidByIdQueryHandler(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public Task<ClientNuidDto?> Handle(GetClientNuidByIdQuery request, CancellationToken cancellationToken)
    {    
        var item = DataDbContext.ClientNuids
            .AsNoTracking()
            .SingleOrDefault(r =>
                r.Id.Equals(request.keyId) &&
                r.DeletedAtUtc == null);
        return Task.FromResult(OnResponse(item));
    }
}