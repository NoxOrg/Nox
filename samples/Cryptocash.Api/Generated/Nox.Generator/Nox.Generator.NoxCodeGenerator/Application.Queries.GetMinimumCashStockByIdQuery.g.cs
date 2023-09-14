// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using Cryptocash.Application.Dto;
using Cryptocash.Infrastructure.Persistence;

namespace Cryptocash.Application.Queries;

public record GetMinimumCashStockByIdQuery(System.Int64 keyId) : IRequest <MinimumCashStockDto?>;

public partial class GetMinimumCashStockByIdQueryHandler:  QueryBase<MinimumCashStockDto?>, IRequestHandler<GetMinimumCashStockByIdQuery, MinimumCashStockDto?>
{
    public  GetMinimumCashStockByIdQueryHandler(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public Task<MinimumCashStockDto?> Handle(GetMinimumCashStockByIdQuery request, CancellationToken cancellationToken)
    {    
        var item = DataDbContext.MinimumCashStocks
            .AsNoTracking()
            .Include(r => r.MinimumCashStocksRequiredByVendingMachines)
            .Include(r => r.MinimumCashStockRelatedCurrency)
            .SingleOrDefault(r =>
                r.Id.Equals(request.keyId) &&
                r.DeletedAtUtc == null);
        return Task.FromResult(OnResponse(item));
    }
}