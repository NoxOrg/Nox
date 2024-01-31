// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Queries;
using Nox.Application.Repositories;

using TestWebApp.Application.Dto;

namespace TestWebApp.Application.Queries;

public partial record GetTestEntityOneOrManyToZeroOrManyByIdQuery(System.String keyId) : IRequest <IQueryable<TestEntityOneOrManyToZeroOrManyDto>>;

internal partial class GetTestEntityOneOrManyToZeroOrManyByIdQueryHandler:GetTestEntityOneOrManyToZeroOrManyByIdQueryHandlerBase
{
    public GetTestEntityOneOrManyToZeroOrManyByIdQueryHandler(IReadOnlyRepository readOnlyRepository): base(readOnlyRepository){}
}

internal abstract class GetTestEntityOneOrManyToZeroOrManyByIdQueryHandlerBase:  QueryBase<IQueryable<TestEntityOneOrManyToZeroOrManyDto>>, IRequestHandler<GetTestEntityOneOrManyToZeroOrManyByIdQuery, IQueryable<TestEntityOneOrManyToZeroOrManyDto>>
{
    public  GetTestEntityOneOrManyToZeroOrManyByIdQueryHandlerBase(IReadOnlyRepository readOnlyRepository)
    {
        ReadOnlyRepository = readOnlyRepository;
    }

    public IReadOnlyRepository ReadOnlyRepository { get; }

    public virtual Task<IQueryable<TestEntityOneOrManyToZeroOrManyDto>> Handle(GetTestEntityOneOrManyToZeroOrManyByIdQuery request, CancellationToken cancellationToken)
    {    
        var query = ReadOnlyRepository.Query<TestEntityOneOrManyToZeroOrManyDto>()
            .Where(r =>
                r.Id.Equals(request.keyId));
        return Task.FromResult(OnResponse(query));
    }
}