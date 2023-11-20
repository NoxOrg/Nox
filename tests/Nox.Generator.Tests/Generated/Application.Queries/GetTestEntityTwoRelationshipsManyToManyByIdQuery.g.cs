// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using TestWebApp.Application.Dto;
using TestWebApp.Infrastructure.Persistence;

namespace TestWebApp.Application.Queries;

public partial record GetTestEntityTwoRelationshipsManyToManyByIdQuery(System.String keyId) : IRequest <IQueryable<TestEntityTwoRelationshipsManyToManyDto>>;

internal partial class GetTestEntityTwoRelationshipsManyToManyByIdQueryHandler:GetTestEntityTwoRelationshipsManyToManyByIdQueryHandlerBase
{
    public  GetTestEntityTwoRelationshipsManyToManyByIdQueryHandler(DtoDbContext dataDbContext): base(dataDbContext)
    {
    
    }
}

internal abstract class GetTestEntityTwoRelationshipsManyToManyByIdQueryHandlerBase:  QueryBase<IQueryable<TestEntityTwoRelationshipsManyToManyDto>>, IRequestHandler<GetTestEntityTwoRelationshipsManyToManyByIdQuery, IQueryable<TestEntityTwoRelationshipsManyToManyDto>>
{
    public  GetTestEntityTwoRelationshipsManyToManyByIdQueryHandlerBase(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public virtual Task<IQueryable<TestEntityTwoRelationshipsManyToManyDto>> Handle(GetTestEntityTwoRelationshipsManyToManyByIdQuery request, CancellationToken cancellationToken)
    {    
        var query = DataDbContext.TestEntityTwoRelationshipsManyToManies
            .AsNoTracking()
            .Where(r =>
                r.Id.Equals(request.keyId));
        return Task.FromResult(OnResponse(query));
    }
}