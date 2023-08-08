// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using SampleWebApp.Application.Dto;
using SampleWebApp.Presentation.Api.OData;

namespace SampleWebApp.Application.Queries;

public record GetCountryLocalNamesByIdQuery(System.String Id) : IRequest<CountryLocalNamesDto?>;

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
            .SingleOrDefault(r =>
                r.Id.Equals(request.Id) &&
                !(r.Deleted == true));
        return Task.FromResult(item);
    }
}