// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Queries;
using Nox.Application.Repositories;

using TestWebApp.Application.Dto;
using TestWebApp.Infrastructure.Persistence;

namespace TestWebApp.Application.Queries;

public partial record GetTestEntityZeroOrManyToExactlyOneByIdQuery(System.String keyId) : IRequest <IQueryable<TestEntityZeroOrManyToExactlyOneDto>>;

internal partial class GetTestEntityZeroOrManyToExactlyOneByIdQueryHandler:GetTestEntityZeroOrManyToExactlyOneByIdQueryHandlerBase
{
    public GetTestEntityZeroOrManyToExactlyOneByIdQueryHandler(IReadOnlyRepository readOnlyRepository): base(readOnlyRepository){}
}

internal abstract class GetTestEntityZeroOrManyToExactlyOneByIdQueryHandlerBase:  QueryBase<IQueryable<TestEntityZeroOrManyToExactlyOneDto>>, IRequestHandler<GetTestEntityZeroOrManyToExactlyOneByIdQuery, IQueryable<TestEntityZeroOrManyToExactlyOneDto>>
{
    public  GetTestEntityZeroOrManyToExactlyOneByIdQueryHandlerBase(IReadOnlyRepository readOnlyRepository)
    {
        ReadOnlyRepository = readOnlyRepository;
    }

    public IReadOnlyRepository ReadOnlyRepository { get; }

    public virtual Task<IQueryable<TestEntityZeroOrManyToExactlyOneDto>> Handle(GetTestEntityZeroOrManyToExactlyOneByIdQuery request, CancellationToken cancellationToken)
    {    
        var query = ReadOnlyRepository.Query<TestEntityZeroOrManyToExactlyOneDto>()
            .Where(r =>
                r.Id.Equals(request.keyId));
        return Task.FromResult(OnResponse(query));
    }
}