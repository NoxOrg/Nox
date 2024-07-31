// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Queries;
using Nox.Application.Repositories;
using TestWebApp.Application.Dto;

namespace TestWebApp.Application.Queries;

public partial record GetThirdTestEntityOneOrManiesQuery() : IRequest<IQueryable<ThirdTestEntityOneOrManyDto>>;

internal partial class GetThirdTestEntityOneOrManiesQueryHandler: GetThirdTestEntityOneOrManiesQueryHandlerBase
{
    public GetThirdTestEntityOneOrManiesQueryHandler(IReadOnlyRepository readOnlyRepository): base(readOnlyRepository){}
}

internal abstract class GetThirdTestEntityOneOrManiesQueryHandlerBase : QueryBase<IQueryable<ThirdTestEntityOneOrManyDto>>, IRequestHandler<GetThirdTestEntityOneOrManiesQuery, IQueryable<ThirdTestEntityOneOrManyDto>>
{
    public  GetThirdTestEntityOneOrManiesQueryHandlerBase(IReadOnlyRepository readOnlyRepository)
    {
        ReadOnlyRepository = readOnlyRepository;
    }

    public IReadOnlyRepository ReadOnlyRepository { get; }

    public virtual Task<IQueryable<ThirdTestEntityOneOrManyDto>> Handle(GetThirdTestEntityOneOrManiesQuery request, CancellationToken cancellationToken)
    {
        var query = ReadOnlyRepository.Query<ThirdTestEntityOneOrManyDto>();
       return Task.FromResult(OnResponse(query));
    }
}