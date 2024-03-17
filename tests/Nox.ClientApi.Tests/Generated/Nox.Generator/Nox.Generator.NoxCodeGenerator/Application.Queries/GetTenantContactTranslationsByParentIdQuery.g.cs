// Generated

#nullable enable

using Microsoft.EntityFrameworkCore;
using MediatR;
using YamlDotNet.Core.Tokens;

using Nox.Application.Queries;
using Nox.Application.Repositories;

using ClientApi.Application.Dto;

namespace ClientApi.Application.Queries;

public record  GetTenantContactTranslationsByParentIdQuery(System.UInt32 keyId) : IRequest <IQueryable<TenantContactLocalizedDto>>;

internal partial class GetTenantContactTranslationsByParentIdQueryHandler:GetTenantContactTranslationsByParentIdQueryHandlerBase
{
    public  GetTenantContactTranslationsByParentIdQueryHandler(IReadOnlyRepository readOnlyRepository): base(readOnlyRepository){}
}

internal abstract class GetTenantContactTranslationsByParentIdQueryHandlerBase:  QueryBase<IQueryable<TenantContactLocalizedDto>>, IRequestHandler<GetTenantContactTranslationsByParentIdQuery, IQueryable<TenantContactLocalizedDto>>
{
    public  GetTenantContactTranslationsByParentIdQueryHandlerBase(IReadOnlyRepository readOnlyRepository)
    {
        ReadOnlyRepository = readOnlyRepository;
    }

    public IReadOnlyRepository ReadOnlyRepository { get; }

    public virtual Task<IQueryable<TenantContactLocalizedDto>> Handle(GetTenantContactTranslationsByParentIdQuery request, CancellationToken cancellationToken)
    {    
        var query = ReadOnlyRepository.Query<TenantContactLocalizedDto>()
                    .Where(r =>
                        r.TenantId.Equals(request.keyId)
                    );
        
        return Task.FromResult(OnResponse(query));
    }
}