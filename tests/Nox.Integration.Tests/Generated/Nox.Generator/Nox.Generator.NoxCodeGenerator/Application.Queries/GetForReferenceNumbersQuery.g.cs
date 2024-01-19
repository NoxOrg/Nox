// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Queries;
using Nox.Application.Repositories;
using TestWebApp.Application.Dto;
using TestWebApp.Infrastructure.Persistence;

namespace TestWebApp.Application.Queries;

public partial record GetForReferenceNumbersQuery() : IRequest<IQueryable<ForReferenceNumberDto>>;

internal partial class GetForReferenceNumbersQueryHandler: GetForReferenceNumbersQueryHandlerBase
{
    public GetForReferenceNumbersQueryHandler(IReadOnlyRepository readOnlyRepository): base(readOnlyRepository){}
}

internal abstract class GetForReferenceNumbersQueryHandlerBase : QueryBase<IQueryable<ForReferenceNumberDto>>, IRequestHandler<GetForReferenceNumbersQuery, IQueryable<ForReferenceNumberDto>>
{
    public  GetForReferenceNumbersQueryHandlerBase(IReadOnlyRepository readOnlyRepository)
    {
        ReadOnlyRepository = readOnlyRepository;
    }

    public IReadOnlyRepository ReadOnlyRepository { get; }

    public virtual Task<IQueryable<ForReferenceNumberDto>> Handle(GetForReferenceNumbersQuery request, CancellationToken cancellationToken)
    {
        var query = ReadOnlyRepository.Query<ForReferenceNumberDto>();
       return Task.FromResult(OnResponse(query));
    }
}