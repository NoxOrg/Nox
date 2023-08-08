// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using SampleWebApp.Application.Dto;
using SampleWebApp.Presentation.Api.OData;

namespace SampleWebApp.Application.Queries;

public record GetStoreSecurityPasswordsQuery() : IRequest<IQueryable<StoreSecurityPasswordsDto>>;

public class GetStoreSecurityPasswordsQueryHandler : IRequestHandler<GetStoreSecurityPasswordsQuery, IQueryable<StoreSecurityPasswordsDto>>
{
    public  GetStoreSecurityPasswordsQueryHandler(ODataDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public ODataDbContext DataDbContext { get; }

    public Task<IQueryable<StoreSecurityPasswordsDto>> Handle(GetStoreSecurityPasswordsQuery request, CancellationToken cancellationToken)
    {
        var item = (IQueryable<StoreSecurityPasswordsDto>)DataDbContext.StoreSecurityPasswords
            .Where(r => !(r.Deleted == true))
            .AsNoTracking();
        return Task.FromResult(item);
    }
}