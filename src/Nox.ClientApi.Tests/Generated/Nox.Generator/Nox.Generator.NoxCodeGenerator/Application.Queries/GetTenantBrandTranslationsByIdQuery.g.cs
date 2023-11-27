// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;
using YamlDotNet.Core.Tokens;
using ClientApi.Application.Dto;
using ClientApi.Infrastructure.Persistence;

namespace ClientApi.Application.Queries;

public record  GetTenantBrandTranslationsByIdQuery(System.Int64 keyId, Nox.Types.CultureCode CultureCode) : IRequest <IQueryable<TenantBrandLocalizedDto>>;

internal partial class GetTenantBrandTranslationsByIdQueryHandler:GetTenantBrandTranslationsByIdQueryHandlerBase
{
    public  GetTenantBrandTranslationsByIdQueryHandler(DtoDbContext dataDbContext): base(dataDbContext)
    {
    
    }
}

internal abstract class GetTenantBrandTranslationsByIdQueryHandlerBase:  QueryBase<IQueryable<TenantBrandLocalizedDto>>, IRequestHandler<GetTenantBrandTranslationsByIdQuery, IQueryable<TenantBrandLocalizedDto>>
{
    public  GetTenantBrandTranslationsByIdQueryHandlerBase(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public virtual Task<IQueryable<TenantBrandLocalizedDto>> Handle(GetTenantBrandTranslationsByIdQuery request, CancellationToken cancellationToken)
    {    
        var query = DataDbContext.TenantBrandsLocalized
            .AsNoTracking()
            .Where(r =>
                r.Id.Equals(request.keyId)
                && r.CultureCode == request.CultureCode.Value
            );
        return Task.FromResult(OnResponse(query));
    }
}