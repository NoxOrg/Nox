// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Queries;
using Nox.Application.Repositories;
using TestWebApp.Application.Dto;
using TestWebApp.Infrastructure.Persistence;

namespace TestWebApp.Application.Queries;

public partial record GetTestEntityExactlyOnesQuery() : IRequest<IQueryable<TestEntityExactlyOneDto>>;

internal partial class GetTestEntityExactlyOnesQueryHandler: GetTestEntityExactlyOnesQueryHandlerBase
{
    public GetTestEntityExactlyOnesQueryHandler(IReadOnlyRepository readOnlyRepository): base(readOnlyRepository){}
}

internal abstract class GetTestEntityExactlyOnesQueryHandlerBase : QueryBase<IQueryable<TestEntityExactlyOneDto>>, IRequestHandler<GetTestEntityExactlyOnesQuery, IQueryable<TestEntityExactlyOneDto>>
{
    public  GetTestEntityExactlyOnesQueryHandlerBase(IReadOnlyRepository readOnlyRepository)
    {
        ReadOnlyRepository = readOnlyRepository;
    }

    public IReadOnlyRepository ReadOnlyRepository { get; }

    public virtual Task<IQueryable<TestEntityExactlyOneDto>> Handle(GetTestEntityExactlyOnesQuery request, CancellationToken cancellationToken)
    {
        var query = ReadOnlyRepository.Query<TestEntityExactlyOneDto>();
       return Task.FromResult(OnResponse(query));
    }
}