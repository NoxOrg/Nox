// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using CryptocashApi.Application.Dto;
using CryptocashApi.Infrastructure.Persistence;

namespace CryptocashApi.Application.Queries;

public record GetVendingMachineOrdersQuery() : IRequest<IQueryable<VendingMachineOrderDto>>;

public class GetVendingMachineOrdersQueryHandler : IRequestHandler<GetVendingMachineOrdersQuery, IQueryable<VendingMachineOrderDto>>
{
    public  GetVendingMachineOrdersQueryHandler(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public Task<IQueryable<VendingMachineOrderDto>> Handle(GetVendingMachineOrdersQuery request, CancellationToken cancellationToken)
    {
        var item = (IQueryable<VendingMachineOrderDto>)DataDbContext.VendingMachineOrders
            .Where(r => r.DeletedAtUtc == null)
            .AsNoTracking();
        return Task.FromResult(item);
    }
}