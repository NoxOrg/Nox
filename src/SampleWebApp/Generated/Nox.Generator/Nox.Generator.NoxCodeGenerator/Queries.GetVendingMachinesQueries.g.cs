// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using SampleWebApp.Application.Dto;
using SampleWebApp.Presentation.Api.OData;

namespace SampleWebApp.Application.Queries;

public record GetVendingMachinesQuery() : IRequest<IQueryable<VendingMachineDto>>;

public class GetVendingMachinesQueryHandler : IRequestHandler<GetVendingMachinesQuery, IQueryable<VendingMachineDto>>
{
    public  GetVendingMachinesQueryHandler(ODataDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public ODataDbContext DataDbContext { get; }

    public Task<IQueryable<VendingMachineDto>> Handle(GetVendingMachinesQuery request, CancellationToken cancellationToken)
    {
        var item = (IQueryable<VendingMachineDto>)DataDbContext.VendingMachines
            .Where(r => !(r.Deleted == true))
            .AsNoTracking();
        return Task.FromResult(item);
    }
}