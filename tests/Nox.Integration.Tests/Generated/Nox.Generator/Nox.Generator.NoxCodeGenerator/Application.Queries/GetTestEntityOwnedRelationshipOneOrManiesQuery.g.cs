// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Queries;
using Nox.Application.Repositories;
using TestWebApp.Application.Dto;

namespace TestWebApp.Application.Queries;

public partial record GetTestEntityOwnedRelationshipOneOrManiesQuery() : IRequest<IQueryable<TestEntityOwnedRelationshipOneOrManyDto>>;

internal partial class GetTestEntityOwnedRelationshipOneOrManiesQueryHandler: GetTestEntityOwnedRelationshipOneOrManiesQueryHandlerBase
{
    public GetTestEntityOwnedRelationshipOneOrManiesQueryHandler(IReadOnlyRepository readOnlyRepository): base(readOnlyRepository){}
}

internal abstract class GetTestEntityOwnedRelationshipOneOrManiesQueryHandlerBase : QueryBase<IQueryable<TestEntityOwnedRelationshipOneOrManyDto>>, IRequestHandler<GetTestEntityOwnedRelationshipOneOrManiesQuery, IQueryable<TestEntityOwnedRelationshipOneOrManyDto>>
{
    public  GetTestEntityOwnedRelationshipOneOrManiesQueryHandlerBase(IReadOnlyRepository readOnlyRepository)
    {
        ReadOnlyRepository = readOnlyRepository;
    }

    public IReadOnlyRepository ReadOnlyRepository { get; }

    public virtual Task<IQueryable<TestEntityOwnedRelationshipOneOrManyDto>> Handle(GetTestEntityOwnedRelationshipOneOrManiesQuery request, CancellationToken cancellationToken)
    {
        var query = ReadOnlyRepository.Query<TestEntityOwnedRelationshipOneOrManyDto>()
            .Include(e => e.SecEntityOwnedRelOneOrManies);
       return Task.FromResult(OnResponse(query));
    }
}