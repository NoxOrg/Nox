// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Queries;
using Nox.Application.Repositories;

using DtoNameSpace = ClientApi.Application.Dto;

namespace ClientApi.Application.Queries;
public partial record GetTenantContactsStatusesTranslationsQuery() : IRequest<IQueryable<DtoNameSpace.TenantContactStatusLocalizedDto>>;

internal partial class GetTenantContactsStatusesTranslationsQueryHandler: GetTenantContactsStatusesTranslationsQueryHandlerBase
{
    public GetTenantContactsStatusesTranslationsQueryHandler(IReadOnlyRepository readOnlyRepository): base(readOnlyRepository){}
}

internal abstract class GetTenantContactsStatusesTranslationsQueryHandlerBase : QueryBase<IQueryable<DtoNameSpace.TenantContactStatusLocalizedDto>>, IRequestHandler<GetTenantContactsStatusesTranslationsQuery, IQueryable<DtoNameSpace.TenantContactStatusLocalizedDto>>
{
    public  GetTenantContactsStatusesTranslationsQueryHandlerBase(IReadOnlyRepository readOnlyRepository)
    {
        ReadOnlyRepository = readOnlyRepository;
    }

    public IReadOnlyRepository ReadOnlyRepository { get; }

    public virtual Task<IQueryable<DtoNameSpace.TenantContactStatusLocalizedDto>> Handle(GetTenantContactsStatusesTranslationsQuery request, CancellationToken cancellationToken)
    {       
        var queryBuilder = ReadOnlyRepository.Query<DtoNameSpace.TenantContactStatusLocalizedDto>();
        return Task.FromResult(OnResponse(queryBuilder));       
    }  
}