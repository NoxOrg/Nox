// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using Cryptocash.Application.Dto;
using Cryptocash.Infrastructure.Persistence;

namespace Cryptocash.Application.Queries;

public partial record Get PaymentDetailByIdQuery(System.Int64 keyId) : IRequest <IQueryable<PaymentDetailDto>>;

internal partial class GetPaymentDetailByIdQueryHandler:GetPaymentDetailByIdQueryHandlerBase
{
    public  GetPaymentDetailByIdQueryHandler(DtoDbContext dataDbContext): base(dataDbContext)
    {
    
    }
}

internal abstract class GetPaymentDetailByIdQueryHandlerBase:  QueryBase<IQueryable<PaymentDetailDto>>, IRequestHandler<GetPaymentDetailByIdQuery, IQueryable<PaymentDetailDto>>
{
    public  GetPaymentDetailByIdQueryHandlerBase(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public virtual Task<IQueryable<PaymentDetailDto>> Handle(GetPaymentDetailByIdQuery request, CancellationToken cancellationToken)
    {    
        var query = DataDbContext.PaymentDetails
            .AsNoTracking()
            .Where(r =>
                r.Id.Equals(request.keyId));
        return Task.FromResult(OnResponse(query));
    }
}