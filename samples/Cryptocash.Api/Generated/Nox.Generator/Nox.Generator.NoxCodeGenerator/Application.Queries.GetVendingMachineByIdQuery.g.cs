// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using Cryptocash.Application.Dto;
using Cryptocash.Infrastructure.Persistence;

namespace Cryptocash.Application.Queries;

public record GetVendingMachineByIdQuery(System.Guid keyId) : IRequest <VendingMachineDto?>;

public partial class GetVendingMachineByIdQueryHandler:  QueryBase<VendingMachineDto?>, IRequestHandler<GetVendingMachineByIdQuery, VendingMachineDto?>
{
    public  GetVendingMachineByIdQueryHandler(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public Task<VendingMachineDto?> Handle(GetVendingMachineByIdQuery request, CancellationToken cancellationToken)
    {    
        var item = DataDbContext.VendingMachines
            .AsNoTracking()
            .Include(r => r.VendingMachineInstallationCountry)
            .Include(r => r.VendingMachineContractedAreaLandLord)
            .Include(r => r.VendingMachineRelatedBookings)
            .Include(r => r.VendingMachineRelatedCashStockOrders)
            .Include(r => r.VendingMachineRequiredMinimumCashStocks)
            .SingleOrDefault(r =>
                r.Id.Equals(request.keyId) &&
                r.DeletedAtUtc == null);
        return Task.FromResult(OnResponse(item));
    }
}