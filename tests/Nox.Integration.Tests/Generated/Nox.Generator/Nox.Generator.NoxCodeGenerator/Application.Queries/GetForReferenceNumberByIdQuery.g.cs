// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Queries;
using Nox.Application.Repositories;

using TestWebApp.Application.Dto;
using TestWebApp.Infrastructure.Persistence;

namespace TestWebApp.Application.Queries;

public partial record GetForReferenceNumberByIdQuery(System.String keyId) : IRequest <IQueryable<ForReferenceNumberDto>>;

internal partial class GetForReferenceNumberByIdQueryHandler:GetForReferenceNumberByIdQueryHandlerBase
{
    public GetForReferenceNumberByIdQueryHandler(IReadOnlyRepository readOnlyRepository): base(readOnlyRepository){}
}

internal abstract class GetForReferenceNumberByIdQueryHandlerBase:  QueryBase<IQueryable<ForReferenceNumberDto>>, IRequestHandler<GetForReferenceNumberByIdQuery, IQueryable<ForReferenceNumberDto>>
{
    public  GetForReferenceNumberByIdQueryHandlerBase(IReadOnlyRepository readOnlyRepository)
    {
        ReadOnlyRepository = readOnlyRepository;
    }

    public IReadOnlyRepository ReadOnlyRepository { get; }

    public virtual Task<IQueryable<ForReferenceNumberDto>> Handle(GetForReferenceNumberByIdQuery request, CancellationToken cancellationToken)
    {    
        var query = ReadOnlyRepository.Query<ForReferenceNumberDto>()
            .Where(r =>
                r.Id.Equals(request.keyId));
        return Task.FromResult(OnResponse(query));
    }
}