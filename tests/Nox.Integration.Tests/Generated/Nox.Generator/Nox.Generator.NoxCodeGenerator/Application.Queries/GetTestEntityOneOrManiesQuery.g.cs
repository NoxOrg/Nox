// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Queries;
using Nox.Application.Repositories;
using TestWebApp.Application.Dto;
using TestWebApp.Infrastructure.Persistence;

namespace TestWebApp.Application.Queries;

public partial record GetTestEntityOneOrManiesQuery() : IRequest<IQueryable<TestEntityOneOrManyDto>>;

internal partial class GetTestEntityOneOrManiesQueryHandler: GetTestEntityOneOrManiesQueryHandlerBase
{
    public GetTestEntityOneOrManiesQueryHandler(IReadOnlyRepository readOnlyRepository): base(readOnlyRepository){}
}

internal abstract class GetTestEntityOneOrManiesQueryHandlerBase : QueryBase<IQueryable<TestEntityOneOrManyDto>>, IRequestHandler<GetTestEntityOneOrManiesQuery, IQueryable<TestEntityOneOrManyDto>>
{
    public  GetTestEntityOneOrManiesQueryHandlerBase(IReadOnlyRepository readOnlyRepository)
    {
        ReadOnlyRepository = readOnlyRepository;
    }

    public IReadOnlyRepository ReadOnlyRepository { get; }

    public virtual Task<IQueryable<TestEntityOneOrManyDto>> Handle(GetTestEntityOneOrManiesQuery request, CancellationToken cancellationToken)
    {
        var query = ReadOnlyRepository.Query<TestEntityOneOrManyDto>();
       return Task.FromResult(OnResponse(query));
    }
}