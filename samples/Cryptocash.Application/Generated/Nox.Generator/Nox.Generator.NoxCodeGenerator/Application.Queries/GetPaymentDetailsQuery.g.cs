// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Queries;
using Nox.Application.Repositories;
using Cryptocash.Application.Dto;

namespace Cryptocash.Application.Queries;

public partial record GetPaymentDetailsQuery() : IRequest<IQueryable<PaymentDetailDto>>;

internal partial class GetPaymentDetailsQueryHandler: GetPaymentDetailsQueryHandlerBase
{
    public GetPaymentDetailsQueryHandler(IReadOnlyRepository readOnlyRepository): base(readOnlyRepository){}
}

internal abstract class GetPaymentDetailsQueryHandlerBase : QueryBase<IQueryable<PaymentDetailDto>>, IRequestHandler<GetPaymentDetailsQuery, IQueryable<PaymentDetailDto>>
{
    public  GetPaymentDetailsQueryHandlerBase(IReadOnlyRepository readOnlyRepository)
    {
        ReadOnlyRepository = readOnlyRepository;
    }

    public IReadOnlyRepository ReadOnlyRepository { get; }

    public virtual Task<IQueryable<PaymentDetailDto>> Handle(GetPaymentDetailsQuery request, CancellationToken cancellationToken)
    {
        var query = ReadOnlyRepository.Query<PaymentDetailDto>();
       return Task.FromResult(OnResponse(query));
    }
}