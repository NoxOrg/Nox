// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using ClientApi.Application.Dto;
using ClientApi.Infrastructure.Persistence;

namespace ClientApi.Application.Queries;

public record GetRatingProgramsQuery() : IRequest<IQueryable<RatingProgramDto>>;

internal partial class GetRatingProgramsQueryHandler: GetRatingProgramsQueryHandlerBase
{
    public GetRatingProgramsQueryHandler(DtoDbContext dataDbContext): base(dataDbContext)
    {
    
    }
}

internal abstract class GetRatingProgramsQueryHandlerBase : QueryBase<IQueryable<RatingProgramDto>>, IRequestHandler<GetRatingProgramsQuery, IQueryable<RatingProgramDto>>
{
    public  GetRatingProgramsQueryHandlerBase(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public virtual Task<IQueryable<RatingProgramDto>> Handle(GetRatingProgramsQuery request, CancellationToken cancellationToken)
    {
        var item = (IQueryable<RatingProgramDto>)DataDbContext.RatingPrograms
            .AsNoTracking();
       return Task.FromResult(OnResponse(item));
    }
}