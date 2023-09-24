// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using ClientApi.Application.Dto;
using ClientApi.Infrastructure.Persistence;

namespace ClientApi.Application.Queries;

public record GetStoreLicenseByIdQuery(System.Int64 keyId) : IRequest <IQueryable<StoreLicenseDto>>;

public partial class GetStoreLicenseByIdQueryHandler:GetStoreLicenseByIdQueryHandlerBase
{
    public  GetStoreLicenseByIdQueryHandler(DtoDbContext dataDbContext): base(dataDbContext)
    {
    
    }
}

public abstract class GetStoreLicenseByIdQueryHandlerBase:  QueryBase<IQueryable<StoreLicenseDto>>, IRequestHandler<GetStoreLicenseByIdQuery, IQueryable<StoreLicenseDto>>
{
    public  GetStoreLicenseByIdQueryHandlerBase(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public virtual Task<IQueryable<StoreLicenseDto>> Handle(GetStoreLicenseByIdQuery request, CancellationToken cancellationToken)
    {    
        var query = DataDbContext.StoreLicenses
            .AsNoTracking()
            .Where(r =>
                r.Id.Equals(request.keyId) &&
                r.DeletedAtUtc == null);
        return Task.FromResult(OnResponse(query));
    }
}