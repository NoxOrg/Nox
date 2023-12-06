// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using ClientApi.Application.Dto;
using ClientApi.Infrastructure.Persistence;

namespace ClientApi.Application.Queries;

public partial record GetWorkplaceByIdQuery(System.Int64 keyId) : IRequest <IQueryable<WorkplaceDto>>;

internal partial class GetWorkplaceByIdQueryHandler:GetWorkplaceByIdQueryHandlerBase
{
    public  GetWorkplaceByIdQueryHandler(DtoDbContext dataDbContext): base(dataDbContext)
    {
    
    }
}

internal abstract class GetWorkplaceByIdQueryHandlerBase:  QueryBase<IQueryable<WorkplaceDto>>, IRequestHandler<GetWorkplaceByIdQuery, IQueryable<WorkplaceDto>>
{
    public  GetWorkplaceByIdQueryHandlerBase(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public virtual Task<IQueryable<WorkplaceDto>> Handle(GetWorkplaceByIdQuery request, CancellationToken cancellationToken)
    {    
        var query = DataDbContext.Workplaces
            .AsNoTracking()
            .Where(r =>
                r.Id.Equals(request.keyId));
        return Task.FromResult(OnResponse(query));
    }
}