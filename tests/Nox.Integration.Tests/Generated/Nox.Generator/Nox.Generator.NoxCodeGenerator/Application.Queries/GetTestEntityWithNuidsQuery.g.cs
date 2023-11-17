// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using TestWebApp.Application.Dto;
using TestWebApp.Infrastructure.Persistence;

namespace TestWebApp.Application.Queries;

public partial record GetTestEntityWithNuidsQuery() : IRequest<IQueryable<TestEntityWithNuidDto>>;

internal partial class GetTestEntityWithNuidsQueryHandler: GetTestEntityWithNuidsQueryHandlerBase
{
    public GetTestEntityWithNuidsQueryHandler(DtoDbContext dataDbContext): base(dataDbContext)
    {
    
    }
}

internal abstract class GetTestEntityWithNuidsQueryHandlerBase : QueryBase<IQueryable<TestEntityWithNuidDto>>, IRequestHandler<GetTestEntityWithNuidsQuery, IQueryable<TestEntityWithNuidDto>>
{
    public  GetTestEntityWithNuidsQueryHandlerBase(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public virtual Task<IQueryable<TestEntityWithNuidDto>> Handle(GetTestEntityWithNuidsQuery request, CancellationToken cancellationToken)
    {
        var item = (IQueryable<TestEntityWithNuidDto>)DataDbContext.TestEntityWithNuids
            .AsNoTracking();
       return Task.FromResult(OnResponse(item));
    }
}