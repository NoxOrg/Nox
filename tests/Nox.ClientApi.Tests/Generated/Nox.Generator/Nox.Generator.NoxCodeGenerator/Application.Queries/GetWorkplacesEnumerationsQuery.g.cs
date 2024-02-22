// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Queries;
using Nox.Application.Repositories;

using DtoNameSpace = ClientApi.Application.Dto;

namespace ClientApi.Application.Queries;
public partial record GetWorkplacesOwnershipsQuery(Nox.Types.CultureCode cultureCode) : IRequest<IQueryable<DtoNameSpace.WorkplaceOwnershipDto>>;

internal partial class GetWorkplacesOwnershipsQueryHandler: GetWorkplacesOwnershipsQueryHandlerBase
{
    public GetWorkplacesOwnershipsQueryHandler(IReadOnlyRepository readOnlyRepository): base(readOnlyRepository){}
}

internal abstract class GetWorkplacesOwnershipsQueryHandlerBase : QueryBase<IQueryable<DtoNameSpace.WorkplaceOwnershipDto>>, IRequestHandler<GetWorkplacesOwnershipsQuery, IQueryable<DtoNameSpace.WorkplaceOwnershipDto>>
{
    public  GetWorkplacesOwnershipsQueryHandlerBase(IReadOnlyRepository readOnlyRepository)
    {
        ReadOnlyRepository = readOnlyRepository;
    }

    public IReadOnlyRepository ReadOnlyRepository { get; }

    public virtual Task<IQueryable<DtoNameSpace.WorkplaceOwnershipDto>> Handle(GetWorkplacesOwnershipsQuery request, CancellationToken cancellationToken)
    {
        {
            var cultureCode = request.cultureCode.Value;
            IQueryable<DtoNameSpace.WorkplaceOwnershipDto> queryBuilder =
            from enumValues in ReadOnlyRepository.Query<DtoNameSpace.WorkplaceOwnershipDto>()
            from enumLocalized in ReadOnlyRepository.Query<DtoNameSpace.WorkplaceOwnershipLocalizedDto>()
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
    public GetWorkplacesTypesQueryHandler(IReadOnlyRepository readOnlyRepository): base(readOnlyRepository){}
}

internal abstract class GetWorkplacesTypesQueryHandlerBase : QueryBase<IQueryable<DtoNameSpace.WorkplaceTypeDto>>, IRequestHandler<GetWorkplacesTypesQuery, IQueryable<DtoNameSpace.WorkplaceTypeDto>>
{
    public  GetWorkplacesTypesQueryHandlerBase(IReadOnlyRepository readOnlyRepository)
    {
        ReadOnlyRepository = readOnlyRepository;
    }

    public IReadOnlyRepository ReadOnlyRepository { get; }

    public virtual Task<IQueryable<DtoNameSpace.WorkplaceTypeDto>> Handle(GetWorkplacesTypesQuery request, CancellationToken cancellationToken)
    {
        var queryBuilder = ReadOnlyRepository.Query<DtoNameSpace.WorkplaceTypeDto>();
        return Task.FromResult(OnResponse(queryBuilder));
    }
}