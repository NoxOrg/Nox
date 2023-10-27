// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using ClientApi.Application.Dto;
using ClientApi.Infrastructure.Persistence;using Nox.Presentation.Api;
using Nox.Solution;

namespace ClientApi.Application.Queries;

public record GetWorkplacesQuery() : IRequest<IQueryable<WorkplaceDto>>;

internal partial class GetWorkplacesQueryHandler: GetWorkplacesQueryHandlerBase
{
    public GetWorkplacesQueryHandler(DtoDbContext dataDbContext,
        NoxSolution solution,
        IHttpLanguageProvider languageProvider): base(dataDbContext,
            solution,
            languageProvider)
    {
    
    }
}

internal abstract class GetWorkplacesQueryHandlerBase : QueryBase<IQueryable<WorkplaceDto>>, IRequestHandler<GetWorkplacesQuery, IQueryable<WorkplaceDto>>
{private readonly NoxSolution _solution;
        private readonly IHttpLanguageProvider _languageProvider;

    public  GetWorkplacesQueryHandlerBase(DtoDbContext dataDbContext,
        NoxSolution solution,
        IHttpLanguageProvider languageProvider)
    {
        DataDbContext = dataDbContext;_solution = solution;
        _languageProvider = languageProvider;
    }

    public DtoDbContext DataDbContext { get; }

    public virtual Task<IQueryable<WorkplaceDto>> Handle(GetWorkplacesQuery request, CancellationToken cancellationToken)
    {
        var cultureCode = _languageProvider.GetLanguage();

        IQueryable<WorkplaceDto> linqQueryBuilder =
            from item in DataDbContext.Workplaces.AsNoTracking()
            join itemLocalizedFromJoin in DataDbContext.WorkplacesLocalized on cultureCode equals itemLocalizedFromJoin.CultureCode into joinedData
            from itemLocalized in joinedData.Where(l => item.Id == l.Id).DefaultIfEmpty()
            select new WorkplaceDto()
            {
        Id = item.Id,
        Name = item.Name,
        Description = itemLocalized.Description ?? "[" + item.Description + "]",
        Greeting = item.Greeting,
        BelongsToCountryId = item.BelongsToCountryId,
        Etag = item.Etag
            };

        var sqlStatement = linqQueryBuilder.ToQueryString().Replace($"WHERE @__{nameof(cultureCode)}_0", $"WHERE '{cultureCode}'");

        IQueryable<WorkplaceDto> getItemsQuery =
            from item in DataDbContext.Workplaces.FromSqlRaw(sqlStatement)
            select item;

        return Task.FromResult(OnResponse(getItemsQuery));

    }
}