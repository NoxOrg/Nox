// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using Cryptocash.Application.Dto;
using Cryptocash.Infrastructure.Persistence;

namespace Cryptocash.Application.Queries;

public record GetPaymentDetailByIdQuery(System.Int64 keyId) : IRequest <PaymentDetailDto?>;

public partial class GetPaymentDetailByIdQueryHandler:  QueryBase<PaymentDetailDto?>, IRequestHandler<GetPaymentDetailByIdQuery, PaymentDetailDto?>
{
    public  GetPaymentDetailByIdQueryHandler(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public Task<PaymentDetailDto?> Handle(GetPaymentDetailByIdQuery request, CancellationToken cancellationToken)
    {    
        var item = DataDbContext.PaymentDetails
            .AsNoTracking()
            .Include(r => r.PaymentDetailsUsedByCustomer)
            .Include(r => r.PaymentDetailsRelatedPaymentProvider)
            .SingleOrDefault(r =>
                r.Id.Equals(request.keyId) &&
                r.DeletedAtUtc == null);
        return Task.FromResult(OnResponse(item));
    }
}