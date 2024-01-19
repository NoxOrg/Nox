// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Queries;
using Nox.Application.Repositories;

using TestWebApp.Application.Dto;
using TestWebApp.Infrastructure.Persistence;

namespace TestWebApp.Application.Queries;

public partial record GetTestEntityForUniqueConstraintsByIdQuery(System.String keyId) : IRequest <IQueryable<TestEntityForUniqueConstraintsDto>>;

internal partial class GetTestEntityForUniqueConstraintsByIdQueryHandler:GetTestEntityForUniqueConstraintsByIdQueryHandlerBase
{
    public GetTestEntityForUniqueConstraintsByIdQueryHandler(IReadOnlyRepository readOnlyRepository): base(readOnlyRepository){}
}

internal abstract class GetTestEntityForUniqueConstraintsByIdQueryHandlerBase:  QueryBase<IQueryable<TestEntityForUniqueConstraintsDto>>, IRequestHandler<GetTestEntityForUniqueConstraintsByIdQuery, IQueryable<TestEntityForUniqueConstraintsDto>>
{
    public  GetTestEntityForUniqueConstraintsByIdQueryHandlerBase(IReadOnlyRepository readOnlyRepository)
    {
        ReadOnlyRepository = readOnlyRepository;
    }

    public IReadOnlyRepository ReadOnlyRepository { get; }

    public virtual Task<IQueryable<TestEntityForUniqueConstraintsDto>> Handle(GetTestEntityForUniqueConstraintsByIdQuery request, CancellationToken cancellationToken)
    {    
        var query = ReadOnlyRepository.Query<TestEntityForUniqueConstraintsDto >()
            .Where(r =>
                r.Id.Equals(request.keyId));
        return Task.FromResult(OnResponse(query));
    }
}