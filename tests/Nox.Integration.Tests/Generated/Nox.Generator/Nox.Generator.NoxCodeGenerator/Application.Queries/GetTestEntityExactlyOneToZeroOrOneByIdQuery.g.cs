// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Queries;
using Nox.Application.Repositories;

using TestWebApp.Application.Dto;

namespace TestWebApp.Application.Queries;

public partial record GetTestEntityExactlyOneToZeroOrOneByIdQuery(System.String keyId) : IRequest <IQueryable<TestEntityExactlyOneToZeroOrOneDto>>;

internal partial class GetTestEntityExactlyOneToZeroOrOneByIdQueryHandler:GetTestEntityExactlyOneToZeroOrOneByIdQueryHandlerBase
{
    public GetTestEntityExactlyOneToZeroOrOneByIdQueryHandler(IReadOnlyRepository readOnlyRepository): base(readOnlyRepository){}
}

internal abstract class GetTestEntityExactlyOneToZeroOrOneByIdQueryHandlerBase:  QueryBase<IQueryable<TestEntityExactlyOneToZeroOrOneDto>>, IRequestHandler<GetTestEntityExactlyOneToZeroOrOneByIdQuery, IQueryable<TestEntityExactlyOneToZeroOrOneDto>>
{
    public  GetTestEntityExactlyOneToZeroOrOneByIdQueryHandlerBase(IReadOnlyRepository readOnlyRepository)
    {
        ReadOnlyRepository = readOnlyRepository;
    }

    public IReadOnlyRepository ReadOnlyRepository { get; }

    public virtual Task<IQueryable<TestEntityExactlyOneToZeroOrOneDto>> Handle(GetTestEntityExactlyOneToZeroOrOneByIdQuery request, CancellationToken cancellationToken)
    {    
        var query = ReadOnlyRepository.Query<TestEntityExactlyOneToZeroOrOneDto>()
            .Where(r =>
                r.Id.Equals(request.keyId));
        return Task.FromResult(OnResponse(query));
    }
}