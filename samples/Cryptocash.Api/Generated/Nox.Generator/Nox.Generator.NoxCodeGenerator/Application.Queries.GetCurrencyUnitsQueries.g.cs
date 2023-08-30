// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using CryptocashApi.Application.Dto;
using CryptocashApi.Infrastructure.Persistence;

namespace CryptocashApi.Application.Queries;

public record GetCurrencyUnitsQuery() : IRequest<IQueryable<CurrencyUnitsDto>>;

public partial class GetCurrencyUnitsQueryHandler : QueryBase<IQueryable<CurrencyUnitsDto>>, IRequestHandler<GetCurrencyUnitsQuery, IQueryable<CurrencyUnitsDto>>
{
    public  GetCurrencyUnitsQueryHandler(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public Task<IQueryable<CurrencyUnitsDto>> Handle(GetCurrencyUnitsQuery request, CancellationToken cancellationToken)
    {
        var item = (IQueryable<CurrencyUnitsDto>)DataDbContext.CurrencyUnits
            .Where(r => r.DeletedAtUtc == null)
            .AsNoTracking();
       return Task.FromResult(OnResponse(item));
    }
}