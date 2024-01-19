// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Queries;
using Nox.Application.Repositories;
using TestWebApp.Application.Dto;
using TestWebApp.Infrastructure.Persistence;

namespace TestWebApp.Application.Queries;

public partial record GetTestEntityOneOrManyToZeroOrOnesQuery() : IRequest<IQueryable<TestEntityOneOrManyToZeroOrOneDto>>;

internal partial class GetTestEntityOneOrManyToZeroOrOnesQueryHandler: GetTestEntityOneOrManyToZeroOrOnesQueryHandlerBase
{
    public GetTestEntityOneOrManyToZeroOrOnesQueryHandler(IReadOnlyRepository readOnlyRepository): base(readOnlyRepository){}
}

internal abstract class GetTestEntityOneOrManyToZeroOrOnesQueryHandlerBase : QueryBase<IQueryable<TestEntityOneOrManyToZeroOrOneDto>>, IRequestHandler<GetTestEntityOneOrManyToZeroOrOnesQuery, IQueryable<TestEntityOneOrManyToZeroOrOneDto>>
{
    public  GetTestEntityOneOrManyToZeroOrOnesQueryHandlerBase(IReadOnlyRepository readOnlyRepository)
    {
        ReadOnlyRepository = readOnlyRepository;
    }

    public IReadOnlyRepository ReadOnlyRepository { get; }

    public virtual Task<IQueryable<TestEntityOneOrManyToZeroOrOneDto>> Handle(GetTestEntityOneOrManyToZeroOrOnesQuery request, CancellationToken cancellationToken)
    {
        var query = ReadOnlyRepository.Query<TestEntityOneOrManyToZeroOrOneDto>();
       return Task.FromResult(OnResponse(query));
    }
}