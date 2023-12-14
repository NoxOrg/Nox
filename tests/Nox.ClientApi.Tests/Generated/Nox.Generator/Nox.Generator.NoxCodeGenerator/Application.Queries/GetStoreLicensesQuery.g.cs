// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using ClientApi.Application.Dto;
using ClientApi.Infrastructure.Persistence;

namespace ClientApi.Application.Queries;

public partial record GetStoreLicensesQuery() : IRequest<IQueryable<StoreLicenseDto>>;

internal partial class GetStoreLicensesQueryHandler: GetStoreLicensesQueryHandlerBase
{
    public GetStoreLicensesQueryHandler(DtoDbContext dataDbContext): base(dataDbContext)
    {
    
    }
}

internal abstract class GetStoreLicensesQueryHandlerBase : QueryBase<IQueryable<StoreLicenseDto>>, IRequestHandler<GetStoreLicensesQuery, IQueryable<StoreLicenseDto>>
{
    public  GetStoreLicensesQueryHandlerBase(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public virtual Task<IQueryable<StoreLicenseDto>> Handle(GetStoreLicensesQuery request, CancellationToken cancellationToken)
    {
        var item = (IQueryable<StoreLicenseDto>)DataDbContext.StoreLicenses
            .AsNoTracking();
       return Task.FromResult(OnResponse(item));
    }
}