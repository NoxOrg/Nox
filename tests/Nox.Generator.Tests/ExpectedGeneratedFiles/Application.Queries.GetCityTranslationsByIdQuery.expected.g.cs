// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;
using YamlDotNet.Core.Tokens;
using SampleWebApp.Application.Dto;
using SampleWebApp.Infrastructure.Persistence;

namespace SampleWebApp.Application.Queries;

public record  GetCityTranslationsByIdQuery(System.String keyId, Nox.Types.CultureCode CultureCode) : IRequest <IQueryable<CityLocalizedDto>>;

internal partial class GetCityTranslationsByIdQueryHandler:GetCityTranslationsByIdQueryHandlerBase
{
    public  GetCityTranslationsByIdQueryHandler(DtoDbContext dataDbContext): base(dataDbContext)
    {
    
    }
}

internal abstract class GetCityTranslationsByIdQueryHandlerBase:  QueryBase<IQueryable<CityLocalizedDto>>, IRequestHandler<GetCityTranslationsByIdQuery, IQueryable<CityLocalizedDto>>
{
    public  GetCityTranslationsByIdQueryHandlerBase(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public virtual Task<IQueryable<CityLocalizedDto>> Handle(GetCityTranslationsByIdQuery request, CancellationToken cancellationToken)
    {    
        var query = DataDbContext.CitiesLocalized
            .AsNoTracking()
            .Where(r =>
                r.Id.Equals(request.keyId)
                && r.CultureCode == request.CultureCode.Value
            );
        return Task.FromResult(OnResponse(query));
    }
}