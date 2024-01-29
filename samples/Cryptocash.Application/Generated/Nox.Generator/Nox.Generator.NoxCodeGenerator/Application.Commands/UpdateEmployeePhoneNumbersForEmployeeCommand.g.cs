﻿﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using FluentValidation;
using Microsoft.Extensions.Logging;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Domain;
using Nox.Types;
using Nox.Application.Factories;
using Nox.Extensions;
using Nox.Exceptions;

using Cryptocash.Domain;
using Cryptocash.Application.Dto;
using Dto = Cryptocash.Application.Dto;
using EmployeePhoneNumberEntity = Cryptocash.Domain.EmployeePhoneNumber;
using EmployeeEntity = Cryptocash.Domain.Employee;

namespace Cryptocash.Application.Commands;

public partial record UpdateEmployeePhoneNumbersForEmployeeCommand(EmployeeKeyDto ParentKeyDto, EmployeePhoneNumberUpsertDto EntityDto, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest <EmployeePhoneNumberKeyDto>;

internal partial class UpdateEmployeePhoneNumbersForEmployeeCommandHandler : UpdateEmployeePhoneNumbersForEmployeeCommandHandlerBase
{
	public UpdateEmployeePhoneNumbersForEmployeeCommandHandler(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<EmployeePhoneNumberEntity, EmployeePhoneNumberUpsertDto, EmployeePhoneNumberUpsertDto> entityFactory)
		: base(repository, noxSolution, entityFactory)
	{
	}
}

internal partial class UpdateEmployeePhoneNumbersForEmployeeCommandHandlerBase : CommandBase<UpdateEmployeePhoneNumbersForEmployeeCommand, EmployeePhoneNumberEntity>, IRequestHandler <UpdateEmployeePhoneNumbersForEmployeeCommand, EmployeePhoneNumberKeyDto>
{
	private readonly IRepository _repository;
	private readonly IEntityFactory<EmployeePhoneNumberEntity, EmployeePhoneNumberUpsertDto, EmployeePhoneNumberUpsertDto> _entityFactory;

	protected UpdateEmployeePhoneNumbersForEmployeeCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<EmployeePhoneNumberEntity, EmployeePhoneNumberUpsertDto, EmployeePhoneNumberUpsertDto> entityFactory)
		: base(noxSolution)
	{
		_repository = repository;
		_entityFactory = entityFactory;
	}

	public virtual async Task<EmployeePhoneNumberKeyDto> Handle(UpdateEmployeePhoneNumbersForEmployeeCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);

		var keys = new List<object?>(1);
		keys.Add(Dto.EmployeeMetadata.CreateId(request.ParentKeyDto.keyId));

		var parentEntity = await _repository.FindAndIncludeAsync<Employee>(keys.ToArray(),e => e.EmployeePhoneNumbers, cancellationToken);
		EntityNotFoundException.ThrowIfNull(parentEntity, "Employee",  "keyId");				
		EmployeePhoneNumberEntity? entity;
		if(request.EntityDto.Id is null)
		{
			entity = await CreateEntityAsync(request.EntityDto, parentEntity, request.CultureCode);
		}
		else
		{
			var ownedId =Dto.EmployeePhoneNumberMetadata.CreateId(request.EntityDto.Id.NonNullValue<System.Int64>());
			entity = parentEntity.EmployeePhoneNumbers.SingleOrDefault(x => x.Id == ownedId);
			if (entity is null)
				throw new EntityNotFoundException("EmployeePhoneNumber",  $"ownedId");
			else
				await _entityFactory.UpdateEntityAsync(entity, request.EntityDto, request.CultureCode);
		}

		parentEntity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;		
		_repository.SetStateModified(parentEntity);
		await OnCompletedAsync(request, entity!);
		await _repository.SaveChangesAsync();

		return new EmployeePhoneNumberKeyDto(entity.Id.Value);
	}
	
	private async Task<EmployeePhoneNumberEntity> CreateEntityAsync(EmployeePhoneNumberUpsertDto upsertDto, EmployeeEntity parent, Nox.Types.CultureCode cultureCode)
	{
		var entity = await _entityFactory.CreateEntityAsync(upsertDto, cultureCode);
		parent.CreateRefToEmployeePhoneNumbers(entity);
		return entity;
	}
}

public class UpdateEmployeePhoneNumbersForEmployeeValidator : AbstractValidator<UpdateEmployeePhoneNumbersForEmployeeCommand>
{
    public UpdateEmployeePhoneNumbersForEmployeeValidator()
    {
    }
}