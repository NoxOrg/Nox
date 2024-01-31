// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Queries;
using Nox.Application.Repositories;

using TestWebApp.Application.Dto;

namespace TestWebApp.Application.Queries;

public partial record GetTestEntityZeroOrOneToZeroOrManyByIdQuery(System.String keyId) : IRequest <IQueryable<TestEntityZeroOrOneToZeroOrManyDto>>;

internal partial class GetTestEntityZeroOrOneToZeroOrManyByIdQueryHandler:GetTestEntityZeroOrOneToZeroOrManyByIdQueryHandlerBase
{
    public GetTestEntityZeroOrOneToZeroOrManyByIdQueryHandler(IReadOnlyRepository readOnlyRepository): base(readOnlyRepository){}
}

internal abstract class GetTestEntityZeroOrOneToZeroOrManyByIdQueryHandlerBase:  QueryBase<IQueryable<TestEntityZeroOrOneToZeroOrManyDto>>, IRequestHandler<GetTestEntityZeroOrOneToZeroOrManyByIdQuery, IQueryable<TestEntityZeroOrOneToZeroOrManyDto>>
{
    public  GetTestEntityZeroOrOneToZeroOrManyByIdQueryHandlerBase(IReadOnlyRepository readOnlyRepository)
    {
        ReadOnlyRepository = readOnlyRepository;
    }

    public IReadOnlyRepository ReadOnlyRepository { get; }

    public virtual Task<IQueryable<TestEntityZeroOrOneToZeroOrManyDto>> Handle(GetTestEntityZeroOrOneToZeroOrManyByIdQuery request, CancellationToken cancellationToken)
    {    
        var query = ReadOnlyRepository.Query<TestEntityZeroOrOneToZeroOrManyDto>()
            .Where(r =>
                r.Id.Equals(request.keyId));
        return Task.FromResult(OnResponse(query));
    }
}