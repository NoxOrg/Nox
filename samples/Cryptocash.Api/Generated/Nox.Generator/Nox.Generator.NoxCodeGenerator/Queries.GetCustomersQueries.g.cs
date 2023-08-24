// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using CryptocashApi.Application.Dto;
using CryptocashApi.Infrastructure.Persistence;

namespace CryptocashApi.Application.Queries;

public record GetCustomersQuery() : IRequest<IQueryable<CustomerDto>>;

public partial class GetCustomersQueryHandler : QueryBase<IQueryable<CustomerDto>>, IRequestHandler<GetCustomersQuery, IQueryable<CustomerDto>>
{
    public  GetCustomersQueryHandler(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public Task<IQueryable<CustomerDto>> Handle(GetCustomersQuery request, CancellationToken cancellationToken)
    {
        var item = (IQueryable<CustomerDto>)DataDbContext.Customers
            .Where(r => r.DeletedAtUtc == null)
            .AsNoTracking();
        return Task.FromResult(item);
    }
}