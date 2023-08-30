// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using Cryptocash.Application.Dto;
using Cryptocash.Infrastructure.Persistence;

namespace Cryptocash.Application.Queries;

public record GetCurrenciesQuery() : IRequest<IQueryable<CurrencyDto>>;

public partial class GetCurrenciesQueryHandler : QueryBase<IQueryable<CurrencyDto>>, IRequestHandler<GetCurrenciesQuery, IQueryable<CurrencyDto>>
{
    public  GetCurrenciesQueryHandler(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public Task<IQueryable<CurrencyDto>> Handle(GetCurrenciesQuery request, CancellationToken cancellationToken)
    {
        var item = (IQueryable<CurrencyDto>)DataDbContext.Currencies
            .Where(r => r.DeletedAtUtc == null)
            .AsNoTracking();
       return Task.FromResult(OnResponse(item));
    }
}