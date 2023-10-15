// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using TestWebApp.Application.Dto;
using TestWebApp.Infrastructure.Persistence;

namespace TestWebApp.Application.Queries;

public record GetTestEntityTwoRelationshipsManyToManiesQuery() : IRequest<IQueryable<TestEntityTwoRelationshipsManyToManyDto>>;

internal partial class GetTestEntityTwoRelationshipsManyToManiesQueryHandler: GetTestEntityTwoRelationshipsManyToManiesQueryHandlerBase
{
    public GetTestEntityTwoRelationshipsManyToManiesQueryHandler(DtoDbContext dataDbContext): base(dataDbContext)
    {
    
    }
}

internal abstract class GetTestEntityTwoRelationshipsManyToManiesQueryHandlerBase : QueryBase<IQueryable<TestEntityTwoRelationshipsManyToManyDto>>, IRequestHandler<GetTestEntityTwoRelationshipsManyToManiesQuery, IQueryable<TestEntityTwoRelationshipsManyToManyDto>>
{
    public  GetTestEntityTwoRelationshipsManyToManiesQueryHandlerBase(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public virtual Task<IQueryable<TestEntityTwoRelationshipsManyToManyDto>> Handle(GetTestEntityTwoRelationshipsManyToManiesQuery request, CancellationToken cancellationToken)
    {
        var item = (IQueryable<TestEntityTwoRelationshipsManyToManyDto>)DataDbContext.TestEntityTwoRelationshipsManyToManies
            .AsNoTracking();
       return Task.FromResult(OnResponse(item));
    }
}