// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using Cryptocash.Application.Dto;
using Cryptocash.Infrastructure.Persistence;

namespace Cryptocash.Application.Queries;

public partial record GetVendingMachinesQuery() : IRequest<IQueryable<VendingMachineDto>>;

internal partial class GetVendingMachinesQueryHandler: GetVendingMachinesQueryHandlerBase
{
    public GetVendingMachinesQueryHandler(DtoDbContext dataDbContext): base(dataDbContext)
    {
    
    }
}

internal abstract class GetVendingMachinesQueryHandlerBase : QueryBase<IQueryable<VendingMachineDto>>, IRequestHandler<GetVendingMachinesQuery, IQueryable<VendingMachineDto>>
{
    public  GetVendingMachinesQueryHandlerBase(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public virtual Task<IQueryable<VendingMachineDto>> Handle(GetVendingMachinesQuery request, CancellationToken cancellationToken)
    {
        var item = (IQueryable<VendingMachineDto>)DataDbContext.VendingMachines
            .AsNoTracking();
       return Task.FromResult(OnResponse(item));
    }
}