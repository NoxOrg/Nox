// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Queries;
using Nox.Application.Repositories;
using ClientApi.Application.Dto;

namespace ClientApi.Application.Queries;

public partial record GetStoreLicensesQuery() : IRequest<IQueryable<StoreLicenseDto>>;

internal partial class GetStoreLicensesQueryHandler: GetStoreLicensesQueryHandlerBase
{
    public GetStoreLicensesQueryHandler(IReadOnlyRepository readOnlyRepository): base(readOnlyRepository){}
}

internal abstract class GetStoreLicensesQueryHandlerBase : QueryBase<IQueryable<StoreLicenseDto>>, IRequestHandler<GetStoreLicensesQuery, IQueryable<StoreLicenseDto>>
{
    public  GetStoreLicensesQueryHandlerBase(IReadOnlyRepository readOnlyRepository)
    {
        ReadOnlyRepository = readOnlyRepository;
    }

    public IReadOnlyRepository ReadOnlyRepository { get; }

    public virtual Task<IQueryable<StoreLicenseDto>> Handle(GetStoreLicensesQuery request, CancellationToken cancellationToken)
    {
        var query = ReadOnlyRepository.Query<StoreLicenseDto>();
       return Task.FromResult(OnResponse(query));
    }
}