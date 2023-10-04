// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using TestWebApp.Application.Dto;
using TestWebApp.Infrastructure.Persistence;

namespace TestWebApp.Application.Queries;

public record GetSecondTestEntityTwoRelationshipsOneToManiesQuery() : IRequest<IQueryable<SecondTestEntityTwoRelationshipsOneToManyDto>>;

internal partial class GetSecondTestEntityTwoRelationshipsOneToManiesQueryHandler: GetSecondTestEntityTwoRelationshipsOneToManiesQueryHandlerBase
{
    public GetSecondTestEntityTwoRelationshipsOneToManiesQueryHandler(DtoDbContext dataDbContext): base(dataDbContext)
    {
    
    }
}

internal abstract class GetSecondTestEntityTwoRelationshipsOneToManiesQueryHandlerBase : QueryBase<IQueryable<SecondTestEntityTwoRelationshipsOneToManyDto>>, IRequestHandler<GetSecondTestEntityTwoRelationshipsOneToManiesQuery, IQueryable<SecondTestEntityTwoRelationshipsOneToManyDto>>
{
    public  GetSecondTestEntityTwoRelationshipsOneToManiesQueryHandlerBase(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public virtual Task<IQueryable<SecondTestEntityTwoRelationshipsOneToManyDto>> Handle(GetSecondTestEntityTwoRelationshipsOneToManiesQuery request, CancellationToken cancellationToken)
    {
        var item = (IQueryable<SecondTestEntityTwoRelationshipsOneToManyDto>)DataDbContext.SecondTestEntityTwoRelationshipsOneToManies
            .AsNoTracking();
       return Task.FromResult(OnResponse(item));
    }
}