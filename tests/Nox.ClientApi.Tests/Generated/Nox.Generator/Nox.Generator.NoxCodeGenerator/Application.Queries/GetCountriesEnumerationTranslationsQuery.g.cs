// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Queries;

using DtoNameSpace = ClientApi.Application.Dto;
using PersistenceNameSpace = ClientApi.Infrastructure.Persistence;

namespace ClientApi.Application.Queries;
public partial record GetCountriesContinentsTranslationsQuery() : IRequest<IQueryable<DtoNameSpace.CountryContinentLocalizedDto>>;

internal partial class GetCountriesContinentsTranslationsQueryHandler: GetCountriesContinentsTranslationsQueryHandlerBase
{
    public GetCountriesContinentsTranslationsQueryHandler(PersistenceNameSpace.DtoDbContext dataDbContext): base(dataDbContext){}
}

internal abstract class GetCountriesContinentsTranslationsQueryHandlerBase : QueryBase<IQueryable<DtoNameSpace.CountryContinentLocalizedDto>>, IRequestHandler<GetCountriesContinentsTranslationsQuery, IQueryable<DtoNameSpace.CountryContinentLocalizedDto>>
{
    public  GetCountriesContinentsTranslationsQueryHandlerBase(PersistenceNameSpace.DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public PersistenceNameSpace.DtoDbContext DataDbContext { get; }

    public virtual Task<IQueryable<DtoNameSpace.CountryContinentLocalizedDto>> Handle(GetCountriesContinentsTranslationsQuery request, CancellationToken cancellationToken)
    {
       
        var queryBuilder = DataDbContext.CountriesContinentsLocalized
            .AsNoTracking<DtoNameSpace.CountryContinentLocalizedDto>();
        return Task.FromResult(OnResponse(queryBuilder));
       
    }  
}