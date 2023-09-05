// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using Cryptocash.Application.Dto;
using Cryptocash.Infrastructure.Persistence;

namespace Cryptocash.Application.Queries;

public record GetTransactionsQuery() : IRequest<IQueryable<TransactionDto>>;

public partial class GetTransactionsQueryHandler : QueryBase<IQueryable<TransactionDto>>, IRequestHandler<GetTransactionsQuery, IQueryable<TransactionDto>>
{
    public  GetTransactionsQueryHandler(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public Task<IQueryable<TransactionDto>> Handle(GetTransactionsQuery request, CancellationToken cancellationToken)
    {
        var item = (IQueryable<TransactionDto>)DataDbContext.Transactions
            .Where(r => r.DeletedAtUtc == null)
            .AsNoTracking();
       return Task.FromResult(OnResponse(item));
    }
}