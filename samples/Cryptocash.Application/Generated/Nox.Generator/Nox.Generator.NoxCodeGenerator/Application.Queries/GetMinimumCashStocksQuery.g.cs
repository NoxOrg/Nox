// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Queries;
using Nox.Application.Repositories;
using Cryptocash.Application.Dto;
using Cryptocash.Infrastructure.Persistence;

namespace Cryptocash.Application.Queries;

public partial record GetMinimumCashStocksQuery() : IRequest<IQueryable<MinimumCashStockDto>>;

internal partial class GetMinimumCashStocksQueryHandler: GetMinimumCashStocksQueryHandlerBase
{
    public GetMinimumCashStocksQueryHandler(IReadOnlyRepository readOnlyRepository): base(readOnlyRepository){}
}

internal abstract class GetMinimumCashStocksQueryHandlerBase : QueryBase<IQueryable<MinimumCashStockDto>>, IRequestHandler<GetMinimumCashStocksQuery, IQueryable<MinimumCashStockDto>>
{
    public  GetMinimumCashStocksQueryHandlerBase(IReadOnlyRepository readOnlyRepository)
    {
        ReadOnlyRepository = readOnlyRepository;
    }

    public IReadOnlyRepository ReadOnlyRepository { get; }

    public virtual Task<IQueryable<MinimumCashStockDto>> Handle(GetMinimumCashStocksQuery request, CancellationToken cancellationToken)
    {
        var query = ReadOnlyRepository.Query<MinimumCashStockDto>();
       return Task.FromResult(OnResponse(query));
    }
}