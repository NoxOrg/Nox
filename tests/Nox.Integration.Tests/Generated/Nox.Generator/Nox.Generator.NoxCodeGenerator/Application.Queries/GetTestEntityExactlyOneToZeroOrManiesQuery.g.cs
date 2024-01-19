// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Queries;

using TestWebApp.Application.Dto;
using TestWebApp.Infrastructure.Persistence;

namespace TestWebApp.Application.Queries;

public partial record GetTestEntityExactlyOneToZeroOrManiesQuery() : IRequest<IQueryable<TestEntityExactlyOneToZeroOrManyDto>>;

internal partial class GetTestEntityExactlyOneToZeroOrManiesQueryHandler: GetTestEntityExactlyOneToZeroOrManiesQueryHandlerBase
{
    public GetTestEntityExactlyOneToZeroOrManiesQueryHandler(DtoDbContext dataDbContext): base(dataDbContext)
    {
    
    }
}

internal abstract class GetTestEntityExactlyOneToZeroOrManiesQueryHandlerBase : QueryBase<IQueryable<TestEntityExactlyOneToZeroOrManyDto>>, IRequestHandler<GetTestEntityExactlyOneToZeroOrManiesQuery, IQueryable<TestEntityExactlyOneToZeroOrManyDto>>
{
    public  GetTestEntityExactlyOneToZeroOrManiesQueryHandlerBase(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public virtual Task<IQueryable<TestEntityExactlyOneToZeroOrManyDto>> Handle(GetTestEntityExactlyOneToZeroOrManiesQuery request, CancellationToken cancellationToken)
    {
        var item = (IQueryable<TestEntityExactlyOneToZeroOrManyDto>)DataDbContext.TestEntityExactlyOneToZeroOrManies
            .AsNoTracking();
       return Task.FromResult(OnResponse(item));
    }
}