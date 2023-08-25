// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using CryptocashApi.Application.Dto;
using CryptocashApi.Infrastructure.Persistence;

namespace CryptocashApi.Application.Queries;

public record GetVendingMachineOrderByIdQuery(System.Int64 keyId) : IRequest<VendingMachineOrderDto?>;

public class GetVendingMachineOrderByIdQueryHandler: IRequestHandler<GetVendingMachineOrderByIdQuery, VendingMachineOrderDto?>
{
    public  GetVendingMachineOrderByIdQueryHandler(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public Task<VendingMachineOrderDto?> Handle(GetVendingMachineOrderByIdQuery request, CancellationToken cancellationToken)
    {    
        var item = DataDbContext.VendingMachineOrders
            .AsNoTracking()
            .SingleOrDefault(r =>
                r.Id.Equals(request.keyId) &&
                r.DeletedAtUtc == null);
        return Task.FromResult(item);
    }
}