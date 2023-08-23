// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using SampleWebApp.Application.Dto;
using SampleWebApp.Infrastructure.Persistence;

namespace SampleWebApp.Application.Queries;

public record GetStoreSecurityPasswordsQuery() : IRequest<IQueryable<StoreSecurityPasswordsDto>>;

public class GetStoreSecurityPasswordsQueryHandler : IRequestHandler<GetStoreSecurityPasswordsQuery, IQueryable<StoreSecurityPasswordsDto>>
{
    public  GetStoreSecurityPasswordsQueryHandler(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public Task<IQueryable<StoreSecurityPasswordsDto>> Handle(GetStoreSecurityPasswordsQuery request, CancellationToken cancellationToken)
    {
        var item = (IQueryable<StoreSecurityPasswordsDto>)DataDbContext.StoreSecurityPasswords
            .Where(r => r.DeletedAtUtc == null)
            .AsNoTracking();
        return Task.FromResult(item);
    }
}