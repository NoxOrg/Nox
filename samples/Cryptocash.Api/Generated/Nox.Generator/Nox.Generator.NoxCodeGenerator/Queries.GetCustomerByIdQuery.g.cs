// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using CryptocashApi.Application.Dto;
using CryptocashApi.Infrastructure.Persistence;

namespace CryptocashApi.Application.Queries;

public record GetCustomerByIdQuery(System.Int64 keyId) : IRequest <CustomerDto?>;

public partial class GetCustomerByIdQueryHandler:  QueryBase<CustomerDto?>, IRequestHandler<GetCustomerByIdQuery, CustomerDto?>
{
    public  GetCustomerByIdQueryHandler(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public Task<CustomerDto?> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
    {    
        var item = DataDbContext.Customers
            .AsNoTracking()
            .SingleOrDefault(r =>
                r.Id.Equals(request.keyId) &&
                r.DeletedAtUtc == null);
        return Task.FromResult(OnResponse(item));
    }
}