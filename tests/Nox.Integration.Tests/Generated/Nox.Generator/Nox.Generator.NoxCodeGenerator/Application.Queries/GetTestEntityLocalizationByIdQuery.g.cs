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

public record GetTestEntityLocalizationByIdQuery(CultureCode cultureCode, System.String keyId) : IRequest <IQueryable<TestEntityLocalizationDto>>;

internal partial class GetTestEntityLocalizationByIdQueryHandler : GetTestEntityLocalizationByIdQueryHandlerBase
{
    public  GetTestEntityLocalizationByIdQueryHandler(DtoDbContext dataDbContext) : base(dataDbContext)
    {

    }
}

internal abstract class GetTestEntityLocalizationByIdQueryHandlerBase:  QueryBase<IQueryable<TestEntityLocalizationDto>>, IRequestHandler<GetTestEntityLocalizationByIdQuery, IQueryable<TestEntityLocalizationDto>>
{
    public  GetTestEntityLocalizationByIdQueryHandlerBase(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public virtual Task<IQueryable<TestEntityLocalizationDto>> Handle(GetTestEntityLocalizationByIdQuery request, CancellationToken cancellationToken)
    {
        var cultureCode = request.cultureCode.Value;

        IQueryable<TestEntityLocalizationDto> linqQueryBuilder =
            from item in DataDbContext.TestEntityLocalizations.Where(r =>
                r.Id.Equals(request.keyId)).AsNoTracking()
            join itemLocalizedFromJoin in DataDbContext.TestEntityLocalizationsLocalized on cultureCode equals itemLocalizedFromJoin.CultureCode into joinedData
            from itemLocalized in joinedData.Where(l => item.Id == l.Id).DefaultIfEmpty()
            select new TestEntityLocalizationDto()
            {
        Id = item.Id,
        TextFieldToLocalize = itemLocalized.TextFieldToLocalize ?? "[" + item.TextFieldToLocalize + "]",
        NumberField = item.NumberField,
        Etag = item.Etag
            };

        var sqlStatement = linqQueryBuilder.ToQueryString()
            .Replace("DECLARE", "-- DECLARE")
            .Replace($"= @__{nameof(request)}_{nameof(request.keyId)}_0", $"= '{request.keyId}'")
            .Replace($"WHERE @__{nameof(cultureCode)}_1", $"WHERE '{cultureCode}'");

        IQueryable<TestEntityLocalizationDto> getItemsQuery =
            from item in DataDbContext.TestEntityLocalizations.FromSqlRaw(sqlStatement)
            select item;

        return Task.FromResult(OnResponse(getItemsQuery));
    }
}