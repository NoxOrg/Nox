// Generated

#nullable enable

using Microsoft.EntityFrameworkCore;
using MediatR;
using YamlDotNet.Core.Tokens;

using Nox.Application.Queries;
using Nox.Application.Repositories;
using Nox.Exceptions;

using ClientApi.Application.Dto;

namespace ClientApi.Application.Queries;

public record  GetTenantBrandTranslationsByParentIdQuery(System.UInt32 TenantId,System.Int64 TenantBrandId) : IRequest <IQueryable<TenantBrandLocalizedDto>>;

internal partial class GetTenantBrandTranslationsByParentIdQueryHandler:GetTenantBrandTranslationsByParentIdQueryHandlerBase
{
    public  GetTenantBrandTranslationsByParentIdQueryHandler(IReadOnlyRepository readOnlyRepository): base(readOnlyRepository){}
}

internal abstract class GetTenantBrandTranslationsByParentIdQueryHandlerBase:  QueryBase<IQueryable<TenantBrandLocalizedDto>>, IRequestHandler<GetTenantBrandTranslationsByParentIdQuery, IQueryable<TenantBrandLocalizedDto>>
{
    public  GetTenantBrandTranslationsByParentIdQueryHandlerBase(IReadOnlyRepository readOnlyRepository)
    {
        ReadOnlyRepository = readOnlyRepository;
    }

    public IReadOnlyRepository ReadOnlyRepository { get; }

    public virtual async Task<IQueryable<TenantBrandLocalizedDto>> Handle(GetTenantBrandTranslationsByParentIdQuery request, CancellationToken cancellationToken)
    {    
        var parentEntity = await ReadOnlyRepository.Query<TenantDto>()
                    .Include(e => e.TenantBrands)
                    .Where(r =>
                            r.Id.Equals(request.TenantId)
                            && r.TenantBrands.Any(e => e.Id.Equals(request.TenantBrandId))
                    ).FirstOrDefaultAsync();
        if (parentEntity is null)
        {
            EntityNotFoundException.ThrowIfNull(parentEntity, "Tenant", request.TenantId.ToString());
        }
        
        var query = ReadOnlyRepository.Query<TenantBrandLocalizedDto>()
           .Where(r =>
                r.Id.Equals(request.TenantBrandId) 
           );
           
        
        return OnResponse(query);
        
    }
}