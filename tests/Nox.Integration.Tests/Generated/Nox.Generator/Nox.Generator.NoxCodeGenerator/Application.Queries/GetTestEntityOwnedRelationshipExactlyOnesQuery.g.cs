// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Queries;

using TestWebApp.Application.Dto;
using TestWebApp.Infrastructure.Persistence;

namespace TestWebApp.Application.Queries;

public partial record GetTestEntityOwnedRelationshipExactlyOnesQuery() : IRequest<IQueryable<TestEntityOwnedRelationshipExactlyOneDto>>;

internal partial class GetTestEntityOwnedRelationshipExactlyOnesQueryHandler: GetTestEntityOwnedRelationshipExactlyOnesQueryHandlerBase
{
    public GetTestEntityOwnedRelationshipExactlyOnesQueryHandler(DtoDbContext dataDbContext): base(dataDbContext)
    {
    
    }
}

internal abstract class GetTestEntityOwnedRelationshipExactlyOnesQueryHandlerBase : QueryBase<IQueryable<TestEntityOwnedRelationshipExactlyOneDto>>, IRequestHandler<GetTestEntityOwnedRelationshipExactlyOnesQuery, IQueryable<TestEntityOwnedRelationshipExactlyOneDto>>
{
    public  GetTestEntityOwnedRelationshipExactlyOnesQueryHandlerBase(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public virtual Task<IQueryable<TestEntityOwnedRelationshipExactlyOneDto>> Handle(GetTestEntityOwnedRelationshipExactlyOnesQuery request, CancellationToken cancellationToken)
    {
        var item = (IQueryable<TestEntityOwnedRelationshipExactlyOneDto>)DataDbContext.TestEntityOwnedRelationshipExactlyOnes
            .AsNoTracking()
            .Include(e => e.SecEntityOwnedRelExactlyOne);
       return Task.FromResult(OnResponse(item));
    }
}