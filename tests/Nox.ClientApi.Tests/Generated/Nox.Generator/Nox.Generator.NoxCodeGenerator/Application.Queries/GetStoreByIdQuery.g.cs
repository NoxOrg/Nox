// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Queries;
using Nox.Application.Repositories;

using ClientApi.Application.Dto;
using ClientApi.Infrastructure.Persistence;

namespace ClientApi.Application.Queries;

public partial record GetStoreByIdQuery(System.Guid keyId) : IRequest <IQueryable<StoreDto>>;

internal partial class GetStoreByIdQueryHandler:GetStoreByIdQueryHandlerBase
{
    public GetStoreByIdQueryHandler(IReadOnlyRepository readOnlyRepository): base(readOnlyRepository){}
}

internal abstract class GetStoreByIdQueryHandlerBase:  QueryBase<IQueryable<StoreDto>>, IRequestHandler<GetStoreByIdQuery, IQueryable<StoreDto>>
{
    public  GetStoreByIdQueryHandlerBase(IReadOnlyRepository readOnlyRepository)
    {
        ReadOnlyRepository = readOnlyRepository;
    }

    public IReadOnlyRepository ReadOnlyRepository { get; }

    public virtual Task<IQueryable<StoreDto>> Handle(GetStoreByIdQuery request, CancellationToken cancellationToken)
    {    
        var query = ReadOnlyRepository.Query<StoreDto>()
            .Include(e => e.EmailAddress)
            .Where(r =>
                r.Id.Equals(request.keyId));
        return Task.FromResult(OnResponse(query));
    }
}