// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using TestWebApp.Application.Dto;
using TestWebApp.Infrastructure.Persistence;

namespace TestWebApp.Application.Queries;

public partial record GetEntityUniqueConstraintsWithForeignKeyByIdQuery(System.Guid keyId) : IRequest <IQueryable<EntityUniqueConstraintsWithForeignKeyDto>>;

internal partial class GetEntityUniqueConstraintsWithForeignKeyByIdQueryHandler:GetEntityUniqueConstraintsWithForeignKeyByIdQueryHandlerBase
{
    public  GetEntityUniqueConstraintsWithForeignKeyByIdQueryHandler(DtoDbContext dataDbContext): base(dataDbContext)
    {
    
    }
}

internal abstract class GetEntityUniqueConstraintsWithForeignKeyByIdQueryHandlerBase:  QueryBase<IQueryable<EntityUniqueConstraintsWithForeignKeyDto>>, IRequestHandler<GetEntityUniqueConstraintsWithForeignKeyByIdQuery, IQueryable<EntityUniqueConstraintsWithForeignKeyDto>>
{
    public  GetEntityUniqueConstraintsWithForeignKeyByIdQueryHandlerBase(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public virtual Task<IQueryable<EntityUniqueConstraintsWithForeignKeyDto>> Handle(GetEntityUniqueConstraintsWithForeignKeyByIdQuery request, CancellationToken cancellationToken)
    {    
        var query = DataDbContext.EntityUniqueConstraintsWithForeignKeys
            .AsNoTracking()
            .Where(r =>
                r.Id.Equals(request.keyId));
        return Task.FromResult(OnResponse(query));
    }
}