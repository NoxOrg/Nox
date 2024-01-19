// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Queries;

using TestWebApp.Application.Dto;
using TestWebApp.Infrastructure.Persistence;

namespace TestWebApp.Application.Queries;

public partial record GetEntityUniqueConstraintsRelatedForeignKeysQuery() : IRequest<IQueryable<EntityUniqueConstraintsRelatedForeignKeyDto>>;

internal partial class GetEntityUniqueConstraintsRelatedForeignKeysQueryHandler: GetEntityUniqueConstraintsRelatedForeignKeysQueryHandlerBase
{
    public GetEntityUniqueConstraintsRelatedForeignKeysQueryHandler(DtoDbContext dataDbContext): base(dataDbContext)
    {
    
    }
}

internal abstract class GetEntityUniqueConstraintsRelatedForeignKeysQueryHandlerBase : QueryBase<IQueryable<EntityUniqueConstraintsRelatedForeignKeyDto>>, IRequestHandler<GetEntityUniqueConstraintsRelatedForeignKeysQuery, IQueryable<EntityUniqueConstraintsRelatedForeignKeyDto>>
{
    public  GetEntityUniqueConstraintsRelatedForeignKeysQueryHandlerBase(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public virtual Task<IQueryable<EntityUniqueConstraintsRelatedForeignKeyDto>> Handle(GetEntityUniqueConstraintsRelatedForeignKeysQuery request, CancellationToken cancellationToken)
    {
        var item = (IQueryable<EntityUniqueConstraintsRelatedForeignKeyDto>)DataDbContext.EntityUniqueConstraintsRelatedForeignKeys
            .AsNoTracking();
       return Task.FromResult(OnResponse(item));
    }
}