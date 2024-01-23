// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Queries;
using Nox.Application.Repositories;
using TestWebApp.Application.Dto;
using TestWebApp.Infrastructure.Persistence;

namespace TestWebApp.Application.Queries;

public partial record GetTestEntityTwoRelationshipsManyToManiesQuery() : IRequest<IQueryable<TestEntityTwoRelationshipsManyToManyDto>>;

internal partial class GetTestEntityTwoRelationshipsManyToManiesQueryHandler: GetTestEntityTwoRelationshipsManyToManiesQueryHandlerBase
{
    public GetTestEntityTwoRelationshipsManyToManiesQueryHandler(IReadOnlyRepository readOnlyRepository): base(readOnlyRepository){}
}

internal abstract class GetTestEntityTwoRelationshipsManyToManiesQueryHandlerBase : QueryBase<IQueryable<TestEntityTwoRelationshipsManyToManyDto>>, IRequestHandler<GetTestEntityTwoRelationshipsManyToManiesQuery, IQueryable<TestEntityTwoRelationshipsManyToManyDto>>
{
    public  GetTestEntityTwoRelationshipsManyToManiesQueryHandlerBase(IReadOnlyRepository readOnlyRepository)
    {
        ReadOnlyRepository = readOnlyRepository;
    }

    public IReadOnlyRepository ReadOnlyRepository { get; }

    public virtual Task<IQueryable<TestEntityTwoRelationshipsManyToManyDto>> Handle(GetTestEntityTwoRelationshipsManyToManiesQuery request, CancellationToken cancellationToken)
    {
        var query = ReadOnlyRepository.Query<TestEntityTwoRelationshipsManyToManyDto>();
       return Task.FromResult(OnResponse(query));
    }
}