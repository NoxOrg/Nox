// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Queries;
using Nox.Application.Repositories;

using TestWebApp.Application.Dto;

namespace TestWebApp.Application.Queries;

public partial record GetThirdTestEntityOneOrManyByIdQuery(System.String keyId) : IRequest <IQueryable<ThirdTestEntityOneOrManyDto>>;

internal partial class GetThirdTestEntityOneOrManyByIdQueryHandler:GetThirdTestEntityOneOrManyByIdQueryHandlerBase
{
    public GetThirdTestEntityOneOrManyByIdQueryHandler(IReadOnlyRepository readOnlyRepository): base(readOnlyRepository){}
}

internal abstract class GetThirdTestEntityOneOrManyByIdQueryHandlerBase:  QueryBase<IQueryable<ThirdTestEntityOneOrManyDto>>, IRequestHandler<GetThirdTestEntityOneOrManyByIdQuery, IQueryable<ThirdTestEntityOneOrManyDto>>
{
    public  GetThirdTestEntityOneOrManyByIdQueryHandlerBase(IReadOnlyRepository readOnlyRepository)
    {
        ReadOnlyRepository = readOnlyRepository;
    }

    public IReadOnlyRepository ReadOnlyRepository { get; }

    public virtual Task<IQueryable<ThirdTestEntityOneOrManyDto>> Handle(GetThirdTestEntityOneOrManyByIdQuery request, CancellationToken cancellationToken)
    {    
        var query = ReadOnlyRepository.Query<ThirdTestEntityOneOrManyDto>()
            .Where(r =>
                r.Id.Equals(request.keyId));
        return Task.FromResult(OnResponse(query));
    }
}