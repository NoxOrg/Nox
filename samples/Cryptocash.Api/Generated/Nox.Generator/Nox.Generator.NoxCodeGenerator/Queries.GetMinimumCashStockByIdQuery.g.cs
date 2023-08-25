// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using CryptocashApi.Application.Dto;
using CryptocashApi.Infrastructure.Persistence;

namespace CryptocashApi.Application.Queries;

public record GetMinimumCashStockByIdQuery(System.Int64 keyId) : IRequest<MinimumCashStockDto?>;

public class GetMinimumCashStockByIdQueryHandler: IRequestHandler<GetMinimumCashStockByIdQuery, MinimumCashStockDto?>
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
            .SingleOrDefault(r =>
                r.Id.Equals(request.keyId) &&
                r.DeletedAtUtc == null);
        return Task.FromResult(item);
    }
}