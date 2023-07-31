// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using SampleWebApp.Presentation.Api.OData;

namespace SampleWebApp.Application.Queries;

public record GetCurrencyByIdQuery(String key) : IRequest<OCurrency?>;

public class GetCurrencyByIdQueryHandler: IRequestHandler<GetCurrencyByIdQuery, OCurrency?>
{
    public  GetCurrencyByIdQueryHandler(ODataDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public ODataDbContext DataDbContext { get; }

    public Task<OCurrency?> Handle(GetCurrencyByIdQuery request, CancellationToken cancellationToken)
    {    
        var item = DataDbContext.Currencies.SingleOrDefault(r => r.Id.Equals(request.key));
        return Task.FromResult(item);
    }
}