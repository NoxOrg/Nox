// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using ClientApi.Application.Dto;
using ClientApi.Infrastructure.Persistence;

namespace ClientApi.Application.Queries;

public record GetClientDatabaseNumberByIdQuery(System.Int64 keyId) : IRequest <ClientDatabaseNumberDto?>;

public partial class GetClientDatabaseNumberByIdQueryHandler:  QueryBase<ClientDatabaseNumberDto?>, IRequestHandler<GetClientDatabaseNumberByIdQuery, ClientDatabaseNumberDto?>
{
    public  GetClientDatabaseNumberByIdQueryHandler(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public Task<ClientDatabaseNumberDto?> Handle(GetClientDatabaseNumberByIdQuery request, CancellationToken cancellationToken)
    {    
        var item = DataDbContext.ClientDatabaseNumbers
            .AsNoTracking()
            .SingleOrDefault(r =>
                r.Id.Equals(request.keyId) &&
                r.DeletedAtUtc == null);
        return Task.FromResult(OnResponse(item));
    }
}