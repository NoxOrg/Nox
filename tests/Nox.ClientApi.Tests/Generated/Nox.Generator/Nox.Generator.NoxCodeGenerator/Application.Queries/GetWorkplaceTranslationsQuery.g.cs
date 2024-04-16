// Generated

#nullable enable

using Microsoft.EntityFrameworkCore;
using MediatR;
using YamlDotNet.Core.Tokens;

using Nox.Application.Queries;
using Nox.Application.Repositories;

using ClientApi.Application.Dto;

namespace ClientApi.Application.Queries;

public partial record  GetWorkplaceTranslationsQuery(System.Int64 keyId) : IRequest <IQueryable<WorkplaceLocalizedDto>>;

internal partial class GetWorkplaceTranslationsQueryHandler:GetWorkplaceTranslationsQueryHandlerBase
{
    public  GetWorkplaceTranslationsQueryHandler(IReadOnlyRepository readOnlyRepository): base(readOnlyRepository){}
}

internal abstract class GetWorkplaceTranslationsQueryHandlerBase:  QueryBase<IQueryable<WorkplaceLocalizedDto>>, IRequestHandler<GetWorkplaceTranslationsQuery, IQueryable<WorkplaceLocalizedDto>>
{
    public  GetWorkplaceTranslationsQueryHandlerBase(IReadOnlyRepository readOnlyRepository)
    {
        ReadOnlyRepository = readOnlyRepository;
    }

    public IReadOnlyRepository ReadOnlyRepository { get; }

    public virtual Task<IQueryable<WorkplaceLocalizedDto>> Handle(GetWorkplaceTranslationsQuery request, CancellationToken cancellationToken)
    {    
        var query = ReadOnlyRepository.Query<WorkplaceLocalizedDto>()
            .Where(r =>
                r.Id.Equals(request.keyId));
        return Task.FromResult(OnResponse(query));
    }
}