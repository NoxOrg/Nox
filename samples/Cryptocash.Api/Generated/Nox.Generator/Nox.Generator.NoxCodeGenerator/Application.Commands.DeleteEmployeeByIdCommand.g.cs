﻿// Generated

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

public record DeleteEmployeeByIdCommand(System.Int64 keyId, System.Guid? Etag) : IRequest<bool>;

public class DeleteEmployeeByIdCommandHandler:DeleteEmployeeByIdCommandHandlerBase
{
	public DeleteEmployeeByIdCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider): base(dbContext, noxSolution, serviceProvider)
	{
	}
}
public abstract class DeleteEmployeeByIdCommandHandlerBase: CommandBase<DeleteEmployeeByIdCommand,Employee>, IRequestHandler<DeleteEmployeeByIdCommand, bool>
{
	public CryptocashDbContext DbContext { get; }

	public DeleteEmployeeByIdCommandHandlerBase(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
	}

	public virtual async Task<bool> Handle(DeleteEmployeeByIdCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = CreateNoxTypeForKey<Employee,Nox.Types.AutoNumber>("Id", request.keyId);

		var entity = await DbContext.Employees.FindAsync(keyId);
		if (entity == null || entity.IsDeleted == true)
		{
			return false;
		}

		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

		OnCompleted(request, entity);
		DbContext.Entry(entity).State = EntityState.Deleted;
		await DbContext.SaveChangesAsync(cancellationToken);
		return true;
	}
}