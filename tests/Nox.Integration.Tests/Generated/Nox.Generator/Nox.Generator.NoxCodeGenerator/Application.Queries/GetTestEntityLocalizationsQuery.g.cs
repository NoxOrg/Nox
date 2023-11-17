// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using TestWebApp.Application.Dto;
using TestWebApp.Infrastructure.Persistence;
using Nox.Presentation.Api;
using Nox.Solution;
using Nox.Types;

namespace TestWebApp.Application.Queries;

public partial class GetTestEntityLocalizationsQuery : IRequest<IQueryable<TestEntityLocalizationDto>>
{
    public CultureCode CultureCode { get; set; }

    public GetTestEntityLocalizationsQuery(CultureCode cultureCode)
    {
        CultureCode = cultureCode;
    }
};

internal partial class GetTestEntityLocalizationsQueryHandler: GetTestEntityLocalizationsQueryHandlerBase
{
    public GetTestEntityLocalizationsQueryHandler(DtoDbContext dataDbContext): base(dataDbContext)
    {

    }
}

internal abstract class GetTestEntityLocalizationsQueryHandlerBase : QueryBase<IQueryable<TestEntityLocalizationDto>>, IRequestHandler<GetTestEntityLocalizationsQuery, IQueryable<TestEntityLocalizationDto>>
{
    public  GetTestEntityLocalizationsQueryHandlerBase(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public virtual Task<IQueryable<TestEntityLocalizationDto>> Handle(GetTestEntityLocalizationsQuery request, CancellationToken cancellationToken)
    {
        var cultureCode = request.CultureCode.Value;

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

        var sqlStatement = linqQueryBuilder.ToQueryString().Replace($"WHERE @__{nameof(cultureCode)}_0", $"WHERE '{cultureCode}'");

        IQueryable<TestEntityLocalizationDto> getItemsQuery =
            from item in DataDbContext.TestEntityLocalizations.FromSqlRaw(sqlStatement)
            select item;

        return Task.FromResult(OnResponse(getItemsQuery));
    }
}