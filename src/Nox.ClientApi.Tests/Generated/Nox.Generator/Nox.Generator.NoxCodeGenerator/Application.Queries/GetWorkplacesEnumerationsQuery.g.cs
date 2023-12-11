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
        {
            var cultureCode = request.cultureCode.Value;
            IQueryable<DtoNameSpace.WorkplaceOwnershipDto> queryBuilder =
            from enumValues in DataDbContext.WorkplacesOwnerships.AsNoTracking()
            from enumLocalized in DataDbContext.WorkplacesOwnershipsLocalized.AsNoTracking()
                .Where(l => enumValues.Id == l.Id && l.CultureCode == cultureCode).DefaultIfEmpty()
            select new DtoNameSpace.WorkplaceOwnershipDto()
            {
                Id = enumValues.Id,
                Name = enumLocalized.Name ?? "[" + enumValues.Name + "]",
            };
            return Task.FromResult(OnResponse(queryBuilder));
        }
    }
}
public partial record GetWorkplacesTypesQuery(Nox.Types.CultureCode cultureCode) : IRequest<IQueryable<DtoNameSpace.WorkplaceTypeDto>>;

internal partial class GetWorkplacesTypesQueryHandler: GetWorkplacesTypesQueryHandlerBase
{
    public GetWorkplacesTypesQueryHandler(PersistenceNameSpace.DtoDbContext dataDbContext): base(dataDbContext){}
}

internal abstract class GetWorkplacesTypesQueryHandlerBase : QueryBase<IQueryable<DtoNameSpace.WorkplaceTypeDto>>, IRequestHandler<GetWorkplacesTypesQuery, IQueryable<DtoNameSpace.WorkplaceTypeDto>>
{
    public  GetWorkplacesTypesQueryHandlerBase(PersistenceNameSpace.DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public PersistenceNameSpace.DtoDbContext DataDbContext { get; }

    public virtual Task<IQueryable<DtoNameSpace.WorkplaceTypeDto>> Handle(GetWorkplacesTypesQuery request, CancellationToken cancellationToken)
    {
        var queryBuilder = (IQueryable<DtoNameSpace.WorkplaceTypeDto>)DataDbContext.WorkplacesTypes
            .AsNoTracking();
        return Task.FromResult(OnResponse(queryBuilder));
    }
}