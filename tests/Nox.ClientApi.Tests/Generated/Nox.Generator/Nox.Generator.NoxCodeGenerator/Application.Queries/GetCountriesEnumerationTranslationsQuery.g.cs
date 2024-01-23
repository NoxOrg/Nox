// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Queries;
using Nox.Application.Repositories;

using DtoNameSpace = ClientApi.Application.Dto;
using PersistenceNameSpace = ClientApi.Infrastructure.Persistence;

namespace ClientApi.Application.Queries;
public partial record GetCountriesContinentsTranslationsQuery() : IRequest<IQueryable<DtoNameSpace.CountryContinentLocalizedDto>>;

internal partial class GetCountriesContinentsTranslationsQueryHandler: GetCountriesContinentsTranslationsQueryHandlerBase
{
    public GetCountriesContinentsTranslationsQueryHandler(IReadOnlyRepository readOnlyRepository): base(readOnlyRepository){}
}

internal abstract class GetCountriesContinentsTranslationsQueryHandlerBase : QueryBase<IQueryable<DtoNameSpace.CountryContinentLocalizedDto>>, IRequestHandler<GetCountriesContinentsTranslationsQuery, IQueryable<DtoNameSpace.CountryContinentLocalizedDto>>
{
    public  GetCountriesContinentsTranslationsQueryHandlerBase(IReadOnlyRepository readOnlyRepository)
    {
        ReadOnlyRepository = readOnlyRepository;
    }

    public IReadOnlyRepository ReadOnlyRepository { get; }

    public virtual Task<IQueryable<DtoNameSpace.CountryContinentLocalizedDto>> Handle(GetCountriesContinentsTranslationsQuery request, CancellationToken cancellationToken)
    {       
        var queryBuilder = ReadOnlyRepository.Query<DtoNameSpace.CountryContinentLocalizedDto>();
        return Task.FromResult(OnResponse(queryBuilder));       
    }  
}