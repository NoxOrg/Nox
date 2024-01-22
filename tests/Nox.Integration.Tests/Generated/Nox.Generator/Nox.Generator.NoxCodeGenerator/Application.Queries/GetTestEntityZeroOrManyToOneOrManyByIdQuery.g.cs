// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Queries;
using Nox.Application.Repositories;

using TestWebApp.Application.Dto;
using TestWebApp.Infrastructure.Persistence;

namespace TestWebApp.Application.Queries;

public partial record GetTestEntityZeroOrManyToOneOrManyByIdQuery(System.String keyId) : IRequest <IQueryable<TestEntityZeroOrManyToOneOrManyDto>>;

internal partial class GetTestEntityZeroOrManyToOneOrManyByIdQueryHandler:GetTestEntityZeroOrManyToOneOrManyByIdQueryHandlerBase
{
    public GetTestEntityZeroOrManyToOneOrManyByIdQueryHandler(IReadOnlyRepository readOnlyRepository): base(readOnlyRepository){}
}

internal abstract class GetTestEntityZeroOrManyToOneOrManyByIdQueryHandlerBase:  QueryBase<IQueryable<TestEntityZeroOrManyToOneOrManyDto>>, IRequestHandler<GetTestEntityZeroOrManyToOneOrManyByIdQuery, IQueryable<TestEntityZeroOrManyToOneOrManyDto>>
{
    public  GetTestEntityZeroOrManyToOneOrManyByIdQueryHandlerBase(IReadOnlyRepository readOnlyRepository)
    {
        ReadOnlyRepository = readOnlyRepository;
    }

    public IReadOnlyRepository ReadOnlyRepository { get; }

    public virtual Task<IQueryable<TestEntityZeroOrManyToOneOrManyDto>> Handle(GetTestEntityZeroOrManyToOneOrManyByIdQuery request, CancellationToken cancellationToken)
    {    
        var query = ReadOnlyRepository.Query<TestEntityZeroOrManyToOneOrManyDto>()
            .Where(r =>
                r.Id.Equals(request.keyId));
        return Task.FromResult(OnResponse(query));
    }
}