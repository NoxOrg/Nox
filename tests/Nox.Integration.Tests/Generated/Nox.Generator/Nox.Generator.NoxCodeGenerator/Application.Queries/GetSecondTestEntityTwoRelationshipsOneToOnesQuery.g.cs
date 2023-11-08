// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using TestWebApp.Application.Dto;
using TestWebApp.Infrastructure.Persistence;

namespace TestWebApp.Application.Queries;

public partial record GetSecondTestEntityTwoRelationshipsOneToOnesQuery() : IRequest<IQueryable<SecondTestEntityTwoRelationshipsOneToOneDto>>;

internal partial class GetSecondTestEntityTwoRelationshipsOneToOnesQueryHandler: GetSecondTestEntityTwoRelationshipsOneToOnesQueryHandlerBase
{
    public GetSecondTestEntityTwoRelationshipsOneToOnesQueryHandler(DtoDbContext dataDbContext): base(dataDbContext)
    {
    
    }
}

internal abstract class GetSecondTestEntityTwoRelationshipsOneToOnesQueryHandlerBase : QueryBase<IQueryable<SecondTestEntityTwoRelationshipsOneToOneDto>>, IRequestHandler<GetSecondTestEntityTwoRelationshipsOneToOnesQuery, IQueryable<SecondTestEntityTwoRelationshipsOneToOneDto>>
{
    public  GetSecondTestEntityTwoRelationshipsOneToOnesQueryHandlerBase(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public virtual Task<IQueryable<SecondTestEntityTwoRelationshipsOneToOneDto>> Handle(GetSecondTestEntityTwoRelationshipsOneToOnesQuery request, CancellationToken cancellationToken)
    {
        var item = (IQueryable<SecondTestEntityTwoRelationshipsOneToOneDto>)DataDbContext.SecondTestEntityTwoRelationshipsOneToOnes
            .AsNoTracking();
       return Task.FromResult(OnResponse(item));
    }
}