// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Queries;
using Nox.Application.Repositories;

using DtoNameSpace = ClientApi.Application.Dto;

namespace ClientApi.Application.Queries;
public partial record GetTenantContactsStatusesQuery(Nox.Types.CultureCode cultureCode) : IRequest<IQueryable<DtoNameSpace.TenantContactStatusDto>>;

internal partial class GetTenantContactsStatusesQueryHandler: GetTenantContactsStatusesQueryHandlerBase
{
    public GetTenantContactsStatusesQueryHandler(IReadOnlyRepository readOnlyRepository): base(readOnlyRepository){}
}

internal abstract class GetTenantContactsStatusesQueryHandlerBase : QueryBase<IQueryable<DtoNameSpace.TenantContactStatusDto>>, IRequestHandler<GetTenantContactsStatusesQuery, IQueryable<DtoNameSpace.TenantContactStatusDto>>
{
    public  GetTenantContactsStatusesQueryHandlerBase(IReadOnlyRepository readOnlyRepository)
    {
        ReadOnlyRepository = readOnlyRepository;
    }

    public IReadOnlyRepository ReadOnlyRepository { get; }

    public virtual Task<IQueryable<DtoNameSpace.TenantContactStatusDto>> Handle(GetTenantContactsStatusesQuery request, CancellationToken cancellationToken)
    {
        {
            var cultureCode = request.cultureCode.Value;
            IQueryable<DtoNameSpace.TenantContactStatusDto> queryBuilder =
            from enumValues in ReadOnlyRepository.Query<DtoNameSpace.TenantContactStatusDto>()
            from enumLocalized in ReadOnlyRepository.Query<DtoNameSpace.TenantContactStatusLocalizedDto>()
                .Where(l => enumValues.Id == l.Id && l.CultureCode == cultureCode).DefaultIfEmpty()
            select new DtoNameSpace.TenantContactStatusDto()
            {
                Id = enumValues.Id,
                Name = enumLocalized.Name ?? "[" + enumValues.Name + "]",
            };
            return Task.FromResult(OnResponse(queryBuilder));
        }
    }
}