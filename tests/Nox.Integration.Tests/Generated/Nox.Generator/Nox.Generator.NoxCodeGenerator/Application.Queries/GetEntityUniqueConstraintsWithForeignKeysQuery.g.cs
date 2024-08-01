// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Queries;
using Nox.Application.Repositories;
using TestWebApp.Application.Dto;

namespace TestWebApp.Application.Queries;

public partial record GetEntityUniqueConstraintsWithForeignKeysQuery() : IRequest<IQueryable<EntityUniqueConstraintsWithForeignKeyDto>>;

internal partial class GetEntityUniqueConstraintsWithForeignKeysQueryHandler: GetEntityUniqueConstraintsWithForeignKeysQueryHandlerBase
{
    public GetEntityUniqueConstraintsWithForeignKeysQueryHandler(IReadOnlyRepository readOnlyRepository): base(readOnlyRepository){}
}

internal abstract class GetEntityUniqueConstraintsWithForeignKeysQueryHandlerBase : QueryBase<IQueryable<EntityUniqueConstraintsWithForeignKeyDto>>, IRequestHandler<GetEntityUniqueConstraintsWithForeignKeysQuery, IQueryable<EntityUniqueConstraintsWithForeignKeyDto>>
{
    public  GetEntityUniqueConstraintsWithForeignKeysQueryHandlerBase(IReadOnlyRepository readOnlyRepository)
    {
        ReadOnlyRepository = readOnlyRepository;
    }

    public IReadOnlyRepository ReadOnlyRepository { get; }

    public virtual Task<IQueryable<EntityUniqueConstraintsWithForeignKeyDto>> Handle(GetEntityUniqueConstraintsWithForeignKeysQuery request, CancellationToken cancellationToken)
    {
        var query = ReadOnlyRepository.Query<EntityUniqueConstraintsWithForeignKeyDto>();
       return Task.FromResult(OnResponse(query));
    }
}