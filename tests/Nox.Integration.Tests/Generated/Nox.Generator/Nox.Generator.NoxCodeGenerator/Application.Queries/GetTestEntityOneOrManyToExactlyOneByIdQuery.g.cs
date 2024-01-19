// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Queries;
using Nox.Application.Repositories;

using TestWebApp.Application.Dto;
using TestWebApp.Infrastructure.Persistence;

namespace TestWebApp.Application.Queries;

public partial record GetTestEntityOneOrManyToExactlyOneByIdQuery(System.String keyId) : IRequest <IQueryable<TestEntityOneOrManyToExactlyOneDto>>;

internal partial class GetTestEntityOneOrManyToExactlyOneByIdQueryHandler:GetTestEntityOneOrManyToExactlyOneByIdQueryHandlerBase
{
    public GetTestEntityOneOrManyToExactlyOneByIdQueryHandler(IReadOnlyRepository readOnlyRepository): base(readOnlyRepository){}
}

internal abstract class GetTestEntityOneOrManyToExactlyOneByIdQueryHandlerBase:  QueryBase<IQueryable<TestEntityOneOrManyToExactlyOneDto>>, IRequestHandler<GetTestEntityOneOrManyToExactlyOneByIdQuery, IQueryable<TestEntityOneOrManyToExactlyOneDto>>
{
    public  GetTestEntityOneOrManyToExactlyOneByIdQueryHandlerBase(IReadOnlyRepository readOnlyRepository)
    {
        ReadOnlyRepository = readOnlyRepository;
    }

    public IReadOnlyRepository ReadOnlyRepository { get; }

    public virtual Task<IQueryable<TestEntityOneOrManyToExactlyOneDto>> Handle(GetTestEntityOneOrManyToExactlyOneByIdQuery request, CancellationToken cancellationToken)
    {    
        var query = ReadOnlyRepository.Query<TestEntityOneOrManyToExactlyOneDto>()
            .Where(r =>
                r.Id.Equals(request.keyId));
        return Task.FromResult(OnResponse(query));
    }
}