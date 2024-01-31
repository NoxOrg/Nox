// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Queries;
using Nox.Application.Repositories;
using Cryptocash.Application.Dto;

namespace Cryptocash.Application.Queries;

public partial record GetEmployeesQuery() : IRequest<IQueryable<EmployeeDto>>;

internal partial class GetEmployeesQueryHandler: GetEmployeesQueryHandlerBase
{
    public GetEmployeesQueryHandler(IReadOnlyRepository readOnlyRepository): base(readOnlyRepository){}
}

internal abstract class GetEmployeesQueryHandlerBase : QueryBase<IQueryable<EmployeeDto>>, IRequestHandler<GetEmployeesQuery, IQueryable<EmployeeDto>>
{
    public  GetEmployeesQueryHandlerBase(IReadOnlyRepository readOnlyRepository)
    {
        ReadOnlyRepository = readOnlyRepository;
    }

    public IReadOnlyRepository ReadOnlyRepository { get; }

    public virtual Task<IQueryable<EmployeeDto>> Handle(GetEmployeesQuery request, CancellationToken cancellationToken)
    {
        var query = ReadOnlyRepository.Query<EmployeeDto>()
            .Include(e => e.EmployeePhoneNumbers);
       return Task.FromResult(OnResponse(query));
    }
}