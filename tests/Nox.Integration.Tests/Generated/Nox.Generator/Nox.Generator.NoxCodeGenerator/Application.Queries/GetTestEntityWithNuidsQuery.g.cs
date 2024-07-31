// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Queries;
using Nox.Application.Repositories;
using TestWebApp.Application.Dto;

namespace TestWebApp.Application.Queries;

public partial record GetTestEntityWithNuidsQuery() : IRequest<IQueryable<TestEntityWithNuidDto>>;

internal partial class GetTestEntityWithNuidsQueryHandler: GetTestEntityWithNuidsQueryHandlerBase
{
    public GetTestEntityWithNuidsQueryHandler(IReadOnlyRepository readOnlyRepository): base(readOnlyRepository){}
}

internal abstract class GetTestEntityWithNuidsQueryHandlerBase : QueryBase<IQueryable<TestEntityWithNuidDto>>, IRequestHandler<GetTestEntityWithNuidsQuery, IQueryable<TestEntityWithNuidDto>>
{
    public  GetTestEntityWithNuidsQueryHandlerBase(IReadOnlyRepository readOnlyRepository)
    {
        ReadOnlyRepository = readOnlyRepository;
    }

    public IReadOnlyRepository ReadOnlyRepository { get; }

    public virtual Task<IQueryable<TestEntityWithNuidDto>> Handle(GetTestEntityWithNuidsQuery request, CancellationToken cancellationToken)
    {
        var query = ReadOnlyRepository.Query<TestEntityWithNuidDto>();
       return Task.FromResult(OnResponse(query));
    }
}