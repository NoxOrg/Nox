// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Queries;
using Nox.Application.Repositories;

using DtoNameSpace = ClientApi.Application.Dto;

namespace ClientApi.Application.Queries;
public partial record GetTenantBrandsStatusesTranslationsQuery() : IRequest<IQueryable<DtoNameSpace.TenantBrandStatusLocalizedDto>>;

internal partial class GetTenantBrandsStatusesTranslationsQueryHandler: GetTenantBrandsStatusesTranslationsQueryHandlerBase
{
    public GetTenantBrandsStatusesTranslationsQueryHandler(IReadOnlyRepository readOnlyRepository): base(readOnlyRepository){}
}

internal abstract class GetTenantBrandsStatusesTranslationsQueryHandlerBase : QueryBase<IQueryable<DtoNameSpace.TenantBrandStatusLocalizedDto>>, IRequestHandler<GetTenantBrandsStatusesTranslationsQuery, IQueryable<DtoNameSpace.TenantBrandStatusLocalizedDto>>
{
    public  GetTenantBrandsStatusesTranslationsQueryHandlerBase(IReadOnlyRepository readOnlyRepository)
    {
        ReadOnlyRepository = readOnlyRepository;
    }

    public IReadOnlyRepository ReadOnlyRepository { get; }

    public virtual Task<IQueryable<DtoNameSpace.TenantBrandStatusLocalizedDto>> Handle(GetTenantBrandsStatusesTranslationsQuery request, CancellationToken cancellationToken)
    {       
        var queryBuilder = ReadOnlyRepository.Query<DtoNameSpace.TenantBrandStatusLocalizedDto>();
        return Task.FromResult(OnResponse(queryBuilder));       
    }  
}