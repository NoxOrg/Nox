// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using SampleWebApp.Application.Dto;
using SampleWebApp.Presentation.Api.OData;

namespace SampleWebApp.Application.Queries;

public record GetVendingMachineByIdQuery(System.UInt64 key) : IRequest<VendingMachineDto?>;

public class GetVendingMachineByIdQueryHandler: IRequestHandler<GetVendingMachineByIdQuery, VendingMachineDto?>
{
    public  GetVendingMachineByIdQueryHandler(ODataDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public ODataDbContext DataDbContext { get; }

    public Task<VendingMachineDto?> Handle(GetVendingMachineByIdQuery request, CancellationToken cancellationToken)
    {    
        var item = DataDbContext.VendingMachines
            .AsNoTracking()
            .SingleOrDefault(r => !(r.Deleted == true) && r.Id.Equals(request.key));            
        return Task.FromResult(item);
    }
}