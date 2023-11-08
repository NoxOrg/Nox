// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using TestWebApp.Application.Dto;
using TestWebApp.Infrastructure.Persistence;

namespace TestWebApp.Application.Queries;

public partial record GetThirdTestEntityZeroOrOnesQuery() : IRequest<IQueryable<ThirdTestEntityZeroOrOneDto>>;

internal partial class GetThirdTestEntityZeroOrOnesQueryHandler: GetThirdTestEntityZeroOrOnesQueryHandlerBase
{
    public GetThirdTestEntityZeroOrOnesQueryHandler(DtoDbContext dataDbContext): base(dataDbContext)
    {
    
    }
}

internal abstract class GetThirdTestEntityZeroOrOnesQueryHandlerBase : QueryBase<IQueryable<ThirdTestEntityZeroOrOneDto>>, IRequestHandler<GetThirdTestEntityZeroOrOnesQuery, IQueryable<ThirdTestEntityZeroOrOneDto>>
{
    public  GetThirdTestEntityZeroOrOnesQueryHandlerBase(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public virtual Task<IQueryable<ThirdTestEntityZeroOrOneDto>> Handle(GetThirdTestEntityZeroOrOnesQuery request, CancellationToken cancellationToken)
    {
        var item = (IQueryable<ThirdTestEntityZeroOrOneDto>)DataDbContext.ThirdTestEntityZeroOrOnes
            .AsNoTracking();
       return Task.FromResult(OnResponse(item));
    }
}