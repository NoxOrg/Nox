// Generated

#nullable enable

using Microsoft.EntityFrameworkCore;
using MediatR;
using YamlDotNet.Core.Tokens;

using Nox.Application.Queries;
using Nox.Application.Repositories;

using ClientApi.Application.Dto;

namespace ClientApi.Application.Queries;

public record  GetWorkplaceAddressTranslationsByIdQuery(System.Guid keyId, Nox.Types.CultureCode CultureCode) : IRequest <IQueryable<WorkplaceAddressLocalizedDto>>;

internal partial class GetWorkplaceAddressTranslationsByIdQueryHandler:GetWorkplaceAddressTranslationsByIdQueryHandlerBase
{
    public  GetWorkplaceAddressTranslationsByIdQueryHandler(IReadOnlyRepository readOnlyRepository): base(readOnlyRepository){}
}

internal abstract class GetWorkplaceAddressTranslationsByIdQueryHandlerBase:  QueryBase<IQueryable<WorkplaceAddressLocalizedDto>>, IRequestHandler<GetWorkplaceAddressTranslationsByIdQuery, IQueryable<WorkplaceAddressLocalizedDto>>
{
    public  GetWorkplaceAddressTranslationsByIdQueryHandlerBase(IReadOnlyRepository readOnlyRepository)
    {
        ReadOnlyRepository = readOnlyRepository;
    }

    public IReadOnlyRepository ReadOnlyRepository { get; }

    public virtual Task<IQueryable<WorkplaceAddressLocalizedDto>> Handle(GetWorkplaceAddressTranslationsByIdQuery request, CancellationToken cancellationToken)
    {    
        var query = ReadOnlyRepository.Query<WorkplaceAddressLocalizedDto>()
            .Where(r =>
                r.Id.Equals(request.keyId)
                && r.CultureCode == request.CultureCode.Value
            );
        return Task.FromResult(OnResponse(query));
    }
}