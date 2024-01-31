// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Queries;
using Nox.Application.Repositories;
using TestWebApp.Application.Dto;

namespace TestWebApp.Application.Queries;

public partial record GetSecondTestEntityOneOrManiesQuery() : IRequest<IQueryable<SecondTestEntityOneOrManyDto>>;

internal partial class GetSecondTestEntityOneOrManiesQueryHandler: GetSecondTestEntityOneOrManiesQueryHandlerBase
{
    public GetSecondTestEntityOneOrManiesQueryHandler(IReadOnlyRepository readOnlyRepository): base(readOnlyRepository){}
}

internal abstract class GetSecondTestEntityOneOrManiesQueryHandlerBase : QueryBase<IQueryable<SecondTestEntityOneOrManyDto>>, IRequestHandler<GetSecondTestEntityOneOrManiesQuery, IQueryable<SecondTestEntityOneOrManyDto>>
{
    public  GetSecondTestEntityOneOrManiesQueryHandlerBase(IReadOnlyRepository readOnlyRepository)
    {
        ReadOnlyRepository = readOnlyRepository;
    }

    public IReadOnlyRepository ReadOnlyRepository { get; }

    public virtual Task<IQueryable<SecondTestEntityOneOrManyDto>> Handle(GetSecondTestEntityOneOrManiesQuery request, CancellationToken cancellationToken)
    {
        var query = ReadOnlyRepository.Query<SecondTestEntityOneOrManyDto>();
       return Task.FromResult(OnResponse(query));
    }
}