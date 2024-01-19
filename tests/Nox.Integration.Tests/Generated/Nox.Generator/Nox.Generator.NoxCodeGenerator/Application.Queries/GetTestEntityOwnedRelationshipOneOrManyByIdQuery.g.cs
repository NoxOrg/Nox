// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Queries;
using Nox.Application.Repositories;

using TestWebApp.Application.Dto;
using TestWebApp.Infrastructure.Persistence;

namespace TestWebApp.Application.Queries;

public partial record GetTestEntityOwnedRelationshipOneOrManyByIdQuery(System.String keyId) : IRequest <IQueryable<TestEntityOwnedRelationshipOneOrManyDto>>;

internal partial class GetTestEntityOwnedRelationshipOneOrManyByIdQueryHandler:GetTestEntityOwnedRelationshipOneOrManyByIdQueryHandlerBase
{
    public GetTestEntityOwnedRelationshipOneOrManyByIdQueryHandler(IReadOnlyRepository readOnlyRepository): base(readOnlyRepository){}
}

internal abstract class GetTestEntityOwnedRelationshipOneOrManyByIdQueryHandlerBase:  QueryBase<IQueryable<TestEntityOwnedRelationshipOneOrManyDto>>, IRequestHandler<GetTestEntityOwnedRelationshipOneOrManyByIdQuery, IQueryable<TestEntityOwnedRelationshipOneOrManyDto>>
{
    public  GetTestEntityOwnedRelationshipOneOrManyByIdQueryHandlerBase(IReadOnlyRepository readOnlyRepository)
    {
        ReadOnlyRepository = readOnlyRepository;
    }

    public IReadOnlyRepository ReadOnlyRepository { get; }

    public virtual Task<IQueryable<TestEntityOwnedRelationshipOneOrManyDto>> Handle(GetTestEntityOwnedRelationshipOneOrManyByIdQuery request, CancellationToken cancellationToken)
    {    
        var query = ReadOnlyRepository.Query<TestEntityOwnedRelationshipOneOrManyDto>()
            .Include(e => e.SecEntityOwnedRelOneOrManies)
            .Where(r =>
                r.Id.Equals(request.keyId));
        return Task.FromResult(OnResponse(query));
    }
}