// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Queries;
using Nox.Application.Repositories;

using TestWebApp.Application.Dto;

namespace TestWebApp.Application.Queries;

public partial record GetSecondTestEntityZeroOrOneByIdQuery(System.String keyId) : IRequest <IQueryable<SecondTestEntityZeroOrOneDto>>;

internal partial class GetSecondTestEntityZeroOrOneByIdQueryHandler:GetSecondTestEntityZeroOrOneByIdQueryHandlerBase
{
    public GetSecondTestEntityZeroOrOneByIdQueryHandler(IReadOnlyRepository readOnlyRepository): base(readOnlyRepository){}
}

internal abstract class GetSecondTestEntityZeroOrOneByIdQueryHandlerBase:  QueryBase<IQueryable<SecondTestEntityZeroOrOneDto>>, IRequestHandler<GetSecondTestEntityZeroOrOneByIdQuery, IQueryable<SecondTestEntityZeroOrOneDto>>
{
    public  GetSecondTestEntityZeroOrOneByIdQueryHandlerBase(IReadOnlyRepository readOnlyRepository)
    {
        ReadOnlyRepository = readOnlyRepository;
    }

    public IReadOnlyRepository ReadOnlyRepository { get; }

    public virtual Task<IQueryable<SecondTestEntityZeroOrOneDto>> Handle(GetSecondTestEntityZeroOrOneByIdQuery request, CancellationToken cancellationToken)
    {    
        var query = ReadOnlyRepository.Query<SecondTestEntityZeroOrOneDto>()
            .Where(r =>
                r.Id.Equals(request.keyId));
        return Task.FromResult(OnResponse(query));
    }
}