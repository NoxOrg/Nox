// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Queries;
using Nox.Application.Repositories;
using TestWebApp.Application.Dto;
using TestWebApp.Infrastructure.Persistence;

namespace TestWebApp.Application.Queries;

public partial record GetTestEntityExactlyOneToZeroOrManiesQuery() : IRequest<IQueryable<TestEntityExactlyOneToZeroOrManyDto>>;

internal partial class GetTestEntityExactlyOneToZeroOrManiesQueryHandler: GetTestEntityExactlyOneToZeroOrManiesQueryHandlerBase
{
    public GetTestEntityExactlyOneToZeroOrManiesQueryHandler(IReadOnlyRepository readOnlyRepository): base(readOnlyRepository){}
}

internal abstract class GetTestEntityExactlyOneToZeroOrManiesQueryHandlerBase : QueryBase<IQueryable<TestEntityExactlyOneToZeroOrManyDto>>, IRequestHandler<GetTestEntityExactlyOneToZeroOrManiesQuery, IQueryable<TestEntityExactlyOneToZeroOrManyDto>>
{
    public  GetTestEntityExactlyOneToZeroOrManiesQueryHandlerBase(IReadOnlyRepository readOnlyRepository)
    {
        ReadOnlyRepository = readOnlyRepository;
    }

    public IReadOnlyRepository ReadOnlyRepository { get; }

    public virtual Task<IQueryable<TestEntityExactlyOneToZeroOrManyDto>> Handle(GetTestEntityExactlyOneToZeroOrManiesQuery request, CancellationToken cancellationToken)
    {
        var query = ReadOnlyRepository.Query<TestEntityExactlyOneToZeroOrManyDto>();
       return Task.FromResult(OnResponse(query));
    }
}