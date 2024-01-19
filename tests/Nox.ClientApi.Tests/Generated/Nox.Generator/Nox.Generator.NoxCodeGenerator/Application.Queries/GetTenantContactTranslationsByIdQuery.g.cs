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

public record  GetTenantContactTranslationsByIdQuery(System.UInt32 keyTenantId, Nox.Types.CultureCode CultureCode) : IRequest <IQueryable<TenantContactLocalizedDto>>;

internal partial class GetTenantContactTranslationsByIdQueryHandler:GetTenantContactTranslationsByIdQueryHandlerBase
{
    public  GetTenantContactTranslationsByIdQueryHandler(IReadOnlyRepository readOnlyRepository): base(readOnlyRepository){}
}

internal abstract class GetTenantContactTranslationsByIdQueryHandlerBase:  QueryBase<IQueryable<TenantContactLocalizedDto>>, IRequestHandler<GetTenantContactTranslationsByIdQuery, IQueryable<TenantContactLocalizedDto>>
{
    public  GetTenantContactTranslationsByIdQueryHandlerBase(IReadOnlyRepository readOnlyRepository)
    {
        ReadOnlyRepository = readOnlyRepository;
    }

    public IReadOnlyRepository ReadOnlyRepository { get; }

    public virtual Task<IQueryable<TenantContactLocalizedDto>> Handle(GetTenantContactTranslationsByIdQuery request, CancellationToken cancellationToken)
    {    
        var query = ReadOnlyRepository.Query<TenantContactLocalizedDto>()
            .Where(r =>
                r.TenantId.Equals(request.keyTenantId)
                && r.CultureCode == request.CultureCode.Value
            );
        return Task.FromResult(OnResponse(query));
    }
}