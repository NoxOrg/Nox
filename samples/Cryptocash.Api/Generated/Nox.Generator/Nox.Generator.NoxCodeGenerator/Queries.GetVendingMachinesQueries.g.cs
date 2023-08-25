// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using CryptocashApi.Application.Dto;
using CryptocashApi.Infrastructure.Persistence;

namespace CryptocashApi.Application.Queries;

public record GetVendingMachinesQuery() : IRequest<IQueryable<VendingMachineDto>>;

public class GetVendingMachinesQueryHandler : IRequestHandler<GetVendingMachinesQuery, IQueryable<VendingMachineDto>>
{
    public  GetVendingMachinesQueryHandler(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public Task<IQueryable<VendingMachineDto>> Handle(GetVendingMachinesQuery request, CancellationToken cancellationToken)
    {
        var item = (IQueryable<VendingMachineDto>)DataDbContext.VendingMachines
            .Where(r => r.DeletedAtUtc == null)
            .AsNoTracking();
        return Task.FromResult(item);
    }
}