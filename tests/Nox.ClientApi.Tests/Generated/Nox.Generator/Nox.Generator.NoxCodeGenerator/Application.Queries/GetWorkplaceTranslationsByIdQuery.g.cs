// Generated

#nullable enable

using Microsoft.EntityFrameworkCore;
using MediatR;
using YamlDotNet.Core.Tokens;

using Nox.Application.Queries;
using Nox.Application.Repositories;

using ClientApi.Application.Dto;

namespace ClientApi.Application.Queries;

public record  GetWorkplaceTranslationsByIdQuery(System.Int64 keyId, Nox.Types.CultureCode CultureCode) : IRequest <IQueryable<WorkplaceLocalizedDto>>;

internal partial class GetWorkplaceTranslationsByIdQueryHandler:GetWorkplaceTranslationsByIdQueryHandlerBase
{
    public  GetWorkplaceTranslationsByIdQueryHandler(IReadOnlyRepository readOnlyRepository): base(readOnlyRepository){}
}

internal abstract class GetWorkplaceTranslationsByIdQueryHandlerBase:  QueryBase<IQueryable<WorkplaceLocalizedDto>>, IRequestHandler<GetWorkplaceTranslationsByIdQuery, IQueryable<WorkplaceLocalizedDto>>
{
    public  GetWorkplaceTranslationsByIdQueryHandlerBase(IReadOnlyRepository readOnlyRepository)
    {
        ReadOnlyRepository = readOnlyRepository;
    }

    public IReadOnlyRepository ReadOnlyRepository { get; }

    public virtual Task<IQueryable<WorkplaceLocalizedDto>> Handle(GetWorkplaceTranslationsByIdQuery request, CancellationToken cancellationToken)
    {    
        var query = ReadOnlyRepository.Query<WorkplaceLocalizedDto>()
            .Where(r =>
                r.Id.Equals(request.keyId)
                && r.CultureCode == request.CultureCode.Value
            );
        return Task.FromResult(OnResponse(query));
    }
}