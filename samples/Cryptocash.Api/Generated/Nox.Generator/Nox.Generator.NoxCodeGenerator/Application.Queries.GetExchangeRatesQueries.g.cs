// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using Cryptocash.Application.Dto;
using Cryptocash.Infrastructure.Persistence;

namespace Cryptocash.Application.Queries;

public record GetExchangeRatesQuery() : IRequest<IQueryable<ExchangeRateDto>>;

public partial class GetExchangeRatesQueryHandler : QueryBase<IQueryable<ExchangeRateDto>>, IRequestHandler<GetExchangeRatesQuery, IQueryable<ExchangeRateDto>>
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
       return Task.FromResult(OnResponse(item));
    }
}