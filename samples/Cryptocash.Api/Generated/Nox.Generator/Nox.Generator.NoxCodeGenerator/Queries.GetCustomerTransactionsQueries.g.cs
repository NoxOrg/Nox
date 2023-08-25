// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using CryptocashApi.Application.Dto;
using CryptocashApi.Infrastructure.Persistence;

namespace CryptocashApi.Application.Queries;

public record GetCustomerTransactionsQuery() : IRequest<IQueryable<CustomerTransactionDto>>;

public class GetCustomerTransactionsQueryHandler : IRequestHandler<GetCustomerTransactionsQuery, IQueryable<CustomerTransactionDto>>
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
        return Task.FromResult(item);
    }
}