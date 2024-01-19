// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Queries;
using Nox.Application.Repositories;

using DtoNameSpace = ClientApi.Application.Dto;
using PersistenceNameSpace = ClientApi.Infrastructure.Persistence;

namespace ClientApi.Application.Queries;
public partial record GetTenantsStatusesQuery(Nox.Types.CultureCode cultureCode) : IRequest<IQueryable<DtoNameSpace.TenantStatusDto>>;

internal partial class GetTenantsStatusesQueryHandler: GetTenantsStatusesQueryHandlerBase
{
    public GetTenantsStatusesQueryHandler(IReadOnlyRepository readOnlyRepository): base(readOnlyRepository){}
}

internal abstract class GetTenantsStatusesQueryHandlerBase : QueryBase<IQueryable<DtoNameSpace.TenantStatusDto>>, IRequestHandler<GetTenantsStatusesQuery, IQueryable<DtoNameSpace.TenantStatusDto>>
{
    public  GetTenantsStatusesQueryHandlerBase(IReadOnlyRepository readOnlyRepository)
    {
        ReadOnlyRepository = readOnlyRepository;
    }

    public IReadOnlyRepository ReadOnlyRepository { get; }

    public virtual Task<IQueryable<DtoNameSpace.TenantStatusDto>> Handle(GetTenantsStatusesQuery request, CancellationToken cancellationToken)
    {
        var queryBuilder = ReadOnlyRepository.Query<DtoNameSpace.TenantStatusDto>();
        return Task.FromResult(OnResponse(queryBuilder));
    }
}