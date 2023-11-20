// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using TestWebApp.Application.Dto;
using TestWebApp.Infrastructure.Persistence;

namespace TestWebApp.Application.Queries;

public partial record GetTestEntityZeroOrManyToOneOrManiesQuery() : IRequest<IQueryable<TestEntityZeroOrManyToOneOrManyDto>>;

internal partial class GetTestEntityZeroOrManyToOneOrManiesQueryHandler: GetTestEntityZeroOrManyToOneOrManiesQueryHandlerBase
{
    public GetTestEntityZeroOrManyToOneOrManiesQueryHandler(DtoDbContext dataDbContext): base(dataDbContext)
    {
    
    }
}

internal abstract class GetTestEntityZeroOrManyToOneOrManiesQueryHandlerBase : QueryBase<IQueryable<TestEntityZeroOrManyToOneOrManyDto>>, IRequestHandler<GetTestEntityZeroOrManyToOneOrManiesQuery, IQueryable<TestEntityZeroOrManyToOneOrManyDto>>
{
    public  GetTestEntityZeroOrManyToOneOrManiesQueryHandlerBase(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public virtual Task<IQueryable<TestEntityZeroOrManyToOneOrManyDto>> Handle(GetTestEntityZeroOrManyToOneOrManiesQuery request, CancellationToken cancellationToken)
    {
        var item = (IQueryable<TestEntityZeroOrManyToOneOrManyDto>)DataDbContext.TestEntityZeroOrManyToOneOrManies
            .AsNoTracking();
       return Task.FromResult(OnResponse(item));
    }
}