// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using TestWebApp.Application.Dto;
using TestWebApp.Infrastructure.Persistence;

namespace TestWebApp.Application.Queries;

public record GetTestEntityForTypesByIdQuery(System.String keyId) : IRequest <IQueryable<TestEntityForTypesDto>>;

internal partial class GetTestEntityForTypesByIdQueryHandler:GetTestEntityForTypesByIdQueryHandlerBase
{
    public  GetTestEntityForTypesByIdQueryHandler(DtoDbContext dataDbContext): base(dataDbContext)
    {
    
    }
}

internal abstract class GetTestEntityForTypesByIdQueryHandlerBase:  QueryBase<IQueryable<TestEntityForTypesDto>>, IRequestHandler<GetTestEntityForTypesByIdQuery, IQueryable<TestEntityForTypesDto>>
{
    public  GetTestEntityForTypesByIdQueryHandlerBase(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public virtual Task<IQueryable<TestEntityForTypesDto>> Handle(GetTestEntityForTypesByIdQuery request, CancellationToken cancellationToken)
    {    
        var query = DataDbContext.TestEntityForTypes
            .AsNoTracking()
            .Where(r =>
                r.Id.Equals(request.keyId) &&
                r.DeletedAtUtc == null);
        return Task.FromResult(OnResponse(query));
    }
}