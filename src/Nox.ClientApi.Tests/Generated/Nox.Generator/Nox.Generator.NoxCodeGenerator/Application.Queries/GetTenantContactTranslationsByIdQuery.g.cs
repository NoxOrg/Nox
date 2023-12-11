// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;
using YamlDotNet.Core.Tokens;
using ClientApi.Application.Dto;
using ClientApi.Infrastructure.Persistence;

namespace ClientApi.Application.Queries;

public record  GetTenantContactTranslationsByIdQuery(System.UInt32 keyTenantId, Nox.Types.CultureCode CultureCode) : IRequest <IQueryable<TenantContactLocalizedDto>>;

internal partial class GetTenantContactTranslationsByIdQueryHandler:GetTenantContactTranslationsByIdQueryHandlerBase
{
    public  GetTenantContactTranslationsByIdQueryHandler(DtoDbContext dataDbContext): base(dataDbContext)
    {
    
    }
}

internal abstract class GetTenantContactTranslationsByIdQueryHandlerBase:  QueryBase<IQueryable<TenantContactLocalizedDto>>, IRequestHandler<GetTenantContactTranslationsByIdQuery, IQueryable<TenantContactLocalizedDto>>
{
    public  GetTenantContactTranslationsByIdQueryHandlerBase(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public virtual Task<IQueryable<TenantContactLocalizedDto>> Handle(GetTenantContactTranslationsByIdQuery request, CancellationToken cancellationToken)
    {    
        var query = DataDbContext.TenantContactsLocalized
            .AsNoTracking()
            .Where(r =>
                r.TenantId.Equals(request.keyTenantId)
                && r.CultureCode == request.CultureCode.Value
            );
        return Task.FromResult(OnResponse(query));
    }
}