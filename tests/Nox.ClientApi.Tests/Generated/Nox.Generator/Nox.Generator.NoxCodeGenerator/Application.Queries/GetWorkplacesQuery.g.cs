// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Queries;

using ClientApi.Application.Dto;
using ClientApi.Infrastructure.Persistence;

namespace ClientApi.Application.Queries;

public partial record GetWorkplacesQuery() : IRequest<IQueryable<WorkplaceDto>>;

internal partial class GetWorkplacesQueryHandler: GetWorkplacesQueryHandlerBase
{
    public GetWorkplacesQueryHandler(DtoDbContext dataDbContext): base(dataDbContext)
    {
    
    }
}

internal abstract class GetWorkplacesQueryHandlerBase : QueryBase<IQueryable<WorkplaceDto>>, IRequestHandler<GetWorkplacesQuery, IQueryable<WorkplaceDto>>
{
    public  GetWorkplacesQueryHandlerBase(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public virtual Task<IQueryable<WorkplaceDto>> Handle(GetWorkplacesQuery request, CancellationToken cancellationToken)
    {
        var item = (IQueryable<WorkplaceDto>)DataDbContext.Workplaces
            .AsNoTracking();
       return Task.FromResult(OnResponse(item));
    }
}