// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using ClientApi.Application.Dto;
using ClientApi.Infrastructure.Persistence;

namespace ClientApi.Application.Queries;

public record GetRatingProgramByIdQuery(System.Guid keyStoreId, System.Int64 keyId) : IRequest <IQueryable<RatingProgramDto>>;

internal partial class GetRatingProgramByIdQueryHandler:GetRatingProgramByIdQueryHandlerBase
{
    public  GetRatingProgramByIdQueryHandler(DtoDbContext dataDbContext): base(dataDbContext)
    {
    
    }
}

internal abstract class GetRatingProgramByIdQueryHandlerBase:  QueryBase<IQueryable<RatingProgramDto>>, IRequestHandler<GetRatingProgramByIdQuery, IQueryable<RatingProgramDto>>
{
    public  GetRatingProgramByIdQueryHandlerBase(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public virtual Task<IQueryable<RatingProgramDto>> Handle(GetRatingProgramByIdQuery request, CancellationToken cancellationToken)
    {    
        var query = DataDbContext.RatingPrograms
            .AsNoTracking()
            .Where(r =>
                r.StoreId.Equals(request.keyStoreId) &&
                r.Id.Equals(request.keyId) &&
                true
            );
        return Task.FromResult(OnResponse(query));
    }
}