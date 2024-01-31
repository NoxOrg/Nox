// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Queries;
using Nox.Application.Repositories;
using Cryptocash.Application.Dto;

namespace Cryptocash.Application.Queries;

public partial record GetLandLordsQuery() : IRequest<IQueryable<LandLordDto>>;

internal partial class GetLandLordsQueryHandler: GetLandLordsQueryHandlerBase
{
    public GetLandLordsQueryHandler(IReadOnlyRepository readOnlyRepository): base(readOnlyRepository){}
}

internal abstract class GetLandLordsQueryHandlerBase : QueryBase<IQueryable<LandLordDto>>, IRequestHandler<GetLandLordsQuery, IQueryable<LandLordDto>>
{
    public  GetLandLordsQueryHandlerBase(IReadOnlyRepository readOnlyRepository)
    {
        ReadOnlyRepository = readOnlyRepository;
    }

    public IReadOnlyRepository ReadOnlyRepository { get; }

    public virtual Task<IQueryable<LandLordDto>> Handle(GetLandLordsQuery request, CancellationToken cancellationToken)
    {
        var query = ReadOnlyRepository.Query<LandLordDto>();
       return Task.FromResult(OnResponse(query));
    }
}