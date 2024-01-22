// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Queries;
using Nox.Application.Repositories;
using TestWebApp.Application.Dto;
using TestWebApp.Infrastructure.Persistence;

namespace TestWebApp.Application.Queries;

public partial record GetTestEntityZeroOrManyToOneOrManiesQuery() : IRequest<IQueryable<TestEntityZeroOrManyToOneOrManyDto>>;

internal partial class GetTestEntityZeroOrManyToOneOrManiesQueryHandler: GetTestEntityZeroOrManyToOneOrManiesQueryHandlerBase
{
    public GetTestEntityZeroOrManyToOneOrManiesQueryHandler(IReadOnlyRepository readOnlyRepository): base(readOnlyRepository){}
}

internal abstract class GetTestEntityZeroOrManyToOneOrManiesQueryHandlerBase : QueryBase<IQueryable<TestEntityZeroOrManyToOneOrManyDto>>, IRequestHandler<GetTestEntityZeroOrManyToOneOrManiesQuery, IQueryable<TestEntityZeroOrManyToOneOrManyDto>>
{
    public  GetTestEntityZeroOrManyToOneOrManiesQueryHandlerBase(IReadOnlyRepository readOnlyRepository)
    {
        ReadOnlyRepository = readOnlyRepository;
    }

    public IReadOnlyRepository ReadOnlyRepository { get; }

    public virtual Task<IQueryable<TestEntityZeroOrManyToOneOrManyDto>> Handle(GetTestEntityZeroOrManyToOneOrManiesQuery request, CancellationToken cancellationToken)
    {
        var query = ReadOnlyRepository.Query<TestEntityZeroOrManyToOneOrManyDto>();
       return Task.FromResult(OnResponse(query));
    }
}