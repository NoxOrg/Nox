// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using SampleWebApp.Presentation.Api.OData;

namespace SampleWebApp.Domain;

public record GetStoresQuery() : IRequest<IQueryable<OStore>>;

public class GetStoresQueryHandler : IRequestHandler<GetStoresQuery, IQueryable<OStore>>
{
    public  GetStoresQueryHandler(ODataDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public ODataDbContext DataDbContext { get; }

    public Task<IQueryable<OStore>> Handle(GetStoresQuery request, CancellationToken cancellationToken)
    {
        return Task.FromResult((IQueryable<OStore>)DataDbContext.Stores);
    }
}