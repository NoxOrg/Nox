// Generated

#nullable enable

using Microsoft.EntityFrameworkCore;
using MediatR;
using YamlDotNet.Core.Tokens;

using Nox.Application.Queries;
using Nox.Application.Repositories;

using TestWebApp.Application.Dto;
using TestWebApp.Infrastructure.Persistence;

namespace TestWebApp.Application.Queries;

public record  GetTestEntityLocalizationTranslationsByIdQuery(System.String keyId, Nox.Types.CultureCode CultureCode) : IRequest <IQueryable<TestEntityLocalizationLocalizedDto>>;

internal partial class GetTestEntityLocalizationTranslationsByIdQueryHandler:GetTestEntityLocalizationTranslationsByIdQueryHandlerBase
{
    public  GetTestEntityLocalizationTranslationsByIdQueryHandler(IReadOnlyRepository readOnlyRepository): base(readOnlyRepository){}
}

internal abstract class GetTestEntityLocalizationTranslationsByIdQueryHandlerBase:  QueryBase<IQueryable<TestEntityLocalizationLocalizedDto>>, IRequestHandler<GetTestEntityLocalizationTranslationsByIdQuery, IQueryable<TestEntityLocalizationLocalizedDto>>
{
    public  GetTestEntityLocalizationTranslationsByIdQueryHandlerBase(IReadOnlyRepository readOnlyRepository)
    {
        ReadOnlyRepository = readOnlyRepository;
    }

    public IReadOnlyRepository ReadOnlyRepository { get; }

    public virtual Task<IQueryable<TestEntityLocalizationLocalizedDto>> Handle(GetTestEntityLocalizationTranslationsByIdQuery request, CancellationToken cancellationToken)
    {    
        var query = ReadOnlyRepository.Query<TestEntityLocalizationLocalizedDto>()
            .Where(r =>
                r.Id.Equals(request.keyId)
                && r.CultureCode == request.CultureCode.Value
            );
        return Task.FromResult(OnResponse(query));
    }
}