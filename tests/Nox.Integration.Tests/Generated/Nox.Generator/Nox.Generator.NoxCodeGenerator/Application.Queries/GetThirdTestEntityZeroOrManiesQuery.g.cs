// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Queries;
using Nox.Application.Repositories;
using TestWebApp.Application.Dto;

namespace TestWebApp.Application.Queries;

public partial record GetThirdTestEntityZeroOrManiesQuery() : IRequest<IQueryable<ThirdTestEntityZeroOrManyDto>>;

internal partial class GetThirdTestEntityZeroOrManiesQueryHandler: GetThirdTestEntityZeroOrManiesQueryHandlerBase
{
    public GetThirdTestEntityZeroOrManiesQueryHandler(IReadOnlyRepository readOnlyRepository): base(readOnlyRepository){}
}

internal abstract class GetThirdTestEntityZeroOrManiesQueryHandlerBase : QueryBase<IQueryable<ThirdTestEntityZeroOrManyDto>>, IRequestHandler<GetThirdTestEntityZeroOrManiesQuery, IQueryable<ThirdTestEntityZeroOrManyDto>>
{
    public  GetThirdTestEntityZeroOrManiesQueryHandlerBase(IReadOnlyRepository readOnlyRepository)
    {
        ReadOnlyRepository = readOnlyRepository;
    }

    public IReadOnlyRepository ReadOnlyRepository { get; }

    public virtual Task<IQueryable<ThirdTestEntityZeroOrManyDto>> Handle(GetThirdTestEntityZeroOrManiesQuery request, CancellationToken cancellationToken)
    {
        var query = ReadOnlyRepository.Query<ThirdTestEntityZeroOrManyDto>();
       return Task.FromResult(OnResponse(query));
    }
}