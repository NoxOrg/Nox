// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Queries;
using Nox.Application.Repositories;
using Cryptocash.Application.Dto;
using Cryptocash.Infrastructure.Persistence;

namespace Cryptocash.Application.Queries;

public partial record GetPaymentProvidersQuery() : IRequest<IQueryable<PaymentProviderDto>>;

internal partial class GetPaymentProvidersQueryHandler: GetPaymentProvidersQueryHandlerBase
{
    public GetPaymentProvidersQueryHandler(IReadOnlyRepository readOnlyRepository): base(readOnlyRepository){}
}

internal abstract class GetPaymentProvidersQueryHandlerBase : QueryBase<IQueryable<PaymentProviderDto>>, IRequestHandler<GetPaymentProvidersQuery, IQueryable<PaymentProviderDto>>
{
    public  GetPaymentProvidersQueryHandlerBase(IReadOnlyRepository readOnlyRepository)
    {
        ReadOnlyRepository = readOnlyRepository;
    }

    public IReadOnlyRepository ReadOnlyRepository { get; }

    public virtual Task<IQueryable<PaymentProviderDto>> Handle(GetPaymentProvidersQuery request, CancellationToken cancellationToken)
    {
        var query = ReadOnlyRepository.Query<PaymentProviderDto>();
       return Task.FromResult(OnResponse(query));
    }
}