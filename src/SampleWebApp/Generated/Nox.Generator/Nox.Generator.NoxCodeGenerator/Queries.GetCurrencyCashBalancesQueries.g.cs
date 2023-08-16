// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using SampleWebApp.Application.Dto;
using SampleWebApp.Presentation.Api.OData;

namespace SampleWebApp.Application.Queries;

public record GetCurrencyCashBalancesQuery() : IRequest<IQueryable<CurrencyCashBalanceDto>>;

public class GetCurrencyCashBalancesQueryHandler : IRequestHandler<GetCurrencyCashBalancesQuery, IQueryable<CurrencyCashBalanceDto>>
{
    public  GetCurrencyCashBalancesQueryHandler(ODataDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public ODataDbContext DataDbContext { get; }

    public Task<IQueryable<CurrencyCashBalanceDto>> Handle(GetCurrencyCashBalancesQuery request, CancellationToken cancellationToken)
    {
        var item = (IQueryable<CurrencyCashBalanceDto>)DataDbContext.CurrencyCashBalances
            .Where(r => !(r.IsDeleted == true))
            .AsNoTracking();
        return Task.FromResult(item);
    }
}