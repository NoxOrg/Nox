// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Queries;
using Nox.Application.Repositories;
using Cryptocash.Application.Dto;

namespace Cryptocash.Application.Queries;

public partial record GetCommissionsQuery() : IRequest<IQueryable<CommissionDto>>;

internal partial class GetCommissionsQueryHandler: GetCommissionsQueryHandlerBase
{
    public GetCommissionsQueryHandler(IReadOnlyRepository readOnlyRepository): base(readOnlyRepository){}
}

internal abstract class GetCommissionsQueryHandlerBase : QueryBase<IQueryable<CommissionDto>>, IRequestHandler<GetCommissionsQuery, IQueryable<CommissionDto>>
{
    public  GetCommissionsQueryHandlerBase(IReadOnlyRepository readOnlyRepository)
    {
        ReadOnlyRepository = readOnlyRepository;
    }

    public IReadOnlyRepository ReadOnlyRepository { get; }

    public virtual Task<IQueryable<CommissionDto>> Handle(GetCommissionsQuery request, CancellationToken cancellationToken)
    {
        var query = ReadOnlyRepository.Query<CommissionDto>();
       return Task.FromResult(OnResponse(query));
    }
}