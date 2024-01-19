// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Queries;
using Nox.Application.Repositories;
using ClientApi.Application.Dto;
using ClientApi.Infrastructure.Persistence;

namespace ClientApi.Application.Queries;

public partial record GetClientsQuery() : IRequest<IQueryable<ClientDto>>;

internal partial class GetClientsQueryHandler: GetClientsQueryHandlerBase
{
    public GetClientsQueryHandler(IReadOnlyRepository readOnlyRepository): base(readOnlyRepository){}
}

internal abstract class GetClientsQueryHandlerBase : QueryBase<IQueryable<ClientDto>>, IRequestHandler<GetClientsQuery, IQueryable<ClientDto>>
{
    public  GetClientsQueryHandlerBase(IReadOnlyRepository readOnlyRepository)
    {
        ReadOnlyRepository = readOnlyRepository;
    }

    public IReadOnlyRepository ReadOnlyRepository { get; }

    public virtual Task<IQueryable<ClientDto>> Handle(GetClientsQuery request, CancellationToken cancellationToken)
    {
        var query = ReadOnlyRepository.Query<ClientDto>();
       return Task.FromResult(OnResponse(query));
    }
}