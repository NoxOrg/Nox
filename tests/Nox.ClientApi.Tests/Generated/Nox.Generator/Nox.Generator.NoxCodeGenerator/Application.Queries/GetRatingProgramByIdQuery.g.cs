// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Queries;
using Nox.Application.Repositories;

using ClientApi.Application.Dto;
using ClientApi.Infrastructure.Persistence;

namespace ClientApi.Application.Queries;

public partial record GetRatingProgramByIdQuery(System.Guid keyStoreId, System.Int64 keyId) : IRequest <IQueryable<RatingProgramDto>>;

internal partial class GetRatingProgramByIdQueryHandler:GetRatingProgramByIdQueryHandlerBase
{
    public GetRatingProgramByIdQueryHandler(IReadOnlyRepository readOnlyRepository): base(readOnlyRepository){}
}

internal abstract class GetRatingProgramByIdQueryHandlerBase:  QueryBase<IQueryable<RatingProgramDto>>, IRequestHandler<GetRatingProgramByIdQuery, IQueryable<RatingProgramDto>>
{
    public  GetRatingProgramByIdQueryHandlerBase(IReadOnlyRepository readOnlyRepository)
    {
        ReadOnlyRepository = readOnlyRepository;
    }

    public IReadOnlyRepository ReadOnlyRepository { get; }

    public virtual Task<IQueryable<RatingProgramDto>> Handle(GetRatingProgramByIdQuery request, CancellationToken cancellationToken)
    {    
        var query = ReadOnlyRepository.Query<RatingProgramDto>()
            .Where(r =>
                r.StoreId.Equals(request.keyStoreId) &&
                r.Id.Equals(request.keyId));
        return Task.FromResult(OnResponse(query));
    }
}