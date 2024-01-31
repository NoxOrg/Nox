// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Queries;
using Nox.Application.Repositories;
using TestWebApp.Application.Dto;

namespace TestWebApp.Application.Queries;

public partial record GetTestEntityZeroOrManyToZeroOrOnesQuery() : IRequest<IQueryable<TestEntityZeroOrManyToZeroOrOneDto>>;

internal partial class GetTestEntityZeroOrManyToZeroOrOnesQueryHandler: GetTestEntityZeroOrManyToZeroOrOnesQueryHandlerBase
{
    public GetTestEntityZeroOrManyToZeroOrOnesQueryHandler(IReadOnlyRepository readOnlyRepository): base(readOnlyRepository){}
}

internal abstract class GetTestEntityZeroOrManyToZeroOrOnesQueryHandlerBase : QueryBase<IQueryable<TestEntityZeroOrManyToZeroOrOneDto>>, IRequestHandler<GetTestEntityZeroOrManyToZeroOrOnesQuery, IQueryable<TestEntityZeroOrManyToZeroOrOneDto>>
{
    public  GetTestEntityZeroOrManyToZeroOrOnesQueryHandlerBase(IReadOnlyRepository readOnlyRepository)
    {
        ReadOnlyRepository = readOnlyRepository;
    }

    public IReadOnlyRepository ReadOnlyRepository { get; }

    public virtual Task<IQueryable<TestEntityZeroOrManyToZeroOrOneDto>> Handle(GetTestEntityZeroOrManyToZeroOrOnesQuery request, CancellationToken cancellationToken)
    {
        var query = ReadOnlyRepository.Query<TestEntityZeroOrManyToZeroOrOneDto>();
       return Task.FromResult(OnResponse(query));
    }
}