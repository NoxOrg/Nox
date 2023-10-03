// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using TestWebApp.Application.Dto;
using TestWebApp.Infrastructure.Persistence;

namespace TestWebApp.Application.Queries;

public record GetTestEntityTwoRelationshipsOneToManiesQuery() : IRequest<IQueryable<TestEntityTwoRelationshipsOneToManyDto>>;

internal partial class GetTestEntityTwoRelationshipsOneToManiesQueryHandler: GetTestEntityTwoRelationshipsOneToManiesQueryHandlerBase
{
    public GetTestEntityTwoRelationshipsOneToManiesQueryHandler(DtoDbContext dataDbContext): base(dataDbContext)
    {
    
    }
}

internal abstract class GetTestEntityTwoRelationshipsOneToManiesQueryHandlerBase : QueryBase<IQueryable<TestEntityTwoRelationshipsOneToManyDto>>, IRequestHandler<GetTestEntityTwoRelationshipsOneToManiesQuery, IQueryable<TestEntityTwoRelationshipsOneToManyDto>>
{
    public  GetTestEntityTwoRelationshipsOneToManiesQueryHandlerBase(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public virtual Task<IQueryable<TestEntityTwoRelationshipsOneToManyDto>> Handle(GetTestEntityTwoRelationshipsOneToManiesQuery request, CancellationToken cancellationToken)
    {
        var item = (IQueryable<TestEntityTwoRelationshipsOneToManyDto>)DataDbContext.TestEntityTwoRelationshipsOneToManies
            .Where(r => r.DeletedAtUtc == null)
            .AsNoTracking();
       return Task.FromResult(OnResponse(item));
    }
}