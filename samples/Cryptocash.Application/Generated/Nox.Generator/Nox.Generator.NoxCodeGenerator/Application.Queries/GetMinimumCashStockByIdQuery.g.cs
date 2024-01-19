// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Queries;
using Nox.Application.Repositories;

using Cryptocash.Application.Dto;
using Cryptocash.Infrastructure.Persistence;

namespace Cryptocash.Application.Queries;

public partial record GetMinimumCashStockByIdQuery(System.Int64 keyId) : IRequest <IQueryable<MinimumCashStockDto>>;

internal partial class GetMinimumCashStockByIdQueryHandler:GetMinimumCashStockByIdQueryHandlerBase
{
    public GetMinimumCashStockByIdQueryHandler(IReadOnlyRepository readOnlyRepository): base(readOnlyRepository){}
}

internal abstract class GetMinimumCashStockByIdQueryHandlerBase:  QueryBase<IQueryable<MinimumCashStockDto>>, IRequestHandler<GetMinimumCashStockByIdQuery, IQueryable<MinimumCashStockDto>>
{
    public  GetMinimumCashStockByIdQueryHandlerBase(IReadOnlyRepository readOnlyRepository)
    {
        ReadOnlyRepository = readOnlyRepository;
    }

    public IReadOnlyRepository ReadOnlyRepository { get; }

    public virtual Task<IQueryable<MinimumCashStockDto>> Handle(GetMinimumCashStockByIdQuery request, CancellationToken cancellationToken)
    {    
        var query = ReadOnlyRepository.Query<MinimumCashStockDto>()
            .Where(r =>
                r.Id.Equals(request.keyId));
        return Task.FromResult(OnResponse(query));
    }
}