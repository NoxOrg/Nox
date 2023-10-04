// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using Cryptocash.Application.Dto;
using Cryptocash.Infrastructure.Persistence;

namespace Cryptocash.Application.Queries;

public record GetCountryByIdQuery(System.String keyId) : IRequest <IQueryable<CountryDto>>;

internal partial class GetCountryByIdQueryHandler:GetCountryByIdQueryHandlerBase
{
    public  GetCountryByIdQueryHandler(DtoDbContext dataDbContext): base(dataDbContext)
    {
    
    }
}

internal abstract class GetCountryByIdQueryHandlerBase:  QueryBase<IQueryable<CountryDto>>, IRequestHandler<GetCountryByIdQuery, IQueryable<CountryDto>>
{
    public  GetCountryByIdQueryHandlerBase(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public virtual Task<IQueryable<CountryDto>> Handle(GetCountryByIdQuery request, CancellationToken cancellationToken)
    {    
        var query = DataDbContext.Countries
            .AsNoTracking()
            .Where(r =>
                r.Id.Equals(request.keyId));
        return Task.FromResult(OnResponse(query));
    }
}