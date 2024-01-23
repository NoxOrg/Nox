// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Queries;
using Nox.Application.Repositories;
using Cryptocash.Application.Dto;
using Cryptocash.Infrastructure.Persistence;

namespace Cryptocash.Application.Queries;

public partial record GetCustomersQuery() : IRequest<IQueryable<CustomerDto>>;

internal partial class GetCustomersQueryHandler: GetCustomersQueryHandlerBase
{
    public GetCustomersQueryHandler(IReadOnlyRepository readOnlyRepository): base(readOnlyRepository){}
}

internal abstract class GetCustomersQueryHandlerBase : QueryBase<IQueryable<CustomerDto>>, IRequestHandler<GetCustomersQuery, IQueryable<CustomerDto>>
{
    public  GetCustomersQueryHandlerBase(IReadOnlyRepository readOnlyRepository)
    {
        ReadOnlyRepository = readOnlyRepository;
    }

    public IReadOnlyRepository ReadOnlyRepository { get; }

    public virtual Task<IQueryable<CustomerDto>> Handle(GetCustomersQuery request, CancellationToken cancellationToken)
    {
        var query = ReadOnlyRepository.Query<CustomerDto>();
       return Task.FromResult(OnResponse(query));
    }
}