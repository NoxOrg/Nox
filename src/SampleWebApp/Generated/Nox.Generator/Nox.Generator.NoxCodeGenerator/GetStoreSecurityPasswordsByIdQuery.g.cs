// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using SampleWebApp.Presentation.Api.OData;

namespace SampleWebApp.Domain;

public record GetStoreSecurityPasswordsByIdQuery(String key) : IRequest<OStoreSecurityPasswords?>;

public class GetStoreSecurityPasswordsByIdQueryHandler: IRequestHandler<GetStoreSecurityPasswordsByIdQuery, OStoreSecurityPasswords?>
{
    public  GetStoreSecurityPasswordsByIdQueryHandler(ODataDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public ODataDbContext DataDbContext { get; }

    public Task<OStoreSecurityPasswords?> Handle(GetStoreSecurityPasswordsByIdQuery request, CancellationToken cancellationToken)
    {    
        var item = DataDbContext.StoreSecurityPasswords.SingleOrDefault(r => r.Id.Equals(request.key));
        return Task.FromResult(item);
    }
}