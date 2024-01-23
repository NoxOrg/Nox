// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Queries;
using Nox.Application.Repositories;
using TestWebApp.Application.Dto;
using TestWebApp.Infrastructure.Persistence;

namespace TestWebApp.Application.Queries;

public partial record GetTestEntityLocalizationsQuery() : IRequest<IQueryable<TestEntityLocalizationDto>>;

internal partial class GetTestEntityLocalizationsQueryHandler: GetTestEntityLocalizationsQueryHandlerBase
{
    public GetTestEntityLocalizationsQueryHandler(IReadOnlyRepository readOnlyRepository): base(readOnlyRepository){}
}

internal abstract class GetTestEntityLocalizationsQueryHandlerBase : QueryBase<IQueryable<TestEntityLocalizationDto>>, IRequestHandler<GetTestEntityLocalizationsQuery, IQueryable<TestEntityLocalizationDto>>
{
    public  GetTestEntityLocalizationsQueryHandlerBase(IReadOnlyRepository readOnlyRepository)
    {
        ReadOnlyRepository = readOnlyRepository;
    }

    public IReadOnlyRepository ReadOnlyRepository { get; }

    public virtual Task<IQueryable<TestEntityLocalizationDto>> Handle(GetTestEntityLocalizationsQuery request, CancellationToken cancellationToken)
    {
        var query = ReadOnlyRepository.Query<TestEntityLocalizationDto>();
       return Task.FromResult(OnResponse(query));
    }
}