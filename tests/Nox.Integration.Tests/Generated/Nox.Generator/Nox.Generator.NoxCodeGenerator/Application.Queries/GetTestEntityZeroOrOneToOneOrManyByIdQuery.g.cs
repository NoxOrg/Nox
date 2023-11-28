// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using TestWebApp.Application.Dto;
using TestWebApp.Infrastructure.Persistence;

namespace TestWebApp.Application.Queries;

public partial record GetTestEntityZeroOrOneToOneOrManyByIdQuery(System.String keyId) : IRequest <IQueryable<TestEntityZeroOrOneToOneOrManyDto>>;

internal partial class GetTestEntityZeroOrOneToOneOrManyByIdQueryHandler:GetTestEntityZeroOrOneToOneOrManyByIdQueryHandlerBase
{
    public  GetTestEntityZeroOrOneToOneOrManyByIdQueryHandler(DtoDbContext dataDbContext): base(dataDbContext)
    {
    
    }
}

internal abstract class GetTestEntityZeroOrOneToOneOrManyByIdQueryHandlerBase:  QueryBase<IQueryable<TestEntityZeroOrOneToOneOrManyDto>>, IRequestHandler<GetTestEntityZeroOrOneToOneOrManyByIdQuery, IQueryable<TestEntityZeroOrOneToOneOrManyDto>>
{
    public  GetTestEntityZeroOrOneToOneOrManyByIdQueryHandlerBase(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public virtual Task<IQueryable<TestEntityZeroOrOneToOneOrManyDto>> Handle(GetTestEntityZeroOrOneToOneOrManyByIdQuery request, CancellationToken cancellationToken)
    {    
        var query = DataDbContext.TestEntityZeroOrOneToOneOrManies
            .AsNoTracking()
            .Where(r =>
                r.Id.Equals(request.keyId));
        return Task.FromResult(OnResponse(query));
    }
}