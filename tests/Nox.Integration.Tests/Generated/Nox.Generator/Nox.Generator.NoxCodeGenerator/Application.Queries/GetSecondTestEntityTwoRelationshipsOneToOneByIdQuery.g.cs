// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Queries;
using Nox.Application.Repositories;

using TestWebApp.Application.Dto;
using TestWebApp.Infrastructure.Persistence;

namespace TestWebApp.Application.Queries;

public partial record GetSecondTestEntityTwoRelationshipsOneToOneByIdQuery(System.String keyId) : IRequest <IQueryable<SecondTestEntityTwoRelationshipsOneToOneDto>>;

internal partial class GetSecondTestEntityTwoRelationshipsOneToOneByIdQueryHandler:GetSecondTestEntityTwoRelationshipsOneToOneByIdQueryHandlerBase
{
    public GetSecondTestEntityTwoRelationshipsOneToOneByIdQueryHandler(IReadOnlyRepository readOnlyRepository): base(readOnlyRepository){}
}

internal abstract class GetSecondTestEntityTwoRelationshipsOneToOneByIdQueryHandlerBase:  QueryBase<IQueryable<SecondTestEntityTwoRelationshipsOneToOneDto>>, IRequestHandler<GetSecondTestEntityTwoRelationshipsOneToOneByIdQuery, IQueryable<SecondTestEntityTwoRelationshipsOneToOneDto>>
{
    public  GetSecondTestEntityTwoRelationshipsOneToOneByIdQueryHandlerBase(IReadOnlyRepository readOnlyRepository)
    {
        ReadOnlyRepository = readOnlyRepository;
    }

    public IReadOnlyRepository ReadOnlyRepository { get; }

    public virtual Task<IQueryable<SecondTestEntityTwoRelationshipsOneToOneDto>> Handle(GetSecondTestEntityTwoRelationshipsOneToOneByIdQuery request, CancellationToken cancellationToken)
    {    
        var query = ReadOnlyRepository.Query<SecondTestEntityTwoRelationshipsOneToOneDto >()
            .Where(r =>
                r.Id.Equals(request.keyId));
        return Task.FromResult(OnResponse(query));
    }
}