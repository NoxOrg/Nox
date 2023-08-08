// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using SampleWebApp.Application.Dto;
using SampleWebApp.Presentation.Api.OData;

namespace SampleWebApp.Application.Queries;

public record GetCurrencyByIdQuery(System.UInt32 key) : IRequest<CurrencyDto?>;

public class GetCurrencyByIdQueryHandler: IRequestHandler<GetCurrencyByIdQuery, CurrencyDto?>
{
    public  GetCurrencyByIdQueryHandler(ODataDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public ODataDbContext DataDbContext { get; }

    public Task<CurrencyDto?> Handle(GetCurrencyByIdQuery request, CancellationToken cancellationToken)
    {    
        var item = DataDbContext.Currencies
            .AsNoTracking()
            .SingleOrDefault(r => !(r.Deleted == true) && r.Id.Equals(request.key));            
        return Task.FromResult(item);
    }
}