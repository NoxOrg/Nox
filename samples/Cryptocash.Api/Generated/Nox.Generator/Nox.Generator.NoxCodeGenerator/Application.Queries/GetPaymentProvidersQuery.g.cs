﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using Cryptocash.Application.Dto;
using Cryptocash.Infrastructure.Persistence;

namespace Cryptocash.Application.Queries;

public partial record GetPaymentProvidersQuery() : IRequest<IQueryable<PaymentProviderDto>>;

internal partial class GetPaymentProvidersQueryHandler: GetPaymentProvidersQueryHandlerBase
{
    public GetPaymentProvidersQueryHandler(DtoDbContext dataDbContext): base(dataDbContext)
    {
    
    }
}

internal abstract class GetPaymentProvidersQueryHandlerBase : QueryBase<IQueryable<PaymentProviderDto>>, IRequestHandler<GetPaymentProvidersQuery, IQueryable<PaymentProviderDto>>
{
    public  GetPaymentProvidersQueryHandlerBase(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public virtual Task<IQueryable<PaymentProviderDto>> Handle(GetPaymentProvidersQuery request, CancellationToken cancellationToken)
    {
        var item = (IQueryable<PaymentProviderDto>)DataDbContext.PaymentProviders
            .AsNoTracking();
       return Task.FromResult(OnResponse(item));
    }
}