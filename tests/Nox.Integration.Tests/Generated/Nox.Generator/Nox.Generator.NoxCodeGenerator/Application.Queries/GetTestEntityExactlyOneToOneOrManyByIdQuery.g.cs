// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Queries;
using Nox.Application.Repositories;

using TestWebApp.Application.Dto;
using TestWebApp.Infrastructure.Persistence;

namespace TestWebApp.Application.Queries;

public partial record GetTestEntityExactlyOneToOneOrManyByIdQuery(System.String keyId) : IRequest <IQueryable<TestEntityExactlyOneToOneOrManyDto>>;

internal partial class GetTestEntityExactlyOneToOneOrManyByIdQueryHandler:GetTestEntityExactlyOneToOneOrManyByIdQueryHandlerBase
{
    public GetTestEntityExactlyOneToOneOrManyByIdQueryHandler(IReadOnlyRepository readOnlyRepository): base(readOnlyRepository){}
}

internal abstract class GetTestEntityExactlyOneToOneOrManyByIdQueryHandlerBase:  QueryBase<IQueryable<TestEntityExactlyOneToOneOrManyDto>>, IRequestHandler<GetTestEntityExactlyOneToOneOrManyByIdQuery, IQueryable<TestEntityExactlyOneToOneOrManyDto>>
{
    public  GetTestEntityExactlyOneToOneOrManyByIdQueryHandlerBase(IReadOnlyRepository readOnlyRepository)
    {
        ReadOnlyRepository = readOnlyRepository;
    }

    public IReadOnlyRepository ReadOnlyRepository { get; }

    public virtual Task<IQueryable<TestEntityExactlyOneToOneOrManyDto>> Handle(GetTestEntityExactlyOneToOneOrManyByIdQuery request, CancellationToken cancellationToken)
    {    
        var query = ReadOnlyRepository.Query<TestEntityExactlyOneToOneOrManyDto>()
            .Where(r =>
                r.Id.Equals(request.keyId));
        return Task.FromResult(OnResponse(query));
    }
}