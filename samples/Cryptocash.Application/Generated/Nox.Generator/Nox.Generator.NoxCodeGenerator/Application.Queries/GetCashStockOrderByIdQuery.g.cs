// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Queries;
using Nox.Application.Repositories;

using Cryptocash.Application.Dto;
using Cryptocash.Infrastructure.Persistence;

namespace Cryptocash.Application.Queries;

public partial record GetCashStockOrderByIdQuery(System.Int64 keyId) : IRequest <IQueryable<CashStockOrderDto>>;

internal partial class GetCashStockOrderByIdQueryHandler:GetCashStockOrderByIdQueryHandlerBase
{
    public GetCashStockOrderByIdQueryHandler(IReadOnlyRepository readOnlyRepository): base(readOnlyRepository){}
}

internal abstract class GetCashStockOrderByIdQueryHandlerBase:  QueryBase<IQueryable<CashStockOrderDto>>, IRequestHandler<GetCashStockOrderByIdQuery, IQueryable<CashStockOrderDto>>
{
    public  GetCashStockOrderByIdQueryHandlerBase(IReadOnlyRepository readOnlyRepository)
    {
        ReadOnlyRepository = readOnlyRepository;
    }

    public IReadOnlyRepository ReadOnlyRepository { get; }

    public virtual Task<IQueryable<CashStockOrderDto>> Handle(GetCashStockOrderByIdQuery request, CancellationToken cancellationToken)
    {    
        var query = ReadOnlyRepository.Query<CashStockOrderDto >()
            .Where(r =>
                r.Id.Equals(request.keyId));
        return Task.FromResult(OnResponse(query));
    }
}