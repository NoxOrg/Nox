// Generated

#nullable enable

using Microsoft.EntityFrameworkCore;
using MediatR;
using YamlDotNet.Core.Tokens;

using Nox.Application.Queries;
using Nox.Application.Repositories;

using ClientApi.Application.Dto;

namespace ClientApi.Application.Queries;

public record  GetCountryTranslationsByIdQuery(System.Int64 keyId, Nox.Types.CultureCode CultureCode) : IRequest <IQueryable<CountryLocalizedDto>>;

internal partial class GetCountryTranslationsByIdQueryHandler:GetCountryTranslationsByIdQueryHandlerBase
{
    public  GetCountryTranslationsByIdQueryHandler(IReadOnlyRepository readOnlyRepository): base(readOnlyRepository){}
}

internal abstract class GetCountryTranslationsByIdQueryHandlerBase:  QueryBase<IQueryable<CountryLocalizedDto>>, IRequestHandler<GetCountryTranslationsByIdQuery, IQueryable<CountryLocalizedDto>>
{
    public  GetCountryTranslationsByIdQueryHandlerBase(IReadOnlyRepository readOnlyRepository)
    {
        ReadOnlyRepository = readOnlyRepository;
    }

    public IReadOnlyRepository ReadOnlyRepository { get; }

    public virtual Task<IQueryable<CountryLocalizedDto>> Handle(GetCountryTranslationsByIdQuery request, CancellationToken cancellationToken)
    {    
        var query = ReadOnlyRepository.Query<CountryLocalizedDto>()
            .Where(r =>
                r.Id.Equals(request.keyId)
                && r.CultureCode == request.CultureCode.Value
            );
        return Task.FromResult(OnResponse(query));
    }
}