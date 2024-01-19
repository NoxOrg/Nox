// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Queries;
using Nox.Application.Repositories;

using ClientApi.Application.Dto;
using ClientApi.Infrastructure.Persistence;

namespace ClientApi.Application.Queries;

public partial record GetReferenceNumberEntityByIdQuery(System.String keyId) : IRequest <IQueryable<ReferenceNumberEntityDto>>;

internal partial class GetReferenceNumberEntityByIdQueryHandler:GetReferenceNumberEntityByIdQueryHandlerBase
{
    public GetReferenceNumberEntityByIdQueryHandler(IReadOnlyRepository readOnlyRepository): base(readOnlyRepository){}
}

internal abstract class GetReferenceNumberEntityByIdQueryHandlerBase:  QueryBase<IQueryable<ReferenceNumberEntityDto>>, IRequestHandler<GetReferenceNumberEntityByIdQuery, IQueryable<ReferenceNumberEntityDto>>
{
    public  GetReferenceNumberEntityByIdQueryHandlerBase(IReadOnlyRepository readOnlyRepository)
    {
        ReadOnlyRepository = readOnlyRepository;
    }

    public IReadOnlyRepository ReadOnlyRepository { get; }

    public virtual Task<IQueryable<ReferenceNumberEntityDto>> Handle(GetReferenceNumberEntityByIdQuery request, CancellationToken cancellationToken)
    {    
        var query = ReadOnlyRepository.Query<ReferenceNumberEntityDto >()
            .Where(r =>
                r.Id.Equals(request.keyId));
        return Task.FromResult(OnResponse(query));
    }
}