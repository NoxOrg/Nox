// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Queries;
using Nox.Application.Repositories;

using TestWebApp.Application.Dto;
using TestWebApp.Infrastructure.Persistence;

namespace TestWebApp.Application.Queries;

public partial record GetTestEntityTwoRelationshipsOneToOneByIdQuery(System.String keyId) : IRequest <IQueryable<TestEntityTwoRelationshipsOneToOneDto>>;

internal partial class GetTestEntityTwoRelationshipsOneToOneByIdQueryHandler:GetTestEntityTwoRelationshipsOneToOneByIdQueryHandlerBase
{
    public GetTestEntityTwoRelationshipsOneToOneByIdQueryHandler(IReadOnlyRepository readOnlyRepository): base(readOnlyRepository){}
}

internal abstract class GetTestEntityTwoRelationshipsOneToOneByIdQueryHandlerBase:  QueryBase<IQueryable<TestEntityTwoRelationshipsOneToOneDto>>, IRequestHandler<GetTestEntityTwoRelationshipsOneToOneByIdQuery, IQueryable<TestEntityTwoRelationshipsOneToOneDto>>
{
    public  GetTestEntityTwoRelationshipsOneToOneByIdQueryHandlerBase(IReadOnlyRepository readOnlyRepository)
    {
        ReadOnlyRepository = readOnlyRepository;
    }

    public IReadOnlyRepository ReadOnlyRepository { get; }

    public virtual Task<IQueryable<TestEntityTwoRelationshipsOneToOneDto>> Handle(GetTestEntityTwoRelationshipsOneToOneByIdQuery request, CancellationToken cancellationToken)
    {    
        var query = ReadOnlyRepository.Query<TestEntityTwoRelationshipsOneToOneDto>()
            .Where(r =>
                r.Id.Equals(request.keyId));
        return Task.FromResult(OnResponse(query));
    }
}