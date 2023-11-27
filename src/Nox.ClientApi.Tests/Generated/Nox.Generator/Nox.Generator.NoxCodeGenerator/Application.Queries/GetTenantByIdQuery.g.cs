// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using ClientApi.Application.Dto;
using ClientApi.Infrastructure.Persistence;
using Nox.Presentation.Api;
using Nox.Solution;
using Nox.Types;

namespace ClientApi.Application.Queries;

public partial record GetTenantByIdQuery(CultureCode cultureCode, System.UInt32 keyId) : IRequest <IQueryable<TenantDto>>;

internal partial class GetTenantByIdQueryHandler : GetTenantByIdQueryHandlerBase
{
    public GetTenantByIdQueryHandler(DtoDbContext dataDbContext) : base(dataDbContext)
    {

    }
}

internal abstract class GetTenantByIdQueryHandlerBase:  QueryBase<IQueryable<TenantDto>>, IRequestHandler<GetTenantByIdQuery, IQueryable<TenantDto>>
{
    protected GetTenantByIdQueryHandlerBase(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public virtual Task<IQueryable<TenantDto>> Handle(GetTenantByIdQuery request, CancellationToken cancellationToken)
    {
        var cultureCode = request.cultureCode.Value;

        IQueryable<TenantDto> linqQueryBuilder =
            from item in DataDbContext.Tenants.Where(r =>
                r.Id.Equals(request.keyId)).AsNoTracking()
            select new TenantDto()
            {
                Id = item.Id,
                Name = item.Name,
                TenantBrands =
                    (from itemTenantBrands in item.TenantBrands
                    join itemTenantBrandsLocalized in DataDbContext.TenantBrandsLocalized 
                        on new { Id = itemTenantBrands.Id, CultureCode = cultureCode } 
                        equals new { Id = itemTenantBrandsLocalized.Id, CultureCode = itemTenantBrandsLocalized.CultureCode } 
                        into  itemTenantBrandsLocalizedJoinedData
                    from  itemTenantBrandsLocalized in itemTenantBrandsLocalizedJoinedData.DefaultIfEmpty()
                    select new TenantBrandDto()
                    {
                        Id = itemTenantBrands.Id,
                        Name = itemTenantBrands.Name,
                        Description = itemTenantBrandsLocalized.Description ?? "[" + itemTenantBrands.Description + "]",
                    }).ToList(),
                Etag = item.Etag
            };

        var sqlStatement = linqQueryBuilder.ToQueryString();

        IQueryable<TenantDto> getItemsQuery =
            from item in DataDbContext.Tenants.FromSqlRaw(sqlStatement)
            select item;

        return Task.FromResult(OnResponse(getItemsQuery));
    }
}