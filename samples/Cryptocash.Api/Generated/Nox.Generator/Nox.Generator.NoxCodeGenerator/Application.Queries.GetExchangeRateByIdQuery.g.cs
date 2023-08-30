﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using Cryptocash.Application.Dto;
using Cryptocash.Infrastructure.Persistence;

namespace Cryptocash.Application.Queries;

public record GetExchangeRateByIdQuery(System.Int64 keyId) : IRequest <ExchangeRateDto?>;

public partial class GetExchangeRateByIdQueryHandler:  QueryBase<ExchangeRateDto?>, IRequestHandler<GetExchangeRateByIdQuery, ExchangeRateDto?>
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
        return Task.FromResult(OnResponse(item));
    }
}