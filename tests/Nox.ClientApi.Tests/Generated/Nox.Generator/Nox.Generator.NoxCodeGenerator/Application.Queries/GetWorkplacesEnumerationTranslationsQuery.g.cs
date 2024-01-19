// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Queries;

using DtoNameSpace = ClientApi.Application.Dto;
using PersistenceNameSpace = ClientApi.Infrastructure.Persistence;

namespace ClientApi.Application.Queries;
public partial record GetWorkplacesOwnershipsTranslationsQuery() : IRequest<IQueryable<DtoNameSpace.WorkplaceOwnershipLocalizedDto>>;

internal partial class GetWorkplacesOwnershipsTranslationsQueryHandler: GetWorkplacesOwnershipsTranslationsQueryHandlerBase
{
    public GetWorkplacesOwnershipsTranslationsQueryHandler(PersistenceNameSpace.DtoDbContext dataDbContext): base(dataDbContext){}
}

internal abstract class GetWorkplacesOwnershipsTranslationsQueryHandlerBase : QueryBase<IQueryable<DtoNameSpace.WorkplaceOwnershipLocalizedDto>>, IRequestHandler<GetWorkplacesOwnershipsTranslationsQuery, IQueryable<DtoNameSpace.WorkplaceOwnershipLocalizedDto>>
{
    public  GetWorkplacesOwnershipsTranslationsQueryHandlerBase(PersistenceNameSpace.DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public PersistenceNameSpace.DtoDbContext DataDbContext { get; }

    public virtual Task<IQueryable<DtoNameSpace.WorkplaceOwnershipLocalizedDto>> Handle(GetWorkplacesOwnershipsTranslationsQuery request, CancellationToken cancellationToken)
    {
       
        var queryBuilder = DataDbContext.WorkplacesOwnershipsLocalized
            .AsNoTracking<DtoNameSpace.WorkplaceOwnershipLocalizedDto>();
        return Task.FromResult(OnResponse(queryBuilder));
       
    }  
}