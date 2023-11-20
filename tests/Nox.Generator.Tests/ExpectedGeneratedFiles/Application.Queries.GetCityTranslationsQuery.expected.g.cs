// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;
using YamlDotNet.Core.Tokens;
using SampleWebApp.Application.Dto;
using SampleWebApp.Infrastructure.Persistence;

namespace SampleWebApp.Application.Queries;

public partial record  GetCityTranslationsQuery(System.String keyId) : IRequest <IQueryable<CityLocalizedDto>>;

internal partial class GetCityTranslationsQueryHandler:GetCityTranslationsQueryHandlerBase
{
    public  GetCityTranslationsQueryHandler(DtoDbContext dataDbContext): base(dataDbContext)
    {
    
    }
}

internal abstract class GetCityTranslationsQueryHandlerBase:  QueryBase<IQueryable<CityLocalizedDto>>, IRequestHandler<GetCityTranslationsQuery, IQueryable<CityLocalizedDto>>
{
    public  GetCityTranslationsQueryHandlerBase(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public virtual Task<IQueryable<CityLocalizedDto>> Handle(GetCityTranslationsQuery request, CancellationToken cancellationToken)
    {    
        var query = DataDbContext.CitiesLocalized
            .AsNoTracking()
            .Where(r =>
                r.Id.Equals(request.keyId));
        return Task.FromResult(OnResponse(query));
    }
}