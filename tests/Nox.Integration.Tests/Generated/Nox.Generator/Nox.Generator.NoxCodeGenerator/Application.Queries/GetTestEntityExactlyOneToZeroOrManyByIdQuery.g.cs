// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Queries;
using Nox.Application.Repositories;

using TestWebApp.Application.Dto;
using TestWebApp.Infrastructure.Persistence;

namespace TestWebApp.Application.Queries;

public partial record GetTestEntityExactlyOneToZeroOrManyByIdQuery(System.String keyId) : IRequest <IQueryable<TestEntityExactlyOneToZeroOrManyDto>>;

internal partial class GetTestEntityExactlyOneToZeroOrManyByIdQueryHandler:GetTestEntityExactlyOneToZeroOrManyByIdQueryHandlerBase
{
    public GetTestEntityExactlyOneToZeroOrManyByIdQueryHandler(IReadOnlyRepository readOnlyRepository): base(readOnlyRepository){}
}

internal abstract class GetTestEntityExactlyOneToZeroOrManyByIdQueryHandlerBase:  QueryBase<IQueryable<TestEntityExactlyOneToZeroOrManyDto>>, IRequestHandler<GetTestEntityExactlyOneToZeroOrManyByIdQuery, IQueryable<TestEntityExactlyOneToZeroOrManyDto>>
{
    public  GetTestEntityExactlyOneToZeroOrManyByIdQueryHandlerBase(IReadOnlyRepository readOnlyRepository)
    {
        ReadOnlyRepository = readOnlyRepository;
    }

    public IReadOnlyRepository ReadOnlyRepository { get; }

    public virtual Task<IQueryable<TestEntityExactlyOneToZeroOrManyDto>> Handle(GetTestEntityExactlyOneToZeroOrManyByIdQuery request, CancellationToken cancellationToken)
    {    
        var query = ReadOnlyRepository.Query<TestEntityExactlyOneToZeroOrManyDto >()
            .Where(r =>
                r.Id.Equals(request.keyId));
        return Task.FromResult(OnResponse(query));
    }
}