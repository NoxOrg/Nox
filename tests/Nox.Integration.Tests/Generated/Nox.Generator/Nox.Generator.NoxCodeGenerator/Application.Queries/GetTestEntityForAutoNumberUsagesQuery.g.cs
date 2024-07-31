// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Queries;
using Nox.Application.Repositories;
using TestWebApp.Application.Dto;

namespace TestWebApp.Application.Queries;

public partial record GetTestEntityForAutoNumberUsagesQuery() : IRequest<IQueryable<TestEntityForAutoNumberUsagesDto>>;

internal partial class GetTestEntityForAutoNumberUsagesQueryHandler: GetTestEntityForAutoNumberUsagesQueryHandlerBase
{
    public GetTestEntityForAutoNumberUsagesQueryHandler(IReadOnlyRepository readOnlyRepository): base(readOnlyRepository){}
}

internal abstract class GetTestEntityForAutoNumberUsagesQueryHandlerBase : QueryBase<IQueryable<TestEntityForAutoNumberUsagesDto>>, IRequestHandler<GetTestEntityForAutoNumberUsagesQuery, IQueryable<TestEntityForAutoNumberUsagesDto>>
{
    public  GetTestEntityForAutoNumberUsagesQueryHandlerBase(IReadOnlyRepository readOnlyRepository)
    {
        ReadOnlyRepository = readOnlyRepository;
    }

    public IReadOnlyRepository ReadOnlyRepository { get; }

    public virtual Task<IQueryable<TestEntityForAutoNumberUsagesDto>> Handle(GetTestEntityForAutoNumberUsagesQuery request, CancellationToken cancellationToken)
    {
        var query = ReadOnlyRepository.Query<TestEntityForAutoNumberUsagesDto>();
       return Task.FromResult(OnResponse(query));
    }
}