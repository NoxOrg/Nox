// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Queries;
using Nox.Application.Repositories;
using TestWebApp.Application.Dto;
using TestWebApp.Infrastructure.Persistence;

namespace TestWebApp.Application.Queries;

public partial record GetTestEntityOwnedRelationshipZeroOrOnesQuery() : IRequest<IQueryable<TestEntityOwnedRelationshipZeroOrOneDto>>;

internal partial class GetTestEntityOwnedRelationshipZeroOrOnesQueryHandler: GetTestEntityOwnedRelationshipZeroOrOnesQueryHandlerBase
{
    public GetTestEntityOwnedRelationshipZeroOrOnesQueryHandler(IReadOnlyRepository readOnlyRepository): base(readOnlyRepository){}
}

internal abstract class GetTestEntityOwnedRelationshipZeroOrOnesQueryHandlerBase : QueryBase<IQueryable<TestEntityOwnedRelationshipZeroOrOneDto>>, IRequestHandler<GetTestEntityOwnedRelationshipZeroOrOnesQuery, IQueryable<TestEntityOwnedRelationshipZeroOrOneDto>>
{
    public  GetTestEntityOwnedRelationshipZeroOrOnesQueryHandlerBase(IReadOnlyRepository readOnlyRepository)
    {
        ReadOnlyRepository = readOnlyRepository;
    }

    public IReadOnlyRepository ReadOnlyRepository { get; }

    public virtual Task<IQueryable<TestEntityOwnedRelationshipZeroOrOneDto>> Handle(GetTestEntityOwnedRelationshipZeroOrOnesQuery request, CancellationToken cancellationToken)
    {
        var query = ReadOnlyRepository.Query<TestEntityOwnedRelationshipZeroOrOneDto>()
            .Include(e => e.SecondTestEntityOwnedRelationshipZeroOrOne);
       return Task.FromResult(OnResponse(query));
    }
}