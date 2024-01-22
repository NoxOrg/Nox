// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Queries;
using Nox.Application.Repositories;
using TestWebApp.Application.Dto;
using TestWebApp.Infrastructure.Persistence;

namespace TestWebApp.Application.Queries;

public partial record GetTestEntityOneOrManyToExactlyOnesQuery() : IRequest<IQueryable<TestEntityOneOrManyToExactlyOneDto>>;

internal partial class GetTestEntityOneOrManyToExactlyOnesQueryHandler: GetTestEntityOneOrManyToExactlyOnesQueryHandlerBase
{
    public GetTestEntityOneOrManyToExactlyOnesQueryHandler(IReadOnlyRepository readOnlyRepository): base(readOnlyRepository){}
}

internal abstract class GetTestEntityOneOrManyToExactlyOnesQueryHandlerBase : QueryBase<IQueryable<TestEntityOneOrManyToExactlyOneDto>>, IRequestHandler<GetTestEntityOneOrManyToExactlyOnesQuery, IQueryable<TestEntityOneOrManyToExactlyOneDto>>
{
    public  GetTestEntityOneOrManyToExactlyOnesQueryHandlerBase(IReadOnlyRepository readOnlyRepository)
    {
        ReadOnlyRepository = readOnlyRepository;
    }

    public IReadOnlyRepository ReadOnlyRepository { get; }

    public virtual Task<IQueryable<TestEntityOneOrManyToExactlyOneDto>> Handle(GetTestEntityOneOrManyToExactlyOnesQuery request, CancellationToken cancellationToken)
    {
        var query = ReadOnlyRepository.Query<TestEntityOneOrManyToExactlyOneDto>();
       return Task.FromResult(OnResponse(query));
    }
}