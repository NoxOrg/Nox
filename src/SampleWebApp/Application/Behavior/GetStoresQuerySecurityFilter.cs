using MediatR;
using SampleWebApp.Application.Queries;
using SampleWebApp.Application.Dto;
using Nox.Types;

namespace SampleWebApp.Application.Behavior
{
    public class GetStoresQuerySecurityFilter : IPipelineBehavior<GetStoresQuery, IQueryable<StoreDto>>
    {
        public async Task<IQueryable<StoreDto>> Handle(GetStoresQuery request, RequestHandlerDelegate<IQueryable<StoreDto>> next, CancellationToken cancellationToken)
        {
            var result = await next();

            return result.Where(store => store.Id == Nuid.From("Shippi Tivoli Einkaufscenter.Shopping Center, 8957 Spreitenbach, CH").Value);
        }
    }
}