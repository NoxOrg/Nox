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

public partial record  GetTenantContactTranslationsQuery(System.UInt32 keyTenantId) : IRequest <IQueryable<TenantContactLocalizedDto>>;

internal partial class GetTenantContactTranslationsQueryHandler:GetTenantContactTranslationsQueryHandlerBase
{
    public  GetTenantContactTranslationsQueryHandler(IReadOnlyRepository readOnlyRepository): base(readOnlyRepository){}
}

internal abstract class GetTenantContactTranslationsQueryHandlerBase:  QueryBase<IQueryable<TenantContactLocalizedDto>>, IRequestHandler<GetTenantContactTranslationsQuery, IQueryable<TenantContactLocalizedDto>>
{
    public  GetTenantContactTranslationsQueryHandlerBase(IReadOnlyRepository readOnlyRepository)
    {
        ReadOnlyRepository = readOnlyRepository;
    }

    public IReadOnlyRepository ReadOnlyRepository { get; }

    public virtual Task<IQueryable<TenantContactLocalizedDto>> Handle(GetTenantContactTranslationsQuery request, CancellationToken cancellationToken)
    {    
        var query = ReadOnlyRepository.Query<TenantContactLocalizedDto>()
            .Where(r =>
                r.TenantId.Equals(request.keyTenantId));
        return Task.FromResult(OnResponse(query));
    }
}