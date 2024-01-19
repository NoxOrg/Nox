// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Queries;
using Nox.Application.Repositories;

using TestWebApp.Application.Dto;
using TestWebApp.Infrastructure.Persistence;

namespace TestWebApp.Application.Queries;

public partial record GetTestEntityOneOrManyByIdQuery(System.String keyId) : IRequest <IQueryable<TestEntityOneOrManyDto>>;

internal partial class GetTestEntityOneOrManyByIdQueryHandler:GetTestEntityOneOrManyByIdQueryHandlerBase
{
    public GetTestEntityOneOrManyByIdQueryHandler(IReadOnlyRepository readOnlyRepository): base(readOnlyRepository){}
}

internal abstract class GetTestEntityOneOrManyByIdQueryHandlerBase:  QueryBase<IQueryable<TestEntityOneOrManyDto>>, IRequestHandler<GetTestEntityOneOrManyByIdQuery, IQueryable<TestEntityOneOrManyDto>>
{
    public  GetTestEntityOneOrManyByIdQueryHandlerBase(IReadOnlyRepository readOnlyRepository)
    {
        ReadOnlyRepository = readOnlyRepository;
    }

    public IReadOnlyRepository ReadOnlyRepository { get; }

    public virtual Task<IQueryable<TestEntityOneOrManyDto>> Handle(GetTestEntityOneOrManyByIdQuery request, CancellationToken cancellationToken)
    {    
        var query = ReadOnlyRepository.Query<TestEntityOneOrManyDto >()
            .Where(r =>
                r.Id.Equals(request.keyId));
        return Task.FromResult(OnResponse(query));
    }
}