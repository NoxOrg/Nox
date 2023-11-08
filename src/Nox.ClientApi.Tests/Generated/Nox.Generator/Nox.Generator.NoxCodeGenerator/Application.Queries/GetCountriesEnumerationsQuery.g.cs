// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using DtoNameSpace = ClientApi.Application.Dto;
using PersistenceNameSpace = ClientApi.Infrastructure.Persistence;

namespace ClientApi.Application.Queries;

public record GetCountriesContinentsQuery() : IRequest<IQueryable<DtoNameSpace.CountryContinentDto>>;

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
             //TODO Culture Code
            IQueryable<DtoNameSpace.CountryContinentDto> queryBuilder =
            from enumValues in DataDbContext.CountriesContinents.AsNoTracking()
            from enumLocalized in DataDbContext.CountriesContinentsLocalized.AsNoTracking()
                .Where(l => enumValues.Id == l.Id && l.CultureCode == "pt-PT").DefaultIfEmpty()
            select new DtoNameSpace.CountryContinentDto()
            {
                Id = enumValues.Id,
                Name = enumLocalized.Name ?? enumValues.Name,
            };
            return Task.FromResult(OnResponse(queryBuilder));
        }
    }
}