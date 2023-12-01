// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Cryptocash.Infrastructure.Persistence;
using Cryptocash.Domain;
using Cryptocash.Application.Dto;
using EmployeeEntity = Cryptocash.Domain.Employee;

namespace Cryptocash.Application.Commands;

public partial record DeleteEmployeeByIdCommand(IEnumerable<EmployeeKeyDto> KeyDtos, System.Guid? Etag) : IRequest<bool>;

internal class DeleteEmployeeByIdCommandHandler : DeleteEmployeeByIdCommandHandlerBase
{
	public DeleteEmployeeByIdCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(dbContext, noxSolution)
	{
	}
}
internal abstract class DeleteEmployeeByIdCommandHandlerBase : CommandBase<DeleteEmployeeByIdCommand, EmployeeEntity>, IRequestHandler<DeleteEmployeeByIdCommand, bool>
{
	public AppDbContext DbContext { get; }

	public DeleteEmployeeByIdCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(noxSolution)
	{
		DbContext = dbContext;
	}

	public virtual async Task<bool> Handle(DeleteEmployeeByIdCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		
		foreach(var keyDto in request.KeyDtos)
		{
			var keyId = Cryptocash.Domain.EmployeeMetadata.CreateId(keyDto.keyId);		

			var entity = await DbContext.Employees.FindAsync(keyId);
			if (entity == null || entity.IsDeleted == true)
			{
				return false;
			}

			entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;
			DbContext.Entry(entity).State = EntityState.Deleted;
		}

		await OnCompletedAsync(request, new EmployeeEntity());

		await DbContext.SaveChangesAsync(cancellationToken);
		return true;
	}
}