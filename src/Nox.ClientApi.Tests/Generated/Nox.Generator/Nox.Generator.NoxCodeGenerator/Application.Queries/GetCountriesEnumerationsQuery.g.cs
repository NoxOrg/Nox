// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using DtoNameSpace = ClientApi.Application.Dto;
using PersistenceNameSpace = ClientApi.Infrastructure.Persistence;

namespace ClientApi.Application.Queries;

public partial record GetCountriesContinentsQuery(CultureCode cultureCode) : IRequest<IQueryable<DtoNameSpace.CountryContinentDto>>;

internal partial class GetCountriesContinentsQueryHandler: GetCountriesContinentsQueryHandlerBase
{
    public GetCountriesContinentsQueryHandler(PersistenceNameSpace.DtoDbContext dataDbContext): base(dataDbContext){}
}

internal abstract class GetCountriesContinentsQueryHandlerBase : QueryBase<IQueryable<DtoNameSpace.CountryContinentDto>>, IRequestHandler<GetCountriesContinentsQuery, IQueryable<DtoNameSpace.CountryContinentDto>>
{
    public  GetCountriesContinentsQueryHandlerBase(PersistenceNameSpace.DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public PersistenceNameSpace.DtoDbContext DataDbContext { get; }

    public virtual Task<IQueryable<DtoNameSpace.CountryContinentDto>> Handle(GetCountriesContinentsQuery request, CancellationToken cancellationToken)
    {
        {
            var cultureCode = request.cultureCode.Value;
            IQueryable<DtoNameSpace.CountryContinentDto> queryBuilder =
            from enumValues in DataDbContext.CountriesContinents.AsNoTracking()
            from enumLocalized in DataDbContext.CountriesContinentsLocalized.AsNoTracking()
                .Where(l => enumValues.Id == l.Id && l.CultureCode == cultureCode).DefaultIfEmpty()
            select new DtoNameSpace.CountryContinentDto()
            {
                Id = enumValues.Id,
                Name = enumLocalized.Name ?? "[" + enumValues.Name + "]",
            };
            return Task.FromResult(OnResponse(queryBuilder));
        }
    }
}