// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Queries;
using Nox.Application.Repositories;
using TestWebApp.Application.Dto;
using TestWebApp.Infrastructure.Persistence;

namespace TestWebApp.Application.Queries;

public partial record GetSecondTestEntityTwoRelationshipsManyToManiesQuery() : IRequest<IQueryable<SecondTestEntityTwoRelationshipsManyToManyDto>>;

internal partial class GetSecondTestEntityTwoRelationshipsManyToManiesQueryHandler: GetSecondTestEntityTwoRelationshipsManyToManiesQueryHandlerBase
{
    public GetSecondTestEntityTwoRelationshipsManyToManiesQueryHandler(IReadOnlyRepository readOnlyRepository): base(readOnlyRepository){}
}

internal abstract class GetSecondTestEntityTwoRelationshipsManyToManiesQueryHandlerBase : QueryBase<IQueryable<SecondTestEntityTwoRelationshipsManyToManyDto>>, IRequestHandler<GetSecondTestEntityTwoRelationshipsManyToManiesQuery, IQueryable<SecondTestEntityTwoRelationshipsManyToManyDto>>
{
    public  GetSecondTestEntityTwoRelationshipsManyToManiesQueryHandlerBase(IReadOnlyRepository readOnlyRepository)
    {
        ReadOnlyRepository = readOnlyRepository;
    }

    public IReadOnlyRepository ReadOnlyRepository { get; }

    public virtual Task<IQueryable<SecondTestEntityTwoRelationshipsManyToManyDto>> Handle(GetSecondTestEntityTwoRelationshipsManyToManiesQuery request, CancellationToken cancellationToken)
    {
        var query = ReadOnlyRepository.Query<SecondTestEntityTwoRelationshipsManyToManyDto>();
       return Task.FromResult(OnResponse(query));
    }
}