// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using SampleWebApp.Presentation.Api.OData;

namespace SampleWebApp.Application.Queries;

public record GetCountryLocalNamesByIdQuery(String key) : IRequest<OCountryLocalNames?>;

public class GetCountryLocalNamesByIdQueryHandler: IRequestHandler<GetCountryLocalNamesByIdQuery, OCountryLocalNames?>
{
    public  GetCountryLocalNamesByIdQueryHandler(ODataDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public ODataDbContext DataDbContext { get; }

    public Task<OCountryLocalNames?> Handle(GetCountryLocalNamesByIdQuery request, CancellationToken cancellationToken)
    {    
        var item = DataDbContext.CountryLocalNames.SingleOrDefault(r => !(r.Deleted == true) && r.Id.Equals(request.key));
        return Task.FromResult(item);
    }
}