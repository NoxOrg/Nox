// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Queries;
using Nox.Application.Repositories;

using TestWebApp.Application.Dto;
using TestWebApp.Infrastructure.Persistence;

namespace TestWebApp.Application.Queries;

public partial record GetSecondTestEntityZeroOrManyByIdQuery(System.String keyId) : IRequest <IQueryable<SecondTestEntityZeroOrManyDto>>;

internal partial class GetSecondTestEntityZeroOrManyByIdQueryHandler:GetSecondTestEntityZeroOrManyByIdQueryHandlerBase
{
    public GetSecondTestEntityZeroOrManyByIdQueryHandler(IReadOnlyRepository readOnlyRepository): base(readOnlyRepository){}
}

internal abstract class GetSecondTestEntityZeroOrManyByIdQueryHandlerBase:  QueryBase<IQueryable<SecondTestEntityZeroOrManyDto>>, IRequestHandler<GetSecondTestEntityZeroOrManyByIdQuery, IQueryable<SecondTestEntityZeroOrManyDto>>
{
    public  GetSecondTestEntityZeroOrManyByIdQueryHandlerBase(IReadOnlyRepository readOnlyRepository)
    {
        ReadOnlyRepository = readOnlyRepository;
    }

    public IReadOnlyRepository ReadOnlyRepository { get; }

    public virtual Task<IQueryable<SecondTestEntityZeroOrManyDto>> Handle(GetSecondTestEntityZeroOrManyByIdQuery request, CancellationToken cancellationToken)
    {    
        var query = ReadOnlyRepository.Query<SecondTestEntityZeroOrManyDto>()
            .Where(r =>
                r.Id.Equals(request.keyId));
        return Task.FromResult(OnResponse(query));
    }
}