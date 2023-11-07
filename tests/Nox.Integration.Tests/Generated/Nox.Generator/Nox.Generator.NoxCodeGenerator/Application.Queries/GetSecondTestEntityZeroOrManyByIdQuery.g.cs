// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using TestWebApp.Application.Dto;
using TestWebApp.Infrastructure.Persistence;

namespace TestWebApp.Application.Queries;

public partial record GetSecondTestEntityZeroOrManyByIdQuery(System.String keyId) : IRequest <IQueryable<SecondTestEntityZeroOrManyDto>>;

internal partial class GetSecondTestEntityZeroOrManyByIdQueryHandler:GetSecondTestEntityZeroOrManyByIdQueryHandlerBase
{
    public  GetSecondTestEntityZeroOrManyByIdQueryHandler(DtoDbContext dataDbContext): base(dataDbContext)
    {
    
    }
}

internal abstract class GetSecondTestEntityZeroOrManyByIdQueryHandlerBase:  QueryBase<IQueryable<SecondTestEntityZeroOrManyDto>>, IRequestHandler<GetSecondTestEntityZeroOrManyByIdQuery, IQueryable<SecondTestEntityZeroOrManyDto>>
{
    public  GetSecondTestEntityZeroOrManyByIdQueryHandlerBase(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public virtual Task<IQueryable<SecondTestEntityZeroOrManyDto>> Handle(GetSecondTestEntityZeroOrManyByIdQuery request, CancellationToken cancellationToken)
    {    
        var query = DataDbContext.SecondTestEntityZeroOrManies
            .AsNoTracking()
            .Where(r =>
                r.Id.Equals(request.keyId));
        return Task.FromResult(OnResponse(query));
    }
}