// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Queries;
using Nox.Application.Repositories;

using TestWebApp.Application.Dto;
using TestWebApp.Infrastructure.Persistence;

namespace TestWebApp.Application.Queries;

public partial record GetEntityUniqueConstraintsRelatedForeignKeyByIdQuery(System.Int32 keyId) : IRequest <IQueryable<EntityUniqueConstraintsRelatedForeignKeyDto>>;

internal partial class GetEntityUniqueConstraintsRelatedForeignKeyByIdQueryHandler:GetEntityUniqueConstraintsRelatedForeignKeyByIdQueryHandlerBase
{
    public GetEntityUniqueConstraintsRelatedForeignKeyByIdQueryHandler(IReadOnlyRepository readOnlyRepository): base(readOnlyRepository){}
}

internal abstract class GetEntityUniqueConstraintsRelatedForeignKeyByIdQueryHandlerBase:  QueryBase<IQueryable<EntityUniqueConstraintsRelatedForeignKeyDto>>, IRequestHandler<GetEntityUniqueConstraintsRelatedForeignKeyByIdQuery, IQueryable<EntityUniqueConstraintsRelatedForeignKeyDto>>
{
    public  GetEntityUniqueConstraintsRelatedForeignKeyByIdQueryHandlerBase(IReadOnlyRepository readOnlyRepository)
    {
        ReadOnlyRepository = readOnlyRepository;
    }

    public IReadOnlyRepository ReadOnlyRepository { get; }

    public virtual Task<IQueryable<EntityUniqueConstraintsRelatedForeignKeyDto>> Handle(GetEntityUniqueConstraintsRelatedForeignKeyByIdQuery request, CancellationToken cancellationToken)
    {    
        var query = ReadOnlyRepository.Query<EntityUniqueConstraintsRelatedForeignKeyDto>()
            .Where(r =>
                r.Id.Equals(request.keyId));
        return Task.FromResult(OnResponse(query));
    }
}