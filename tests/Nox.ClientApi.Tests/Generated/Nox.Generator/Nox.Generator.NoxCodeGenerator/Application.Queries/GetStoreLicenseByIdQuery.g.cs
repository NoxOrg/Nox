// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Queries;
using Nox.Application.Repositories;

using ClientApi.Application.Dto;
using ClientApi.Infrastructure.Persistence;

namespace ClientApi.Application.Queries;

public partial record GetStoreLicenseByIdQuery(System.Int64 keyId) : IRequest <IQueryable<StoreLicenseDto>>;

internal partial class GetStoreLicenseByIdQueryHandler:GetStoreLicenseByIdQueryHandlerBase
{
    public GetStoreLicenseByIdQueryHandler(IReadOnlyRepository readOnlyRepository): base(readOnlyRepository){}
}

internal abstract class GetStoreLicenseByIdQueryHandlerBase:  QueryBase<IQueryable<StoreLicenseDto>>, IRequestHandler<GetStoreLicenseByIdQuery, IQueryable<StoreLicenseDto>>
{
    public  GetStoreLicenseByIdQueryHandlerBase(IReadOnlyRepository readOnlyRepository)
    {
        ReadOnlyRepository = readOnlyRepository;
    }

    public IReadOnlyRepository ReadOnlyRepository { get; }

    public virtual Task<IQueryable<StoreLicenseDto>> Handle(GetStoreLicenseByIdQuery request, CancellationToken cancellationToken)
    {    
        var query = ReadOnlyRepository.Query<StoreLicenseDto>()
            .Where(r =>
                r.Id.Equals(request.keyId));
        return Task.FromResult(OnResponse(query));
    }
}