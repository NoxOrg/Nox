// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using CryptocashApi.Application.Dto;
using CryptocashApi.Infrastructure.Persistence;

namespace CryptocashApi.Application.Queries;

public record GetLandLordByIdQuery(System.Int64 keyId) : IRequest<LandLordDto?>;

public class GetLandLordByIdQueryHandler: IRequestHandler<GetLandLordByIdQuery, LandLordDto?>
{
    public  GetLandLordByIdQueryHandler(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public Task<LandLordDto?> Handle(GetLandLordByIdQuery request, CancellationToken cancellationToken)
    {    
        var item = DataDbContext.LandLords
            .AsNoTracking()
            .SingleOrDefault(r =>
                r.Id.Equals(request.keyId) &&
                r.DeletedAtUtc == null);
        return Task.FromResult(item);
    }
}