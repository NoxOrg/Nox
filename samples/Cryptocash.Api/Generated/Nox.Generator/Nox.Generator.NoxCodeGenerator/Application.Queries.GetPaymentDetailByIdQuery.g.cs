// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using Cryptocash.Application.Dto;
using Cryptocash.Infrastructure.Persistence;

namespace Cryptocash.Application.Queries;

public record GetPaymentDetailByIdQuery(System.Int64 keyId) : IRequest <IQueryable<PaymentDetailDto>>;

public partial class GetPaymentDetailByIdQueryHandler:GetPaymentDetailByIdQueryHandlerBase
{
    public  GetPaymentDetailByIdQueryHandler(DtoDbContext dataDbContext): base(dataDbContext)
    {
    
    }
}

public abstract class GetPaymentDetailByIdQueryHandlerBase:  QueryBase<IQueryable<PaymentDetailDto>>, IRequestHandler<GetPaymentDetailByIdQuery, IQueryable<PaymentDetailDto>>
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
                r.Id.Equals(request.keyId) &&
                r.DeletedAtUtc == null);
        return Task.FromResult(OnResponse(query));
    }
}