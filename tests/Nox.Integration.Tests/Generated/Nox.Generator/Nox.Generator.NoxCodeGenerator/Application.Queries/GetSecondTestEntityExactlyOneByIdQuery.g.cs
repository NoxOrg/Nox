// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Queries;
using Nox.Application.Repositories;

using TestWebApp.Application.Dto;
using TestWebApp.Infrastructure.Persistence;

namespace TestWebApp.Application.Queries;

public partial record GetSecondTestEntityExactlyOneByIdQuery(System.String keyId) : IRequest <IQueryable<SecondTestEntityExactlyOneDto>>;

internal partial class GetSecondTestEntityExactlyOneByIdQueryHandler:GetSecondTestEntityExactlyOneByIdQueryHandlerBase
{
    public GetSecondTestEntityExactlyOneByIdQueryHandler(IReadOnlyRepository readOnlyRepository): base(readOnlyRepository){}
}

internal abstract class GetSecondTestEntityExactlyOneByIdQueryHandlerBase:  QueryBase<IQueryable<SecondTestEntityExactlyOneDto>>, IRequestHandler<GetSecondTestEntityExactlyOneByIdQuery, IQueryable<SecondTestEntityExactlyOneDto>>
{
    public  GetSecondTestEntityExactlyOneByIdQueryHandlerBase(IReadOnlyRepository readOnlyRepository)
    {
        ReadOnlyRepository = readOnlyRepository;
    }

    public IReadOnlyRepository ReadOnlyRepository { get; }

    public virtual Task<IQueryable<SecondTestEntityExactlyOneDto>> Handle(GetSecondTestEntityExactlyOneByIdQuery request, CancellationToken cancellationToken)
    {    
        var query = ReadOnlyRepository.Query<SecondTestEntityExactlyOneDto>()
            .Where(r =>
                r.Id.Equals(request.keyId));
        return Task.FromResult(OnResponse(query));
    }
}