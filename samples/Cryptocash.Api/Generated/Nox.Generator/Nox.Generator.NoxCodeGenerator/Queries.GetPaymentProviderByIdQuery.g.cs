﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using CryptocashApi.Application.Dto;
using CryptocashApi.Infrastructure.Persistence;

namespace CryptocashApi.Application.Queries;

public record GetPaymentProviderByIdQuery(System.Int64 keyId) : IRequest <PaymentProviderDto?>;

public partial class GetPaymentProviderByIdQueryHandler:  QueryBase<PaymentProviderDto?>, IRequestHandler<GetPaymentProviderByIdQuery, PaymentProviderDto?>
{
    public  GetPaymentProviderByIdQueryHandler(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public Task<PaymentProviderDto?> Handle(GetPaymentProviderByIdQuery request, CancellationToken cancellationToken)
    {    
        var item = DataDbContext.PaymentProviders
            .AsNoTracking()
            .SingleOrDefault(r =>
                r.Id.Equals(request.keyId) &&
                r.DeletedAtUtc == null);
        return Task.FromResult(OnResponse(item));
    }
}