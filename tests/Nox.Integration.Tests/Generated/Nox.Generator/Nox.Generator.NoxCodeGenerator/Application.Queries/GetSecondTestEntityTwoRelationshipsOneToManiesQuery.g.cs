// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Queries;
using Nox.Application.Repositories;
using TestWebApp.Application.Dto;

namespace TestWebApp.Application.Queries;

public partial record GetSecondTestEntityTwoRelationshipsOneToManiesQuery() : IRequest<IQueryable<SecondTestEntityTwoRelationshipsOneToManyDto>>;

internal partial class GetSecondTestEntityTwoRelationshipsOneToManiesQueryHandler: GetSecondTestEntityTwoRelationshipsOneToManiesQueryHandlerBase
{
    public GetSecondTestEntityTwoRelationshipsOneToManiesQueryHandler(IReadOnlyRepository readOnlyRepository): base(readOnlyRepository){}
}

internal abstract class GetSecondTestEntityTwoRelationshipsOneToManiesQueryHandlerBase : QueryBase<IQueryable<SecondTestEntityTwoRelationshipsOneToManyDto>>, IRequestHandler<GetSecondTestEntityTwoRelationshipsOneToManiesQuery, IQueryable<SecondTestEntityTwoRelationshipsOneToManyDto>>
{
    public  GetSecondTestEntityTwoRelationshipsOneToManiesQueryHandlerBase(IReadOnlyRepository readOnlyRepository)
    {
        ReadOnlyRepository = readOnlyRepository;
    }

    public IReadOnlyRepository ReadOnlyRepository { get; }

    public virtual Task<IQueryable<SecondTestEntityTwoRelationshipsOneToManyDto>> Handle(GetSecondTestEntityTwoRelationshipsOneToManiesQuery request, CancellationToken cancellationToken)
    {
        var query = ReadOnlyRepository.Query<SecondTestEntityTwoRelationshipsOneToManyDto>();
       return Task.FromResult(OnResponse(query));
    }
}