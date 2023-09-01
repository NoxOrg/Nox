// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using Cryptocash.Application.Dto;
using Cryptocash.Infrastructure.Persistence;

namespace Cryptocash.Application.Queries;

public record GetCustomerTransactionsQuery() : IRequest<IQueryable<CustomerTransactionDto>>;

public partial class GetCustomerTransactionsQueryHandler : QueryBase<IQueryable<CustomerTransactionDto>>, IRequestHandler<GetCustomerTransactionsQuery, IQueryable<CustomerTransactionDto>>
{
    public  GetCustomerTransactionsQueryHandler(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public Task<IQueryable<CustomerTransactionDto>> Handle(GetCustomerTransactionsQuery request, CancellationToken cancellationToken)
    {
        var item = (IQueryable<CustomerTransactionDto>)DataDbContext.CustomerTransactions
            .Where(r => r.DeletedAtUtc == null)
            .AsNoTracking();
       return Task.FromResult(OnResponse(item));
    }
}