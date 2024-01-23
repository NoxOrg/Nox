// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Queries;
using Nox.Application.Repositories;

using TestWebApp.Application.Dto;
using TestWebApp.Infrastructure.Persistence;

namespace TestWebApp.Application.Queries;

public partial record GetSecondTestEntityTwoRelationshipsOneToManyByIdQuery(System.String keyId) : IRequest <IQueryable<SecondTestEntityTwoRelationshipsOneToManyDto>>;

internal partial class GetSecondTestEntityTwoRelationshipsOneToManyByIdQueryHandler:GetSecondTestEntityTwoRelationshipsOneToManyByIdQueryHandlerBase
{
    public GetSecondTestEntityTwoRelationshipsOneToManyByIdQueryHandler(IReadOnlyRepository readOnlyRepository): base(readOnlyRepository){}
}

internal abstract class GetSecondTestEntityTwoRelationshipsOneToManyByIdQueryHandlerBase:  QueryBase<IQueryable<SecondTestEntityTwoRelationshipsOneToManyDto>>, IRequestHandler<GetSecondTestEntityTwoRelationshipsOneToManyByIdQuery, IQueryable<SecondTestEntityTwoRelationshipsOneToManyDto>>
{
    public  GetSecondTestEntityTwoRelationshipsOneToManyByIdQueryHandlerBase(IReadOnlyRepository readOnlyRepository)
    {
        ReadOnlyRepository = readOnlyRepository;
    }

    public IReadOnlyRepository ReadOnlyRepository { get; }

    public virtual Task<IQueryable<SecondTestEntityTwoRelationshipsOneToManyDto>> Handle(GetSecondTestEntityTwoRelationshipsOneToManyByIdQuery request, CancellationToken cancellationToken)
    {    
        var query = ReadOnlyRepository.Query<SecondTestEntityTwoRelationshipsOneToManyDto>()
            .Where(r =>
                r.Id.Equals(request.keyId));
        return Task.FromResult(OnResponse(query));
    }
}