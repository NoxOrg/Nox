using MediatR;
using SampleWebApp.Application.Queries;
using SampleWebApp.Application.Dto;

namespace SampleWebApp.Application.Behavior
{
    public class GetVendingMachinesQuerySecurityFilter : IPipelineBehavior<GetVendingMachinesQuery, IQueryable<VendingMachineDto>>
    {
        public async Task<IQueryable<VendingMachineDto>> Handle(GetVendingMachinesQuery request, RequestHandlerDelegate<IQueryable<VendingMachineDto>> next, CancellationToken cancellationToken)
        {
            var result = await next();

            return result.Where(store => store.Id == 1);
        }
    }
}