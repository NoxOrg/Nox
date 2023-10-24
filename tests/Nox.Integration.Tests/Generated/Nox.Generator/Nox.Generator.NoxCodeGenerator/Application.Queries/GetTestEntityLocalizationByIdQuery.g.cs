// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using TestWebApp.Application.Dto;
using TestWebApp.Infrastructure.Persistence;

namespace TestWebApp.Application.Queries;

public record GetTestEntityLocalizationByIdQuery(System.String keyId) : IRequest <IQueryable<TestEntityLocalizationDto>>;

internal partial class GetTestEntityLocalizationByIdQueryHandler:GetTestEntityLocalizationByIdQueryHandlerBase
{
    public  GetTestEntityLocalizationByIdQueryHandler(DtoDbContext dataDbContext): base(dataDbContext)
    {
    
    }
}

internal abstract class GetTestEntityLocalizationByIdQueryHandlerBase:  QueryBase<IQueryable<TestEntityLocalizationDto>>, IRequestHandler<GetTestEntityLocalizationByIdQuery, IQueryable<TestEntityLocalizationDto>>
{
    public  GetTestEntityLocalizationByIdQueryHandlerBase(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public virtual Task<IQueryable<TestEntityLocalizationDto>> Handle(GetTestEntityLocalizationByIdQuery request, CancellationToken cancellationToken)
    {    
        var query = DataDbContext.TestEntityLocalizations
            .AsNoTracking()
            .Where(r =>
                r.Id.Equals(request.keyId));
        return Task.FromResult(OnResponse(query));
    }
}