// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using CryptocashApi.Application.Dto;
using CryptocashApi.Infrastructure.Persistence;

namespace CryptocashApi.Application.Queries;

public record GetLandLordsQuery() : IRequest<IQueryable<LandLordDto>>;

public class GetLandLordsQueryHandler : IRequestHandler<GetLandLordsQuery, IQueryable<LandLordDto>>
{
    public  GetLandLordsQueryHandler(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public Task<IQueryable<LandLordDto>> Handle(GetLandLordsQuery request, CancellationToken cancellationToken)
    {
        var item = (IQueryable<LandLordDto>)DataDbContext.LandLords
            .Where(r => r.DeletedAtUtc == null)
            .AsNoTracking();
        return Task.FromResult(item);
    }
}