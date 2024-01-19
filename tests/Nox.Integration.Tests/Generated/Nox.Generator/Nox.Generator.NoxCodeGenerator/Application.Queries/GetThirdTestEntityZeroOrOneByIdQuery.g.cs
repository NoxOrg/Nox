// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Queries;
using Nox.Application.Repositories;

using TestWebApp.Application.Dto;
using TestWebApp.Infrastructure.Persistence;

namespace TestWebApp.Application.Queries;

public partial record GetThirdTestEntityZeroOrOneByIdQuery(System.String keyId) : IRequest <IQueryable<ThirdTestEntityZeroOrOneDto>>;

internal partial class GetThirdTestEntityZeroOrOneByIdQueryHandler:GetThirdTestEntityZeroOrOneByIdQueryHandlerBase
{
    public GetThirdTestEntityZeroOrOneByIdQueryHandler(IReadOnlyRepository readOnlyRepository): base(readOnlyRepository){}
}

internal abstract class GetThirdTestEntityZeroOrOneByIdQueryHandlerBase:  QueryBase<IQueryable<ThirdTestEntityZeroOrOneDto>>, IRequestHandler<GetThirdTestEntityZeroOrOneByIdQuery, IQueryable<ThirdTestEntityZeroOrOneDto>>
{
    public  GetThirdTestEntityZeroOrOneByIdQueryHandlerBase(IReadOnlyRepository readOnlyRepository)
    {
        ReadOnlyRepository = readOnlyRepository;
    }

    public IReadOnlyRepository ReadOnlyRepository { get; }

    public virtual Task<IQueryable<ThirdTestEntityZeroOrOneDto>> Handle(GetThirdTestEntityZeroOrOneByIdQuery request, CancellationToken cancellationToken)
    {    
        var query = ReadOnlyRepository.Query<ThirdTestEntityZeroOrOneDto >()
            .Where(r =>
                r.Id.Equals(request.keyId));
        return Task.FromResult(OnResponse(query));
    }
}