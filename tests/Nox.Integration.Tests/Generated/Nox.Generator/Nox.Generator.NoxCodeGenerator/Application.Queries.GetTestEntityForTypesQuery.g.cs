// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using TestWebApp.Application.Dto;
using TestWebApp.Infrastructure.Persistence;

namespace TestWebApp.Application.Queries;

public record GetTestEntityForTypesQuery() : IRequest<IQueryable<TestEntityForTypesDto>>;

internal partial class GetTestEntityForTypesQueryHandler: GetTestEntityForTypesQueryHandlerBase
{
    public GetTestEntityForTypesQueryHandler(DtoDbContext dataDbContext): base(dataDbContext)
    {
    
    }
}

internal abstract class GetTestEntityForTypesQueryHandlerBase : QueryBase<IQueryable<TestEntityForTypesDto>>, IRequestHandler<GetTestEntityForTypesQuery, IQueryable<TestEntityForTypesDto>>
{
    public  GetTestEntityForTypesQueryHandlerBase(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public virtual Task<IQueryable<TestEntityForTypesDto>> Handle(GetTestEntityForTypesQuery request, CancellationToken cancellationToken)
    {
        var item = (IQueryable<TestEntityForTypesDto>)DataDbContext.TestEntityForTypes
            .AsNoTracking();
       return Task.FromResult(OnResponse(item));
    }
}