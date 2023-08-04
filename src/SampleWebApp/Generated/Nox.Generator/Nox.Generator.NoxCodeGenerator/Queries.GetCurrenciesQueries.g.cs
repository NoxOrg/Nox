// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using SampleWebApp.Presentation.Api.OData;

namespace SampleWebApp.Application.Queries;

public record GetCurrenciesQuery() : IRequest<IQueryable<OCurrency>>;

public class GetCurrenciesQueryHandler : IRequestHandler<GetCurrenciesQuery, IQueryable<OCurrency>>
{
    public  GetCurrenciesQueryHandler(ODataDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public ODataDbContext DataDbContext { get; }

    public Task<IQueryable<OCurrency>> Handle(GetCurrenciesQuery request, CancellationToken cancellationToken)
    {
        var item = (IQueryable<OCurrency>)DataDbContext.Currencies
            .Where(r => !(r.Deleted == true))
            .AsNoTracking();
        return Task.FromResult(item);
    }
}