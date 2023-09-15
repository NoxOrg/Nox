// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using Cryptocash.Application.Dto;
using Cryptocash.Infrastructure.Persistence;

namespace Cryptocash.Application.Queries;

public record GetCashStockOrderByIdQuery(System.Int64 keyId) : IRequest <IQueryable<CashStockOrderDto>>;

public partial class GetCashStockOrderByIdQueryHandler:  QueryBase<IQueryable<CashStockOrderDto>>, IRequestHandler<GetCashStockOrderByIdQuery, IQueryable<CashStockOrderDto>>
{
    public  GetCashStockOrderByIdQueryHandler(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public Task<IQueryable<CashStockOrderDto>> Handle(GetCashStockOrderByIdQuery request, CancellationToken cancellationToken)
    {    
        var query = DataDbContext.CashStockOrders
            .AsNoTracking()
            .Where(r =>
                r.Id.Equals(request.keyId) &&
                r.DeletedAtUtc == null);
        return Task.FromResult(OnResponse(query));
    }
}