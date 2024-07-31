// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Queries;
using Nox.Application.Repositories;
using TestWebApp.Application.Dto;

namespace TestWebApp.Application.Queries;

public partial record GetTestEntityTwoRelationshipsOneToManiesQuery() : IRequest<IQueryable<TestEntityTwoRelationshipsOneToManyDto>>;

internal partial class GetTestEntityTwoRelationshipsOneToManiesQueryHandler: GetTestEntityTwoRelationshipsOneToManiesQueryHandlerBase
{
    public GetTestEntityTwoRelationshipsOneToManiesQueryHandler(IReadOnlyRepository readOnlyRepository): base(readOnlyRepository){}
}

internal abstract class GetTestEntityTwoRelationshipsOneToManiesQueryHandlerBase : QueryBase<IQueryable<TestEntityTwoRelationshipsOneToManyDto>>, IRequestHandler<GetTestEntityTwoRelationshipsOneToManiesQuery, IQueryable<TestEntityTwoRelationshipsOneToManyDto>>
{
    public  GetTestEntityTwoRelationshipsOneToManiesQueryHandlerBase(IReadOnlyRepository readOnlyRepository)
    {
        ReadOnlyRepository = readOnlyRepository;
    }

    public IReadOnlyRepository ReadOnlyRepository { get; }

    public virtual Task<IQueryable<TestEntityTwoRelationshipsOneToManyDto>> Handle(GetTestEntityTwoRelationshipsOneToManiesQuery request, CancellationToken cancellationToken)
    {
        var query = ReadOnlyRepository.Query<TestEntityTwoRelationshipsOneToManyDto>();
       return Task.FromResult(OnResponse(query));
    }
}