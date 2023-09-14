// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using Cryptocash.Application.Dto;
using Cryptocash.Infrastructure.Persistence;

namespace Cryptocash.Application.Queries;

public record GetLandLordByIdQuery(System.Int64 keyId) : IRequest <LandLordDto?>;

public partial class GetLandLordByIdQueryHandler:  QueryBase<LandLordDto?>, IRequestHandler<GetLandLordByIdQuery, LandLordDto?>
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
            .Include(r => r.ContractedAreasForVendingMachines)
            .SingleOrDefault(r =>
                r.Id.Equals(request.keyId) &&
                r.DeletedAtUtc == null);
        return Task.FromResult(OnResponse(item));
    }
}