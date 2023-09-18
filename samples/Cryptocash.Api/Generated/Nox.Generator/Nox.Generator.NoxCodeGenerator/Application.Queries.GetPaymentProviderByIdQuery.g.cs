// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using Cryptocash.Application.Dto;
using Cryptocash.Infrastructure.Persistence;

namespace Cryptocash.Application.Queries;

public record GetPaymentProviderByIdQuery(System.Int64 keyId) : IRequest <IQueryable<PaymentProviderDto>>;

public partial class GetPaymentProviderByIdQueryHandler:  QueryBase<IQueryable<PaymentProviderDto>>, IRequestHandler<GetPaymentProviderByIdQuery, IQueryable<PaymentProviderDto>>
{
    public  GetPaymentProviderByIdQueryHandler(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public Task<IQueryable<PaymentProviderDto>> Handle(GetPaymentProviderByIdQuery request, CancellationToken cancellationToken)
    {    
        var query = DataDbContext.PaymentProviders
            .AsNoTracking()
            .Where(r =>
                r.Id.Equals(request.keyId) &&
                r.DeletedAtUtc == null);
        return Task.FromResult(OnResponse(query));
    }
}