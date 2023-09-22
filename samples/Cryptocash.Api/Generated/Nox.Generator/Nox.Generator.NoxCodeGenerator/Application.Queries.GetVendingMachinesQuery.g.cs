// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using Cryptocash.Application.Dto;
using Cryptocash.Infrastructure.Persistence;

namespace Cryptocash.Application.Queries;

public record GetVendingMachinesQuery() : IRequest<IQueryable<VendingMachineDto>>;

public partial class GetVendingMachinesQueryHandler: GetVendingMachinesQueryHandlerBase
{
    public GetVendingMachinesQueryHandler(DtoDbContext dataDbContext): base(dataDbContext)
    {
    
    }
}

public abstract class GetVendingMachinesQueryHandlerBase : QueryBase<IQueryable<VendingMachineDto>>, IRequestHandler<GetVendingMachinesQuery, IQueryable<VendingMachineDto>>
{
    public  GetVendingMachinesQueryHandlerBase(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public virtual Task<IQueryable<VendingMachineDto>> Handle(GetVendingMachinesQuery request, CancellationToken cancellationToken)
    {
        var item = (IQueryable<VendingMachineDto>)DataDbContext.VendingMachines
            .Where(r => r.DeletedAtUtc == null)
            .AsNoTracking();
       return Task.FromResult(OnResponse(item));
    }
}