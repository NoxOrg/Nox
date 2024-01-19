// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Queries;
using Nox.Application.Repositories;

using TestWebApp.Application.Dto;
using TestWebApp.Infrastructure.Persistence;

namespace TestWebApp.Application.Queries;

public partial record GetTestEntityExactlyOneByIdQuery(System.String keyId) : IRequest <IQueryable<TestEntityExactlyOneDto>>;

internal partial class GetTestEntityExactlyOneByIdQueryHandler:GetTestEntityExactlyOneByIdQueryHandlerBase
{
    public GetTestEntityExactlyOneByIdQueryHandler(IReadOnlyRepository readOnlyRepository): base(readOnlyRepository){}
}

internal abstract class GetTestEntityExactlyOneByIdQueryHandlerBase:  QueryBase<IQueryable<TestEntityExactlyOneDto>>, IRequestHandler<GetTestEntityExactlyOneByIdQuery, IQueryable<TestEntityExactlyOneDto>>
{
    public  GetTestEntityExactlyOneByIdQueryHandlerBase(IReadOnlyRepository readOnlyRepository)
    {
        ReadOnlyRepository = readOnlyRepository;
    }

    public IReadOnlyRepository ReadOnlyRepository { get; }

    public virtual Task<IQueryable<TestEntityExactlyOneDto>> Handle(GetTestEntityExactlyOneByIdQuery request, CancellationToken cancellationToken)
    {    
        var query = ReadOnlyRepository.Query<TestEntityExactlyOneDto >()
            .Where(r =>
                r.Id.Equals(request.keyId));
        return Task.FromResult(OnResponse(query));
    }
}