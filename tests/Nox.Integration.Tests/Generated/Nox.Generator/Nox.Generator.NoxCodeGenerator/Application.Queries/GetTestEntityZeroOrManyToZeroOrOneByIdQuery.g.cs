// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Queries;
using Nox.Application.Repositories;

using TestWebApp.Application.Dto;
using TestWebApp.Infrastructure.Persistence;

namespace TestWebApp.Application.Queries;

public partial record GetTestEntityZeroOrManyToZeroOrOneByIdQuery(System.String keyId) : IRequest <IQueryable<TestEntityZeroOrManyToZeroOrOneDto>>;

internal partial class GetTestEntityZeroOrManyToZeroOrOneByIdQueryHandler:GetTestEntityZeroOrManyToZeroOrOneByIdQueryHandlerBase
{
    public GetTestEntityZeroOrManyToZeroOrOneByIdQueryHandler(IReadOnlyRepository readOnlyRepository): base(readOnlyRepository){}
}

internal abstract class GetTestEntityZeroOrManyToZeroOrOneByIdQueryHandlerBase:  QueryBase<IQueryable<TestEntityZeroOrManyToZeroOrOneDto>>, IRequestHandler<GetTestEntityZeroOrManyToZeroOrOneByIdQuery, IQueryable<TestEntityZeroOrManyToZeroOrOneDto>>
{
    public  GetTestEntityZeroOrManyToZeroOrOneByIdQueryHandlerBase(IReadOnlyRepository readOnlyRepository)
    {
        ReadOnlyRepository = readOnlyRepository;
    }

    public IReadOnlyRepository ReadOnlyRepository { get; }

    public virtual Task<IQueryable<TestEntityZeroOrManyToZeroOrOneDto>> Handle(GetTestEntityZeroOrManyToZeroOrOneByIdQuery request, CancellationToken cancellationToken)
    {    
        var query = ReadOnlyRepository.Query<TestEntityZeroOrManyToZeroOrOneDto >()
            .Where(r =>
                r.Id.Equals(request.keyId));
        return Task.FromResult(OnResponse(query));
    }
}