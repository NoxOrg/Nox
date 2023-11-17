// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using TestWebApp.Application.Dto;
using TestWebApp.Infrastructure.Persistence;

namespace TestWebApp.Application.Queries;

public partial record GetTestEntityForAutoNumberUsagesByIdQuery(System.Int64 keyId) : IRequest <IQueryable<TestEntityForAutoNumberUsagesDto>>;

internal partial class GetTestEntityForAutoNumberUsagesByIdQueryHandler:GetTestEntityForAutoNumberUsagesByIdQueryHandlerBase
{
    public  GetTestEntityForAutoNumberUsagesByIdQueryHandler(DtoDbContext dataDbContext): base(dataDbContext)
    {
    
    }
}

internal abstract class GetTestEntityForAutoNumberUsagesByIdQueryHandlerBase:  QueryBase<IQueryable<TestEntityForAutoNumberUsagesDto>>, IRequestHandler<GetTestEntityForAutoNumberUsagesByIdQuery, IQueryable<TestEntityForAutoNumberUsagesDto>>
{
    public  GetTestEntityForAutoNumberUsagesByIdQueryHandlerBase(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public virtual Task<IQueryable<TestEntityForAutoNumberUsagesDto>> Handle(GetTestEntityForAutoNumberUsagesByIdQuery request, CancellationToken cancellationToken)
    {    
        var query = DataDbContext.TestEntityForAutoNumberUsages
            .AsNoTracking()
            .Where(r =>
                r.Id.Equals(request.keyId));
        return Task.FromResult(OnResponse(query));
    }
}