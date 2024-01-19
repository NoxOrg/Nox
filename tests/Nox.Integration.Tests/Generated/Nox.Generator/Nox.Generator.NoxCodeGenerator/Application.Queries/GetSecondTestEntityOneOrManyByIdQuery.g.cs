// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Queries;
using Nox.Application.Repositories;

using TestWebApp.Application.Dto;
using TestWebApp.Infrastructure.Persistence;

namespace TestWebApp.Application.Queries;

public partial record GetSecondTestEntityOneOrManyByIdQuery(System.String keyId) : IRequest <IQueryable<SecondTestEntityOneOrManyDto>>;

internal partial class GetSecondTestEntityOneOrManyByIdQueryHandler:GetSecondTestEntityOneOrManyByIdQueryHandlerBase
{
    public GetSecondTestEntityOneOrManyByIdQueryHandler(IReadOnlyRepository readOnlyRepository): base(readOnlyRepository){}
}

internal abstract class GetSecondTestEntityOneOrManyByIdQueryHandlerBase:  QueryBase<IQueryable<SecondTestEntityOneOrManyDto>>, IRequestHandler<GetSecondTestEntityOneOrManyByIdQuery, IQueryable<SecondTestEntityOneOrManyDto>>
{
    public  GetSecondTestEntityOneOrManyByIdQueryHandlerBase(IReadOnlyRepository readOnlyRepository)
    {
        ReadOnlyRepository = readOnlyRepository;
    }

    public IReadOnlyRepository ReadOnlyRepository { get; }

    public virtual Task<IQueryable<SecondTestEntityOneOrManyDto>> Handle(GetSecondTestEntityOneOrManyByIdQuery request, CancellationToken cancellationToken)
    {    
        var query = ReadOnlyRepository.Query<SecondTestEntityOneOrManyDto>()
            .Where(r =>
                r.Id.Equals(request.keyId));
        return Task.FromResult(OnResponse(query));
    }
}