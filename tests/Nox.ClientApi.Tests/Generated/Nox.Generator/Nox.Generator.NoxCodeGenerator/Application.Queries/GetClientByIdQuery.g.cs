// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Queries;
using Nox.Application.Repositories;

using ClientApi.Application.Dto;
using ClientApi.Infrastructure.Persistence;

namespace ClientApi.Application.Queries;

public partial record GetClientByIdQuery(System.Guid keyId) : IRequest <IQueryable<ClientDto>>;

internal partial class GetClientByIdQueryHandler:GetClientByIdQueryHandlerBase
{
    public GetClientByIdQueryHandler(IReadOnlyRepository readOnlyRepository): base(readOnlyRepository){}
}

internal abstract class GetClientByIdQueryHandlerBase:  QueryBase<IQueryable<ClientDto>>, IRequestHandler<GetClientByIdQuery, IQueryable<ClientDto>>
{
    public  GetClientByIdQueryHandlerBase(IReadOnlyRepository readOnlyRepository)
    {
        ReadOnlyRepository = readOnlyRepository;
    }

    public IReadOnlyRepository ReadOnlyRepository { get; }

    public virtual Task<IQueryable<ClientDto>> Handle(GetClientByIdQuery request, CancellationToken cancellationToken)
    {    
        var query = ReadOnlyRepository.Query<ClientDto >()
            .Where(r =>
                r.Id.Equals(request.keyId));
        return Task.FromResult(OnResponse(query));
    }
}