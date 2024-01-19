// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Queries;
using Nox.Application.Repositories;

using TestWebApp.Application.Dto;
using TestWebApp.Infrastructure.Persistence;

namespace TestWebApp.Application.Queries;

public partial record GetTestEntityZeroOrOneToExactlyOneByIdQuery(System.String keyId) : IRequest <IQueryable<TestEntityZeroOrOneToExactlyOneDto>>;

internal partial class GetTestEntityZeroOrOneToExactlyOneByIdQueryHandler:GetTestEntityZeroOrOneToExactlyOneByIdQueryHandlerBase
{
    public GetTestEntityZeroOrOneToExactlyOneByIdQueryHandler(IReadOnlyRepository readOnlyRepository): base(readOnlyRepository){}
}

internal abstract class GetTestEntityZeroOrOneToExactlyOneByIdQueryHandlerBase:  QueryBase<IQueryable<TestEntityZeroOrOneToExactlyOneDto>>, IRequestHandler<GetTestEntityZeroOrOneToExactlyOneByIdQuery, IQueryable<TestEntityZeroOrOneToExactlyOneDto>>
{
    public  GetTestEntityZeroOrOneToExactlyOneByIdQueryHandlerBase(IReadOnlyRepository readOnlyRepository)
    {
        ReadOnlyRepository = readOnlyRepository;
    }

    public IReadOnlyRepository ReadOnlyRepository { get; }

    public virtual Task<IQueryable<TestEntityZeroOrOneToExactlyOneDto>> Handle(GetTestEntityZeroOrOneToExactlyOneByIdQuery request, CancellationToken cancellationToken)
    {    
        var query = ReadOnlyRepository.Query<TestEntityZeroOrOneToExactlyOneDto>()
            .Where(r =>
                r.Id.Equals(request.keyId));
        return Task.FromResult(OnResponse(query));
    }
}