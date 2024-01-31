// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Queries;
using Nox.Application.Repositories;
using TestWebApp.Application.Dto;

namespace TestWebApp.Application.Queries;

public partial record GetThirdTestEntityZeroOrOnesQuery() : IRequest<IQueryable<ThirdTestEntityZeroOrOneDto>>;

internal partial class GetThirdTestEntityZeroOrOnesQueryHandler: GetThirdTestEntityZeroOrOnesQueryHandlerBase
{
    public GetThirdTestEntityZeroOrOnesQueryHandler(IReadOnlyRepository readOnlyRepository): base(readOnlyRepository){}
}

internal abstract class GetThirdTestEntityZeroOrOnesQueryHandlerBase : QueryBase<IQueryable<ThirdTestEntityZeroOrOneDto>>, IRequestHandler<GetThirdTestEntityZeroOrOnesQuery, IQueryable<ThirdTestEntityZeroOrOneDto>>
{
    public  GetThirdTestEntityZeroOrOnesQueryHandlerBase(IReadOnlyRepository readOnlyRepository)
    {
        ReadOnlyRepository = readOnlyRepository;
    }

    public IReadOnlyRepository ReadOnlyRepository { get; }

    public virtual Task<IQueryable<ThirdTestEntityZeroOrOneDto>> Handle(GetThirdTestEntityZeroOrOnesQuery request, CancellationToken cancellationToken)
    {
        var query = ReadOnlyRepository.Query<ThirdTestEntityZeroOrOneDto>();
       return Task.FromResult(OnResponse(query));
    }
}