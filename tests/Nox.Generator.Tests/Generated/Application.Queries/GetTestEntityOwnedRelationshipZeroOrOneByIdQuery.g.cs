// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using TestWebApp.Application.Dto;
using TestWebApp.Infrastructure.Persistence;

namespace TestWebApp.Application.Queries;

public partial record GetTestEntityOwnedRelationshipZeroOrOneByIdQuery(System.String keyId) : IRequest <IQueryable<TestEntityOwnedRelationshipZeroOrOneDto>>;

internal partial class GetTestEntityOwnedRelationshipZeroOrOneByIdQueryHandler:GetTestEntityOwnedRelationshipZeroOrOneByIdQueryHandlerBase
{
    public  GetTestEntityOwnedRelationshipZeroOrOneByIdQueryHandler(DtoDbContext dataDbContext): base(dataDbContext)
    {
    
    }
}

internal abstract class GetTestEntityOwnedRelationshipZeroOrOneByIdQueryHandlerBase:  QueryBase<IQueryable<TestEntityOwnedRelationshipZeroOrOneDto>>, IRequestHandler<GetTestEntityOwnedRelationshipZeroOrOneByIdQuery, IQueryable<TestEntityOwnedRelationshipZeroOrOneDto>>
{
    public  GetTestEntityOwnedRelationshipZeroOrOneByIdQueryHandlerBase(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public virtual Task<IQueryable<TestEntityOwnedRelationshipZeroOrOneDto>> Handle(GetTestEntityOwnedRelationshipZeroOrOneByIdQuery request, CancellationToken cancellationToken)
    {    
        var query = DataDbContext.TestEntityOwnedRelationshipZeroOrOnes
            .AsNoTracking()
            .Include(e => e.SecondTestEntityOwnedRelationshipZeroOrOne)
            .Where(r =>
                r.Id.Equals(request.keyId));
        return Task.FromResult(OnResponse(query));
    }
}