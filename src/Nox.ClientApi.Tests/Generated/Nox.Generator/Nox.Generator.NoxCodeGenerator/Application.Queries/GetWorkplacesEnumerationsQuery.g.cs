// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using DtoNameSpace = ClientApi.Application.Dto;
using PersistenceNameSpace = ClientApi.Infrastructure.Persistence;

namespace ClientApi.Application.Queries;
public partial record GetWorkplacesOwnershipsQuery(Nox.Types.CultureCode cultureCode) : IRequest<IQueryable<DtoNameSpace.WorkplaceOwnershipDto>>;

internal partial class GetWorkplacesOwnershipsQueryHandler: GetWorkplacesOwnershipsQueryHandlerBase
{
    public GetWorkplacesOwnershipsQueryHandler(PersistenceNameSpace.DtoDbContext dataDbContext): base(dataDbContext){}
}

internal abstract class GetWorkplacesOwnershipsQueryHandlerBase : QueryBase<IQueryable<DtoNameSpace.WorkplaceOwnershipDto>>, IRequestHandler<GetWorkplacesOwnershipsQuery, IQueryable<DtoNameSpace.WorkplaceOwnershipDto>>
{
    public  GetWorkplacesOwnershipsQueryHandlerBase(PersistenceNameSpace.DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public PersistenceNameSpace.DtoDbContext DataDbContext { get; }

    public virtual Task<IQueryable<DtoNameSpace.WorkplaceOwnershipDto>> Handle(GetWorkplacesOwnershipsQuery request, CancellationToken cancellationToken)
    {
        var queryBuilder = (IQueryable<DtoNameSpace.WorkplaceOwnershipDto>)DataDbContext.WorkplacesOwnerships
            .AsNoTracking();
        return Task.FromResult(OnResponse(queryBuilder));
    }
}