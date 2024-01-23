// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Queries;
using Nox.Application.Repositories;

using TestWebApp.Application.Dto;
using TestWebApp.Infrastructure.Persistence;

namespace TestWebApp.Application.Queries;

public partial record GetSecondTestEntityTwoRelationshipsManyToManyByIdQuery(System.String keyId) : IRequest <IQueryable<SecondTestEntityTwoRelationshipsManyToManyDto>>;

internal partial class GetSecondTestEntityTwoRelationshipsManyToManyByIdQueryHandler:GetSecondTestEntityTwoRelationshipsManyToManyByIdQueryHandlerBase
{
    public GetSecondTestEntityTwoRelationshipsManyToManyByIdQueryHandler(IReadOnlyRepository readOnlyRepository): base(readOnlyRepository){}
}

internal abstract class GetSecondTestEntityTwoRelationshipsManyToManyByIdQueryHandlerBase:  QueryBase<IQueryable<SecondTestEntityTwoRelationshipsManyToManyDto>>, IRequestHandler<GetSecondTestEntityTwoRelationshipsManyToManyByIdQuery, IQueryable<SecondTestEntityTwoRelationshipsManyToManyDto>>
{
    public  GetSecondTestEntityTwoRelationshipsManyToManyByIdQueryHandlerBase(IReadOnlyRepository readOnlyRepository)
    {
        ReadOnlyRepository = readOnlyRepository;
    }

    public IReadOnlyRepository ReadOnlyRepository { get; }

    public virtual Task<IQueryable<SecondTestEntityTwoRelationshipsManyToManyDto>> Handle(GetSecondTestEntityTwoRelationshipsManyToManyByIdQuery request, CancellationToken cancellationToken)
    {    
        var query = ReadOnlyRepository.Query<SecondTestEntityTwoRelationshipsManyToManyDto>()
            .Where(r =>
                r.Id.Equals(request.keyId));
        return Task.FromResult(OnResponse(query));
    }
}