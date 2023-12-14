// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using ClientApi.Application.Dto;
using ClientApi.Infrastructure.Persistence;

namespace ClientApi.Application.Queries;

public partial record GetClientsQuery() : IRequest<IQueryable<ClientDto>>;

internal partial class GetClientsQueryHandler: GetClientsQueryHandlerBase
{
    public GetClientsQueryHandler(DtoDbContext dataDbContext): base(dataDbContext)
    {
    
    }
}

internal abstract class GetClientsQueryHandlerBase : QueryBase<IQueryable<ClientDto>>, IRequestHandler<GetClientsQuery, IQueryable<ClientDto>>
{
    public  GetClientsQueryHandlerBase(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public virtual Task<IQueryable<ClientDto>> Handle(GetClientsQuery request, CancellationToken cancellationToken)
    {
        var item = (IQueryable<ClientDto>)DataDbContext.Clients
            .AsNoTracking();
       return Task.FromResult(OnResponse(item));
    }
}