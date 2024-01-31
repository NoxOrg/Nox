// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Queries;
using Nox.Application.Repositories;

using TestWebApp.Application.Dto;

namespace TestWebApp.Application.Queries;

public partial record GetTestEntityOwnedRelationshipExactlyOneByIdQuery(System.String keyId) : IRequest <IQueryable<TestEntityOwnedRelationshipExactlyOneDto>>;

internal partial class GetTestEntityOwnedRelationshipExactlyOneByIdQueryHandler:GetTestEntityOwnedRelationshipExactlyOneByIdQueryHandlerBase
{
    public GetTestEntityOwnedRelationshipExactlyOneByIdQueryHandler(IReadOnlyRepository readOnlyRepository): base(readOnlyRepository){}
}

internal abstract class GetTestEntityOwnedRelationshipExactlyOneByIdQueryHandlerBase:  QueryBase<IQueryable<TestEntityOwnedRelationshipExactlyOneDto>>, IRequestHandler<GetTestEntityOwnedRelationshipExactlyOneByIdQuery, IQueryable<TestEntityOwnedRelationshipExactlyOneDto>>
{
    public  GetTestEntityOwnedRelationshipExactlyOneByIdQueryHandlerBase(IReadOnlyRepository readOnlyRepository)
    {
        ReadOnlyRepository = readOnlyRepository;
    }

    public IReadOnlyRepository ReadOnlyRepository { get; }

    public virtual Task<IQueryable<TestEntityOwnedRelationshipExactlyOneDto>> Handle(GetTestEntityOwnedRelationshipExactlyOneByIdQuery request, CancellationToken cancellationToken)
    {    
        var query = ReadOnlyRepository.Query<TestEntityOwnedRelationshipExactlyOneDto>()
            .Include(e => e.SecEntityOwnedRelExactlyOne)
            .Where(r =>
                r.Id.Equals(request.keyId));
        return Task.FromResult(OnResponse(query));
    }
}