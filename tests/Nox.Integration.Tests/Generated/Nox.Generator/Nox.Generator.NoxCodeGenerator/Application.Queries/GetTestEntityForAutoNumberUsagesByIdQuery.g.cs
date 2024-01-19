// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Queries;
using Nox.Application.Repositories;

using TestWebApp.Application.Dto;
using TestWebApp.Infrastructure.Persistence;

namespace TestWebApp.Application.Queries;

public partial record GetTestEntityForAutoNumberUsagesByIdQuery(System.Int64 keyId) : IRequest <IQueryable<TestEntityForAutoNumberUsagesDto>>;

internal partial class GetTestEntityForAutoNumberUsagesByIdQueryHandler:GetTestEntityForAutoNumberUsagesByIdQueryHandlerBase
{
    public GetTestEntityForAutoNumberUsagesByIdQueryHandler(IReadOnlyRepository readOnlyRepository): base(readOnlyRepository){}
}

internal abstract class GetTestEntityForAutoNumberUsagesByIdQueryHandlerBase:  QueryBase<IQueryable<TestEntityForAutoNumberUsagesDto>>, IRequestHandler<GetTestEntityForAutoNumberUsagesByIdQuery, IQueryable<TestEntityForAutoNumberUsagesDto>>
{
    public  GetTestEntityForAutoNumberUsagesByIdQueryHandlerBase(IReadOnlyRepository readOnlyRepository)
    {
        ReadOnlyRepository = readOnlyRepository;
    }

    public IReadOnlyRepository ReadOnlyRepository { get; }

    public virtual Task<IQueryable<TestEntityForAutoNumberUsagesDto>> Handle(GetTestEntityForAutoNumberUsagesByIdQuery request, CancellationToken cancellationToken)
    {    
        var query = ReadOnlyRepository.Query<TestEntityForAutoNumberUsagesDto >()
            .Where(r =>
                r.Id.Equals(request.keyId));
        return Task.FromResult(OnResponse(query));
    }
}