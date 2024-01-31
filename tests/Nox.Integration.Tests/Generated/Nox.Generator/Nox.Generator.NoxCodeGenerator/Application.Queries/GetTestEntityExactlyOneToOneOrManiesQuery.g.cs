// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Queries;
using Nox.Application.Repositories;
using TestWebApp.Application.Dto;

namespace TestWebApp.Application.Queries;

public partial record GetTestEntityExactlyOneToOneOrManiesQuery() : IRequest<IQueryable<TestEntityExactlyOneToOneOrManyDto>>;

internal partial class GetTestEntityExactlyOneToOneOrManiesQueryHandler: GetTestEntityExactlyOneToOneOrManiesQueryHandlerBase
{
    public GetTestEntityExactlyOneToOneOrManiesQueryHandler(IReadOnlyRepository readOnlyRepository): base(readOnlyRepository){}
}

internal abstract class GetTestEntityExactlyOneToOneOrManiesQueryHandlerBase : QueryBase<IQueryable<TestEntityExactlyOneToOneOrManyDto>>, IRequestHandler<GetTestEntityExactlyOneToOneOrManiesQuery, IQueryable<TestEntityExactlyOneToOneOrManyDto>>
{
    public  GetTestEntityExactlyOneToOneOrManiesQueryHandlerBase(IReadOnlyRepository readOnlyRepository)
    {
        ReadOnlyRepository = readOnlyRepository;
    }

    public IReadOnlyRepository ReadOnlyRepository { get; }

    public virtual Task<IQueryable<TestEntityExactlyOneToOneOrManyDto>> Handle(GetTestEntityExactlyOneToOneOrManiesQuery request, CancellationToken cancellationToken)
    {
        var query = ReadOnlyRepository.Query<TestEntityExactlyOneToOneOrManyDto>();
       return Task.FromResult(OnResponse(query));
    }
}