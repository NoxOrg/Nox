// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Queries;
using Nox.Application.Repositories;
using TestWebApp.Application.Dto;
using TestWebApp.Infrastructure.Persistence;

namespace TestWebApp.Application.Queries;

public partial record GetTestEntityExactlyOneToZeroOrOnesQuery() : IRequest<IQueryable<TestEntityExactlyOneToZeroOrOneDto>>;

internal partial class GetTestEntityExactlyOneToZeroOrOnesQueryHandler: GetTestEntityExactlyOneToZeroOrOnesQueryHandlerBase
{
    public GetTestEntityExactlyOneToZeroOrOnesQueryHandler(IReadOnlyRepository readOnlyRepository): base(readOnlyRepository){}
}

internal abstract class GetTestEntityExactlyOneToZeroOrOnesQueryHandlerBase : QueryBase<IQueryable<TestEntityExactlyOneToZeroOrOneDto>>, IRequestHandler<GetTestEntityExactlyOneToZeroOrOnesQuery, IQueryable<TestEntityExactlyOneToZeroOrOneDto>>
{
    public  GetTestEntityExactlyOneToZeroOrOnesQueryHandlerBase(IReadOnlyRepository readOnlyRepository)
    {
        ReadOnlyRepository = readOnlyRepository;
    }

    public IReadOnlyRepository ReadOnlyRepository { get; }

    public virtual Task<IQueryable<TestEntityExactlyOneToZeroOrOneDto>> Handle(GetTestEntityExactlyOneToZeroOrOnesQuery request, CancellationToken cancellationToken)
    {
        var query = ReadOnlyRepository.Query<TestEntityExactlyOneToZeroOrOneDto>();
       return Task.FromResult(OnResponse(query));
    }
}