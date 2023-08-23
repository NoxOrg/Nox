// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using SampleWebApp.Application.Dto;
using SampleWebApp.Infrastructure.Persistence;

namespace SampleWebApp.Application.Queries;

public record GetCurrencyCashBalanceByIdQuery(System.String keyStoreId, System.UInt32 keyCurrencyId) : IRequest<CurrencyCashBalanceDto?>;

public class GetCurrencyCashBalanceByIdQueryHandler: IRequestHandler<GetCurrencyCashBalanceByIdQuery, CurrencyCashBalanceDto?>
{
    public  GetCurrencyCashBalanceByIdQueryHandler(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public Task<CurrencyCashBalanceDto?> Handle(GetCurrencyCashBalanceByIdQuery request, CancellationToken cancellationToken)
    {    
        var item = DataDbContext.CurrencyCashBalances
            .AsNoTracking()
            .SingleOrDefault(r =>
                r.StoreId.Equals(request.keyStoreId) &&
                r.CurrencyId.Equals(request.keyCurrencyId) &&
                r.DeletedAtUtc == null);
        return Task.FromResult(item);
    }
}