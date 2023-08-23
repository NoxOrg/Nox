// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using SampleWebApp.Application.Dto;
using SampleWebApp.Infrastructure.Persistence;

namespace SampleWebApp.Application.Queries;

public record GetStoreSecurityPasswordsByIdQuery(System.String keyId) : IRequest<StoreSecurityPasswordsDto?>;

public class GetStoreSecurityPasswordsByIdQueryHandler: IRequestHandler<GetStoreSecurityPasswordsByIdQuery, StoreSecurityPasswordsDto?>
{
    public  GetStoreSecurityPasswordsByIdQueryHandler(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public Task<StoreSecurityPasswordsDto?> Handle(GetStoreSecurityPasswordsByIdQuery request, CancellationToken cancellationToken)
    {    
        var item = DataDbContext.StoreSecurityPasswords
            .AsNoTracking()
            .SingleOrDefault(r =>
                r.Id.Equals(request.keyId) &&
                r.DeletedAtUtc == null);
        return Task.FromResult(item);
    }
}