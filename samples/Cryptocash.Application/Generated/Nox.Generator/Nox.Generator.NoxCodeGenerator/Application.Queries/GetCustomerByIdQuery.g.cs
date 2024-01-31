// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Queries;
using Nox.Application.Repositories;

using Cryptocash.Application.Dto;

namespace Cryptocash.Application.Queries;

public partial record GetCustomerByIdQuery(System.Guid keyId) : IRequest <IQueryable<CustomerDto>>;

internal partial class GetCustomerByIdQueryHandler:GetCustomerByIdQueryHandlerBase
{
    public GetCustomerByIdQueryHandler(IReadOnlyRepository readOnlyRepository): base(readOnlyRepository){}
}

internal abstract class GetCustomerByIdQueryHandlerBase:  QueryBase<IQueryable<CustomerDto>>, IRequestHandler<GetCustomerByIdQuery, IQueryable<CustomerDto>>
{
    public  GetCustomerByIdQueryHandlerBase(IReadOnlyRepository readOnlyRepository)
    {
        ReadOnlyRepository = readOnlyRepository;
    }

    public IReadOnlyRepository ReadOnlyRepository { get; }

    public virtual Task<IQueryable<CustomerDto>> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
    {    
        var query = ReadOnlyRepository.Query<CustomerDto>()
            .Where(r =>
                r.Id.Equals(request.keyId));
        return Task.FromResult(OnResponse(query));
    }
}