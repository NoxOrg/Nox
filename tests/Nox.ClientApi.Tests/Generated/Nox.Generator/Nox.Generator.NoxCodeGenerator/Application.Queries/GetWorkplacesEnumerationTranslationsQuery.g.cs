// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Queries;
using Nox.Application.Repositories;

using DtoNameSpace = ClientApi.Application.Dto;
using PersistenceNameSpace = ClientApi.Infrastructure.Persistence;

namespace ClientApi.Application.Queries;
public partial record GetWorkplacesOwnershipsTranslationsQuery() : IRequest<IQueryable<DtoNameSpace.WorkplaceOwnershipLocalizedDto>>;

internal partial class GetWorkplacesOwnershipsTranslationsQueryHandler: GetWorkplacesOwnershipsTranslationsQueryHandlerBase
{
    public GetWorkplacesOwnershipsTranslationsQueryHandler(IReadOnlyRepository readOnlyRepository): base(readOnlyRepository){}
}

internal abstract class GetWorkplacesOwnershipsTranslationsQueryHandlerBase : QueryBase<IQueryable<DtoNameSpace.WorkplaceOwnershipLocalizedDto>>, IRequestHandler<GetWorkplacesOwnershipsTranslationsQuery, IQueryable<DtoNameSpace.WorkplaceOwnershipLocalizedDto>>
{
    public  GetWorkplacesOwnershipsTranslationsQueryHandlerBase(IReadOnlyRepository readOnlyRepository)
    {
        ReadOnlyRepository = readOnlyRepository;
    }

    public IReadOnlyRepository ReadOnlyRepository { get; }

    public virtual Task<IQueryable<DtoNameSpace.WorkplaceOwnershipLocalizedDto>> Handle(GetWorkplacesOwnershipsTranslationsQuery request, CancellationToken cancellationToken)
    {       
        var queryBuilder = ReadOnlyRepository.Query<DtoNameSpace.WorkplaceOwnershipLocalizedDto>();
        return Task.FromResult(OnResponse(queryBuilder));       
    }  
}