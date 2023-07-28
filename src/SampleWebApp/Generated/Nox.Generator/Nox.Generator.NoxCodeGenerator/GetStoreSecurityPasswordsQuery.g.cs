// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using SampleWebApp.Presentation.Api.OData;

namespace SampleWebApp.Domain;

public record GetStoreSecurityPasswordsQuery() : IRequest<IQueryable<OStoreSecurityPasswords>>;

public class GetStoreSecurityPasswordsHandler : IRequestHandler<GetStoreSecurityPasswordsQuery, IQueryable<OStoreSecurityPasswords>>
{
    public  GetStoreSecurityPasswordsHandler(ODataDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public ODataDbContext DataDbContext { get; }

    public Task<IQueryable<OStoreSecurityPasswords>> Handle(GetStoreSecurityPasswordsQuery request, CancellationToken cancellationToken)
    {
        return Task.FromResult((IQueryable<OStoreSecurityPasswords>)DataDbContext.StoreSecurityPasswords);
    }
}