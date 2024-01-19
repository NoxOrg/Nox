// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Queries;
using Nox.Application.Repositories;

using TestWebApp.Application.Dto;
using TestWebApp.Infrastructure.Persistence;

namespace TestWebApp.Application.Queries;

public partial record GetTestEntityForTypesByIdQuery(System.String keyId) : IRequest <IQueryable<TestEntityForTypesDto>>;

internal partial class GetTestEntityForTypesByIdQueryHandler:GetTestEntityForTypesByIdQueryHandlerBase
{
    public GetTestEntityForTypesByIdQueryHandler(IReadOnlyRepository readOnlyRepository): base(readOnlyRepository){}
}

internal abstract class GetTestEntityForTypesByIdQueryHandlerBase:  QueryBase<IQueryable<TestEntityForTypesDto>>, IRequestHandler<GetTestEntityForTypesByIdQuery, IQueryable<TestEntityForTypesDto>>
{
    public  GetTestEntityForTypesByIdQueryHandlerBase(IReadOnlyRepository readOnlyRepository)
    {
        ReadOnlyRepository = readOnlyRepository;
    }

    public IReadOnlyRepository ReadOnlyRepository { get; }

    public virtual Task<IQueryable<TestEntityForTypesDto>> Handle(GetTestEntityForTypesByIdQuery request, CancellationToken cancellationToken)
    {    
        var query = ReadOnlyRepository.Query<TestEntityForTypesDto >()
            .Where(r =>
                r.Id.Equals(request.keyId));
        return Task.FromResult(OnResponse(query));
    }
}