// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using Cryptocash.Application.Dto;
using Cryptocash.Infrastructure.Persistence;

namespace Cryptocash.Application.Queries;

public partial record Get LandLordsQuery() : IRequest<IQueryable<LandLordDto>>;

internal partial class GetLandLordsQueryHandler: GetLandLordsQueryHandlerBase
{
    public GetLandLordsQueryHandler(DtoDbContext dataDbContext): base(dataDbContext)
    {
    
    }
}

internal abstract class GetLandLordsQueryHandlerBase : QueryBase<IQueryable<LandLordDto>>, IRequestHandler<GetLandLordsQuery, IQueryable<LandLordDto>>
{
    public  GetLandLordsQueryHandlerBase(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public virtual Task<IQueryable<LandLordDto>> Handle(GetLandLordsQuery request, CancellationToken cancellationToken)
    {
        var item = (IQueryable<LandLordDto>)DataDbContext.LandLords
            .AsNoTracking();
       return Task.FromResult(OnResponse(item));
    }
}