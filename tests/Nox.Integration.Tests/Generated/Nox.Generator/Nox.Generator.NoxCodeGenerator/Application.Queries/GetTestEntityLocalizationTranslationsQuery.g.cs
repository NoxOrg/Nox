// Generated

#nullable enable

using Microsoft.EntityFrameworkCore;
using MediatR;
using YamlDotNet.Core.Tokens;

using Nox.Application.Queries;
using Nox.Application.Repositories;

using TestWebApp.Application.Dto;

namespace TestWebApp.Application.Queries;

public partial record  GetTestEntityLocalizationTranslationsQuery(System.String keyId) : IRequest <IQueryable<TestEntityLocalizationLocalizedDto>>;

internal partial class GetTestEntityLocalizationTranslationsQueryHandler:GetTestEntityLocalizationTranslationsQueryHandlerBase
{
    public  GetTestEntityLocalizationTranslationsQueryHandler(IReadOnlyRepository readOnlyRepository): base(readOnlyRepository){}
}

internal abstract class GetTestEntityLocalizationTranslationsQueryHandlerBase:  QueryBase<IQueryable<TestEntityLocalizationLocalizedDto>>, IRequestHandler<GetTestEntityLocalizationTranslationsQuery, IQueryable<TestEntityLocalizationLocalizedDto>>
{
    public  GetTestEntityLocalizationTranslationsQueryHandlerBase(IReadOnlyRepository readOnlyRepository)
    {
        ReadOnlyRepository = readOnlyRepository;
    }

    public IReadOnlyRepository ReadOnlyRepository { get; }

    public virtual Task<IQueryable<TestEntityLocalizationLocalizedDto>> Handle(GetTestEntityLocalizationTranslationsQuery request, CancellationToken cancellationToken)
    {    
        var query = ReadOnlyRepository.Query<TestEntityLocalizationLocalizedDto>()
            .Where(r =>
                r.Id.Equals(request.keyId));
        return Task.FromResult(OnResponse(query));
    }
}