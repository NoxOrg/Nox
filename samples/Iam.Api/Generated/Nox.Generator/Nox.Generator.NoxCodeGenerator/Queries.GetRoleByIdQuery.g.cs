// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using IamApi.Application.Dto;
using IamApi.Infrastructure.Persistence;

namespace IamApi.Application.Queries;

public record GetRoleByIdQuery(System.String keyId) : IRequest <RoleDto?>;

public partial class GetRoleByIdQueryHandler:  QueryBase<RoleDto?>, IRequestHandler<GetRoleByIdQuery, RoleDto?>
{
    public  GetRoleByIdQueryHandler(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public Task<RoleDto?> Handle(GetRoleByIdQuery request, CancellationToken cancellationToken)
    {    
        var item = DataDbContext.Roles
            .AsNoTracking()
            .SingleOrDefault(r =>
                r.Id.Equals(request.keyId) &&
                r.DeletedAtUtc == null);
        return Task.FromResult(OnResponse(item));
    }
}