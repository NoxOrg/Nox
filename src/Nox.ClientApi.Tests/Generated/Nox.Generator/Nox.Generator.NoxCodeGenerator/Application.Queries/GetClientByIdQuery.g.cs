// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using ClientApi.Application.Dto;
using ClientApi.Infrastructure.Persistence;

namespace ClientApi.Application.Queries;

public partial record GetClientByIdQuery(System.Guid keyId) : IRequest <IQueryable<ClientDto>>;

internal partial class GetClientByIdQueryHandler:GetClientByIdQueryHandlerBase
{
    public  GetClientByIdQueryHandler(DtoDbContext dataDbContext): base(dataDbContext)
    {
    
    }
}

internal abstract class GetClientByIdQueryHandlerBase:  QueryBase<IQueryable<ClientDto>>, IRequestHandler<GetClientByIdQuery, IQueryable<ClientDto>>
{
    public  GetClientByIdQueryHandlerBase(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public virtual Task<IQueryable<ClientDto>> Handle(GetClientByIdQuery request, CancellationToken cancellationToken)
    {    
        var query = DataDbContext.Clients
            .AsNoTracking()
            .Where(r =>
                r.Id.Equals(request.keyId));
        return Task.FromResult(OnResponse(query));
    }
}