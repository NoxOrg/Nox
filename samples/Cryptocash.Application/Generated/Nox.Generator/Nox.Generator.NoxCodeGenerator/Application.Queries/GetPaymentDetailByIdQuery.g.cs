// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Queries;
using Nox.Application.Repositories;

using Cryptocash.Application.Dto;
using Cryptocash.Infrastructure.Persistence;

namespace Cryptocash.Application.Queries;

public partial record GetPaymentDetailByIdQuery(System.Int64 keyId) : IRequest <IQueryable<PaymentDetailDto>>;

internal partial class GetPaymentDetailByIdQueryHandler:GetPaymentDetailByIdQueryHandlerBase
{
    public GetPaymentDetailByIdQueryHandler(IReadOnlyRepository readOnlyRepository): base(readOnlyRepository){}
}

internal abstract class GetPaymentDetailByIdQueryHandlerBase:  QueryBase<IQueryable<PaymentDetailDto>>, IRequestHandler<GetPaymentDetailByIdQuery, IQueryable<PaymentDetailDto>>
{
    public  GetPaymentDetailByIdQueryHandlerBase(IReadOnlyRepository readOnlyRepository)
    {
        ReadOnlyRepository = readOnlyRepository;
    }

    public IReadOnlyRepository ReadOnlyRepository { get; }

    public virtual Task<IQueryable<PaymentDetailDto>> Handle(GetPaymentDetailByIdQuery request, CancellationToken cancellationToken)
    {    
        var query = ReadOnlyRepository.Query<PaymentDetailDto >()
            .Where(r =>
                r.Id.Equals(request.keyId));
        return Task.FromResult(OnResponse(query));
    }
}