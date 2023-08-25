// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using CryptocashApi.Application.Dto;
using CryptocashApi.Infrastructure.Persistence;

namespace CryptocashApi.Application.Queries;

public record GetCustomerPaymentDetailsQuery() : IRequest<IQueryable<CustomerPaymentDetailsDto>>;

public class GetCustomerPaymentDetailsQueryHandler : IRequestHandler<GetCustomerPaymentDetailsQuery, IQueryable<CustomerPaymentDetailsDto>>
{
    public  GetCustomerPaymentDetailsQueryHandler(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public Task<IQueryable<CustomerPaymentDetailsDto>> Handle(GetCustomerPaymentDetailsQuery request, CancellationToken cancellationToken)
    {
        var item = (IQueryable<CustomerPaymentDetailsDto>)DataDbContext.CustomerPaymentDetails
            .Where(r => r.DeletedAtUtc == null)
            .AsNoTracking();
        return Task.FromResult(item);
    }
}