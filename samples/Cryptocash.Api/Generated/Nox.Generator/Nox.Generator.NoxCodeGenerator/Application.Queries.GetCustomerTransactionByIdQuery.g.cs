// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using CryptocashApi.Application.Dto;
using CryptocashApi.Infrastructure.Persistence;

namespace CryptocashApi.Application.Queries;

public record GetCustomerTransactionByIdQuery(System.Int64 keyId) : IRequest <CustomerTransactionDto?>;

public partial class GetCustomerTransactionByIdQueryHandler:  QueryBase<CustomerTransactionDto?>, IRequestHandler<GetCustomerTransactionByIdQuery, CustomerTransactionDto?>
{
    public  GetCustomerTransactionByIdQueryHandler(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public Task<CustomerTransactionDto?> Handle(GetCustomerTransactionByIdQuery request, CancellationToken cancellationToken)
    {    
        var item = DataDbContext.CustomerTransactions
            .AsNoTracking()
            .SingleOrDefault(r =>
                r.Id.Equals(request.keyId) &&
                r.DeletedAtUtc == null);
        return Task.FromResult(OnResponse(item));
    }
}