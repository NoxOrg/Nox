// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using TestWebApp.Application.Dto;
using TestWebApp.Infrastructure.Persistence;using Nox.Presentation.Api;
using Nox.Solution;

namespace TestWebApp.Application.Queries;

public record GetTestEntityLocalizationsQuery() : IRequest<IQueryable<TestEntityLocalizationDto>>;

internal partial class GetTestEntityLocalizationsQueryHandler: GetTestEntityLocalizationsQueryHandlerBase
{
    public GetTestEntityLocalizationsQueryHandler(DtoDbContext dataDbContext,
        NoxSolution solution,
        IHttpLanguageProvider languageProvider): base(dataDbContext,
            solution,
            languageProvider)
    {
    
    }
}

internal abstract class GetTestEntityLocalizationsQueryHandlerBase : QueryBase<IQueryable<TestEntityLocalizationDto>>, IRequestHandler<GetTestEntityLocalizationsQuery, IQueryable<TestEntityLocalizationDto>>
{private readonly NoxSolution _solution;
        private readonly IHttpLanguageProvider _languageProvider;

    public  GetTestEntityLocalizationsQueryHandlerBase(DtoDbContext dataDbContext,
        NoxSolution solution,
        IHttpLanguageProvider languageProvider)
    {
        DataDbContext = dataDbContext;_solution = solution;
        _languageProvider = languageProvider;
    }

    public DtoDbContext DataDbContext { get; }

    public virtual Task<IQueryable<TestEntityLocalizationDto>> Handle(GetTestEntityLocalizationsQuery request, CancellationToken cancellationToken)
    {
        var cultureCode = _languageProvider.GetLanguage();

        IQueryable<TestEntityLocalizationDto> linqQueryBuilder =
            from item in DataDbContext.TestEntityLocalizations.AsNoTracking()
            join itemLocalizedFromJoin in DataDbContext.TestEntityLocalizationsLocalized on cultureCode equals itemLocalizedFromJoin.CultureCode into joinedData
            from itemLocalized in joinedData.Where(l => item.Id == l.Id).DefaultIfEmpty()
            select new TestEntityLocalizationDto()
            {
        Id = item.Id,
        TextFieldToLocalize = itemLocalized.TextFieldToLocalize ?? "[" + item.TextFieldToLocalize + "]",
        NumberField = item.NumberField,
        Etag = item.Etag
            };

        var sqlStatement = linqQueryBuilder.ToQueryString().Replace($"WHERE @__{nameof(cultureCode)}_0", $"'{cultureCode}'");

        IQueryable<TestEntityLocalizationDto> getItemsQuery =
            from item in DataDbContext.TestEntityLocalizations.FromSqlRaw(sqlStatement)
            select item;

        return Task.FromResult(OnResponse(getItemsQuery));

    }
}