// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Queries;
using Nox.Application.Repositories;
using TestWebApp.Application.Dto;
using TestWebApp.Infrastructure.Persistence;

namespace TestWebApp.Application.Queries;

public partial record GetTestEntityForUniqueConstraintsQuery() : IRequest<IQueryable<TestEntityForUniqueConstraintsDto>>;

internal partial class GetTestEntityForUniqueConstraintsQueryHandler: GetTestEntityForUniqueConstraintsQueryHandlerBase
{
    public GetTestEntityForUniqueConstraintsQueryHandler(IReadOnlyRepository readOnlyRepository): base(readOnlyRepository){}
}

internal abstract class GetTestEntityForUniqueConstraintsQueryHandlerBase : QueryBase<IQueryable<TestEntityForUniqueConstraintsDto>>, IRequestHandler<GetTestEntityForUniqueConstraintsQuery, IQueryable<TestEntityForUniqueConstraintsDto>>
{
    public  GetTestEntityForUniqueConstraintsQueryHandlerBase(IReadOnlyRepository readOnlyRepository)
    {
        ReadOnlyRepository = readOnlyRepository;
    }

    public IReadOnlyRepository ReadOnlyRepository { get; }

    public virtual Task<IQueryable<TestEntityForUniqueConstraintsDto>> Handle(GetTestEntityForUniqueConstraintsQuery request, CancellationToken cancellationToken)
    {
        var query = ReadOnlyRepository.Query<TestEntityForUniqueConstraintsDto>();
       return Task.FromResult(OnResponse(query));
    }
}