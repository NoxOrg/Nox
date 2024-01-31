// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Queries;
using Nox.Application.Repositories;
using TestWebApp.Application.Dto;

namespace TestWebApp.Application.Queries;

public partial record GetTestEntityOwnedRelationshipExactlyOnesQuery() : IRequest<IQueryable<TestEntityOwnedRelationshipExactlyOneDto>>;

internal partial class GetTestEntityOwnedRelationshipExactlyOnesQueryHandler: GetTestEntityOwnedRelationshipExactlyOnesQueryHandlerBase
{
    public GetTestEntityOwnedRelationshipExactlyOnesQueryHandler(IReadOnlyRepository readOnlyRepository): base(readOnlyRepository){}
}

internal abstract class GetTestEntityOwnedRelationshipExactlyOnesQueryHandlerBase : QueryBase<IQueryable<TestEntityOwnedRelationshipExactlyOneDto>>, IRequestHandler<GetTestEntityOwnedRelationshipExactlyOnesQuery, IQueryable<TestEntityOwnedRelationshipExactlyOneDto>>
{
    public  GetTestEntityOwnedRelationshipExactlyOnesQueryHandlerBase(IReadOnlyRepository readOnlyRepository)
    {
        ReadOnlyRepository = readOnlyRepository;
    }

    public IReadOnlyRepository ReadOnlyRepository { get; }

    public virtual Task<IQueryable<TestEntityOwnedRelationshipExactlyOneDto>> Handle(GetTestEntityOwnedRelationshipExactlyOnesQuery request, CancellationToken cancellationToken)
    {
        var query = ReadOnlyRepository.Query<TestEntityOwnedRelationshipExactlyOneDto>()
            .Include(e => e.SecEntityOwnedRelExactlyOne);
       return Task.FromResult(OnResponse(query));
    }
}