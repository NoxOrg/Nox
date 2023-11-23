// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using TestWebApp.Application.Dto;
using TestWebApp.Infrastructure.Persistence;

namespace TestWebApp.Application.Queries;

public partial record GetEntityUniqueConstraintsWithForeignKeysQuery() : IRequest<IQueryable<EntityUniqueConstraintsWithForeignKeyDto>>;

internal partial class GetEntityUniqueConstraintsWithForeignKeysQueryHandler: GetEntityUniqueConstraintsWithForeignKeysQueryHandlerBase
{
    public GetEntityUniqueConstraintsWithForeignKeysQueryHandler(DtoDbContext dataDbContext): base(dataDbContext)
    {
    
    }
}

internal abstract class GetEntityUniqueConstraintsWithForeignKeysQueryHandlerBase : QueryBase<IQueryable<EntityUniqueConstraintsWithForeignKeyDto>>, IRequestHandler<GetEntityUniqueConstraintsWithForeignKeysQuery, IQueryable<EntityUniqueConstraintsWithForeignKeyDto>>
{
    public  GetEntityUniqueConstraintsWithForeignKeysQueryHandlerBase(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public virtual Task<IQueryable<EntityUniqueConstraintsWithForeignKeyDto>> Handle(GetEntityUniqueConstraintsWithForeignKeysQuery request, CancellationToken cancellationToken)
    {
        var item = (IQueryable<EntityUniqueConstraintsWithForeignKeyDto>)DataDbContext.EntityUniqueConstraintsWithForeignKeys
            .AsNoTracking();
       return Task.FromResult(OnResponse(item));
    }
}