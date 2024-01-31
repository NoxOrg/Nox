// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Queries;
using Nox.Application.Repositories;

using TestWebApp.Application.Dto;

namespace TestWebApp.Application.Queries;

public partial record GetTestEntityZeroOrOneToOneOrManyByIdQuery(System.String keyId) : IRequest <IQueryable<TestEntityZeroOrOneToOneOrManyDto>>;

internal partial class GetTestEntityZeroOrOneToOneOrManyByIdQueryHandler:GetTestEntityZeroOrOneToOneOrManyByIdQueryHandlerBase
{
    public GetTestEntityZeroOrOneToOneOrManyByIdQueryHandler(IReadOnlyRepository readOnlyRepository): base(readOnlyRepository){}
}

internal abstract class GetTestEntityZeroOrOneToOneOrManyByIdQueryHandlerBase:  QueryBase<IQueryable<TestEntityZeroOrOneToOneOrManyDto>>, IRequestHandler<GetTestEntityZeroOrOneToOneOrManyByIdQuery, IQueryable<TestEntityZeroOrOneToOneOrManyDto>>
{
    public  GetTestEntityZeroOrOneToOneOrManyByIdQueryHandlerBase(IReadOnlyRepository readOnlyRepository)
    {
        ReadOnlyRepository = readOnlyRepository;
    }

    public IReadOnlyRepository ReadOnlyRepository { get; }

    public virtual Task<IQueryable<TestEntityZeroOrOneToOneOrManyDto>> Handle(GetTestEntityZeroOrOneToOneOrManyByIdQuery request, CancellationToken cancellationToken)
    {    
        var query = ReadOnlyRepository.Query<TestEntityZeroOrOneToOneOrManyDto>()
            .Where(r =>
                r.Id.Equals(request.keyId));
        return Task.FromResult(OnResponse(query));
    }
}