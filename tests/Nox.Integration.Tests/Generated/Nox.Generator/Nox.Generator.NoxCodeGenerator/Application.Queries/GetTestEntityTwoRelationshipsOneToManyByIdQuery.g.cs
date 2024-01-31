// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Queries;
using Nox.Application.Repositories;

using TestWebApp.Application.Dto;

namespace TestWebApp.Application.Queries;

public partial record GetTestEntityTwoRelationshipsOneToManyByIdQuery(System.String keyId) : IRequest <IQueryable<TestEntityTwoRelationshipsOneToManyDto>>;

internal partial class GetTestEntityTwoRelationshipsOneToManyByIdQueryHandler:GetTestEntityTwoRelationshipsOneToManyByIdQueryHandlerBase
{
    public GetTestEntityTwoRelationshipsOneToManyByIdQueryHandler(IReadOnlyRepository readOnlyRepository): base(readOnlyRepository){}
}

internal abstract class GetTestEntityTwoRelationshipsOneToManyByIdQueryHandlerBase:  QueryBase<IQueryable<TestEntityTwoRelationshipsOneToManyDto>>, IRequestHandler<GetTestEntityTwoRelationshipsOneToManyByIdQuery, IQueryable<TestEntityTwoRelationshipsOneToManyDto>>
{
    public  GetTestEntityTwoRelationshipsOneToManyByIdQueryHandlerBase(IReadOnlyRepository readOnlyRepository)
    {
        ReadOnlyRepository = readOnlyRepository;
    }

    public IReadOnlyRepository ReadOnlyRepository { get; }

    public virtual Task<IQueryable<TestEntityTwoRelationshipsOneToManyDto>> Handle(GetTestEntityTwoRelationshipsOneToManyByIdQuery request, CancellationToken cancellationToken)
    {    
        var query = ReadOnlyRepository.Query<TestEntityTwoRelationshipsOneToManyDto>()
            .Where(r =>
                r.Id.Equals(request.keyId));
        return Task.FromResult(OnResponse(query));
    }
}