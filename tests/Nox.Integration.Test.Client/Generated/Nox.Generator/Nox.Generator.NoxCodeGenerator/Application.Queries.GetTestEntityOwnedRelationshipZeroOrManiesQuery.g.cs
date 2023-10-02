// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using TestWebApp.Application.Dto;
using TestWebApp.Infrastructure.Persistence;

namespace TestWebApp.Application.Queries;

public record GetTestEntityOwnedRelationshipZeroOrManiesQuery() : IRequest<IQueryable<TestEntityOwnedRelationshipZeroOrManyDto>>;

internal partial class GetTestEntityOwnedRelationshipZeroOrManiesQueryHandler: GetTestEntityOwnedRelationshipZeroOrManiesQueryHandlerBase
{
    public GetTestEntityOwnedRelationshipZeroOrManiesQueryHandler(DtoDbContext dataDbContext): base(dataDbContext)
    {
    
    }
}

internal abstract class GetTestEntityOwnedRelationshipZeroOrManiesQueryHandlerBase : QueryBase<IQueryable<TestEntityOwnedRelationshipZeroOrManyDto>>, IRequestHandler<GetTestEntityOwnedRelationshipZeroOrManiesQuery, IQueryable<TestEntityOwnedRelationshipZeroOrManyDto>>
{
    public  GetTestEntityOwnedRelationshipZeroOrManiesQueryHandlerBase(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public virtual Task<IQueryable<TestEntityOwnedRelationshipZeroOrManyDto>> Handle(GetTestEntityOwnedRelationshipZeroOrManiesQuery request, CancellationToken cancellationToken)
    {
        var item = (IQueryable<TestEntityOwnedRelationshipZeroOrManyDto>)DataDbContext.TestEntityOwnedRelationshipZeroOrManies
            .Where(r => r.DeletedAtUtc == null)
            .AsNoTracking();
       return Task.FromResult(OnResponse(item));
    }
}