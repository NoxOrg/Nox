// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Queries;
using Nox.Application.Repositories;

using TestWebApp.Application.Dto;
using TestWebApp.Infrastructure.Persistence;

namespace TestWebApp.Application.Queries;

public partial record GetTestEntityWithNuidByIdQuery(System.UInt32 keyId) : IRequest <IQueryable<TestEntityWithNuidDto>>;

internal partial class GetTestEntityWithNuidByIdQueryHandler:GetTestEntityWithNuidByIdQueryHandlerBase
{
    public GetTestEntityWithNuidByIdQueryHandler(IReadOnlyRepository readOnlyRepository): base(readOnlyRepository){}
}

internal abstract class GetTestEntityWithNuidByIdQueryHandlerBase:  QueryBase<IQueryable<TestEntityWithNuidDto>>, IRequestHandler<GetTestEntityWithNuidByIdQuery, IQueryable<TestEntityWithNuidDto>>
{
    public  GetTestEntityWithNuidByIdQueryHandlerBase(IReadOnlyRepository readOnlyRepository)
    {
        ReadOnlyRepository = readOnlyRepository;
    }

    public IReadOnlyRepository ReadOnlyRepository { get; }

    public virtual Task<IQueryable<TestEntityWithNuidDto>> Handle(GetTestEntityWithNuidByIdQuery request, CancellationToken cancellationToken)
    {    
        var query = ReadOnlyRepository.Query<TestEntityWithNuidDto>()
            .Where(r =>
                r.Id.Equals(request.keyId));
        return Task.FromResult(OnResponse(query));
    }
}