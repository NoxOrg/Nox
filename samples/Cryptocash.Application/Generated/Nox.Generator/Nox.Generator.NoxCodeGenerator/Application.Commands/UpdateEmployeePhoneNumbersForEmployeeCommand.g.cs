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

public partial record UpdateEmployeePhoneNumbersForEmployeeCommand(EmployeeKeyDto ParentKeyDto, IEnumerable<EmployeePhoneNumberUpsertDto> EntitiesDto, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest<bool>;

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

internal partial class UpdateEmployeePhoneNumbersForEmployeeCommandHandlerBase : CommandBase<UpdateEmployeePhoneNumbersForEmployeeCommand, EmployeePhoneNumberEntity>, IRequestHandler <UpdateEmployeePhoneNumbersForEmployeeCommand, bool>
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

	public virtual async Task<bool> Handle(UpdateEmployeePhoneNumbersForEmployeeCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);

		var keys = new List<object?>(1);
		keys.Add(Dto.EmployeeMetadata.CreateId(request.ParentKeyDto.keyId));

		var parentEntity = await _repository.FindAndIncludeAsync<Cryptocash.Domain.Employee>(keys.ToArray(),e => e.EmployeePhoneNumbers, cancellationToken);
		EntityNotFoundException.ThrowIfNull(parentEntity, "Employee",  "keyId");				
		List<EmployeePhoneNumberEntity> entities = new(); // count
		foreach(var entityDto in request.EntitiesDto)
		{
			EmployeePhoneNumberEntity? entity;
			if(entityDto.Id is null)
			{
				entity = await CreateEntityAsync(entityDto, parentEntity, request.CultureCode);
			}
			else
			{
				var ownedId = Dto.EmployeePhoneNumberMetadata.CreateId(entityDto.Id.NonNullValue<System.Int64>());
				entity = parentEntity.EmployeePhoneNumbers.SingleOrDefault(x => x.Id == ownedId);
				if (entity is null)
					throw new EntityNotFoundException("EmployeePhoneNumber",  $"ownedId");
				else
					await _entityFactory.UpdateEntityAsync(entity, entityDto, request.CultureCode);
			}

			entities.Add(entity);
		}

		parentEntity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;		
		_repository.Update(parentEntity);
		//await OnCompletedAsync(request, entity!); // fix
		await _repository.SaveChangesAsync();

		return true;
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