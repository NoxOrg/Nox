// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;
using YamlDotNet.Core.Tokens;
using ClientApi.Application.Dto;
using ClientApi.Infrastructure.Persistence;

namespace ClientApi.Application.Queries;

public partial record  GetTenantBrandTranslationsQuery(System.Int64 keyId) : IRequest <IQueryable<TenantBrandLocalizedDto>>;

internal partial class GetTenantBrandTranslationsQueryHandler:GetTenantBrandTranslationsQueryHandlerBase
{
    public  GetTenantBrandTranslationsQueryHandler(DtoDbContext dataDbContext): base(dataDbContext)
    {
    
    }
}

internal abstract class GetTenantBrandTranslationsQueryHandlerBase:  QueryBase<IQueryable<TenantBrandLocalizedDto>>, IRequestHandler<GetTenantBrandTranslationsQuery, IQueryable<TenantBrandLocalizedDto>>
{
    public  GetTenantBrandTranslationsQueryHandlerBase(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public virtual Task<IQueryable<TenantBrandLocalizedDto>> Handle(GetTenantBrandTranslationsQuery request, CancellationToken cancellationToken)
    {    
        var query = DataDbContext.TenantBrandsLocalized
            .AsNoTracking()
            .Where(r =>
                r.Id.Equals(request.keyId));
        return Task.FromResult(OnResponse(query));
    }
}