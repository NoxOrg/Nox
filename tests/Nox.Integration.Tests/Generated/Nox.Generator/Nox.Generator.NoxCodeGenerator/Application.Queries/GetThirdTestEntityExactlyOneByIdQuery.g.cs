// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Queries;
using Nox.Application.Repositories;

using TestWebApp.Application.Dto;

namespace TestWebApp.Application.Queries;

public partial record GetThirdTestEntityExactlyOneByIdQuery(System.String keyId) : IRequest <IQueryable<ThirdTestEntityExactlyOneDto>>;

internal partial class GetThirdTestEntityExactlyOneByIdQueryHandler:GetThirdTestEntityExactlyOneByIdQueryHandlerBase
{
    public GetThirdTestEntityExactlyOneByIdQueryHandler(IReadOnlyRepository readOnlyRepository): base(readOnlyRepository){}
}

internal abstract class GetThirdTestEntityExactlyOneByIdQueryHandlerBase:  QueryBase<IQueryable<ThirdTestEntityExactlyOneDto>>, IRequestHandler<GetThirdTestEntityExactlyOneByIdQuery, IQueryable<ThirdTestEntityExactlyOneDto>>
{
    public  GetThirdTestEntityExactlyOneByIdQueryHandlerBase(IReadOnlyRepository readOnlyRepository)
    {
        ReadOnlyRepository = readOnlyRepository;
    }

    public IReadOnlyRepository ReadOnlyRepository { get; }

    public virtual Task<IQueryable<ThirdTestEntityExactlyOneDto>> Handle(GetThirdTestEntityExactlyOneByIdQuery request, CancellationToken cancellationToken)
    {    
        var query = ReadOnlyRepository.Query<ThirdTestEntityExactlyOneDto>()
            .Where(r =>
                r.Id.Equals(request.keyId));
        return Task.FromResult(OnResponse(query));
    }
}