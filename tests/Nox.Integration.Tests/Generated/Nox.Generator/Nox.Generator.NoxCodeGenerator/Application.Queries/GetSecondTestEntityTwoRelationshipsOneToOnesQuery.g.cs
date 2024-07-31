// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Queries;
using Nox.Application.Repositories;
using TestWebApp.Application.Dto;

namespace TestWebApp.Application.Queries;

public partial record GetSecondTestEntityTwoRelationshipsOneToOnesQuery() : IRequest<IQueryable<SecondTestEntityTwoRelationshipsOneToOneDto>>;

internal partial class GetSecondTestEntityTwoRelationshipsOneToOnesQueryHandler: GetSecondTestEntityTwoRelationshipsOneToOnesQueryHandlerBase
{
    public GetSecondTestEntityTwoRelationshipsOneToOnesQueryHandler(IReadOnlyRepository readOnlyRepository): base(readOnlyRepository){}
}

internal abstract class GetSecondTestEntityTwoRelationshipsOneToOnesQueryHandlerBase : QueryBase<IQueryable<SecondTestEntityTwoRelationshipsOneToOneDto>>, IRequestHandler<GetSecondTestEntityTwoRelationshipsOneToOnesQuery, IQueryable<SecondTestEntityTwoRelationshipsOneToOneDto>>
{
    public  GetSecondTestEntityTwoRelationshipsOneToOnesQueryHandlerBase(IReadOnlyRepository readOnlyRepository)
    {
        ReadOnlyRepository = readOnlyRepository;
    }

    public IReadOnlyRepository ReadOnlyRepository { get; }

    public virtual Task<IQueryable<SecondTestEntityTwoRelationshipsOneToOneDto>> Handle(GetSecondTestEntityTwoRelationshipsOneToOnesQuery request, CancellationToken cancellationToken)
    {
        var query = ReadOnlyRepository.Query<SecondTestEntityTwoRelationshipsOneToOneDto>();
       return Task.FromResult(OnResponse(query));
    }
}