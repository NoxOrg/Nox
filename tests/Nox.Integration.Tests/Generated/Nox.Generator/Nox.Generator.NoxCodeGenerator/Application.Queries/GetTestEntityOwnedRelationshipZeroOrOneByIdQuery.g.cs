// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Queries;
using Nox.Application.Repositories;

using TestWebApp.Application.Dto;
using TestWebApp.Infrastructure.Persistence;

namespace TestWebApp.Application.Queries;

public partial record GetTestEntityOwnedRelationshipZeroOrOneByIdQuery(System.String keyId) : IRequest <IQueryable<TestEntityOwnedRelationshipZeroOrOneDto>>;

internal partial class GetTestEntityOwnedRelationshipZeroOrOneByIdQueryHandler:GetTestEntityOwnedRelationshipZeroOrOneByIdQueryHandlerBase
{
    public GetTestEntityOwnedRelationshipZeroOrOneByIdQueryHandler(IReadOnlyRepository readOnlyRepository): base(readOnlyRepository){}
}

internal abstract class GetTestEntityOwnedRelationshipZeroOrOneByIdQueryHandlerBase:  QueryBase<IQueryable<TestEntityOwnedRelationshipZeroOrOneDto>>, IRequestHandler<GetTestEntityOwnedRelationshipZeroOrOneByIdQuery, IQueryable<TestEntityOwnedRelationshipZeroOrOneDto>>
{
    public  GetTestEntityOwnedRelationshipZeroOrOneByIdQueryHandlerBase(IReadOnlyRepository readOnlyRepository)
    {
        ReadOnlyRepository = readOnlyRepository;
    }

    public IReadOnlyRepository ReadOnlyRepository { get; }

    public virtual Task<IQueryable<TestEntityOwnedRelationshipZeroOrOneDto>> Handle(GetTestEntityOwnedRelationshipZeroOrOneByIdQuery request, CancellationToken cancellationToken)
    {    
        var query = ReadOnlyRepository.Query<TestEntityOwnedRelationshipZeroOrOneDto >()
            .Include(e => e.SecondTestEntityOwnedRelationshipZeroOrOne)
            .Where(r =>
                r.Id.Equals(request.keyId));
        return Task.FromResult(OnResponse(query));
    }
}