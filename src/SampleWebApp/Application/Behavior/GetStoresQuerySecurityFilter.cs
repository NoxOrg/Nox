using MediatR;
using SampleWebApp.Application.Queries;
using SampleWebApp.Application.Dto;

namespace SampleWebApp.Application.Behavior
{
    public class GetStoresQuerySecurityFilter : IPipelineBehavior<GetStoresQuery, IQueryable<OStore>>
    {
        public async Task<IQueryable<OStore>> Handle(GetStoresQuery request, RequestHandlerDelegate<IQueryable<OStore>> next, CancellationToken cancellationToken)
        {
            var result = await next();

            return result.Where(store => store.Id == "EUR");
        }
    }
}
