// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using CryptocashApi.Application.Dto;
using CryptocashApi.Infrastructure.Persistence;

namespace CryptocashApi.Application.Queries;

public record GetExchangeRatesQuery() : IRequest<IQueryable<ExchangeRateDto>>;

public class GetExchangeRatesQueryHandler : IRequestHandler<GetExchangeRatesQuery, IQueryable<ExchangeRateDto>>
{
    public  GetExchangeRatesQueryHandler(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public Task<IQueryable<ExchangeRateDto>> Handle(GetExchangeRatesQuery request, CancellationToken cancellationToken)
    {
        var item = (IQueryable<ExchangeRateDto>)DataDbContext.ExchangeRates
            .Where(r => r.DeletedAtUtc == null)
            .AsNoTracking();
        return Task.FromResult(item);
    }
}