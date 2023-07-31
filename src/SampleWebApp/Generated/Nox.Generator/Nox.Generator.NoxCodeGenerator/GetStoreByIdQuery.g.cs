// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using SampleWebApp.Presentation.Api.OData;

namespace SampleWebApp.Domain;

public record GetStoreByIdQuery(String key) : IRequest<OStore?>;

public class GetStoreByIdQueryHandler: IRequestHandler<GetStoreByIdQuery, OStore?>
{
    public  GetStoreByIdQueryHandler(ODataDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public ODataDbContext DataDbContext { get; }

    public Task<OStore?> Handle(GetStoreByIdQuery request, CancellationToken cancellationToken)
    {    
        var item = DataDbContext.Stores.SingleOrDefault(r => r.Id.Equals(request.key));
        return Task.FromResult(item);
    }
}