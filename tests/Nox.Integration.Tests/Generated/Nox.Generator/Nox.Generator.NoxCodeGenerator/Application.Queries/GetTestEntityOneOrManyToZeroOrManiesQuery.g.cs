// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using TestWebApp.Application.Dto;
using TestWebApp.Infrastructure.Persistence;

namespace TestWebApp.Application.Queries;

public partial record GetTestEntityOneOrManyToZeroOrManiesQuery() : IRequest<IQueryable<TestEntityOneOrManyToZeroOrManyDto>>;

internal partial class GetTestEntityOneOrManyToZeroOrManiesQueryHandler: GetTestEntityOneOrManyToZeroOrManiesQueryHandlerBase
{
    public GetTestEntityOneOrManyToZeroOrManiesQueryHandler(DtoDbContext dataDbContext): base(dataDbContext)
    {
    
    }
}

internal abstract class GetTestEntityOneOrManyToZeroOrManiesQueryHandlerBase : QueryBase<IQueryable<TestEntityOneOrManyToZeroOrManyDto>>, IRequestHandler<GetTestEntityOneOrManyToZeroOrManiesQuery, IQueryable<TestEntityOneOrManyToZeroOrManyDto>>
{
    public  GetTestEntityOneOrManyToZeroOrManiesQueryHandlerBase(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public virtual Task<IQueryable<TestEntityOneOrManyToZeroOrManyDto>> Handle(GetTestEntityOneOrManyToZeroOrManiesQuery request, CancellationToken cancellationToken)
    {
        var item = (IQueryable<TestEntityOneOrManyToZeroOrManyDto>)DataDbContext.TestEntityOneOrManyToZeroOrManies
            .AsNoTracking();
       return Task.FromResult(OnResponse(item));
    }
}