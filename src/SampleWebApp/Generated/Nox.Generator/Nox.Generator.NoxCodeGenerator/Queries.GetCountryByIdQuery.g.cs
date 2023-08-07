// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using SampleWebApp.Application.Dto;
using SampleWebApp.Presentation.Api.OData;

namespace SampleWebApp.Application.Queries;

public record GetCountryByIdQuery(System.String key) : IRequest<OCountry?>;

public class GetCountryByIdQueryHandler: IRequestHandler<GetCountryByIdQuery, OCountry?>
{
    public  GetCountryByIdQueryHandler(ODataDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public ODataDbContext DataDbContext { get; }

    public Task<OCountry?> Handle(GetCountryByIdQuery request, CancellationToken cancellationToken)
    {    
        var item = DataDbContext.Countries
            .AsNoTracking()
            .SingleOrDefault(r => !(r.Deleted == true) && r.Id.Equals(request.key));            
        return Task.FromResult(item);
    }
}