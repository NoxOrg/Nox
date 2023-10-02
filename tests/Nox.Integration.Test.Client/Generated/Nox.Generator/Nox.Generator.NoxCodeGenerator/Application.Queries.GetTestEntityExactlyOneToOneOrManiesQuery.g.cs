// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using TestWebApp.Application.Dto;
using TestWebApp.Infrastructure.Persistence;

namespace TestWebApp.Application.Queries;

public record GetTestEntityExactlyOneToOneOrManiesQuery() : IRequest<IQueryable<TestEntityExactlyOneToOneOrManyDto>>;

internal partial class GetTestEntityExactlyOneToOneOrManiesQueryHandler: GetTestEntityExactlyOneToOneOrManiesQueryHandlerBase
{
    public GetTestEntityExactlyOneToOneOrManiesQueryHandler(DtoDbContext dataDbContext): base(dataDbContext)
    {
    
    }
}

internal abstract class GetTestEntityExactlyOneToOneOrManiesQueryHandlerBase : QueryBase<IQueryable<TestEntityExactlyOneToOneOrManyDto>>, IRequestHandler<GetTestEntityExactlyOneToOneOrManiesQuery, IQueryable<TestEntityExactlyOneToOneOrManyDto>>
{
    public  GetTestEntityExactlyOneToOneOrManiesQueryHandlerBase(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public virtual Task<IQueryable<TestEntityExactlyOneToOneOrManyDto>> Handle(GetTestEntityExactlyOneToOneOrManiesQuery request, CancellationToken cancellationToken)
    {
        var item = (IQueryable<TestEntityExactlyOneToOneOrManyDto>)DataDbContext.TestEntityExactlyOneToOneOrManies
            .Where(r => r.DeletedAtUtc == null)
            .AsNoTracking();
       return Task.FromResult(OnResponse(item));
    }
}