// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using Cryptocash.Application.Dto;
using Cryptocash.Infrastructure.Persistence;

namespace Cryptocash.Application.Queries;

public partial record Get TransactionsQuery() : IRequest<IQueryable<TransactionDto>>;

internal partial class GetTransactionsQueryHandler: GetTransactionsQueryHandlerBase
{
    public GetTransactionsQueryHandler(DtoDbContext dataDbContext): base(dataDbContext)
    {
    
    }
}

internal abstract class GetTransactionsQueryHandlerBase : QueryBase<IQueryable<TransactionDto>>, IRequestHandler<GetTransactionsQuery, IQueryable<TransactionDto>>
{
    public  GetTransactionsQueryHandlerBase(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public virtual Task<IQueryable<TransactionDto>> Handle(GetTransactionsQuery request, CancellationToken cancellationToken)
    {
        var item = (IQueryable<TransactionDto>)DataDbContext.Transactions
            .AsNoTracking();
       return Task.FromResult(OnResponse(item));
    }
}