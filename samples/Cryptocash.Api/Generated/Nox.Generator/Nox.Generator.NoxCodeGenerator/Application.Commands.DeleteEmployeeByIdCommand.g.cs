// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Cryptocash.Infrastructure.Persistence;
using Cryptocash.Domain;
using Employee = Cryptocash.Domain.Employee;

namespace Cryptocash.Application.Commands;

public record DeleteEmployeeByIdCommand(System.Int64 keyId) : IRequest<bool>;

public class DeleteEmployeeByIdCommandHandler: CommandBase<DeleteEmployeeByIdCommand,Employee>, IRequestHandler<DeleteEmployeeByIdCommand, bool>
{
	public CryptocashDbContext DbContext { get; }

	public DeleteEmployeeByIdCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
	}

	public async Task<bool> Handle(DeleteEmployeeByIdCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = CreateNoxTypeForKey<Employee,Nox.Types.AutoNumber>("Id", request.keyId);

		var entity = await DbContext.Employees.FindAsync(keyId);
		if (entity == null || entity.IsDeleted.Value == true)
		{
			return false;
		}

		OnCompleted(request, entity);
		DbContext.Entry(entity).State = EntityState.Deleted;
		await DbContext.SaveChangesAsync(cancellationToken);
		return true;
	}
}