// Generated

#nullable enable

using Microsoft.EntityFrameworkCore;
using MediatR;
using YamlDotNet.Core.Tokens;

using Nox.Application.Queries;
using Nox.Application.Repositories;

using ClientApi.Application.Dto;
using ClientApi.Infrastructure.Persistence;

namespace ClientApi.Application.Queries;

public record  GetTenantBrandTranslationsByIdQuery(System.Int64 keyId, Nox.Types.CultureCode CultureCode) : IRequest <IQueryable<TenantBrandLocalizedDto>>;

internal partial class GetTenantBrandTranslationsByIdQueryHandler:GetTenantBrandTranslationsByIdQueryHandlerBase
{
    public  GetTenantBrandTranslationsByIdQueryHandler(IReadOnlyRepository readOnlyRepository): base(readOnlyRepository){}
}

internal abstract class GetTenantBrandTranslationsByIdQueryHandlerBase:  QueryBase<IQueryable<TenantBrandLocalizedDto>>, IRequestHandler<GetTenantBrandTranslationsByIdQuery, IQueryable<TenantBrandLocalizedDto>>
{
    public  GetTenantBrandTranslationsByIdQueryHandlerBase(IReadOnlyRepository readOnlyRepository)
    {
        ReadOnlyRepository = readOnlyRepository;
    }

    public IReadOnlyRepository ReadOnlyRepository { get; }

    public virtual Task<IQueryable<TenantBrandLocalizedDto>> Handle(GetTenantBrandTranslationsByIdQuery request, CancellationToken cancellationToken)
    {    
        var query = ReadOnlyRepository.Query<TenantBrandLocalizedDto>()
            .Where(r =>
                r.Id.Equals(request.keyId)
                && r.CultureCode == request.CultureCode.Value
            );
        return Task.FromResult(OnResponse(query));
    }
}