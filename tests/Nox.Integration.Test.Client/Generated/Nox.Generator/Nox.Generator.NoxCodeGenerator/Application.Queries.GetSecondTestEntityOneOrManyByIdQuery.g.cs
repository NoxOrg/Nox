// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using TestWebApp.Application.Dto;
using TestWebApp.Infrastructure.Persistence;

namespace TestWebApp.Application.Queries;

public record GetSecondTestEntityOneOrManyByIdQuery(System.String keyId) : IRequest <IQueryable<SecondTestEntityOneOrManyDto>>;

internal partial class GetSecondTestEntityOneOrManyByIdQueryHandler:GetSecondTestEntityOneOrManyByIdQueryHandlerBase
{
    public  GetSecondTestEntityOneOrManyByIdQueryHandler(DtoDbContext dataDbContext): base(dataDbContext)
    {
    
    }
}

internal abstract class GetSecondTestEntityOneOrManyByIdQueryHandlerBase:  QueryBase<IQueryable<SecondTestEntityOneOrManyDto>>, IRequestHandler<GetSecondTestEntityOneOrManyByIdQuery, IQueryable<SecondTestEntityOneOrManyDto>>
{
    public  GetSecondTestEntityOneOrManyByIdQueryHandlerBase(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public virtual Task<IQueryable<SecondTestEntityOneOrManyDto>> Handle(GetSecondTestEntityOneOrManyByIdQuery request, CancellationToken cancellationToken)
    {    
        var query = DataDbContext.SecondTestEntityOneOrManies
            .AsNoTracking()
            .Where(r =>
                r.Id.Equals(request.keyId) &&
                r.DeletedAtUtc == null);
        return Task.FromResult(OnResponse(query));
    }
}