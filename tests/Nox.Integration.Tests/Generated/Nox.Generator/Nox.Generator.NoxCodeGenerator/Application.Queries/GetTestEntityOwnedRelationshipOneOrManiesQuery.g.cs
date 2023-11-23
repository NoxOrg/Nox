// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using TestWebApp.Application.Dto;
using TestWebApp.Infrastructure.Persistence;

namespace TestWebApp.Application.Queries;

public partial record GetTestEntityOwnedRelationshipOneOrManiesQuery() : IRequest<IQueryable<TestEntityOwnedRelationshipOneOrManyDto>>;

internal partial class GetTestEntityOwnedRelationshipOneOrManiesQueryHandler: GetTestEntityOwnedRelationshipOneOrManiesQueryHandlerBase
{
    public GetTestEntityOwnedRelationshipOneOrManiesQueryHandler(DtoDbContext dataDbContext): base(dataDbContext)
    {
    
    }
}

internal abstract class GetTestEntityOwnedRelationshipOneOrManiesQueryHandlerBase : QueryBase<IQueryable<TestEntityOwnedRelationshipOneOrManyDto>>, IRequestHandler<GetTestEntityOwnedRelationshipOneOrManiesQuery, IQueryable<TestEntityOwnedRelationshipOneOrManyDto>>
{
    public  GetTestEntityOwnedRelationshipOneOrManiesQueryHandlerBase(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public virtual Task<IQueryable<TestEntityOwnedRelationshipOneOrManyDto>> Handle(GetTestEntityOwnedRelationshipOneOrManiesQuery request, CancellationToken cancellationToken)
    {
        var item = (IQueryable<TestEntityOwnedRelationshipOneOrManyDto>)DataDbContext.TestEntityOwnedRelationshipOneOrManies
            .AsNoTracking()
            .Include(e => e.SecondTestEntityOwnedRelationshipOneOrManies);
       return Task.FromResult(OnResponse(item));
    }
}