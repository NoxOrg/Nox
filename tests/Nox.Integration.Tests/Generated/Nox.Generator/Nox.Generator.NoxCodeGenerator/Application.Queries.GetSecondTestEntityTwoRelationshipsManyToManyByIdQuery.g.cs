// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using TestWebApp.Application.Dto;
using TestWebApp.Infrastructure.Persistence;

namespace TestWebApp.Application.Queries;

public record GetSecondTestEntityTwoRelationshipsManyToManyByIdQuery(System.String keyId) : IRequest <IQueryable<SecondTestEntityTwoRelationshipsManyToManyDto>>;

internal partial class GetSecondTestEntityTwoRelationshipsManyToManyByIdQueryHandler:GetSecondTestEntityTwoRelationshipsManyToManyByIdQueryHandlerBase
{
    public  GetSecondTestEntityTwoRelationshipsManyToManyByIdQueryHandler(DtoDbContext dataDbContext): base(dataDbContext)
    {
    
    }
}

internal abstract class GetSecondTestEntityTwoRelationshipsManyToManyByIdQueryHandlerBase:  QueryBase<IQueryable<SecondTestEntityTwoRelationshipsManyToManyDto>>, IRequestHandler<GetSecondTestEntityTwoRelationshipsManyToManyByIdQuery, IQueryable<SecondTestEntityTwoRelationshipsManyToManyDto>>
{
    public  GetSecondTestEntityTwoRelationshipsManyToManyByIdQueryHandlerBase(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public virtual Task<IQueryable<SecondTestEntityTwoRelationshipsManyToManyDto>> Handle(GetSecondTestEntityTwoRelationshipsManyToManyByIdQuery request, CancellationToken cancellationToken)
    {    
        var query = DataDbContext.SecondTestEntityTwoRelationshipsManyToManies
            .AsNoTracking()
            .Where(r =>
                r.Id.Equals(request.keyId) &&
                true
            );
        return Task.FromResult(OnResponse(query));
    }
}