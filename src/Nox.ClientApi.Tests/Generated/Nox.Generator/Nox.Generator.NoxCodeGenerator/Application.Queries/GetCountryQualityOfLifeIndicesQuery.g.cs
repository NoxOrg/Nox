// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using ClientApi.Application.Dto;
using ClientApi.Infrastructure.Persistence;

namespace ClientApi.Application.Queries;

public partial record GetCountryQualityOfLifeIndicesQuery() : IRequest<IQueryable<CountryQualityOfLifeIndexDto>>;

internal partial class GetCountryQualityOfLifeIndicesQueryHandler: GetCountryQualityOfLifeIndicesQueryHandlerBase
{
    public GetCountryQualityOfLifeIndicesQueryHandler(DtoDbContext dataDbContext): base(dataDbContext)
    {
    
    }
}

internal abstract class GetCountryQualityOfLifeIndicesQueryHandlerBase : QueryBase<IQueryable<CountryQualityOfLifeIndexDto>>, IRequestHandler<GetCountryQualityOfLifeIndicesQuery, IQueryable<CountryQualityOfLifeIndexDto>>
{
    public  GetCountryQualityOfLifeIndicesQueryHandlerBase(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public virtual Task<IQueryable<CountryQualityOfLifeIndexDto>> Handle(GetCountryQualityOfLifeIndicesQuery request, CancellationToken cancellationToken)
    {
        var item = (IQueryable<CountryQualityOfLifeIndexDto>)DataDbContext.CountryQualityOfLifeIndices
            .AsNoTracking();
       return Task.FromResult(OnResponse(item));
    }
}