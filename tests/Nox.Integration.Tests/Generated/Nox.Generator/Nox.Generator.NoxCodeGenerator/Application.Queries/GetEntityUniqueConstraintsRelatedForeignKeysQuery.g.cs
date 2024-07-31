// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Queries;
using Nox.Application.Repositories;
using TestWebApp.Application.Dto;

namespace TestWebApp.Application.Queries;

public partial record GetEntityUniqueConstraintsRelatedForeignKeysQuery() : IRequest<IQueryable<EntityUniqueConstraintsRelatedForeignKeyDto>>;

internal partial class GetEntityUniqueConstraintsRelatedForeignKeysQueryHandler: GetEntityUniqueConstraintsRelatedForeignKeysQueryHandlerBase
{
    public GetEntityUniqueConstraintsRelatedForeignKeysQueryHandler(IReadOnlyRepository readOnlyRepository): base(readOnlyRepository){}
}

internal abstract class GetEntityUniqueConstraintsRelatedForeignKeysQueryHandlerBase : QueryBase<IQueryable<EntityUniqueConstraintsRelatedForeignKeyDto>>, IRequestHandler<GetEntityUniqueConstraintsRelatedForeignKeysQuery, IQueryable<EntityUniqueConstraintsRelatedForeignKeyDto>>
{
    public  GetEntityUniqueConstraintsRelatedForeignKeysQueryHandlerBase(IReadOnlyRepository readOnlyRepository)
    {
        ReadOnlyRepository = readOnlyRepository;
    }

    public IReadOnlyRepository ReadOnlyRepository { get; }

    public virtual Task<IQueryable<EntityUniqueConstraintsRelatedForeignKeyDto>> Handle(GetEntityUniqueConstraintsRelatedForeignKeysQuery request, CancellationToken cancellationToken)
    {
        var query = ReadOnlyRepository.Query<EntityUniqueConstraintsRelatedForeignKeyDto>();
       return Task.FromResult(OnResponse(query));
    }
}