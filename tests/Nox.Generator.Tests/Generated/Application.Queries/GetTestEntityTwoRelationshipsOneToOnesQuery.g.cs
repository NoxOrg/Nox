// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using TestWebApp.Application.Dto;
using TestWebApp.Infrastructure.Persistence;

namespace TestWebApp.Application.Queries;

public partial record GetTestEntityTwoRelationshipsOneToOnesQuery() : IRequest<IQueryable<TestEntityTwoRelationshipsOneToOneDto>>;

internal partial class GetTestEntityTwoRelationshipsOneToOnesQueryHandler: GetTestEntityTwoRelationshipsOneToOnesQueryHandlerBase
{
    public GetTestEntityTwoRelationshipsOneToOnesQueryHandler(DtoDbContext dataDbContext): base(dataDbContext)
    {
    
    }
}

internal abstract class GetTestEntityTwoRelationshipsOneToOnesQueryHandlerBase : QueryBase<IQueryable<TestEntityTwoRelationshipsOneToOneDto>>, IRequestHandler<GetTestEntityTwoRelationshipsOneToOnesQuery, IQueryable<TestEntityTwoRelationshipsOneToOneDto>>
{
    public  GetTestEntityTwoRelationshipsOneToOnesQueryHandlerBase(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public virtual Task<IQueryable<TestEntityTwoRelationshipsOneToOneDto>> Handle(GetTestEntityTwoRelationshipsOneToOnesQuery request, CancellationToken cancellationToken)
    {
        var item = (IQueryable<TestEntityTwoRelationshipsOneToOneDto>)DataDbContext.TestEntityTwoRelationshipsOneToOnes
            .AsNoTracking();
       return Task.FromResult(OnResponse(item));
    }
}