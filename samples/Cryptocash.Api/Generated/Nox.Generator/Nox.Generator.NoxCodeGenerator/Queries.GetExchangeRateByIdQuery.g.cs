// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using CryptocashApi.Application.Dto;
using CryptocashApi.Infrastructure.Persistence;

namespace CryptocashApi.Application.Queries;

public record GetExchangeRateByIdQuery(System.Int64 keyId) : IRequest<ExchangeRateDto?>;

public class GetExchangeRateByIdQueryHandler: IRequestHandler<GetExchangeRateByIdQuery, ExchangeRateDto?>
{
    public  GetExchangeRateByIdQueryHandler(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public Task<ExchangeRateDto?> Handle(GetExchangeRateByIdQuery request, CancellationToken cancellationToken)
    {    
        var item = DataDbContext.ExchangeRates
            .AsNoTracking()
            .SingleOrDefault(r =>
                r.Id.Equals(request.keyId) &&
                r.DeletedAtUtc == null);
        return Task.FromResult(item);
    }
}