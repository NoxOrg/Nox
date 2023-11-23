// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using TestWebApp.Application.Dto;
using TestWebApp.Infrastructure.Persistence;

namespace TestWebApp.Application.Queries;

public partial record GetTestEntityOneOrManiesQuery() : IRequest<IQueryable<TestEntityOneOrManyDto>>;

internal partial class GetTestEntityOneOrManiesQueryHandler: GetTestEntityOneOrManiesQueryHandlerBase
{
    public GetTestEntityOneOrManiesQueryHandler(DtoDbContext dataDbContext): base(dataDbContext)
    {
    
    }
}

internal abstract class GetTestEntityOneOrManiesQueryHandlerBase : QueryBase<IQueryable<TestEntityOneOrManyDto>>, IRequestHandler<GetTestEntityOneOrManiesQuery, IQueryable<TestEntityOneOrManyDto>>
{
    public  GetTestEntityOneOrManiesQueryHandlerBase(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public virtual Task<IQueryable<TestEntityOneOrManyDto>> Handle(GetTestEntityOneOrManiesQuery request, CancellationToken cancellationToken)
    {
        var item = (IQueryable<TestEntityOneOrManyDto>)DataDbContext.TestEntityOneOrManies
            .AsNoTracking();
       return Task.FromResult(OnResponse(item));
    }
}