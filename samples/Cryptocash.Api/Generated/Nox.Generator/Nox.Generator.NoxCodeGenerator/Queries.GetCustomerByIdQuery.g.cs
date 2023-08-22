// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using CryptocashApi.Application.Dto;
using CryptocashApi.Presentation.Api.OData;

namespace CryptocashApi.Application.Queries;

public record GetCustomerByIdQuery(System.Int64 keyId) : IRequest<CustomerDto?>;

public class GetCustomerByIdQueryHandler: IRequestHandler<GetCustomerByIdQuery, CustomerDto?>
{
    public  GetCustomerByIdQueryHandler(ODataDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public ODataDbContext DataDbContext { get; }

    public Task<CustomerDto?> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
    {    
        var item = DataDbContext.Customers
            .AsNoTracking()
            .SingleOrDefault(r =>
                r.Id.Equals(request.keyId) &&
                !(r.Deleted == true));
        return Task.FromResult(item);
    }
}