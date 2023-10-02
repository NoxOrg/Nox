// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using TestWebApp.Application.Dto;
using TestWebApp.Infrastructure.Persistence;

namespace TestWebApp.Application.Queries;

public record GetTestEntityTwoRelationshipsOneToManyByIdQuery(System.String keyId) : IRequest <IQueryable<TestEntityTwoRelationshipsOneToManyDto>>;

internal partial class GetTestEntityTwoRelationshipsOneToManyByIdQueryHandler:GetTestEntityTwoRelationshipsOneToManyByIdQueryHandlerBase
{
    public  GetTestEntityTwoRelationshipsOneToManyByIdQueryHandler(DtoDbContext dataDbContext): base(dataDbContext)
    {
    
    }
}

internal abstract class GetTestEntityTwoRelationshipsOneToManyByIdQueryHandlerBase:  QueryBase<IQueryable<TestEntityTwoRelationshipsOneToManyDto>>, IRequestHandler<GetTestEntityTwoRelationshipsOneToManyByIdQuery, IQueryable<TestEntityTwoRelationshipsOneToManyDto>>
{
    public  GetTestEntityTwoRelationshipsOneToManyByIdQueryHandlerBase(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public virtual Task<IQueryable<TestEntityTwoRelationshipsOneToManyDto>> Handle(GetTestEntityTwoRelationshipsOneToManyByIdQuery request, CancellationToken cancellationToken)
    {    
        var query = DataDbContext.TestEntityTwoRelationshipsOneToManies
            .AsNoTracking()
            .Where(r =>
                r.Id.Equals(request.keyId) &&
                r.DeletedAtUtc == null);
        return Task.FromResult(OnResponse(query));
    }
}