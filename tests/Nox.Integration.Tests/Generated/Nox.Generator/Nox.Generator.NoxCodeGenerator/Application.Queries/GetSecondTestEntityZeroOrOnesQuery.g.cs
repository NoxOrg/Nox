// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Queries;

using TestWebApp.Application.Dto;
using TestWebApp.Infrastructure.Persistence;

namespace TestWebApp.Application.Queries;

public partial record GetSecondTestEntityZeroOrOnesQuery() : IRequest<IQueryable<SecondTestEntityZeroOrOneDto>>;

internal partial class GetSecondTestEntityZeroOrOnesQueryHandler: GetSecondTestEntityZeroOrOnesQueryHandlerBase
{
    public GetSecondTestEntityZeroOrOnesQueryHandler(DtoDbContext dataDbContext): base(dataDbContext)
    {
    
    }
}

internal abstract class GetSecondTestEntityZeroOrOnesQueryHandlerBase : QueryBase<IQueryable<SecondTestEntityZeroOrOneDto>>, IRequestHandler<GetSecondTestEntityZeroOrOnesQuery, IQueryable<SecondTestEntityZeroOrOneDto>>
{
    public  GetSecondTestEntityZeroOrOnesQueryHandlerBase(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public virtual Task<IQueryable<SecondTestEntityZeroOrOneDto>> Handle(GetSecondTestEntityZeroOrOnesQuery request, CancellationToken cancellationToken)
    {
        var item = (IQueryable<SecondTestEntityZeroOrOneDto>)DataDbContext.SecondTestEntityZeroOrOnes
            .AsNoTracking();
       return Task.FromResult(OnResponse(item));
    }
}