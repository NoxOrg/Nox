﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Nox.Application.Factories;
using Cryptocash.Infrastructure.Persistence;
using Cryptocash.Domain;
using Cryptocash.Application.Dto;
using EmployeePhoneNumberEntity = Cryptocash.Domain.EmployeePhoneNumber;

namespace Cryptocash.Application.Commands;
public partial record DeleteEmployeePhoneNumberForEmployeeCommand(EmployeeKeyDto ParentKeyDto, EmployeePhoneNumberKeyDto EntityKeyDto) : IRequest <bool>;

internal partial class DeleteEmployeePhoneNumberForEmployeeCommandHandler : DeleteEmployeePhoneNumberForEmployeeCommandHandlerBase
{
	public DeleteEmployeePhoneNumberForEmployeeCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution)
		: base(dbContext, noxSolution)
	{
	}
}

internal partial class DeleteEmployeePhoneNumberForEmployeeCommandHandlerBase : CommandBase<DeleteEmployeePhoneNumberForEmployeeCommand, EmployeePhoneNumberEntity>, IRequestHandler <DeleteEmployeePhoneNumberForEmployeeCommand, bool>
{
	public AppDbContext DbContext { get; }

	public DeleteEmployeePhoneNumberForEmployeeCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(noxSolution)
	{
		DbContext = dbContext;
	}

	public virtual async Task<bool> Handle(DeleteEmployeePhoneNumberForEmployeeCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = Cryptocash.Domain.EmployeeMetadata.CreateId(request.ParentKeyDto.keyId);
		var parentEntity = await DbContext.Employees.FindAsync(keyId);
		if (parentEntity == null)
		{
			return false;
		}
		var ownedId = Cryptocash.Domain.EmployeePhoneNumberMetadata.CreateId(request.EntityKeyDto.keyId);
		var entity = parentEntity.EmployeeContactPhoneNumbers.SingleOrDefault(x => x.Id == ownedId);
		if (entity == null)
		{
			return false;
		}
		parentEntity.EmployeeContactPhoneNumbers.Remove(entity);
		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Deleted;

		var result = await DbContext.SaveChangesAsync(cancellationToken);
		if (result < 1)
		{
			return false;
		}

		return true;
	}
}