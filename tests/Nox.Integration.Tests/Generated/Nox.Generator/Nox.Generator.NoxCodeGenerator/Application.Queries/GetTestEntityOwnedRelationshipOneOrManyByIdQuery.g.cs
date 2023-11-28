// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using TestWebApp.Application.Dto;
using TestWebApp.Infrastructure.Persistence;

namespace TestWebApp.Application.Queries;

public partial record GetTestEntityOwnedRelationshipOneOrManyByIdQuery(System.String keyId) : IRequest <IQueryable<TestEntityOwnedRelationshipOneOrManyDto>>;

internal partial class GetTestEntityOwnedRelationshipOneOrManyByIdQueryHandler:GetTestEntityOwnedRelationshipOneOrManyByIdQueryHandlerBase
{
    public  GetTestEntityOwnedRelationshipOneOrManyByIdQueryHandler(DtoDbContext dataDbContext): base(dataDbContext)
    {
    
    }
}

internal abstract class GetTestEntityOwnedRelationshipOneOrManyByIdQueryHandlerBase:  QueryBase<IQueryable<TestEntityOwnedRelationshipOneOrManyDto>>, IRequestHandler<GetTestEntityOwnedRelationshipOneOrManyByIdQuery, IQueryable<TestEntityOwnedRelationshipOneOrManyDto>>
{
    public  GetTestEntityOwnedRelationshipOneOrManyByIdQueryHandlerBase(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public virtual Task<IQueryable<TestEntityOwnedRelationshipOneOrManyDto>> Handle(GetTestEntityOwnedRelationshipOneOrManyByIdQuery request, CancellationToken cancellationToken)
    {    
        var query = DataDbContext.TestEntityOwnedRelationshipOneOrManies
            .AsNoTracking()
            .Include(e => e.SecondTestEntityOwnedRelationshipOneOrManies)
            .Where(r =>
                r.Id.Equals(request.keyId));
        return Task.FromResult(OnResponse(query));
    }
}