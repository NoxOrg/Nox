// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using TestWebApp.Application.Dto;
using TestWebApp.Infrastructure.Persistence;

namespace TestWebApp.Application.Queries;

public partial record GetSecondTestEntityTwoRelationshipsOneToManyByIdQuery(System.String keyId) : IRequest <IQueryable<SecondTestEntityTwoRelationshipsOneToManyDto>>;

internal partial class GetSecondTestEntityTwoRelationshipsOneToManyByIdQueryHandler:GetSecondTestEntityTwoRelationshipsOneToManyByIdQueryHandlerBase
{
    public  GetSecondTestEntityTwoRelationshipsOneToManyByIdQueryHandler(DtoDbContext dataDbContext): base(dataDbContext)
    {
    
    }
}

internal abstract class GetSecondTestEntityTwoRelationshipsOneToManyByIdQueryHandlerBase:  QueryBase<IQueryable<SecondTestEntityTwoRelationshipsOneToManyDto>>, IRequestHandler<GetSecondTestEntityTwoRelationshipsOneToManyByIdQuery, IQueryable<SecondTestEntityTwoRelationshipsOneToManyDto>>
{
    public  GetSecondTestEntityTwoRelationshipsOneToManyByIdQueryHandlerBase(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public virtual Task<IQueryable<SecondTestEntityTwoRelationshipsOneToManyDto>> Handle(GetSecondTestEntityTwoRelationshipsOneToManyByIdQuery request, CancellationToken cancellationToken)
    {    
        var query = DataDbContext.SecondTestEntityTwoRelationshipsOneToManies
            .AsNoTracking()
            .Where(r =>
                r.Id.Equals(request.keyId));
        return Task.FromResult(OnResponse(query));
    }
}