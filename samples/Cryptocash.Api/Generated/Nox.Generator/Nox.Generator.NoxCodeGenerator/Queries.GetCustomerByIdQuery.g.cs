// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using CryptocashApi.Application.Dto;
using CryptocashApi.Infrastructure.Persistence;

namespace CryptocashApi.Application.Queries;

public record GetCustomerByIdQuery(System.Int64 keyId) : IRequest<CustomerDto?>;

public class GetCustomerByIdQueryHandler: IRequestHandler<GetCustomerByIdQuery, CustomerDto?>
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
        return Task.FromResult(item);
    }
}