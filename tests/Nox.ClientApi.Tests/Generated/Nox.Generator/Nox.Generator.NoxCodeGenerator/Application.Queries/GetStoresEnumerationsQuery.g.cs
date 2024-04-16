// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Queries;
using Nox.Application.Repositories;

using DtoNameSpace = ClientApi.Application.Dto;

namespace ClientApi.Application.Queries;
public partial record GetStoresStatusesQuery(Nox.Types.CultureCode cultureCode) : IRequest<IQueryable<DtoNameSpace.StoreStatusDto>>;

internal partial class GetStoresStatusesQueryHandler: GetStoresStatusesQueryHandlerBase
{
    public GetStoresStatusesQueryHandler(IReadOnlyRepository readOnlyRepository): base(readOnlyRepository){}
}

internal abstract class GetStoresStatusesQueryHandlerBase : QueryBase<IQueryable<DtoNameSpace.StoreStatusDto>>, IRequestHandler<GetStoresStatusesQuery, IQueryable<DtoNameSpace.StoreStatusDto>>
{
    public  GetStoresStatusesQueryHandlerBase(IReadOnlyRepository readOnlyRepository)
    {
        ReadOnlyRepository = readOnlyRepository;
    }

    public IReadOnlyRepository ReadOnlyRepository { get; }

    public virtual Task<IQueryable<DtoNameSpace.StoreStatusDto>> Handle(GetStoresStatusesQuery request, CancellationToken cancellationToken)
    {
        var queryBuilder = ReadOnlyRepository.Query<DtoNameSpace.StoreStatusDto>();
        return Task.FromResult(OnResponse(queryBuilder));
    }
}