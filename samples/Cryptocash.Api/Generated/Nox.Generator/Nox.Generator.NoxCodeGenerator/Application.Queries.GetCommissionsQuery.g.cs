﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using Cryptocash.Application.Dto;
using Cryptocash.Infrastructure.Persistence;

namespace Cryptocash.Application.Queries;

public record GetCommissionsQuery() : IRequest<IQueryable<CommissionDto>>;

public partial class GetCommissionsQueryHandler: GetCommissionsQueryHandlerBase
{
    public GetCommissionsQueryHandler(DtoDbContext dataDbContext): base(dataDbContext)
    {
    
    }
}

public abstract class GetCommissionsQueryHandlerBase : QueryBase<IQueryable<CommissionDto>>, IRequestHandler<GetCommissionsQuery, IQueryable<CommissionDto>>
{
    public  GetCommissionsQueryHandlerBase(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public virtual Task<IQueryable<CommissionDto>> Handle(GetCommissionsQuery request, CancellationToken cancellationToken)
    {
        var item = (IQueryable<CommissionDto>)DataDbContext.Commissions
            .Where(r => r.DeletedAtUtc == null)
            .AsNoTracking();
       return Task.FromResult(OnResponse(item));
    }
}