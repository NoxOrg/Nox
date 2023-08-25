// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using CryptocashApi.Application.Dto;
using CryptocashApi.Infrastructure.Persistence;

namespace CryptocashApi.Application.Queries;

public record GetCustomerPaymentDetailsByIdQuery(System.Int64 keyId) : IRequest<CustomerPaymentDetailsDto?>;

public class GetCustomerPaymentDetailsByIdQueryHandler: IRequestHandler<GetCustomerPaymentDetailsByIdQuery, CustomerPaymentDetailsDto?>
{
    public  GetCustomerPaymentDetailsByIdQueryHandler(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public Task<CustomerPaymentDetailsDto?> Handle(GetCustomerPaymentDetailsByIdQuery request, CancellationToken cancellationToken)
    {    
        var item = DataDbContext.CustomerPaymentDetails
            .AsNoTracking()
            .SingleOrDefault(r =>
                r.Id.Equals(request.keyId) &&
                r.DeletedAtUtc == null);
        return Task.FromResult(item);
    }
}