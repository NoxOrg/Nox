// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using TestWebApp.Application.Dto;
using TestWebApp.Infrastructure.Persistence;

namespace TestWebApp.Application.Queries;

public partial record GetTestEntityZeroOrOneToZeroOrManyByIdQuery(System.String keyId) : IRequest <IQueryable<TestEntityZeroOrOneToZeroOrManyDto>>;

internal partial class GetTestEntityZeroOrOneToZeroOrManyByIdQueryHandler:GetTestEntityZeroOrOneToZeroOrManyByIdQueryHandlerBase
{
    public  GetTestEntityZeroOrOneToZeroOrManyByIdQueryHandler(DtoDbContext dataDbContext): base(dataDbContext)
    {
    
    }
}

internal abstract class GetTestEntityZeroOrOneToZeroOrManyByIdQueryHandlerBase:  QueryBase<IQueryable<TestEntityZeroOrOneToZeroOrManyDto>>, IRequestHandler<GetTestEntityZeroOrOneToZeroOrManyByIdQuery, IQueryable<TestEntityZeroOrOneToZeroOrManyDto>>
{
    public  GetTestEntityZeroOrOneToZeroOrManyByIdQueryHandlerBase(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public virtual Task<IQueryable<TestEntityZeroOrOneToZeroOrManyDto>> Handle(GetTestEntityZeroOrOneToZeroOrManyByIdQuery request, CancellationToken cancellationToken)
    {    
        var query = DataDbContext.TestEntityZeroOrOneToZeroOrManies
            .AsNoTracking()
            .Where(r =>
                r.Id.Equals(request.keyId));
        return Task.FromResult(OnResponse(query));
    }
}