// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using Cryptocash.Application.Dto;
using Cryptocash.Infrastructure.Persistence;

namespace Cryptocash.Application.Queries;

public record GetPaymentProvidersQuery() : IRequest<IQueryable<PaymentProviderDto>>;

public partial class GetPaymentProvidersQueryHandler: GetPaymentProvidersQueryHandlerBase
{
    public GetPaymentProvidersQueryHandler(DtoDbContext dataDbContext): base(dataDbContext)
    {
    
    }
}

public partial class GetPaymentProvidersQueryHandlerBase : QueryBase<IQueryable<PaymentProviderDto>>, IRequestHandler<GetPaymentProvidersQuery, IQueryable<PaymentProviderDto>>
{
    public  GetPaymentProvidersQueryHandlerBase(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public virtual Task<IQueryable<PaymentProviderDto>> Handle(GetPaymentProvidersQuery request, CancellationToken cancellationToken)
    {
        var item = (IQueryable<PaymentProviderDto>)DataDbContext.PaymentProviders
            .Where(r => r.DeletedAtUtc == null)
            .AsNoTracking();
       return Task.FromResult(OnResponse(item));
    }
}