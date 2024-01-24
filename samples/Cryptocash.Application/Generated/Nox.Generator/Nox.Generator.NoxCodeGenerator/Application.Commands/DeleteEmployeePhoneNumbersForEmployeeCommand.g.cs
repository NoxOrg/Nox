﻿﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Domain;
using Nox.Types;
using Nox.Application.Factories;
using Nox.Exceptions;
using Cryptocash.Domain;
using Cryptocash.Application.Dto;
using Dto = Cryptocash.Application.Dto;
using EmployeePhoneNumberEntity = Cryptocash.Domain.EmployeePhoneNumber;

namespace Cryptocash.Application.Commands;
public partial record DeleteEmployeePhoneNumbersForEmployeeCommand(EmployeeKeyDto ParentKeyDto, EmployeePhoneNumberKeyDto EntityKeyDto) : IRequest <bool>;

internal partial class DeleteEmployeePhoneNumbersForEmployeeCommandHandler : DeleteEmployeePhoneNumbersForEmployeeCommandHandlerBase
{
	public DeleteEmployeePhoneNumbersForEmployeeCommandHandler(
        IRepository repository,
		NoxSolution noxSolution)
		: base(repository, noxSolution)
	{
	}
}

internal partial class DeleteEmployeePhoneNumbersForEmployeeCommandHandlerBase : CommandBase<DeleteEmployeePhoneNumbersForEmployeeCommand, EmployeePhoneNumberEntity>, IRequestHandler <DeleteEmployeePhoneNumbersForEmployeeCommand, bool>
{
	public IRepository Repository { get; }

	public DeleteEmployeePhoneNumbersForEmployeeCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution) : base(noxSolution)
	{
		Repository = repository;
	}

	public virtual async Task<bool> Handle(DeleteEmployeePhoneNumbersForEmployeeCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		
		var keys = new List<object?>(1);
		keys.Add(Dto.EmployeeMetadata.CreateId(request.ParentKeyDto.keyId));
		var parentEntity = await Repository.FindAndIncludeAsync<Employee>(keys.ToArray(), p => p.EmployeePhoneNumbers, cancellationToken);
		if (parentEntity == null)
		{
			throw new EntityNotFoundException("Employee",  "keyId");
		}
		var ownedId = Dto.EmployeePhoneNumberMetadata.CreateId(request.EntityKeyDto.keyId);
		var entity = parentEntity.EmployeePhoneNumbers.SingleOrDefault(x => x.Id == ownedId);
		if (entity == null)
		{
			throw new EntityNotFoundException("EmployeePhoneNumber.EmployeePhoneNumbers",  $"ownedId");
		}
		parentEntity.EmployeePhoneNumbers.Remove(entity);
		
		await OnCompletedAsync(request, entity);
		Repository.Delete(entity);
		await Repository.SaveChangesAsync(cancellationToken);

		return true;
	}
}