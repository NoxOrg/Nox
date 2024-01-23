// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Queries;
using Nox.Application.Repositories;
using TestWebApp.Application.Dto;
using TestWebApp.Infrastructure.Persistence;

namespace TestWebApp.Application.Queries;

public partial record GetTestEntityZeroOrOneToZeroOrManiesQuery() : IRequest<IQueryable<TestEntityZeroOrOneToZeroOrManyDto>>;

internal partial class GetTestEntityZeroOrOneToZeroOrManiesQueryHandler: GetTestEntityZeroOrOneToZeroOrManiesQueryHandlerBase
{
    public GetTestEntityZeroOrOneToZeroOrManiesQueryHandler(IReadOnlyRepository readOnlyRepository): base(readOnlyRepository){}
}

internal abstract class GetTestEntityZeroOrOneToZeroOrManiesQueryHandlerBase : QueryBase<IQueryable<TestEntityZeroOrOneToZeroOrManyDto>>, IRequestHandler<GetTestEntityZeroOrOneToZeroOrManiesQuery, IQueryable<TestEntityZeroOrOneToZeroOrManyDto>>
{
    public  GetTestEntityZeroOrOneToZeroOrManiesQueryHandlerBase(IReadOnlyRepository readOnlyRepository)
    {
        ReadOnlyRepository = readOnlyRepository;
    }

    public IReadOnlyRepository ReadOnlyRepository { get; }

    public virtual Task<IQueryable<TestEntityZeroOrOneToZeroOrManyDto>> Handle(GetTestEntityZeroOrOneToZeroOrManiesQuery request, CancellationToken cancellationToken)
    {
        var query = ReadOnlyRepository.Query<TestEntityZeroOrOneToZeroOrManyDto>();
       return Task.FromResult(OnResponse(query));
    }
}