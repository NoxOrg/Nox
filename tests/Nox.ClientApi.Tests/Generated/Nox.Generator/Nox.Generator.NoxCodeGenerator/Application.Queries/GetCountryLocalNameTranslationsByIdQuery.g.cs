// Generated

#nullable enable

using Microsoft.EntityFrameworkCore;
using MediatR;
using YamlDotNet.Core.Tokens;

using Nox.Application.Queries;
using Nox.Application.Repositories;

using ClientApi.Application.Dto;

namespace ClientApi.Application.Queries;

public record  GetCountryLocalNameTranslationsByIdQuery(System.Int64 keyId, Nox.Types.CultureCode CultureCode) : IRequest <IQueryable<CountryLocalNameLocalizedDto>>;

internal partial class GetCountryLocalNameTranslationsByIdQueryHandler:GetCountryLocalNameTranslationsByIdQueryHandlerBase
{
    public  GetCountryLocalNameTranslationsByIdQueryHandler(IReadOnlyRepository readOnlyRepository): base(readOnlyRepository){}
}

internal abstract class GetCountryLocalNameTranslationsByIdQueryHandlerBase:  QueryBase<IQueryable<CountryLocalNameLocalizedDto>>, IRequestHandler<GetCountryLocalNameTranslationsByIdQuery, IQueryable<CountryLocalNameLocalizedDto>>
{
    public  GetCountryLocalNameTranslationsByIdQueryHandlerBase(IReadOnlyRepository readOnlyRepository)
    {
        ReadOnlyRepository = readOnlyRepository;
    }

    public IReadOnlyRepository ReadOnlyRepository { get; }

    public virtual Task<IQueryable<CountryLocalNameLocalizedDto>> Handle(GetCountryLocalNameTranslationsByIdQuery request, CancellationToken cancellationToken)
    {    
        var query = ReadOnlyRepository.Query<CountryLocalNameLocalizedDto>()
            .Where(r =>
                r.Id.Equals(request.keyId)
                && r.CultureCode == request.CultureCode.Value
            );
        return Task.FromResult(OnResponse(query));
    }
}