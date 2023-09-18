// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using Cryptocash.Application.Dto;
using Cryptocash.Infrastructure.Persistence;

namespace Cryptocash.Application.Queries;

public record GetPaymentDetailsQuery() : IRequest<IQueryable<PaymentDetailDto>>;

public partial class GetPaymentDetailsQueryHandler: GetPaymentDetailsQueryHandlerBase
{
    public GetPaymentDetailsQueryHandler(DtoDbContext dataDbContext): base(dataDbContext)
    {
    
    }
}

public partial class GetPaymentDetailsQueryHandlerBase : QueryBase<IQueryable<PaymentDetailDto>>, IRequestHandler<GetPaymentDetailsQuery, IQueryable<PaymentDetailDto>>
{
    public  GetPaymentDetailsQueryHandlerBase(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public virtual Task<IQueryable<PaymentDetailDto>> Handle(GetPaymentDetailsQuery request, CancellationToken cancellationToken)
    {
        var item = (IQueryable<PaymentDetailDto>)DataDbContext.PaymentDetails
            .Where(r => r.DeletedAtUtc == null)
            .AsNoTracking();
       return Task.FromResult(OnResponse(item));
    }
}