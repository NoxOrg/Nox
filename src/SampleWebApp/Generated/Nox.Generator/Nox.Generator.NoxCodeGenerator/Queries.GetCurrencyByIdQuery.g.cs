// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using SampleWebApp.Application.Dto;
using SampleWebApp.Presentation.Api.OData;

namespace SampleWebApp.Application.Queries;

public record GetCurrencyByIdQuery(System.UInt32 keyId) : IRequest<CurrencyDto?>;

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
            .SingleOrDefault(r =>
                r.Id.Equals(request.keyId) &&
                !(r.Deleted == true));
        return Task.FromResult(item);
    }
}