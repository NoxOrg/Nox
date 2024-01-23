// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Queries;
using Nox.Application.Repositories;
using Cryptocash.Application.Dto;
using Cryptocash.Infrastructure.Persistence;

namespace Cryptocash.Application.Queries;

public partial record GetCashStockOrdersQuery() : IRequest<IQueryable<CashStockOrderDto>>;

internal partial class GetCashStockOrdersQueryHandler: GetCashStockOrdersQueryHandlerBase
{
    public GetCashStockOrdersQueryHandler(IReadOnlyRepository readOnlyRepository): base(readOnlyRepository){}
}

internal abstract class GetCashStockOrdersQueryHandlerBase : QueryBase<IQueryable<CashStockOrderDto>>, IRequestHandler<GetCashStockOrdersQuery, IQueryable<CashStockOrderDto>>
{
    public  GetCashStockOrdersQueryHandlerBase(IReadOnlyRepository readOnlyRepository)
    {
        ReadOnlyRepository = readOnlyRepository;
    }

    public IReadOnlyRepository ReadOnlyRepository { get; }

    public virtual Task<IQueryable<CashStockOrderDto>> Handle(GetCashStockOrdersQuery request, CancellationToken cancellationToken)
    {
        var query = ReadOnlyRepository.Query<CashStockOrderDto>();
       return Task.FromResult(OnResponse(query));
    }
}