// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Queries;

using TestWebApp.Application.Dto;
using TestWebApp.Infrastructure.Persistence;

namespace TestWebApp.Application.Queries;

public partial record GetTestEntityForAutoNumberUsagesQuery() : IRequest<IQueryable<TestEntityForAutoNumberUsagesDto>>;

internal partial class GetTestEntityForAutoNumberUsagesQueryHandler: GetTestEntityForAutoNumberUsagesQueryHandlerBase
{
    public GetTestEntityForAutoNumberUsagesQueryHandler(DtoDbContext dataDbContext): base(dataDbContext)
    {
    
    }
}

internal abstract class GetTestEntityForAutoNumberUsagesQueryHandlerBase : QueryBase<IQueryable<TestEntityForAutoNumberUsagesDto>>, IRequestHandler<GetTestEntityForAutoNumberUsagesQuery, IQueryable<TestEntityForAutoNumberUsagesDto>>
{
    public  GetTestEntityForAutoNumberUsagesQueryHandlerBase(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public virtual Task<IQueryable<TestEntityForAutoNumberUsagesDto>> Handle(GetTestEntityForAutoNumberUsagesQuery request, CancellationToken cancellationToken)
    {
        var item = (IQueryable<TestEntityForAutoNumberUsagesDto>)DataDbContext.TestEntityForAutoNumberUsages
            .AsNoTracking();
       return Task.FromResult(OnResponse(item));
    }
}