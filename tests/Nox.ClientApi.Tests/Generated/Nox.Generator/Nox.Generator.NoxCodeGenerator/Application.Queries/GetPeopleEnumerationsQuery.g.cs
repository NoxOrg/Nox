// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Queries;
using Nox.Application.Repositories;

using DtoNameSpace = ClientApi.Application.Dto;
using PersistenceNameSpace = ClientApi.Infrastructure.Persistence;

namespace ClientApi.Application.Queries;
public partial record GetPeopleStatusesQuery(Nox.Types.CultureCode cultureCode) : IRequest<IQueryable<DtoNameSpace.PersonStatusDto>>;

internal partial class GetPeopleStatusesQueryHandler: GetPeopleStatusesQueryHandlerBase
{
    public GetPeopleStatusesQueryHandler(IReadOnlyRepository readOnlyRepository): base(readOnlyRepository){}
}

internal abstract class GetPeopleStatusesQueryHandlerBase : QueryBase<IQueryable<DtoNameSpace.PersonStatusDto>>, IRequestHandler<GetPeopleStatusesQuery, IQueryable<DtoNameSpace.PersonStatusDto>>
{
    public  GetPeopleStatusesQueryHandlerBase(IReadOnlyRepository readOnlyRepository)
    {
        ReadOnlyRepository = readOnlyRepository;
    }

    public IReadOnlyRepository ReadOnlyRepository { get; }

    public virtual Task<IQueryable<DtoNameSpace.PersonStatusDto>> Handle(GetPeopleStatusesQuery request, CancellationToken cancellationToken)
    {
        var queryBuilder = ReadOnlyRepository.Query<DtoNameSpace.PersonStatusDto>();
        return Task.FromResult(OnResponse(queryBuilder));
    }
}
public partial record GetPeoplePreferredLoginMethodsQuery(Nox.Types.CultureCode cultureCode) : IRequest<IQueryable<DtoNameSpace.PersonPreferredLoginMethodDto>>;

internal partial class GetPeoplePreferredLoginMethodsQueryHandler: GetPeoplePreferredLoginMethodsQueryHandlerBase
{
    public GetPeoplePreferredLoginMethodsQueryHandler(IReadOnlyRepository readOnlyRepository): base(readOnlyRepository){}
}

internal abstract class GetPeoplePreferredLoginMethodsQueryHandlerBase : QueryBase<IQueryable<DtoNameSpace.PersonPreferredLoginMethodDto>>, IRequestHandler<GetPeoplePreferredLoginMethodsQuery, IQueryable<DtoNameSpace.PersonPreferredLoginMethodDto>>
{
    public  GetPeoplePreferredLoginMethodsQueryHandlerBase(IReadOnlyRepository readOnlyRepository)
    {
        ReadOnlyRepository = readOnlyRepository;
    }

    public IReadOnlyRepository ReadOnlyRepository { get; }

    public virtual Task<IQueryable<DtoNameSpace.PersonPreferredLoginMethodDto>> Handle(GetPeoplePreferredLoginMethodsQuery request, CancellationToken cancellationToken)
    {
        var queryBuilder = ReadOnlyRepository.Query<DtoNameSpace.PersonPreferredLoginMethodDto>();
        return Task.FromResult(OnResponse(queryBuilder));
    }
}