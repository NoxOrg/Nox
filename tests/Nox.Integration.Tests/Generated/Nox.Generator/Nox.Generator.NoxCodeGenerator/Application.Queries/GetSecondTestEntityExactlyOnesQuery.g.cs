// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Queries;
using Nox.Application.Repositories;
using TestWebApp.Application.Dto;
using TestWebApp.Infrastructure.Persistence;

namespace TestWebApp.Application.Queries;

public partial record GetSecondTestEntityExactlyOnesQuery() : IRequest<IQueryable<SecondTestEntityExactlyOneDto>>;

internal partial class GetSecondTestEntityExactlyOnesQueryHandler: GetSecondTestEntityExactlyOnesQueryHandlerBase
{
    public GetSecondTestEntityExactlyOnesQueryHandler(IReadOnlyRepository readOnlyRepository): base(readOnlyRepository){}
}

internal abstract class GetSecondTestEntityExactlyOnesQueryHandlerBase : QueryBase<IQueryable<SecondTestEntityExactlyOneDto>>, IRequestHandler<GetSecondTestEntityExactlyOnesQuery, IQueryable<SecondTestEntityExactlyOneDto>>
{
    public  GetSecondTestEntityExactlyOnesQueryHandlerBase(IReadOnlyRepository readOnlyRepository)
    {
        ReadOnlyRepository = readOnlyRepository;
    }

    public IReadOnlyRepository ReadOnlyRepository { get; }

    public virtual Task<IQueryable<SecondTestEntityExactlyOneDto>> Handle(GetSecondTestEntityExactlyOnesQuery request, CancellationToken cancellationToken)
    {
        var query = ReadOnlyRepository.Query<SecondTestEntityExactlyOneDto>();
       return Task.FromResult(OnResponse(query));
    }
}