// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using Cryptocash.Application.Dto;
using Cryptocash.Infrastructure.Persistence;

namespace Cryptocash.Application.Queries;

public partial record Get MinimumCashStockByIdQuery(System.Int64 keyId) : IRequest <IQueryable<MinimumCashStockDto>>;

internal partial class GetMinimumCashStockByIdQueryHandler:GetMinimumCashStockByIdQueryHandlerBase
{
    public  GetMinimumCashStockByIdQueryHandler(DtoDbContext dataDbContext): base(dataDbContext)
    {
    
    }
}

internal abstract class GetMinimumCashStockByIdQueryHandlerBase:  QueryBase<IQueryable<MinimumCashStockDto>>, IRequestHandler<GetMinimumCashStockByIdQuery, IQueryable<MinimumCashStockDto>>
{
    public  GetMinimumCashStockByIdQueryHandlerBase(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public virtual Task<IQueryable<MinimumCashStockDto>> Handle(GetMinimumCashStockByIdQuery request, CancellationToken cancellationToken)
    {    
        var query = DataDbContext.MinimumCashStocks
            .AsNoTracking()
            .Where(r =>
                r.Id.Equals(request.keyId));
        return Task.FromResult(OnResponse(query));
    }
}