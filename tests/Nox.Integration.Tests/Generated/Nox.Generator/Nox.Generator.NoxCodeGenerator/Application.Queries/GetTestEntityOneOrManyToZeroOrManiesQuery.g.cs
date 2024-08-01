// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Queries;
using Nox.Application.Repositories;
using TestWebApp.Application.Dto;

namespace TestWebApp.Application.Queries;

public partial record GetTestEntityOneOrManyToZeroOrManiesQuery() : IRequest<IQueryable<TestEntityOneOrManyToZeroOrManyDto>>;

internal partial class GetTestEntityOneOrManyToZeroOrManiesQueryHandler: GetTestEntityOneOrManyToZeroOrManiesQueryHandlerBase
{
    public GetTestEntityOneOrManyToZeroOrManiesQueryHandler(IReadOnlyRepository readOnlyRepository): base(readOnlyRepository){}
}

internal abstract class GetTestEntityOneOrManyToZeroOrManiesQueryHandlerBase : QueryBase<IQueryable<TestEntityOneOrManyToZeroOrManyDto>>, IRequestHandler<GetTestEntityOneOrManyToZeroOrManiesQuery, IQueryable<TestEntityOneOrManyToZeroOrManyDto>>
{
    public  GetTestEntityOneOrManyToZeroOrManiesQueryHandlerBase(IReadOnlyRepository readOnlyRepository)
    {
        ReadOnlyRepository = readOnlyRepository;
    }

    public IReadOnlyRepository ReadOnlyRepository { get; }

    public virtual Task<IQueryable<TestEntityOneOrManyToZeroOrManyDto>> Handle(GetTestEntityOneOrManyToZeroOrManiesQuery request, CancellationToken cancellationToken)
    {
        var query = ReadOnlyRepository.Query<TestEntityOneOrManyToZeroOrManyDto>();
       return Task.FromResult(OnResponse(query));
    }
}