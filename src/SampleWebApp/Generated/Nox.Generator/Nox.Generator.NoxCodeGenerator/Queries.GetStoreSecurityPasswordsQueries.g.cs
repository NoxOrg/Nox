// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using SampleWebApp.Application.Dto;
using SampleWebApp.Presentation.Api.OData;

namespace SampleWebApp.Application.Queries;

public record GetStoreSecurityPasswordsQuery() : IRequest<IQueryable<OStoreSecurityPasswords>>;

public class GetStoreSecurityPasswordsQueryHandler : IRequestHandler<GetStoreSecurityPasswordsQuery, IQueryable<OStoreSecurityPasswords>>
{
    public  GetStoreSecurityPasswordsQueryHandler(ODataDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public ODataDbContext DataDbContext { get; }

    public Task<IQueryable<OStoreSecurityPasswords>> Handle(GetStoreSecurityPasswordsQuery request, CancellationToken cancellationToken)
    {
        var item = (IQueryable<OStoreSecurityPasswords>)DataDbContext.StoreSecurityPasswords
            .Where(r => !(r.Deleted == true))
            .AsNoTracking();
        return Task.FromResult(item);
    }
}