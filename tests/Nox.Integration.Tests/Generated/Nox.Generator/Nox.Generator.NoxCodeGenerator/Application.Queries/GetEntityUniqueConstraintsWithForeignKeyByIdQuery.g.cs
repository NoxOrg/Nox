// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Queries;
using Nox.Application.Repositories;

using TestWebApp.Application.Dto;

namespace TestWebApp.Application.Queries;

public partial record GetEntityUniqueConstraintsWithForeignKeyByIdQuery(System.Guid keyId) : IRequest <IQueryable<EntityUniqueConstraintsWithForeignKeyDto>>;

internal partial class GetEntityUniqueConstraintsWithForeignKeyByIdQueryHandler:GetEntityUniqueConstraintsWithForeignKeyByIdQueryHandlerBase
{
    public GetEntityUniqueConstraintsWithForeignKeyByIdQueryHandler(IReadOnlyRepository readOnlyRepository): base(readOnlyRepository){}
}

internal abstract class GetEntityUniqueConstraintsWithForeignKeyByIdQueryHandlerBase:  QueryBase<IQueryable<EntityUniqueConstraintsWithForeignKeyDto>>, IRequestHandler<GetEntityUniqueConstraintsWithForeignKeyByIdQuery, IQueryable<EntityUniqueConstraintsWithForeignKeyDto>>
{
    public  GetEntityUniqueConstraintsWithForeignKeyByIdQueryHandlerBase(IReadOnlyRepository readOnlyRepository)
    {
        ReadOnlyRepository = readOnlyRepository;
    }

    public IReadOnlyRepository ReadOnlyRepository { get; }

    public virtual Task<IQueryable<EntityUniqueConstraintsWithForeignKeyDto>> Handle(GetEntityUniqueConstraintsWithForeignKeyByIdQuery request, CancellationToken cancellationToken)
    {    
        var query = ReadOnlyRepository.Query<EntityUniqueConstraintsWithForeignKeyDto>()
            .Where(r =>
                r.Id.Equals(request.keyId));
        return Task.FromResult(OnResponse(query));
    }
}