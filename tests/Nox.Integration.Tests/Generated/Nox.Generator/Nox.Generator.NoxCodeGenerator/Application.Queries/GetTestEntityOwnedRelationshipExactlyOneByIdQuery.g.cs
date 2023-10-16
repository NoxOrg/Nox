// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using TestWebApp.Application.Dto;
using TestWebApp.Infrastructure.Persistence;

namespace TestWebApp.Application.Queries;

public record GetTestEntityOwnedRelationshipExactlyOneByIdQuery(System.String keyId) : IRequest <IQueryable<TestEntityOwnedRelationshipExactlyOneDto>>;

internal partial class GetTestEntityOwnedRelationshipExactlyOneByIdQueryHandler:GetTestEntityOwnedRelationshipExactlyOneByIdQueryHandlerBase
{
    public  GetTestEntityOwnedRelationshipExactlyOneByIdQueryHandler(DtoDbContext dataDbContext): base(dataDbContext)
    {
    
    }
}

internal abstract class GetTestEntityOwnedRelationshipExactlyOneByIdQueryHandlerBase:  QueryBase<IQueryable<TestEntityOwnedRelationshipExactlyOneDto>>, IRequestHandler<GetTestEntityOwnedRelationshipExactlyOneByIdQuery, IQueryable<TestEntityOwnedRelationshipExactlyOneDto>>
{
    public  GetTestEntityOwnedRelationshipExactlyOneByIdQueryHandlerBase(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public virtual Task<IQueryable<TestEntityOwnedRelationshipExactlyOneDto>> Handle(GetTestEntityOwnedRelationshipExactlyOneByIdQuery request, CancellationToken cancellationToken)
    {    
        var query = DataDbContext.TestEntityOwnedRelationshipExactlyOnes
            .AsNoTracking()
            .Where(r =>
                r.Id.Equals(request.keyId));
        return Task.FromResult(OnResponse(query));
    }
}