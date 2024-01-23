// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Queries;
using Nox.Application.Repositories;
using TestWebApp.Application.Dto;
using TestWebApp.Infrastructure.Persistence;

namespace TestWebApp.Application.Queries;

public partial record GetTestEntityTwoRelationshipsOneToOnesQuery() : IRequest<IQueryable<TestEntityTwoRelationshipsOneToOneDto>>;

internal partial class GetTestEntityTwoRelationshipsOneToOnesQueryHandler: GetTestEntityTwoRelationshipsOneToOnesQueryHandlerBase
{
    public GetTestEntityTwoRelationshipsOneToOnesQueryHandler(IReadOnlyRepository readOnlyRepository): base(readOnlyRepository){}
}

internal abstract class GetTestEntityTwoRelationshipsOneToOnesQueryHandlerBase : QueryBase<IQueryable<TestEntityTwoRelationshipsOneToOneDto>>, IRequestHandler<GetTestEntityTwoRelationshipsOneToOnesQuery, IQueryable<TestEntityTwoRelationshipsOneToOneDto>>
{
    public  GetTestEntityTwoRelationshipsOneToOnesQueryHandlerBase(IReadOnlyRepository readOnlyRepository)
    {
        ReadOnlyRepository = readOnlyRepository;
    }

    public IReadOnlyRepository ReadOnlyRepository { get; }

    public virtual Task<IQueryable<TestEntityTwoRelationshipsOneToOneDto>> Handle(GetTestEntityTwoRelationshipsOneToOnesQuery request, CancellationToken cancellationToken)
    {
        var query = ReadOnlyRepository.Query<TestEntityTwoRelationshipsOneToOneDto>();
       return Task.FromResult(OnResponse(query));
    }
}