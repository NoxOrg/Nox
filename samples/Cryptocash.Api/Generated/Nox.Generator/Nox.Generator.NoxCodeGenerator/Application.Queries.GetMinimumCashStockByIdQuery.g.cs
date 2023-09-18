// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using Cryptocash.Application.Dto;
using Cryptocash.Infrastructure.Persistence;

namespace Cryptocash.Application.Queries;

public record GetMinimumCashStockByIdQuery(System.Int64 keyId) : IRequest <IQueryable<MinimumCashStockDto>>;

public partial class GetMinimumCashStockByIdQueryHandler:  QueryBase<IQueryable<MinimumCashStockDto>>, IRequestHandler<GetMinimumCashStockByIdQuery, IQueryable<MinimumCashStockDto>>
{
    public  GetMinimumCashStockByIdQueryHandler(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public Task<IQueryable<MinimumCashStockDto>> Handle(GetMinimumCashStockByIdQuery request, CancellationToken cancellationToken)
    {    
        var query = DataDbContext.MinimumCashStocks
            .AsNoTracking()
            .Where(r =>
                r.Id.Equals(request.keyId) &&
                r.DeletedAtUtc == null);
        return Task.FromResult(OnResponse(query));
    }
}