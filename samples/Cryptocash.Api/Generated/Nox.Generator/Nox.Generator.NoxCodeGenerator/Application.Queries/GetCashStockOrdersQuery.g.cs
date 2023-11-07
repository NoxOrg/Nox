// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using Cryptocash.Application.Dto;
using Cryptocash.Infrastructure.Persistence;

namespace Cryptocash.Application.Queries;

public partial record GetCashStockOrdersQuery() : IRequest<IQueryable<CashStockOrderDto>>;

internal partial class GetCashStockOrdersQueryHandler: GetCashStockOrdersQueryHandlerBase
{
    public GetCashStockOrdersQueryHandler(DtoDbContext dataDbContext): base(dataDbContext)
    {
    
    }
}

internal abstract class GetCashStockOrdersQueryHandlerBase : QueryBase<IQueryable<CashStockOrderDto>>, IRequestHandler<GetCashStockOrdersQuery, IQueryable<CashStockOrderDto>>
{
    public  GetCashStockOrdersQueryHandlerBase(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public virtual Task<IQueryable<CashStockOrderDto>> Handle(GetCashStockOrdersQuery request, CancellationToken cancellationToken)
    {
        var item = (IQueryable<CashStockOrderDto>)DataDbContext.CashStockOrders
            .AsNoTracking();
       return Task.FromResult(OnResponse(item));
    }
}