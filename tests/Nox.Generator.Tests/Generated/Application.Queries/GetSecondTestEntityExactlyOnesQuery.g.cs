// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using TestWebApp.Application.Dto;
using TestWebApp.Infrastructure.Persistence;

namespace TestWebApp.Application.Queries;

public partial record GetSecondTestEntityExactlyOnesQuery() : IRequest<IQueryable<SecondTestEntityExactlyOneDto>>;

internal partial class GetSecondTestEntityExactlyOnesQueryHandler: GetSecondTestEntityExactlyOnesQueryHandlerBase
{
    public GetSecondTestEntityExactlyOnesQueryHandler(DtoDbContext dataDbContext): base(dataDbContext)
    {
    
    }
}

internal abstract class GetSecondTestEntityExactlyOnesQueryHandlerBase : QueryBase<IQueryable<SecondTestEntityExactlyOneDto>>, IRequestHandler<GetSecondTestEntityExactlyOnesQuery, IQueryable<SecondTestEntityExactlyOneDto>>
{
    public  GetSecondTestEntityExactlyOnesQueryHandlerBase(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public virtual Task<IQueryable<SecondTestEntityExactlyOneDto>> Handle(GetSecondTestEntityExactlyOnesQuery request, CancellationToken cancellationToken)
    {
        var item = (IQueryable<SecondTestEntityExactlyOneDto>)DataDbContext.SecondTestEntityExactlyOnes
            .AsNoTracking();
       return Task.FromResult(OnResponse(item));
    }
}