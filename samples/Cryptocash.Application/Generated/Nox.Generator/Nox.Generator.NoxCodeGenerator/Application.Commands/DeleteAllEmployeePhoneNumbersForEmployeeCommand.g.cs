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

public partial record DeleteAllEmployeePhoneNumbersForEmployeeCommand(EmployeeKeyDto ParentKeyDto, System.Guid? Etag) : IRequest <bool>;


internal partial class DeleteAllEmployeePhoneNumbersForEmployeeCommandHandler : DeleteAllEmployeePhoneNumbersForEmployeeCommandHandlerBase
{
	public DeleteAllEmployeePhoneNumbersForEmployeeCommandHandler(
        IRepository repository,
		NoxSolution noxSolution)
		: base(repository, noxSolution)
	{
	}
}

internal partial class DeleteAllEmployeePhoneNumbersForEmployeeCommandHandlerBase : CommandCollectionBase<DeleteAllEmployeePhoneNumbersForEmployeeCommand, EmployeePhoneNumberEntity>, IRequestHandler <DeleteAllEmployeePhoneNumbersForEmployeeCommand, bool>
{
	public IRepository Repository { get; }

	public DeleteAllEmployeePhoneNumbersForEmployeeCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution) : base(noxSolution)
	{
		Repository = repository;
	}

	public virtual async Task<bool> Handle(DeleteAllEmployeePhoneNumbersForEmployeeCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		
		var keys = new List<object?>(1);
		keys.Add(Dto.EmployeeMetadata.CreateId(request.ParentKeyDto.keyId));
		
		var parentEntity = await Repository.FindAndIncludeAsync<Cryptocash.Domain.Employee>(keys.ToArray(), p => p.EmployeePhoneNumbers, cancellationToken);
		EntityNotFoundException.ThrowIfNull(parentEntity, "Employee", "parentKeyId");
					
		var entities = parentEntity.EmployeePhoneNumbers;
		
		parentEntity.DeleteAllRefToEmployeePhoneNumbers();
		parentEntity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;
		
		await OnCompletedAsync(request, entities);
		Repository.DeleteRange(entities);
		Repository.Update(parentEntity);
		await Repository.SaveChangesAsync(cancellationToken);

		return true;
	}
}