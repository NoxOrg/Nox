// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;
using YamlDotNet.Core.Tokens;
using ClientApi.Application.Dto;
using ClientApi.Infrastructure.Persistence;

namespace ClientApi.Application.Queries;

public partial record  GetTenantContactTranslationsQuery(System.UInt32 keyTenantId) : IRequest <IQueryable<TenantContactLocalizedDto>>;

internal partial class GetTenantContactTranslationsQueryHandler:GetTenantContactTranslationsQueryHandlerBase
{
    public  GetTenantContactTranslationsQueryHandler(DtoDbContext dataDbContext): base(dataDbContext)
    {
    
    }
}

internal abstract class GetTenantContactTranslationsQueryHandlerBase:  QueryBase<IQueryable<TenantContactLocalizedDto>>, IRequestHandler<GetTenantContactTranslationsQuery, IQueryable<TenantContactLocalizedDto>>
{
    public  GetTenantContactTranslationsQueryHandlerBase(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public virtual Task<IQueryable<TenantContactLocalizedDto>> Handle(GetTenantContactTranslationsQuery request, CancellationToken cancellationToken)
    {    
        var query = DataDbContext.TenantContactsLocalized
            .AsNoTracking()
            .Where(r =>
                r.TenantId.Equals(request.keyTenantId));
        return Task.FromResult(OnResponse(query));
    }
}