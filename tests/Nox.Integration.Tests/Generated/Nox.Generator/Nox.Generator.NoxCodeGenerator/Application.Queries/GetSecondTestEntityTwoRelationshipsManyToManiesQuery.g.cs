// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using TestWebApp.Application.Dto;
using TestWebApp.Infrastructure.Persistence;

namespace TestWebApp.Application.Queries;

public partial record GetSecondTestEntityTwoRelationshipsManyToManiesQuery() : IRequest<IQueryable<SecondTestEntityTwoRelationshipsManyToManyDto>>;

internal partial class GetSecondTestEntityTwoRelationshipsManyToManiesQueryHandler: GetSecondTestEntityTwoRelationshipsManyToManiesQueryHandlerBase
{
    public GetSecondTestEntityTwoRelationshipsManyToManiesQueryHandler(DtoDbContext dataDbContext): base(dataDbContext)
    {
    
    }
}

internal abstract class GetSecondTestEntityTwoRelationshipsManyToManiesQueryHandlerBase : QueryBase<IQueryable<SecondTestEntityTwoRelationshipsManyToManyDto>>, IRequestHandler<GetSecondTestEntityTwoRelationshipsManyToManiesQuery, IQueryable<SecondTestEntityTwoRelationshipsManyToManyDto>>
{
    public  GetSecondTestEntityTwoRelationshipsManyToManiesQueryHandlerBase(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public virtual Task<IQueryable<SecondTestEntityTwoRelationshipsManyToManyDto>> Handle(GetSecondTestEntityTwoRelationshipsManyToManiesQuery request, CancellationToken cancellationToken)
    {
        var item = (IQueryable<SecondTestEntityTwoRelationshipsManyToManyDto>)DataDbContext.SecondTestEntityTwoRelationshipsManyToManies
            .AsNoTracking();
       return Task.FromResult(OnResponse(item));
    }
}