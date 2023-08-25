// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using CryptocashApi.Application.Dto;
using CryptocashApi.Infrastructure.Persistence;

namespace CryptocashApi.Application.Queries;

public record GetPaymentProvidersQuery() : IRequest<IQueryable<PaymentProviderDto>>;

public class GetPaymentProvidersQueryHandler : IRequestHandler<GetPaymentProvidersQuery, IQueryable<PaymentProviderDto>>
{
    public  GetPaymentProvidersQueryHandler(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public Task<IQueryable<PaymentProviderDto>> Handle(GetPaymentProvidersQuery request, CancellationToken cancellationToken)
    {
        var item = (IQueryable<PaymentProviderDto>)DataDbContext.PaymentProviders
            .Where(r => r.DeletedAtUtc == null)
            .AsNoTracking();
        return Task.FromResult(item);
    }
}