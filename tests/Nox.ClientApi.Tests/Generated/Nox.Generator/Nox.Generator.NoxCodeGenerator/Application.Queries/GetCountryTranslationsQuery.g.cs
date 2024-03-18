// Generated

#nullable enable

using Microsoft.EntityFrameworkCore;
using MediatR;
using YamlDotNet.Core.Tokens;

using Nox.Application.Queries;
using Nox.Application.Repositories;

using ClientApi.Application.Dto;

namespace ClientApi.Application.Queries;

public partial record  GetCountryTranslationsQuery(System.Int64 keyId) : IRequest <IQueryable<CountryLocalizedDto>>;

internal partial class GetCountryTranslationsQueryHandler:GetCountryTranslationsQueryHandlerBase
{
    public  GetCountryTranslationsQueryHandler(IReadOnlyRepository readOnlyRepository): base(readOnlyRepository){}
}

internal abstract class GetCountryTranslationsQueryHandlerBase:  QueryBase<IQueryable<CountryLocalizedDto>>, IRequestHandler<GetCountryTranslationsQuery, IQueryable<CountryLocalizedDto>>
{
    public  GetCountryTranslationsQueryHandlerBase(IReadOnlyRepository readOnlyRepository)
    {
        ReadOnlyRepository = readOnlyRepository;
    }

    public IReadOnlyRepository ReadOnlyRepository { get; }

    public virtual Task<IQueryable<CountryLocalizedDto>> Handle(GetCountryTranslationsQuery request, CancellationToken cancellationToken)
    {    
        var query = ReadOnlyRepository.Query<CountryLocalizedDto>()
            .Where(r =>
                r.Id.Equals(request.keyId));
        return Task.FromResult(OnResponse(query));
    }
}