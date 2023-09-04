// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using Cryptocash.Application.Dto;
using Cryptocash.Infrastructure.Persistence;

namespace Cryptocash.Application.Queries;

public record GetVendingMachineOrdersQuery() : IRequest<IQueryable<VendingMachineOrderDto>>;

public partial class GetVendingMachineOrdersQueryHandler : QueryBase<IQueryable<VendingMachineOrderDto>>, IRequestHandler<GetVendingMachineOrdersQuery, IQueryable<VendingMachineOrderDto>>
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
       return Task.FromResult(OnResponse(item));
    }
}