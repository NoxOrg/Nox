// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Queries;
using Nox.Application.Repositories;
using TestWebApp.Application.Dto;
using TestWebApp.Infrastructure.Persistence;

namespace TestWebApp.Application.Queries;

public partial record GetTestEntityZeroOrManiesQuery() : IRequest<IQueryable<TestEntityZeroOrManyDto>>;

internal partial class GetTestEntityZeroOrManiesQueryHandler: GetTestEntityZeroOrManiesQueryHandlerBase
{
    public GetTestEntityZeroOrManiesQueryHandler(IReadOnlyRepository readOnlyRepository): base(readOnlyRepository){}
}

internal abstract class GetTestEntityZeroOrManiesQueryHandlerBase : QueryBase<IQueryable<TestEntityZeroOrManyDto>>, IRequestHandler<GetTestEntityZeroOrManiesQuery, IQueryable<TestEntityZeroOrManyDto>>
{
    public  GetTestEntityZeroOrManiesQueryHandlerBase(IReadOnlyRepository readOnlyRepository)
    {
        ReadOnlyRepository = readOnlyRepository;
    }

    public IReadOnlyRepository ReadOnlyRepository { get; }

    public virtual Task<IQueryable<TestEntityZeroOrManyDto>> Handle(GetTestEntityZeroOrManiesQuery request, CancellationToken cancellationToken)
    {
        var query = ReadOnlyRepository.Query<TestEntityZeroOrManyDto>();
       return Task.FromResult(OnResponse(query));
    }
}