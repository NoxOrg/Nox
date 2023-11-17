// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using TestWebApp.Application.Dto;
using TestWebApp.Infrastructure.Persistence;

namespace TestWebApp.Application.Queries;

public partial record GetSecondTestEntityTwoRelationshipsOneToOneByIdQuery(System.String keyId) : IRequest <IQueryable<SecondTestEntityTwoRelationshipsOneToOneDto>>;

internal partial class GetSecondTestEntityTwoRelationshipsOneToOneByIdQueryHandler:GetSecondTestEntityTwoRelationshipsOneToOneByIdQueryHandlerBase
{
    public  GetSecondTestEntityTwoRelationshipsOneToOneByIdQueryHandler(DtoDbContext dataDbContext): base(dataDbContext)
    {
    
    }
}

internal abstract class GetSecondTestEntityTwoRelationshipsOneToOneByIdQueryHandlerBase:  QueryBase<IQueryable<SecondTestEntityTwoRelationshipsOneToOneDto>>, IRequestHandler<GetSecondTestEntityTwoRelationshipsOneToOneByIdQuery, IQueryable<SecondTestEntityTwoRelationshipsOneToOneDto>>
{
    public  GetSecondTestEntityTwoRelationshipsOneToOneByIdQueryHandlerBase(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public virtual Task<IQueryable<SecondTestEntityTwoRelationshipsOneToOneDto>> Handle(GetSecondTestEntityTwoRelationshipsOneToOneByIdQuery request, CancellationToken cancellationToken)
    {    
        var query = DataDbContext.SecondTestEntityTwoRelationshipsOneToOnes
            .AsNoTracking()
            .Where(r =>
                r.Id.Equals(request.keyId));
        return Task.FromResult(OnResponse(query));
    }
}