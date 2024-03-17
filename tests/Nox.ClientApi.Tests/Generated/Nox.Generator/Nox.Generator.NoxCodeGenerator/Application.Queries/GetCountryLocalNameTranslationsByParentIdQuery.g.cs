// Generated

#nullable enable

using Microsoft.EntityFrameworkCore;
using MediatR;
using YamlDotNet.Core.Tokens;

using Nox.Application.Queries;
using Nox.Application.Repositories;

using ClientApi.Application.Dto;

namespace ClientApi.Application.Queries;

public record  GetCountryLocalNameTranslationsByParentIdQuery(System.Int64 keyId) : IRequest <IQueryable<CountryLocalNameLocalizedDto>>;

internal partial class GetCountryLocalNameTranslationsByParentIdQueryHandler:GetCountryLocalNameTranslationsByParentIdQueryHandlerBase
{
    public  GetCountryLocalNameTranslationsByParentIdQueryHandler(IReadOnlyRepository readOnlyRepository): base(readOnlyRepository){}
}

internal abstract class GetCountryLocalNameTranslationsByParentIdQueryHandlerBase:  QueryBase<IQueryable<CountryLocalNameLocalizedDto>>, IRequestHandler<GetCountryLocalNameTranslationsByParentIdQuery, IQueryable<CountryLocalNameLocalizedDto>>
{
    public  GetCountryLocalNameTranslationsByParentIdQueryHandlerBase(IReadOnlyRepository readOnlyRepository)
    {
        ReadOnlyRepository = readOnlyRepository;
    }

    public IReadOnlyRepository ReadOnlyRepository { get; }

    public virtual Task<IQueryable<CountryLocalNameLocalizedDto>> Handle(GetCountryLocalNameTranslationsByParentIdQuery request, CancellationToken cancellationToken)
    {    
        var ownedEntityIds = ReadOnlyRepository.Query<CountryDto>()
                    .Include(e => e.CountryLocalNames)
                    .Where(r =>
                            r.Id.Equals(request.keyId)
                    ).SelectMany(e => e.CountryLocalNames.Select(c => c.Id));
        
        var query = ReadOnlyRepository.Query<CountryLocalNameLocalizedDto>()
           .Where(r =>
                ownedEntityIds.Contains(r.Id)
           );
        
        return Task.FromResult(OnResponse(query));
    }
}