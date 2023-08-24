// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using SampleWebApp.Application.Dto;
using SampleWebApp.Infrastructure.Persistence;

namespace SampleWebApp.Application.Queries;

public record GetStoreSecurityPasswordsQuery() : IRequest<IQueryable<StoreSecurityPasswordsDto>>;

public partial class GetStoreSecurityPasswordsQueryHandler : QueryBase<IQueryable<StoreSecurityPasswordsDto>>, IRequestHandler<GetStoreSecurityPasswordsQuery, IQueryable<StoreSecurityPasswordsDto>>
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