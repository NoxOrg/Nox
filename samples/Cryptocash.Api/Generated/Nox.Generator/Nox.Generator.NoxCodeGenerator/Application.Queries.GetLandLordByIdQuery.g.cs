// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using Cryptocash.Application.Dto;
using Cryptocash.Infrastructure.Persistence;

namespace Cryptocash.Application.Queries;

public record GetLandLordByIdQuery(System.Int64 keyId) : IRequest <IQueryable<LandLordDto>>;

public partial class GetLandLordByIdQueryHandler:  QueryBase<IQueryable<LandLordDto>>, IRequestHandler<GetLandLordByIdQuery, IQueryable<LandLordDto>>
{
    public  GetLandLordByIdQueryHandler(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public Task<IQueryable<LandLordDto>> Handle(GetLandLordByIdQuery request, CancellationToken cancellationToken)
    {    
        var query = DataDbContext.LandLords
            .AsNoTracking()
            .Where(r =>
                r.Id.Equals(request.keyId) &&
                r.DeletedAtUtc == null);
        return Task.FromResult(OnResponse(query));
    }
}