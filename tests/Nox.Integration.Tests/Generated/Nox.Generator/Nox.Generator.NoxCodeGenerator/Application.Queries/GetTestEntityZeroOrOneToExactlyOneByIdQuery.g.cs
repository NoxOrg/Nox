// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using TestWebApp.Application.Dto;
using TestWebApp.Infrastructure.Persistence;

namespace TestWebApp.Application.Queries;

public record GetTestEntityZeroOrOneToExactlyOneByIdQuery(System.String keyId) : IRequest <IQueryable<TestEntityZeroOrOneToExactlyOneDto>>;

internal partial class GetTestEntityZeroOrOneToExactlyOneByIdQueryHandler:GetTestEntityZeroOrOneToExactlyOneByIdQueryHandlerBase
{
    public  GetTestEntityZeroOrOneToExactlyOneByIdQueryHandler(DtoDbContext dataDbContext): base(dataDbContext)
    {
    
    }
}

internal abstract class GetTestEntityZeroOrOneToExactlyOneByIdQueryHandlerBase:  QueryBase<IQueryable<TestEntityZeroOrOneToExactlyOneDto>>, IRequestHandler<GetTestEntityZeroOrOneToExactlyOneByIdQuery, IQueryable<TestEntityZeroOrOneToExactlyOneDto>>
{
    public  GetTestEntityZeroOrOneToExactlyOneByIdQueryHandlerBase(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public virtual Task<IQueryable<TestEntityZeroOrOneToExactlyOneDto>> Handle(GetTestEntityZeroOrOneToExactlyOneByIdQuery request, CancellationToken cancellationToken)
    {    
        var query = DataDbContext.TestEntityZeroOrOneToExactlyOnes
            .AsNoTracking()
            .Where(r =>
                r.Id.Equals(request.keyId));
        return Task.FromResult(OnResponse(query));
    }
}