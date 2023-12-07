// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using ClientApi.Application.Dto;
using ClientApi.Infrastructure.Persistence;

namespace ClientApi.Application.Queries;

public partial record GetReferenceNumberEntitiesQuery() : IRequest<IQueryable<ReferenceNumberEntityDto>>;

internal partial class GetReferenceNumberEntitiesQueryHandler: GetReferenceNumberEntitiesQueryHandlerBase
{
    public GetReferenceNumberEntitiesQueryHandler(DtoDbContext dataDbContext): base(dataDbContext)
    {
    
    }
}

internal abstract class GetReferenceNumberEntitiesQueryHandlerBase : QueryBase<IQueryable<ReferenceNumberEntityDto>>, IRequestHandler<GetReferenceNumberEntitiesQuery, IQueryable<ReferenceNumberEntityDto>>
{
    public  GetReferenceNumberEntitiesQueryHandlerBase(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public virtual Task<IQueryable<ReferenceNumberEntityDto>> Handle(GetReferenceNumberEntitiesQuery request, CancellationToken cancellationToken)
    {
        var item = (IQueryable<ReferenceNumberEntityDto>)DataDbContext.ReferenceNumberEntities
            .AsNoTracking();
       return Task.FromResult(OnResponse(item));
    }
}