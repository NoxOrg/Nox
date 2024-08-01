// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Queries;
using Nox.Application.Repositories;
using TestWebApp.Application.Dto;

namespace TestWebApp.Application.Queries;

public partial record GetTestEntityZeroOrOneToOneOrManiesQuery() : IRequest<IQueryable<TestEntityZeroOrOneToOneOrManyDto>>;

internal partial class GetTestEntityZeroOrOneToOneOrManiesQueryHandler: GetTestEntityZeroOrOneToOneOrManiesQueryHandlerBase
{
    public GetTestEntityZeroOrOneToOneOrManiesQueryHandler(IReadOnlyRepository readOnlyRepository): base(readOnlyRepository){}
}

internal abstract class GetTestEntityZeroOrOneToOneOrManiesQueryHandlerBase : QueryBase<IQueryable<TestEntityZeroOrOneToOneOrManyDto>>, IRequestHandler<GetTestEntityZeroOrOneToOneOrManiesQuery, IQueryable<TestEntityZeroOrOneToOneOrManyDto>>
{
    public  GetTestEntityZeroOrOneToOneOrManiesQueryHandlerBase(IReadOnlyRepository readOnlyRepository)
    {
        ReadOnlyRepository = readOnlyRepository;
    }

    public IReadOnlyRepository ReadOnlyRepository { get; }

    public virtual Task<IQueryable<TestEntityZeroOrOneToOneOrManyDto>> Handle(GetTestEntityZeroOrOneToOneOrManiesQuery request, CancellationToken cancellationToken)
    {
        var query = ReadOnlyRepository.Query<TestEntityZeroOrOneToOneOrManyDto>();
       return Task.FromResult(OnResponse(query));
    }
}