// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Queries;
using Nox.Application.Repositories;

using TestWebApp.Application.Dto;
using TestWebApp.Infrastructure.Persistence;

namespace TestWebApp.Application.Queries;

public partial record GetTestEntityZeroOrManyByIdQuery(System.String keyId) : IRequest <IQueryable<TestEntityZeroOrManyDto>>;

internal partial class GetTestEntityZeroOrManyByIdQueryHandler:GetTestEntityZeroOrManyByIdQueryHandlerBase
{
    public GetTestEntityZeroOrManyByIdQueryHandler(IReadOnlyRepository readOnlyRepository): base(readOnlyRepository){}
}

internal abstract class GetTestEntityZeroOrManyByIdQueryHandlerBase:  QueryBase<IQueryable<TestEntityZeroOrManyDto>>, IRequestHandler<GetTestEntityZeroOrManyByIdQuery, IQueryable<TestEntityZeroOrManyDto>>
{
    public  GetTestEntityZeroOrManyByIdQueryHandlerBase(IReadOnlyRepository readOnlyRepository)
    {
        ReadOnlyRepository = readOnlyRepository;
    }

    public IReadOnlyRepository ReadOnlyRepository { get; }

    public virtual Task<IQueryable<TestEntityZeroOrManyDto>> Handle(GetTestEntityZeroOrManyByIdQuery request, CancellationToken cancellationToken)
    {    
        var query = ReadOnlyRepository.Query<TestEntityZeroOrManyDto>()
            .Where(r =>
                r.Id.Equals(request.keyId));
        return Task.FromResult(OnResponse(query));
    }
}