// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Queries;
using Nox.Application.Repositories;
using TestWebApp.Application.Dto;
using TestWebApp.Infrastructure.Persistence;

namespace TestWebApp.Application.Queries;

public partial record GetSecondTestEntityZeroOrManiesQuery() : IRequest<IQueryable<SecondTestEntityZeroOrManyDto>>;

internal partial class GetSecondTestEntityZeroOrManiesQueryHandler: GetSecondTestEntityZeroOrManiesQueryHandlerBase
{
    public GetSecondTestEntityZeroOrManiesQueryHandler(IReadOnlyRepository readOnlyRepository): base(readOnlyRepository){}
}

internal abstract class GetSecondTestEntityZeroOrManiesQueryHandlerBase : QueryBase<IQueryable<SecondTestEntityZeroOrManyDto>>, IRequestHandler<GetSecondTestEntityZeroOrManiesQuery, IQueryable<SecondTestEntityZeroOrManyDto>>
{
    public  GetSecondTestEntityZeroOrManiesQueryHandlerBase(IReadOnlyRepository readOnlyRepository)
    {
        ReadOnlyRepository = readOnlyRepository;
    }

    public IReadOnlyRepository ReadOnlyRepository { get; }

    public virtual Task<IQueryable<SecondTestEntityZeroOrManyDto>> Handle(GetSecondTestEntityZeroOrManiesQuery request, CancellationToken cancellationToken)
    {
        var query = ReadOnlyRepository.Query<SecondTestEntityZeroOrManyDto>();
       return Task.FromResult(OnResponse(query));
    }
}