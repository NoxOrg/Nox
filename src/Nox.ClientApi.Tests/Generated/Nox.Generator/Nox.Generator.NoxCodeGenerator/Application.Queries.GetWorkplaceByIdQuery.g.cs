// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using ClientApi.Application.Dto;
using ClientApi.Infrastructure.Persistence;

namespace ClientApi.Application.Queries;

public record GetWorkplaceByIdQuery(System.UInt32 keyId) : IRequest <IQueryable<WorkplaceDto>>;

public partial class GetWorkplaceByIdQueryHandler:GetWorkplaceByIdQueryHandlerBase
{
    public  GetWorkplaceByIdQueryHandler(DtoDbContext dataDbContext): base(dataDbContext)
    {
    
    }
}

public partial class GetWorkplaceByIdQueryHandlerBase:  QueryBase<IQueryable<WorkplaceDto>>, IRequestHandler<GetWorkplaceByIdQuery, IQueryable<WorkplaceDto>>
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
                r.Id.Equals(request.keyId) &&
                true
            );
        return Task.FromResult(OnResponse(query));
    }
}