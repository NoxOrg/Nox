// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Queries;
using Nox.Application.Repositories;

using TestWebApp.Application.Dto;
using TestWebApp.Infrastructure.Persistence;

namespace TestWebApp.Application.Queries;

public partial record GetTestEntityZeroOrOneByIdQuery(System.String keyId) : IRequest <IQueryable<TestEntityZeroOrOneDto>>;

internal partial class GetTestEntityZeroOrOneByIdQueryHandler:GetTestEntityZeroOrOneByIdQueryHandlerBase
{
    public GetTestEntityZeroOrOneByIdQueryHandler(IReadOnlyRepository readOnlyRepository): base(readOnlyRepository){}
}

internal abstract class GetTestEntityZeroOrOneByIdQueryHandlerBase:  QueryBase<IQueryable<TestEntityZeroOrOneDto>>, IRequestHandler<GetTestEntityZeroOrOneByIdQuery, IQueryable<TestEntityZeroOrOneDto>>
{
    public  GetTestEntityZeroOrOneByIdQueryHandlerBase(IReadOnlyRepository readOnlyRepository)
    {
        ReadOnlyRepository = readOnlyRepository;
    }

    public IReadOnlyRepository ReadOnlyRepository { get; }

    public virtual Task<IQueryable<TestEntityZeroOrOneDto>> Handle(GetTestEntityZeroOrOneByIdQuery request, CancellationToken cancellationToken)
    {    
        var query = ReadOnlyRepository.Query<TestEntityZeroOrOneDto>()
            .Where(r =>
                r.Id.Equals(request.keyId));
        return Task.FromResult(OnResponse(query));
    }
}