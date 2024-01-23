// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Queries;
using Nox.Application.Repositories;
using TestWebApp.Application.Dto;
using TestWebApp.Infrastructure.Persistence;

namespace TestWebApp.Application.Queries;

public partial record GetTestEntityZeroOrOneToExactlyOnesQuery() : IRequest<IQueryable<TestEntityZeroOrOneToExactlyOneDto>>;

internal partial class GetTestEntityZeroOrOneToExactlyOnesQueryHandler: GetTestEntityZeroOrOneToExactlyOnesQueryHandlerBase
{
    public GetTestEntityZeroOrOneToExactlyOnesQueryHandler(IReadOnlyRepository readOnlyRepository): base(readOnlyRepository){}
}

internal abstract class GetTestEntityZeroOrOneToExactlyOnesQueryHandlerBase : QueryBase<IQueryable<TestEntityZeroOrOneToExactlyOneDto>>, IRequestHandler<GetTestEntityZeroOrOneToExactlyOnesQuery, IQueryable<TestEntityZeroOrOneToExactlyOneDto>>
{
    public  GetTestEntityZeroOrOneToExactlyOnesQueryHandlerBase(IReadOnlyRepository readOnlyRepository)
    {
        ReadOnlyRepository = readOnlyRepository;
    }

    public IReadOnlyRepository ReadOnlyRepository { get; }

    public virtual Task<IQueryable<TestEntityZeroOrOneToExactlyOneDto>> Handle(GetTestEntityZeroOrOneToExactlyOnesQuery request, CancellationToken cancellationToken)
    {
        var query = ReadOnlyRepository.Query<TestEntityZeroOrOneToExactlyOneDto>();
       return Task.FromResult(OnResponse(query));
    }
}