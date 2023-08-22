// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using SampleWebApp.Application.Dto;
using SampleWebApp.Infrastructure.Persistence;

namespace SampleWebApp.Application.Queries;

public record GetCurrencyCashBalancesQuery() : IRequest<IQueryable<CurrencyCashBalanceDto>>;

public class GetCurrencyCashBalancesQueryHandler : IRequestHandler<GetCurrencyCashBalancesQuery, IQueryable<CurrencyCashBalanceDto>>
{
    public  GetCurrencyCashBalancesQueryHandler(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public Task<IQueryable<CurrencyCashBalanceDto>> Handle(GetCurrencyCashBalancesQuery request, CancellationToken cancellationToken)
    {
        var item = (IQueryable<CurrencyCashBalanceDto>)DataDbContext.CurrencyCashBalances
            .Where(r => r.DeletedAtUtc == null)
            .AsNoTracking();
        return Task.FromResult(item);
    }
}