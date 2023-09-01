// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using Cryptocash.Application.Dto;
using Cryptocash.Infrastructure.Persistence;

namespace Cryptocash.Application.Queries;

public record GetMinimumCashStocksQuery() : IRequest<IQueryable<MinimumCashStockDto>>;

public partial class GetMinimumCashStocksQueryHandler : QueryBase<IQueryable<MinimumCashStockDto>>, IRequestHandler<GetMinimumCashStocksQuery, IQueryable<MinimumCashStockDto>>
{
    public  GetMinimumCashStocksQueryHandler(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public Task<IQueryable<MinimumCashStockDto>> Handle(GetMinimumCashStocksQuery request, CancellationToken cancellationToken)
    {
        var item = (IQueryable<MinimumCashStockDto>)DataDbContext.MinimumCashStocks
            .Where(r => r.DeletedAtUtc == null)
            .AsNoTracking();
       return Task.FromResult(OnResponse(item));
    }
}