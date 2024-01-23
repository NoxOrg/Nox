// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Queries;
using Nox.Application.Repositories;
using TestWebApp.Application.Dto;
using TestWebApp.Infrastructure.Persistence;

namespace TestWebApp.Application.Queries;

public partial record GetTestEntityOwnedRelationshipZeroOrManiesQuery() : IRequest<IQueryable<TestEntityOwnedRelationshipZeroOrManyDto>>;

internal partial class GetTestEntityOwnedRelationshipZeroOrManiesQueryHandler: GetTestEntityOwnedRelationshipZeroOrManiesQueryHandlerBase
{
    public GetTestEntityOwnedRelationshipZeroOrManiesQueryHandler(IReadOnlyRepository readOnlyRepository): base(readOnlyRepository){}
}

internal abstract class GetTestEntityOwnedRelationshipZeroOrManiesQueryHandlerBase : QueryBase<IQueryable<TestEntityOwnedRelationshipZeroOrManyDto>>, IRequestHandler<GetTestEntityOwnedRelationshipZeroOrManiesQuery, IQueryable<TestEntityOwnedRelationshipZeroOrManyDto>>
{
    public  GetTestEntityOwnedRelationshipZeroOrManiesQueryHandlerBase(IReadOnlyRepository readOnlyRepository)
    {
        ReadOnlyRepository = readOnlyRepository;
    }

    public IReadOnlyRepository ReadOnlyRepository { get; }

    public virtual Task<IQueryable<TestEntityOwnedRelationshipZeroOrManyDto>> Handle(GetTestEntityOwnedRelationshipZeroOrManiesQuery request, CancellationToken cancellationToken)
    {
        var query = ReadOnlyRepository.Query<TestEntityOwnedRelationshipZeroOrManyDto>()
            .Include(e => e.SecEntityOwnedRelZeroOrManies);
       return Task.FromResult(OnResponse(query));
    }
}