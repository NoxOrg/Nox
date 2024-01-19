// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Queries;
using Nox.Application.Repositories;

using ClientApi.Application.Dto;
using ClientApi.Infrastructure.Persistence;

namespace ClientApi.Application.Queries;

public partial record GetStoreOwnerByIdQuery(System.String keyId) : IRequest <IQueryable<StoreOwnerDto>>;

internal partial class GetStoreOwnerByIdQueryHandler:GetStoreOwnerByIdQueryHandlerBase
{
    public GetStoreOwnerByIdQueryHandler(IReadOnlyRepository readOnlyRepository): base(readOnlyRepository){}
}

internal abstract class GetStoreOwnerByIdQueryHandlerBase:  QueryBase<IQueryable<StoreOwnerDto>>, IRequestHandler<GetStoreOwnerByIdQuery, IQueryable<StoreOwnerDto>>
{
    public  GetStoreOwnerByIdQueryHandlerBase(IReadOnlyRepository readOnlyRepository)
    {
        ReadOnlyRepository = readOnlyRepository;
    }

    public IReadOnlyRepository ReadOnlyRepository { get; }

    public virtual Task<IQueryable<StoreOwnerDto>> Handle(GetStoreOwnerByIdQuery request, CancellationToken cancellationToken)
    {    
        var query = ReadOnlyRepository.Query<StoreOwnerDto >()
            .Where(r =>
                r.Id.Equals(request.keyId));
        return Task.FromResult(OnResponse(query));
    }
}