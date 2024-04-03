// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Queries;
using Nox.Application.Repositories;

using DtoNameSpace = ClientApi.Application.Dto;

namespace ClientApi.Application.Queries;
public partial record GetTenantBrandsStatusesQuery(Nox.Types.CultureCode cultureCode) : IRequest<IQueryable<DtoNameSpace.TenantBrandStatusDto>>;

internal partial class GetTenantBrandsStatusesQueryHandler: GetTenantBrandsStatusesQueryHandlerBase
{
    public GetTenantBrandsStatusesQueryHandler(IReadOnlyRepository readOnlyRepository): base(readOnlyRepository){}
}

internal abstract class GetTenantBrandsStatusesQueryHandlerBase : QueryBase<IQueryable<DtoNameSpace.TenantBrandStatusDto>>, IRequestHandler<GetTenantBrandsStatusesQuery, IQueryable<DtoNameSpace.TenantBrandStatusDto>>
{
    public  GetTenantBrandsStatusesQueryHandlerBase(IReadOnlyRepository readOnlyRepository)
    {
        ReadOnlyRepository = readOnlyRepository;
    }

    public IReadOnlyRepository ReadOnlyRepository { get; }

    public virtual Task<IQueryable<DtoNameSpace.TenantBrandStatusDto>> Handle(GetTenantBrandsStatusesQuery request, CancellationToken cancellationToken)
    {
        {
            var cultureCode = request.cultureCode.Value;
            IQueryable<DtoNameSpace.TenantBrandStatusDto> queryBuilder =
            from enumValues in ReadOnlyRepository.Query<DtoNameSpace.TenantBrandStatusDto>()
            from enumLocalized in ReadOnlyRepository.Query<DtoNameSpace.TenantBrandStatusLocalizedDto>()
                .Where(l => enumValues.Id == l.Id && l.CultureCode == cultureCode).DefaultIfEmpty()
            select new DtoNameSpace.TenantBrandStatusDto()
            {
                Id = enumValues.Id,
                Name = enumLocalized.Name ?? "[" + enumValues.Name + "]",
            };
            return Task.FromResult(OnResponse(queryBuilder));
        }
    }
}