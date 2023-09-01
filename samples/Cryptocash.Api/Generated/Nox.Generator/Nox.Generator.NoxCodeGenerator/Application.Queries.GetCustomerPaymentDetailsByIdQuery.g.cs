// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using Cryptocash.Application.Dto;
using Cryptocash.Infrastructure.Persistence;

namespace Cryptocash.Application.Queries;

public record GetCustomerPaymentDetailsByIdQuery(System.Int64 keyId) : IRequest <CustomerPaymentDetailsDto?>;

public partial class GetCustomerPaymentDetailsByIdQueryHandler:  QueryBase<CustomerPaymentDetailsDto?>, IRequestHandler<GetCustomerPaymentDetailsByIdQuery, CustomerPaymentDetailsDto?>
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
        return Task.FromResult(OnResponse(item));
    }
}