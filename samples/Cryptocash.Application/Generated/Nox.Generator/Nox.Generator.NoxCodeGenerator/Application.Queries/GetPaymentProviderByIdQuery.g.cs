// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Queries;
using Nox.Application.Repositories;

using Cryptocash.Application.Dto;
using Cryptocash.Infrastructure.Persistence;

namespace Cryptocash.Application.Queries;

public partial record GetPaymentProviderByIdQuery(System.Guid keyId) : IRequest <IQueryable<PaymentProviderDto>>;

internal partial class GetPaymentProviderByIdQueryHandler:GetPaymentProviderByIdQueryHandlerBase
{
    public GetPaymentProviderByIdQueryHandler(IReadOnlyRepository readOnlyRepository): base(readOnlyRepository){}
}

internal abstract class GetPaymentProviderByIdQueryHandlerBase:  QueryBase<IQueryable<PaymentProviderDto>>, IRequestHandler<GetPaymentProviderByIdQuery, IQueryable<PaymentProviderDto>>
{
    public  GetPaymentProviderByIdQueryHandlerBase(IReadOnlyRepository readOnlyRepository)
    {
        ReadOnlyRepository = readOnlyRepository;
    }

    public IReadOnlyRepository ReadOnlyRepository { get; }

    public virtual Task<IQueryable<PaymentProviderDto>> Handle(GetPaymentProviderByIdQuery request, CancellationToken cancellationToken)
    {    
        var query = ReadOnlyRepository.Query<PaymentProviderDto >()
            .Where(r =>
                r.Id.Equals(request.keyId));
        return Task.FromResult(OnResponse(query));
    }
}