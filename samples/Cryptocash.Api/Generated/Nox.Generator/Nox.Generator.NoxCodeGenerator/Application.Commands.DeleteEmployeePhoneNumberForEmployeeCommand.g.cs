﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Nox.Factories;
using Cryptocash.Infrastructure.Persistence;
using Cryptocash.Domain;
using Cryptocash.Application.Dto;

namespace Cryptocash.Application.Commands;
public record DeleteEmployeePhoneNumberForEmployeeCommand(EmployeeKeyDto ParentKeyDto, EmployeePhoneNumberKeyDto EntityKeyDto) : IRequest <bool>;

public partial class DeleteEmployeePhoneNumberForEmployeeCommandHandler: CommandBase<DeleteEmployeePhoneNumberForEmployeeCommand, EmployeePhoneNumber>, IRequestHandler <DeleteEmployeePhoneNumberForEmployeeCommand, bool>
{
	public CryptocashDbContext DbContext { get; }

	public DeleteEmployeePhoneNumberForEmployeeCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
	}

	public async Task<bool> Handle(DeleteEmployeePhoneNumberForEmployeeCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = CreateNoxTypeForKey<Employee,Nox.Types.AutoNumber>("Id", request.ParentKeyDto.keyId);
		var parentEntity = await DbContext.Employees.FindAsync(keyId);
		if (parentEntity == null)
		{
			return false;
		}
		var ownedId = CreateNoxTypeForKey<EmployeePhoneNumber,Nox.Types.AutoNumber>("Id", request.EntityKeyDto.keyId);
		var entity = parentEntity.EmployeeContactPhoneNumbers.SingleOrDefault(x => x.Id == ownedId);
		if (entity == null)
		{
			return false;
		}
		parentEntity.EmployeeContactPhoneNumbers.Remove(entity);
		OnCompleted(request, entity);

		DbContext.Entry(entity).State = EntityState.Deleted;
	
		var result = await DbContext.SaveChangesAsync(cancellationToken);
		if (result < 1)
		{
			return false;
		}

		return true;
	}
}