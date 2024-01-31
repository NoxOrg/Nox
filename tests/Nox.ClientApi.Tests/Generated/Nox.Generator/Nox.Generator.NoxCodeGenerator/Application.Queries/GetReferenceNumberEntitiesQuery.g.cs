// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Queries;
using Nox.Application.Repositories;
using ClientApi.Application.Dto;

namespace ClientApi.Application.Queries;

public partial record GetReferenceNumberEntitiesQuery() : IRequest<IQueryable<ReferenceNumberEntityDto>>;

internal partial class GetReferenceNumberEntitiesQueryHandler: GetReferenceNumberEntitiesQueryHandlerBase
{
    public GetReferenceNumberEntitiesQueryHandler(IReadOnlyRepository readOnlyRepository): base(readOnlyRepository){}
}

internal abstract class GetReferenceNumberEntitiesQueryHandlerBase : QueryBase<IQueryable<ReferenceNumberEntityDto>>, IRequestHandler<GetReferenceNumberEntitiesQuery, IQueryable<ReferenceNumberEntityDto>>
{
    public  GetReferenceNumberEntitiesQueryHandlerBase(IReadOnlyRepository readOnlyRepository)
    {
        ReadOnlyRepository = readOnlyRepository;
    }

    public IReadOnlyRepository ReadOnlyRepository { get; }

    public virtual Task<IQueryable<ReferenceNumberEntityDto>> Handle(GetReferenceNumberEntitiesQuery request, CancellationToken cancellationToken)
    {
        var query = ReadOnlyRepository.Query<ReferenceNumberEntityDto>();
       return Task.FromResult(OnResponse(query));
    }
}