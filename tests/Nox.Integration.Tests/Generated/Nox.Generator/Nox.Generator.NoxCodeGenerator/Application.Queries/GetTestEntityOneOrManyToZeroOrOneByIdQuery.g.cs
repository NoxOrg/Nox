// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Queries;
using Nox.Application.Repositories;

using TestWebApp.Application.Dto;

namespace TestWebApp.Application.Queries;

public partial record GetTestEntityOneOrManyToZeroOrOneByIdQuery(System.String keyId) : IRequest <IQueryable<TestEntityOneOrManyToZeroOrOneDto>>;

internal partial class GetTestEntityOneOrManyToZeroOrOneByIdQueryHandler:GetTestEntityOneOrManyToZeroOrOneByIdQueryHandlerBase
{
    public GetTestEntityOneOrManyToZeroOrOneByIdQueryHandler(IReadOnlyRepository readOnlyRepository): base(readOnlyRepository){}
}

internal abstract class GetTestEntityOneOrManyToZeroOrOneByIdQueryHandlerBase:  QueryBase<IQueryable<TestEntityOneOrManyToZeroOrOneDto>>, IRequestHandler<GetTestEntityOneOrManyToZeroOrOneByIdQuery, IQueryable<TestEntityOneOrManyToZeroOrOneDto>>
{
    public  GetTestEntityOneOrManyToZeroOrOneByIdQueryHandlerBase(IReadOnlyRepository readOnlyRepository)
    {
        ReadOnlyRepository = readOnlyRepository;
    }

    public IReadOnlyRepository ReadOnlyRepository { get; }

    public virtual Task<IQueryable<TestEntityOneOrManyToZeroOrOneDto>> Handle(GetTestEntityOneOrManyToZeroOrOneByIdQuery request, CancellationToken cancellationToken)
    {    
        var query = ReadOnlyRepository.Query<TestEntityOneOrManyToZeroOrOneDto>()
            .Where(r =>
                r.Id.Equals(request.keyId));
        return Task.FromResult(OnResponse(query));
    }
}