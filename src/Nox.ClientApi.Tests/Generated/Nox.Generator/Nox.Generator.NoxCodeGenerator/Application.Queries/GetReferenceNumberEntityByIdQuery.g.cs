// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using ClientApi.Application.Dto;
using ClientApi.Infrastructure.Persistence;

namespace ClientApi.Application.Queries;

public partial record GetReferenceNumberEntityByIdQuery(System.String keyId) : IRequest <IQueryable<ReferenceNumberEntityDto>>;

internal partial class GetReferenceNumberEntityByIdQueryHandler:GetReferenceNumberEntityByIdQueryHandlerBase
{
    public  GetReferenceNumberEntityByIdQueryHandler(DtoDbContext dataDbContext): base(dataDbContext)
    {
    
    }
}

internal abstract class GetReferenceNumberEntityByIdQueryHandlerBase:  QueryBase<IQueryable<ReferenceNumberEntityDto>>, IRequestHandler<GetReferenceNumberEntityByIdQuery, IQueryable<ReferenceNumberEntityDto>>
{
    public  GetReferenceNumberEntityByIdQueryHandlerBase(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public virtual Task<IQueryable<ReferenceNumberEntityDto>> Handle(GetReferenceNumberEntityByIdQuery request, CancellationToken cancellationToken)
    {    
        var query = DataDbContext.ReferenceNumberEntities
            .AsNoTracking()
            .Where(r =>
                r.Id.Equals(request.keyId));
        return Task.FromResult(OnResponse(query));
    }
}