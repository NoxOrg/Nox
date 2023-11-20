// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using TestWebApp.Application.Dto;
using TestWebApp.Infrastructure.Persistence;

namespace TestWebApp.Application.Queries;

public partial record GetTestEntityOwnedRelationshipZeroOrOnesQuery() : IRequest<IQueryable<TestEntityOwnedRelationshipZeroOrOneDto>>;

internal partial class GetTestEntityOwnedRelationshipZeroOrOnesQueryHandler: GetTestEntityOwnedRelationshipZeroOrOnesQueryHandlerBase
{
    public GetTestEntityOwnedRelationshipZeroOrOnesQueryHandler(DtoDbContext dataDbContext): base(dataDbContext)
    {
    
    }
}

internal abstract class GetTestEntityOwnedRelationshipZeroOrOnesQueryHandlerBase : QueryBase<IQueryable<TestEntityOwnedRelationshipZeroOrOneDto>>, IRequestHandler<GetTestEntityOwnedRelationshipZeroOrOnesQuery, IQueryable<TestEntityOwnedRelationshipZeroOrOneDto>>
{
    public  GetTestEntityOwnedRelationshipZeroOrOnesQueryHandlerBase(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public virtual Task<IQueryable<TestEntityOwnedRelationshipZeroOrOneDto>> Handle(GetTestEntityOwnedRelationshipZeroOrOnesQuery request, CancellationToken cancellationToken)
    {
        var item = (IQueryable<TestEntityOwnedRelationshipZeroOrOneDto>)DataDbContext.TestEntityOwnedRelationshipZeroOrOnes
            .AsNoTracking();
       return Task.FromResult(OnResponse(item));
    }
}