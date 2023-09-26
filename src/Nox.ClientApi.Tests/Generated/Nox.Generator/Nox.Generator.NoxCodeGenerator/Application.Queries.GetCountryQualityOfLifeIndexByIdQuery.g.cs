// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using ClientApi.Application.Dto;
using ClientApi.Infrastructure.Persistence;

namespace ClientApi.Application.Queries;

public record GetCountryQualityOfLifeIndexByIdQuery(System.Int64 keyCountryId, System.Int64 keyId) : IRequest <IQueryable<CountryQualityOfLifeIndexDto>>;

internal partial class GetCountryQualityOfLifeIndexByIdQueryHandler:GetCountryQualityOfLifeIndexByIdQueryHandlerBase
{
    public  GetCountryQualityOfLifeIndexByIdQueryHandler(DtoDbContext dataDbContext): base(dataDbContext)
    {
    
    }
}

internal abstract class GetCountryQualityOfLifeIndexByIdQueryHandlerBase:  QueryBase<IQueryable<CountryQualityOfLifeIndexDto>>, IRequestHandler<GetCountryQualityOfLifeIndexByIdQuery, IQueryable<CountryQualityOfLifeIndexDto>>
{
    public  GetCountryQualityOfLifeIndexByIdQueryHandlerBase(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public virtual Task<IQueryable<CountryQualityOfLifeIndexDto>> Handle(GetCountryQualityOfLifeIndexByIdQuery request, CancellationToken cancellationToken)
    {    
        var query = DataDbContext.CountryQualityOfLifeIndices
            .AsNoTracking()
            .Where(r =>
                r.CountryId.Equals(request.keyCountryId) &&
                r.Id.Equals(request.keyId) &&
                true
            );
        return Task.FromResult(OnResponse(query));
    }
}