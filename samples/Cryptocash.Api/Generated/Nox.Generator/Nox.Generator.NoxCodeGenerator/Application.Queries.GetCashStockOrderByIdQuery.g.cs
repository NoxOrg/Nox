// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using Cryptocash.Application.Dto;
using Cryptocash.Infrastructure.Persistence;

namespace Cryptocash.Application.Queries;

public record GetCashStockOrderByIdQuery(System.Int64 keyId) : IRequest <CashStockOrderDto?>;

public partial class GetCashStockOrderByIdQueryHandler:  QueryBase<CashStockOrderDto?>, IRequestHandler<GetCashStockOrderByIdQuery, CashStockOrderDto?>
{
    public  GetCashStockOrderByIdQueryHandler(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public Task<CashStockOrderDto?> Handle(GetCashStockOrderByIdQuery request, CancellationToken cancellationToken)
    {    
        var item = DataDbContext.CashStockOrders
            .AsNoTracking()
            .SingleOrDefault(r =>
                r.Id.Equals(request.keyId) &&
                r.DeletedAtUtc == null);
        return Task.FromResult(OnResponse(item));
    }
}