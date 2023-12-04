// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using TestWebApp.Application.Dto;
using TestWebApp.Infrastructure.Persistence;

namespace TestWebApp.Application.Queries;

public partial record GetTestEntityLocalizationsQuery() : IRequest<IQueryable<TestEntityLocalizationDto>>;

internal partial class GetTestEntityLocalizationsQueryHandler: GetTestEntityLocalizationsQueryHandlerBase
{
    public GetTestEntityLocalizationsQueryHandler(DtoDbContext dataDbContext): base(dataDbContext)
    {
    
    }
}

internal abstract class GetTestEntityLocalizationsQueryHandlerBase : QueryBase<IQueryable<TestEntityLocalizationDto>>, IRequestHandler<GetTestEntityLocalizationsQuery, IQueryable<TestEntityLocalizationDto>>
{
    public  GetTestEntityLocalizationsQueryHandlerBase(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public virtual Task<IQueryable<TestEntityLocalizationDto>> Handle(GetTestEntityLocalizationsQuery request, CancellationToken cancellationToken)
    {
        var item = (IQueryable<TestEntityLocalizationDto>)DataDbContext.TestEntityLocalizations
            .AsNoTracking();
       return Task.FromResult(OnResponse(item));
    }
}