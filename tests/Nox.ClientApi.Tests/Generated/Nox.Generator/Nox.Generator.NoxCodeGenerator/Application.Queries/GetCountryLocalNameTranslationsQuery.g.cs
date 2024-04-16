// Generated

#nullable enable

using Microsoft.EntityFrameworkCore;
using MediatR;
using YamlDotNet.Core.Tokens;

using Nox.Application.Queries;
using Nox.Application.Repositories;

using ClientApi.Application.Dto;

namespace ClientApi.Application.Queries;

public partial record  GetCountryLocalNameTranslationsQuery(System.Int64 keyId) : IRequest <IQueryable<CountryLocalNameLocalizedDto>>;

internal partial class GetCountryLocalNameTranslationsQueryHandler:GetCountryLocalNameTranslationsQueryHandlerBase
{
    public  GetCountryLocalNameTranslationsQueryHandler(IReadOnlyRepository readOnlyRepository): base(readOnlyRepository){}
}

internal abstract class GetCountryLocalNameTranslationsQueryHandlerBase:  QueryBase<IQueryable<CountryLocalNameLocalizedDto>>, IRequestHandler<GetCountryLocalNameTranslationsQuery, IQueryable<CountryLocalNameLocalizedDto>>
{
    public  GetCountryLocalNameTranslationsQueryHandlerBase(IReadOnlyRepository readOnlyRepository)
    {
        ReadOnlyRepository = readOnlyRepository;
    }

    public IReadOnlyRepository ReadOnlyRepository { get; }

    public virtual Task<IQueryable<CountryLocalNameLocalizedDto>> Handle(GetCountryLocalNameTranslationsQuery request, CancellationToken cancellationToken)
    {    
        var query = ReadOnlyRepository.Query<CountryLocalNameLocalizedDto>()
            .Where(r =>
                r.Id.Equals(request.keyId));
        return Task.FromResult(OnResponse(query));
    }
}