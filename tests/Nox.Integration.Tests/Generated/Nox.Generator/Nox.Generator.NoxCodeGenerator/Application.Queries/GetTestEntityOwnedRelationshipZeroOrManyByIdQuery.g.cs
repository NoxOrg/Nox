// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using TestWebApp.Application.Dto;
using TestWebApp.Infrastructure.Persistence;

namespace TestWebApp.Application.Queries;

public partial record GetTestEntityOwnedRelationshipZeroOrManyByIdQuery(System.String keyId) : IRequest <IQueryable<TestEntityOwnedRelationshipZeroOrManyDto>>;

internal partial class GetTestEntityOwnedRelationshipZeroOrManyByIdQueryHandler:GetTestEntityOwnedRelationshipZeroOrManyByIdQueryHandlerBase
{
    public  GetTestEntityOwnedRelationshipZeroOrManyByIdQueryHandler(DtoDbContext dataDbContext): base(dataDbContext)
    {
    
    }
}

internal abstract class GetTestEntityOwnedRelationshipZeroOrManyByIdQueryHandlerBase:  QueryBase<IQueryable<TestEntityOwnedRelationshipZeroOrManyDto>>, IRequestHandler<GetTestEntityOwnedRelationshipZeroOrManyByIdQuery, IQueryable<TestEntityOwnedRelationshipZeroOrManyDto>>
{
    public  GetTestEntityOwnedRelationshipZeroOrManyByIdQueryHandlerBase(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public virtual Task<IQueryable<TestEntityOwnedRelationshipZeroOrManyDto>> Handle(GetTestEntityOwnedRelationshipZeroOrManyByIdQuery request, CancellationToken cancellationToken)
    {    
        var query = DataDbContext.TestEntityOwnedRelationshipZeroOrManies
            .AsNoTracking()
            .Include(e => e.SecEntityOwnedRelZeroOrManies)
            .Where(r =>
                r.Id.Equals(request.keyId));
        return Task.FromResult(OnResponse(query));
    }
}