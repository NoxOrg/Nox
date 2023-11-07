// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using ClientApi.Application.Dto;
using ClientApi.Infrastructure.Persistence;

namespace ClientApi.Application.Queries;

public partial record GetCountriesQuery() : IRequest<IQueryable<CountryDto>>;

internal partial class GetCountriesQueryHandler: GetCountriesQueryHandlerBase
{
    public GetCountriesQueryHandler(DtoDbContext dataDbContext): base(dataDbContext)
    {
    
    }
}

internal abstract class GetCountriesQueryHandlerBase : QueryBase<IQueryable<CountryDto>>, IRequestHandler<GetCountriesQuery, IQueryable<CountryDto>>
{
    public  GetCountriesQueryHandlerBase(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public virtual Task<IQueryable<CountryDto>> Handle(GetCountriesQuery request, CancellationToken cancellationToken)
    {
        var item = (IQueryable<CountryDto>)DataDbContext.Countries
            .AsNoTracking();
       return Task.FromResult(OnResponse(item));
    }
}