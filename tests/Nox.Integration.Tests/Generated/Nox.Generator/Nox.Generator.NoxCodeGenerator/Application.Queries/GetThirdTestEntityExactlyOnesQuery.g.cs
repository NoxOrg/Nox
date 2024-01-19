// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Queries;
using Nox.Application.Repositories;
using TestWebApp.Application.Dto;
using TestWebApp.Infrastructure.Persistence;

namespace TestWebApp.Application.Queries;

public partial record GetThirdTestEntityExactlyOnesQuery() : IRequest<IQueryable<ThirdTestEntityExactlyOneDto>>;

internal partial class GetThirdTestEntityExactlyOnesQueryHandler: GetThirdTestEntityExactlyOnesQueryHandlerBase
{
    public GetThirdTestEntityExactlyOnesQueryHandler(IReadOnlyRepository readOnlyRepository): base(readOnlyRepository){}
}

internal abstract class GetThirdTestEntityExactlyOnesQueryHandlerBase : QueryBase<IQueryable<ThirdTestEntityExactlyOneDto>>, IRequestHandler<GetThirdTestEntityExactlyOnesQuery, IQueryable<ThirdTestEntityExactlyOneDto>>
{
    public  GetThirdTestEntityExactlyOnesQueryHandlerBase(IReadOnlyRepository readOnlyRepository)
    {
        ReadOnlyRepository = readOnlyRepository;
    }

    public IReadOnlyRepository ReadOnlyRepository { get; }

    public virtual Task<IQueryable<ThirdTestEntityExactlyOneDto>> Handle(GetThirdTestEntityExactlyOnesQuery request, CancellationToken cancellationToken)
    {
        var query = ReadOnlyRepository.Query<ThirdTestEntityExactlyOneDto>();
       return Task.FromResult(OnResponse(query));
    }
}