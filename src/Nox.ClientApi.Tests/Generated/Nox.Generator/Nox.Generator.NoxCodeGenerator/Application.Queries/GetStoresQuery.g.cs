﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using ClientApi.Application.Dto;
using ClientApi.Infrastructure.Persistence;

namespace ClientApi.Application.Queries;

public partial record GetStoresQuery() : IRequest<IQueryable<StoreDto>>;

internal partial class GetStoresQueryHandler: GetStoresQueryHandlerBase
{
    public GetStoresQueryHandler(DtoDbContext dataDbContext): base(dataDbContext)
    {
    
    }
}

internal abstract class GetStoresQueryHandlerBase : QueryBase<IQueryable<StoreDto>>, IRequestHandler<GetStoresQuery, IQueryable<StoreDto>>
{
    public  GetStoresQueryHandlerBase(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public virtual Task<IQueryable<StoreDto>> Handle(GetStoresQuery request, CancellationToken cancellationToken)
    {
        var item = (IQueryable<StoreDto>)DataDbContext.Stores
            .AsNoTracking();
       return Task.FromResult(OnResponse(item));
    }
}