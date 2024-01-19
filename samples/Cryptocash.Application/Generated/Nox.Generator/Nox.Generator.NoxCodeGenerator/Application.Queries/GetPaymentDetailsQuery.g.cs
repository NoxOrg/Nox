// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Queries;

using Cryptocash.Application.Dto;
using Cryptocash.Infrastructure.Persistence;

namespace Cryptocash.Application.Queries;

public partial record GetPaymentDetailsQuery() : IRequest<IQueryable<PaymentDetailDto>>;

internal partial class GetPaymentDetailsQueryHandler: GetPaymentDetailsQueryHandlerBase
{
    public GetPaymentDetailsQueryHandler(DtoDbContext dataDbContext): base(dataDbContext)
    {
    
    }
}

internal abstract class GetPaymentDetailsQueryHandlerBase : QueryBase<IQueryable<PaymentDetailDto>>, IRequestHandler<GetPaymentDetailsQuery, IQueryable<PaymentDetailDto>>
{
    public  GetPaymentDetailsQueryHandlerBase(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public virtual Task<IQueryable<PaymentDetailDto>> Handle(GetPaymentDetailsQuery request, CancellationToken cancellationToken)
    {
        var item = (IQueryable<PaymentDetailDto>)DataDbContext.PaymentDetails
            .AsNoTracking();
       return Task.FromResult(OnResponse(item));
    }
}