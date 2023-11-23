// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using TestWebApp.Application.Dto;
using TestWebApp.Infrastructure.Persistence;

namespace TestWebApp.Application.Queries;

public partial record GetTestEntityZeroOrManiesQuery() : IRequest<IQueryable<TestEntityZeroOrManyDto>>;

internal partial class GetTestEntityZeroOrManiesQueryHandler: GetTestEntityZeroOrManiesQueryHandlerBase
{
    public GetTestEntityZeroOrManiesQueryHandler(DtoDbContext dataDbContext): base(dataDbContext)
    {
    
    }
}

internal abstract class GetTestEntityZeroOrManiesQueryHandlerBase : QueryBase<IQueryable<TestEntityZeroOrManyDto>>, IRequestHandler<GetTestEntityZeroOrManiesQuery, IQueryable<TestEntityZeroOrManyDto>>
{
    public  GetTestEntityZeroOrManiesQueryHandlerBase(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public virtual Task<IQueryable<TestEntityZeroOrManyDto>> Handle(GetTestEntityZeroOrManiesQuery request, CancellationToken cancellationToken)
    {
        var item = (IQueryable<TestEntityZeroOrManyDto>)DataDbContext.TestEntityZeroOrManies
            .AsNoTracking();
       return Task.FromResult(OnResponse(item));
    }
}