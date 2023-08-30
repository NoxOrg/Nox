// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using CryptocashApi.Application.Dto;
using CryptocashApi.Infrastructure.Persistence;

namespace CryptocashApi.Application.Queries;

public record GetVendingMachinesQuery() : IRequest<IQueryable<VendingMachineDto>>;

public partial class GetVendingMachinesQueryHandler : QueryBase<IQueryable<VendingMachineDto>>, IRequestHandler<GetVendingMachinesQuery, IQueryable<VendingMachineDto>>
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
       return Task.FromResult(OnResponse(item));
    }
}