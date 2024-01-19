// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Queries;
using Nox.Application.Repositories;

using TestWebApp.Application.Dto;
using TestWebApp.Infrastructure.Persistence;

namespace TestWebApp.Application.Queries;

public partial record GetTestEntityTwoRelationshipsManyToManyByIdQuery(System.String keyId) : IRequest <IQueryable<TestEntityTwoRelationshipsManyToManyDto>>;

internal partial class GetTestEntityTwoRelationshipsManyToManyByIdQueryHandler:GetTestEntityTwoRelationshipsManyToManyByIdQueryHandlerBase
{
    public GetTestEntityTwoRelationshipsManyToManyByIdQueryHandler(IReadOnlyRepository readOnlyRepository): base(readOnlyRepository){}
}

internal abstract class GetTestEntityTwoRelationshipsManyToManyByIdQueryHandlerBase:  QueryBase<IQueryable<TestEntityTwoRelationshipsManyToManyDto>>, IRequestHandler<GetTestEntityTwoRelationshipsManyToManyByIdQuery, IQueryable<TestEntityTwoRelationshipsManyToManyDto>>
{
    public  GetTestEntityTwoRelationshipsManyToManyByIdQueryHandlerBase(IReadOnlyRepository readOnlyRepository)
    {
        ReadOnlyRepository = readOnlyRepository;
    }

    public IReadOnlyRepository ReadOnlyRepository { get; }

    public virtual Task<IQueryable<TestEntityTwoRelationshipsManyToManyDto>> Handle(GetTestEntityTwoRelationshipsManyToManyByIdQuery request, CancellationToken cancellationToken)
    {    
        var query = ReadOnlyRepository.Query<TestEntityTwoRelationshipsManyToManyDto>()
            .Where(r =>
                r.Id.Equals(request.keyId));
        return Task.FromResult(OnResponse(query));
    }
}