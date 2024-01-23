// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Queries;
using Nox.Application.Repositories;
using ClientApi.Application.Dto;
using ClientApi.Infrastructure.Persistence;

namespace ClientApi.Application.Queries;

public partial record GetRatingProgramsQuery() : IRequest<IQueryable<RatingProgramDto>>;

internal partial class GetRatingProgramsQueryHandler: GetRatingProgramsQueryHandlerBase
{
    public GetRatingProgramsQueryHandler(IReadOnlyRepository readOnlyRepository): base(readOnlyRepository){}
}

internal abstract class GetRatingProgramsQueryHandlerBase : QueryBase<IQueryable<RatingProgramDto>>, IRequestHandler<GetRatingProgramsQuery, IQueryable<RatingProgramDto>>
{
    public  GetRatingProgramsQueryHandlerBase(IReadOnlyRepository readOnlyRepository)
    {
        ReadOnlyRepository = readOnlyRepository;
    }

    public IReadOnlyRepository ReadOnlyRepository { get; }

    public virtual Task<IQueryable<RatingProgramDto>> Handle(GetRatingProgramsQuery request, CancellationToken cancellationToken)
    {
        var query = ReadOnlyRepository.Query<RatingProgramDto>();
       return Task.FromResult(OnResponse(query));
    }
}