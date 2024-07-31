// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Queries;
using Nox.Application.Repositories;
using TestWebApp.Application.Dto;

namespace TestWebApp.Application.Queries;

public partial record GetSecondTestEntityZeroOrOnesQuery() : IRequest<IQueryable<SecondTestEntityZeroOrOneDto>>;

internal partial class GetSecondTestEntityZeroOrOnesQueryHandler: GetSecondTestEntityZeroOrOnesQueryHandlerBase
{
    public GetSecondTestEntityZeroOrOnesQueryHandler(IReadOnlyRepository readOnlyRepository): base(readOnlyRepository){}
}

internal abstract class GetSecondTestEntityZeroOrOnesQueryHandlerBase : QueryBase<IQueryable<SecondTestEntityZeroOrOneDto>>, IRequestHandler<GetSecondTestEntityZeroOrOnesQuery, IQueryable<SecondTestEntityZeroOrOneDto>>
{
    public  GetSecondTestEntityZeroOrOnesQueryHandlerBase(IReadOnlyRepository readOnlyRepository)
    {
        ReadOnlyRepository = readOnlyRepository;
    }

    public IReadOnlyRepository ReadOnlyRepository { get; }

    public virtual Task<IQueryable<SecondTestEntityZeroOrOneDto>> Handle(GetSecondTestEntityZeroOrOnesQuery request, CancellationToken cancellationToken)
    {
        var query = ReadOnlyRepository.Query<SecondTestEntityZeroOrOneDto>();
       return Task.FromResult(OnResponse(query));
    }
}