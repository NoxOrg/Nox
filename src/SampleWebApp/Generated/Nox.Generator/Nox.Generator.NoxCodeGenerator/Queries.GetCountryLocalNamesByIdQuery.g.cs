// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using SampleWebApp.Application.Dto;
using SampleWebApp.Presentation.Api.OData;

namespace SampleWebApp.Application.Queries;

public record GetCountryLocalNamesByIdQuery(System.String key) : IRequest<CountryLocalNamesDto?>;

public class GetCountryLocalNamesByIdQueryHandler: IRequestHandler<GetCountryLocalNamesByIdQuery, CountryLocalNamesDto?>
{
    public  GetCountryLocalNamesByIdQueryHandler(ODataDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public ODataDbContext DataDbContext { get; }

    public Task<CountryLocalNamesDto?> Handle(GetCountryLocalNamesByIdQuery request, CancellationToken cancellationToken)
    {    
        var item = DataDbContext.CountryLocalNames
            .AsNoTracking()
            .SingleOrDefault(r => !(r.Deleted == true) && r.Id.Equals(request.key));            
        return Task.FromResult(item);
    }
}