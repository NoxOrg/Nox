// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Queries;
using Nox.Application.Repositories;

using TestWebApp.Application.Dto;
using TestWebApp.Infrastructure.Persistence;

namespace TestWebApp.Application.Queries;

public partial record GetTestEntityOwnedRelationshipZeroOrManyByIdQuery(System.String keyId) : IRequest <IQueryable<TestEntityOwnedRelationshipZeroOrManyDto>>;

internal partial class GetTestEntityOwnedRelationshipZeroOrManyByIdQueryHandler:GetTestEntityOwnedRelationshipZeroOrManyByIdQueryHandlerBase
{
    public GetTestEntityOwnedRelationshipZeroOrManyByIdQueryHandler(IReadOnlyRepository readOnlyRepository): base(readOnlyRepository){}
}

internal abstract class GetTestEntityOwnedRelationshipZeroOrManyByIdQueryHandlerBase:  QueryBase<IQueryable<TestEntityOwnedRelationshipZeroOrManyDto>>, IRequestHandler<GetTestEntityOwnedRelationshipZeroOrManyByIdQuery, IQueryable<TestEntityOwnedRelationshipZeroOrManyDto>>
{
    public  GetTestEntityOwnedRelationshipZeroOrManyByIdQueryHandlerBase(IReadOnlyRepository readOnlyRepository)
    {
        ReadOnlyRepository = readOnlyRepository;
    }

    public IReadOnlyRepository ReadOnlyRepository { get; }

    public virtual Task<IQueryable<TestEntityOwnedRelationshipZeroOrManyDto>> Handle(GetTestEntityOwnedRelationshipZeroOrManyByIdQuery request, CancellationToken cancellationToken)
    {    
        var query = ReadOnlyRepository.Query<TestEntityOwnedRelationshipZeroOrManyDto >()
            .Include(e => e.SecEntityOwnedRelZeroOrManies)
            .Where(r =>
                r.Id.Equals(request.keyId));
        return Task.FromResult(OnResponse(query));
    }
}