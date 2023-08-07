using MediatR;
using SampleWebApp.Application.Queries;
using SampleWebApp.Application.Dto;

namespace SampleWebApp.Application.Behavior
{
    public class GetStoresQuerySecurityFilter : IPipelineBehavior<GetStoresQuery, IQueryable<StoreDto>>
    {
        public async Task<IQueryable<StoreDto>> Handle(GetStoresQuery request, RequestHandlerDelegate<IQueryable<StoreDto>> next, CancellationToken cancellationToken)
        {
            var result = await next();

            return result.Where(store => store.Id == "EUR");
        }
    }
}
