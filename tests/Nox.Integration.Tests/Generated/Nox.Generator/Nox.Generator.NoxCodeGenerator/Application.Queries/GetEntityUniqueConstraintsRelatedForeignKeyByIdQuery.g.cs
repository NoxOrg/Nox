// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using TestWebApp.Application.Dto;
using TestWebApp.Infrastructure.Persistence;

namespace TestWebApp.Application.Queries;

public partial record GetEntityUniqueConstraintsRelatedForeignKeyByIdQuery(System.Int32 keyId) : IRequest <IQueryable<EntityUniqueConstraintsRelatedForeignKeyDto>>;

internal partial class GetEntityUniqueConstraintsRelatedForeignKeyByIdQueryHandler:GetEntityUniqueConstraintsRelatedForeignKeyByIdQueryHandlerBase
{
    public  GetEntityUniqueConstraintsRelatedForeignKeyByIdQueryHandler(DtoDbContext dataDbContext): base(dataDbContext)
    {
    
    }
}

internal abstract class GetEntityUniqueConstraintsRelatedForeignKeyByIdQueryHandlerBase:  QueryBase<IQueryable<EntityUniqueConstraintsRelatedForeignKeyDto>>, IRequestHandler<GetEntityUniqueConstraintsRelatedForeignKeyByIdQuery, IQueryable<EntityUniqueConstraintsRelatedForeignKeyDto>>
{
    public  GetEntityUniqueConstraintsRelatedForeignKeyByIdQueryHandlerBase(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public virtual Task<IQueryable<EntityUniqueConstraintsRelatedForeignKeyDto>> Handle(GetEntityUniqueConstraintsRelatedForeignKeyByIdQuery request, CancellationToken cancellationToken)
    {    
        var query = DataDbContext.EntityUniqueConstraintsRelatedForeignKeys
            .AsNoTracking()
            .Where(r =>
                r.Id.Equals(request.keyId));
        return Task.FromResult(OnResponse(query));
    }
}