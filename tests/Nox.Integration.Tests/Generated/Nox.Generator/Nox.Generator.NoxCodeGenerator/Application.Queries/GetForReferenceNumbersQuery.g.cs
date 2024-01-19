// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Queries;

using TestWebApp.Application.Dto;
using TestWebApp.Infrastructure.Persistence;

namespace TestWebApp.Application.Queries;

public partial record GetForReferenceNumbersQuery() : IRequest<IQueryable<ForReferenceNumberDto>>;

internal partial class GetForReferenceNumbersQueryHandler: GetForReferenceNumbersQueryHandlerBase
{
    public GetForReferenceNumbersQueryHandler(DtoDbContext dataDbContext): base(dataDbContext)
    {
    
    }
}

internal abstract class GetForReferenceNumbersQueryHandlerBase : QueryBase<IQueryable<ForReferenceNumberDto>>, IRequestHandler<GetForReferenceNumbersQuery, IQueryable<ForReferenceNumberDto>>
{
    public  GetForReferenceNumbersQueryHandlerBase(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public virtual Task<IQueryable<ForReferenceNumberDto>> Handle(GetForReferenceNumbersQuery request, CancellationToken cancellationToken)
    {
        var item = (IQueryable<ForReferenceNumberDto>)DataDbContext.ForReferenceNumbers
            .AsNoTracking();
       return Task.FromResult(OnResponse(item));
    }
}