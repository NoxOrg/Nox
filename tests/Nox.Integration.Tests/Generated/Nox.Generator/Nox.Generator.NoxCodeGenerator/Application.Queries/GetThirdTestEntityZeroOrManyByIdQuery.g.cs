// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Queries;
using Nox.Application.Repositories;

using TestWebApp.Application.Dto;

namespace TestWebApp.Application.Queries;

public partial record GetThirdTestEntityZeroOrManyByIdQuery(System.String keyId) : IRequest <IQueryable<ThirdTestEntityZeroOrManyDto>>;

internal partial class GetThirdTestEntityZeroOrManyByIdQueryHandler:GetThirdTestEntityZeroOrManyByIdQueryHandlerBase
{
    public GetThirdTestEntityZeroOrManyByIdQueryHandler(IReadOnlyRepository readOnlyRepository): base(readOnlyRepository){}
}

internal abstract class GetThirdTestEntityZeroOrManyByIdQueryHandlerBase:  QueryBase<IQueryable<ThirdTestEntityZeroOrManyDto>>, IRequestHandler<GetThirdTestEntityZeroOrManyByIdQuery, IQueryable<ThirdTestEntityZeroOrManyDto>>
{
    public  GetThirdTestEntityZeroOrManyByIdQueryHandlerBase(IReadOnlyRepository readOnlyRepository)
    {
        ReadOnlyRepository = readOnlyRepository;
    }

    public IReadOnlyRepository ReadOnlyRepository { get; }

    public virtual Task<IQueryable<ThirdTestEntityZeroOrManyDto>> Handle(GetThirdTestEntityZeroOrManyByIdQuery request, CancellationToken cancellationToken)
    {    
        var query = ReadOnlyRepository.Query<ThirdTestEntityZeroOrManyDto>()
            .Where(r =>
                r.Id.Equals(request.keyId));
        return Task.FromResult(OnResponse(query));
    }
}