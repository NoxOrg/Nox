// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using Cryptocash.Application.Dto;
using Cryptocash.Infrastructure.Persistence;

namespace Cryptocash.Application.Queries;

public record GetPaymentDetailsQuery() : IRequest<IQueryable<PaymentDetailDto>>;

public partial class GetPaymentDetailsQueryHandler : QueryBase<IQueryable<PaymentDetailDto>>, IRequestHandler<GetPaymentDetailsQuery, IQueryable<PaymentDetailDto>>
{
    public  GetPaymentDetailsQueryHandler(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public Task<IQueryable<PaymentDetailDto>> Handle(GetPaymentDetailsQuery request, CancellationToken cancellationToken)
    {
        var item = (IQueryable<PaymentDetailDto>)DataDbContext.PaymentDetails
            .Where(r => r.DeletedAtUtc == null)
            .AsNoTracking();
       return Task.FromResult(OnResponse(item));
    }
}