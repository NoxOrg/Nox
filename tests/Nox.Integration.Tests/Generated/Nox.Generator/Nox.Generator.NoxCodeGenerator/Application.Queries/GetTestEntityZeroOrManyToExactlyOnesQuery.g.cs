// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Queries;
using Nox.Application.Repositories;
using TestWebApp.Application.Dto;

namespace TestWebApp.Application.Queries;

public partial record GetTestEntityZeroOrManyToExactlyOnesQuery() : IRequest<IQueryable<TestEntityZeroOrManyToExactlyOneDto>>;

internal partial class GetTestEntityZeroOrManyToExactlyOnesQueryHandler: GetTestEntityZeroOrManyToExactlyOnesQueryHandlerBase
{
    public GetTestEntityZeroOrManyToExactlyOnesQueryHandler(IReadOnlyRepository readOnlyRepository): base(readOnlyRepository){}
}

internal abstract class GetTestEntityZeroOrManyToExactlyOnesQueryHandlerBase : QueryBase<IQueryable<TestEntityZeroOrManyToExactlyOneDto>>, IRequestHandler<GetTestEntityZeroOrManyToExactlyOnesQuery, IQueryable<TestEntityZeroOrManyToExactlyOneDto>>
{
    public  GetTestEntityZeroOrManyToExactlyOnesQueryHandlerBase(IReadOnlyRepository readOnlyRepository)
    {
        ReadOnlyRepository = readOnlyRepository;
    }

    public IReadOnlyRepository ReadOnlyRepository { get; }

    public virtual Task<IQueryable<TestEntityZeroOrManyToExactlyOneDto>> Handle(GetTestEntityZeroOrManyToExactlyOnesQuery request, CancellationToken cancellationToken)
    {
        var query = ReadOnlyRepository.Query<TestEntityZeroOrManyToExactlyOneDto>();
       return Task.FromResult(OnResponse(query));
    }
}