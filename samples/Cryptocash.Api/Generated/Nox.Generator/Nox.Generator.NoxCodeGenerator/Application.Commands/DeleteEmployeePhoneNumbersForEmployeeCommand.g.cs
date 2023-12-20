﻿﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Nox.Application.Factories;
using Nox.Exceptions;
using Cryptocash.Infrastructure.Persistence;
using Cryptocash.Domain;
using Cryptocash.Application.Dto;
using EmployeePhoneNumberEntity = Cryptocash.Domain.EmployeePhoneNumber;

namespace Cryptocash.Application.Commands;
public partial record DeleteEmployeePhoneNumbersForEmployeeCommand(EmployeeKeyDto ParentKeyDto, EmployeePhoneNumberKeyDto EntityKeyDto) : IRequest <bool>;

internal partial class DeleteEmployeePhoneNumbersForEmployeeCommandHandler : DeleteEmployeePhoneNumbersForEmployeeCommandHandlerBase
{
	public DeleteEmployeePhoneNumbersForEmployeeCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution)
		: base(dbContext, noxSolution)
	{
	}
}

internal partial class DeleteEmployeePhoneNumbersForEmployeeCommandHandlerBase : CommandBase<DeleteEmployeePhoneNumbersForEmployeeCommand, EmployeePhoneNumberEntity>, IRequestHandler <DeleteEmployeePhoneNumbersForEmployeeCommand, bool>
{
	public AppDbContext DbContext { get; }

	public DeleteEmployeePhoneNumbersForEmployeeCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(noxSolution)
	{
		DbContext = dbContext;
	}

	public virtual async Task<bool> Handle(DeleteEmployeePhoneNumbersForEmployeeCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = Cryptocash.Domain.EmployeeMetadata.CreateId(request.ParentKeyDto.keyId);
		var parentEntity = await DbContext.Employees.FindAsync(keyId);
		if (parentEntity == null)
		{
			throw new EntityNotFoundException("Employee",  $"{keyId.ToString()}");
		}
		await DbContext.Entry(parentEntity).Collection(p => p.EmployeePhoneNumbers).LoadAsync(cancellationToken);
		var ownedId = Cryptocash.Domain.EmployeePhoneNumberMetadata.CreateId(request.EntityKeyDto.keyId);
		var entity = parentEntity.EmployeePhoneNumbers.SingleOrDefault(x => x.Id == ownedId);
		if (entity == null)
		{
			throw new EntityNotFoundException("EmployeePhoneNumber.EmployeePhoneNumbers",  $"{ownedId.ToString()}");
		}
		parentEntity.EmployeePhoneNumbers.Remove(entity);
		await OnCompletedAsync(request, entity);
		DbContext.Entry(entity).State = EntityState.Deleted;

		var result = await DbContext.SaveChangesAsync(cancellationToken);

		return true;
	}
}