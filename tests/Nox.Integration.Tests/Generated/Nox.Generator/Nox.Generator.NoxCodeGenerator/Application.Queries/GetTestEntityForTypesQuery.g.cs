// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Queries;
using Nox.Application.Repositories;
using TestWebApp.Application.Dto;
using TestWebApp.Infrastructure.Persistence;

namespace TestWebApp.Application.Queries;

public partial record GetTestEntityForTypesQuery() : IRequest<IQueryable<TestEntityForTypesDto>>;

internal partial class GetTestEntityForTypesQueryHandler: GetTestEntityForTypesQueryHandlerBase
{
    public GetTestEntityForTypesQueryHandler(IReadOnlyRepository readOnlyRepository): base(readOnlyRepository){}
}

internal abstract class GetTestEntityForTypesQueryHandlerBase : QueryBase<IQueryable<TestEntityForTypesDto>>, IRequestHandler<GetTestEntityForTypesQuery, IQueryable<TestEntityForTypesDto>>
{
    public  GetTestEntityForTypesQueryHandlerBase(IReadOnlyRepository readOnlyRepository)
    {
        ReadOnlyRepository = readOnlyRepository;
    }

    public IReadOnlyRepository ReadOnlyRepository { get; }

    public virtual Task<IQueryable<TestEntityForTypesDto>> Handle(GetTestEntityForTypesQuery request, CancellationToken cancellationToken)
    {
        var query = ReadOnlyRepository.Query<TestEntityForTypesDto>();
       return Task.FromResult(OnResponse(query));
    }
}