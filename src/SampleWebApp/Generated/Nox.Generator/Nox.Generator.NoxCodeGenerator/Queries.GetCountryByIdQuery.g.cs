// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using SampleWebApp.Application.Dto;
using SampleWebApp.Presentation.Api.OData;

namespace SampleWebApp.Application.Queries;

public record GetCountryByIdQuery(System.String Id) : IRequest<CountryDto?>;

public class GetCountryByIdQueryHandler: IRequestHandler<GetCountryByIdQuery, CountryDto?>
{
    public  GetCountryByIdQueryHandler(ODataDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public ODataDbContext DataDbContext { get; }

    public Task<CountryDto?> Handle(GetCountryByIdQuery request, CancellationToken cancellationToken)
    {    
        var item = DataDbContext.Countries
            .AsNoTracking()
            .SingleOrDefault(r =>
                r.Id.Equals(request.Id) &&
                !(r.Deleted == true));
        return Task.FromResult(item);
    }
}