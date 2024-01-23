// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Queries;
using Nox.Application.Repositories;

using Cryptocash.Application.Dto;
using Cryptocash.Infrastructure.Persistence;

namespace Cryptocash.Application.Queries;

public partial record GetLandLordByIdQuery(System.Guid keyId) : IRequest <IQueryable<LandLordDto>>;

internal partial class GetLandLordByIdQueryHandler:GetLandLordByIdQueryHandlerBase
{
    public GetLandLordByIdQueryHandler(IReadOnlyRepository readOnlyRepository): base(readOnlyRepository){}
}

internal abstract class GetLandLordByIdQueryHandlerBase:  QueryBase<IQueryable<LandLordDto>>, IRequestHandler<GetLandLordByIdQuery, IQueryable<LandLordDto>>
{
    public  GetLandLordByIdQueryHandlerBase(IReadOnlyRepository readOnlyRepository)
    {
        ReadOnlyRepository = readOnlyRepository;
    }

    public IReadOnlyRepository ReadOnlyRepository { get; }

    public virtual Task<IQueryable<LandLordDto>> Handle(GetLandLordByIdQuery request, CancellationToken cancellationToken)
    {    
        var query = ReadOnlyRepository.Query<LandLordDto>()
            .Where(r =>
                r.Id.Equals(request.keyId));
        return Task.FromResult(OnResponse(query));
    }
}