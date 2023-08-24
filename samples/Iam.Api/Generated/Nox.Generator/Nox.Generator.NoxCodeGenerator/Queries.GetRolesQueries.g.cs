// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using IamApi.Application.Dto;
using IamApi.Infrastructure.Persistence;

namespace IamApi.Application.Queries;

public record GetRolesQuery() : IRequest<IQueryable<RoleDto>>;

public partial class GetRolesQueryHandler : QueryBase<IQueryable<RoleDto>>, IRequestHandler<GetRolesQuery, IQueryable<RoleDto>>
{
    public  GetRolesQueryHandler(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public Task<IQueryable<RoleDto>> Handle(GetRolesQuery request, CancellationToken cancellationToken)
    {
        var item = (IQueryable<RoleDto>)DataDbContext.Roles
            .Where(r => r.DeletedAtUtc == null)
            .AsNoTracking();
       return Task.FromResult(OnResponse(item));
    }
}