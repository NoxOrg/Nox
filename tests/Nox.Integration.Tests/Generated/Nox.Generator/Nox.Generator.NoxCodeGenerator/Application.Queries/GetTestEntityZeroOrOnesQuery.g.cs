// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Queries;
using Nox.Application.Repositories;
using TestWebApp.Application.Dto;
using TestWebApp.Infrastructure.Persistence;

namespace TestWebApp.Application.Queries;

public partial record GetTestEntityZeroOrOnesQuery() : IRequest<IQueryable<TestEntityZeroOrOneDto>>;

internal partial class GetTestEntityZeroOrOnesQueryHandler: GetTestEntityZeroOrOnesQueryHandlerBase
{
    public GetTestEntityZeroOrOnesQueryHandler(IReadOnlyRepository readOnlyRepository): base(readOnlyRepository){}
}

internal abstract class GetTestEntityZeroOrOnesQueryHandlerBase : QueryBase<IQueryable<TestEntityZeroOrOneDto>>, IRequestHandler<GetTestEntityZeroOrOnesQuery, IQueryable<TestEntityZeroOrOneDto>>
{
    public  GetTestEntityZeroOrOnesQueryHandlerBase(IReadOnlyRepository readOnlyRepository)
    {
        ReadOnlyRepository = readOnlyRepository;
    }

    public IReadOnlyRepository ReadOnlyRepository { get; }

    public virtual Task<IQueryable<TestEntityZeroOrOneDto>> Handle(GetTestEntityZeroOrOnesQuery request, CancellationToken cancellationToken)
    {
        var query = ReadOnlyRepository.Query<TestEntityZeroOrOneDto>();
       return Task.FromResult(OnResponse(query));
    }
}