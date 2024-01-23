// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Queries;
using Nox.Application.Repositories;

using Cryptocash.Application.Dto;
using Cryptocash.Infrastructure.Persistence;

namespace Cryptocash.Application.Queries;

public partial record GetEmployeeByIdQuery(System.Guid keyId) : IRequest <IQueryable<EmployeeDto>>;

internal partial class GetEmployeeByIdQueryHandler:GetEmployeeByIdQueryHandlerBase
{
    public GetEmployeeByIdQueryHandler(IReadOnlyRepository readOnlyRepository): base(readOnlyRepository){}
}

internal abstract class GetEmployeeByIdQueryHandlerBase:  QueryBase<IQueryable<EmployeeDto>>, IRequestHandler<GetEmployeeByIdQuery, IQueryable<EmployeeDto>>
{
    public  GetEmployeeByIdQueryHandlerBase(IReadOnlyRepository readOnlyRepository)
    {
        ReadOnlyRepository = readOnlyRepository;
    }

    public IReadOnlyRepository ReadOnlyRepository { get; }

    public virtual Task<IQueryable<EmployeeDto>> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
    {    
        var query = ReadOnlyRepository.Query<EmployeeDto>()
            .Include(e => e.EmployeePhoneNumbers)
            .Where(r =>
                r.Id.Equals(request.keyId));
        return Task.FromResult(OnResponse(query));
    }
}