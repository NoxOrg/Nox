// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using CryptocashApi.Application.Dto;
using CryptocashApi.Presentation.Api.OData;

namespace CryptocashApi.Application.Queries;

public record GetCustomersQuery() : IRequest<IQueryable<CustomerDto>>;

public class GetCustomersQueryHandler : IRequestHandler<GetCustomersQuery, IQueryable<CustomerDto>>
{
    public  GetCustomersQueryHandler(ODataDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public ODataDbContext DataDbContext { get; }

    public Task<IQueryable<CustomerDto>> Handle(GetCustomersQuery request, CancellationToken cancellationToken)
    {
        var item = (IQueryable<CustomerDto>)DataDbContext.Customers
            .Where(r => !(r.Deleted == true))
            .AsNoTracking();
        return Task.FromResult(item);
    }
}