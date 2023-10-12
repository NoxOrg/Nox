// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using TestWebApp.Application.Dto;
using TestWebApp.Infrastructure.Persistence;

namespace TestWebApp.Application.Queries;

public record GetTestEntityTwoRelationshipsOneToOneByIdQuery(System.String keyId) : IRequest <IQueryable<TestEntityTwoRelationshipsOneToOneDto>>;

internal partial class GetTestEntityTwoRelationshipsOneToOneByIdQueryHandler:GetTestEntityTwoRelationshipsOneToOneByIdQueryHandlerBase
{
    public  GetTestEntityTwoRelationshipsOneToOneByIdQueryHandler(DtoDbContext dataDbContext): base(dataDbContext)
    {
    
    }
}

internal abstract class GetTestEntityTwoRelationshipsOneToOneByIdQueryHandlerBase:  QueryBase<IQueryable<TestEntityTwoRelationshipsOneToOneDto>>, IRequestHandler<GetTestEntityTwoRelationshipsOneToOneByIdQuery, IQueryable<TestEntityTwoRelationshipsOneToOneDto>>
{
    public  GetTestEntityTwoRelationshipsOneToOneByIdQueryHandlerBase(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public virtual Task<IQueryable<TestEntityTwoRelationshipsOneToOneDto>> Handle(GetTestEntityTwoRelationshipsOneToOneByIdQuery request, CancellationToken cancellationToken)
    {    
        var query = DataDbContext.TestEntityTwoRelationshipsOneToOnes
            .AsNoTracking()
            .Where(r =>
                r.Id.Equals(request.keyId));
        return Task.FromResult(OnResponse(query));
    }
}