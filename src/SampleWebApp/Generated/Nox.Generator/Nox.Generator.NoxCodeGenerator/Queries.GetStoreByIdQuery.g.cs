// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using SampleWebApp.Application.Dto;
using SampleWebApp.Infrastructure.Persistence;

namespace SampleWebApp.Application.Queries;

public record GetStoreByIdQuery(System.String keyId) : IRequest <StoreDto?>;

public partial class GetStoreByIdQueryHandler:  QueryBase<StoreDto?>, IRequestHandler<GetStoreByIdQuery, StoreDto?>
{
    public  GetStoreByIdQueryHandler(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public Task<StoreDto?> Handle(GetStoreByIdQuery request, CancellationToken cancellationToken)
    {    
        var item = DataDbContext.Stores
            .AsNoTracking()
            .SingleOrDefault(r =>
                r.Id.Equals(request.keyId) &&
                r.DeletedAtUtc == null);
        return Task.FromResult(item);
    }
}