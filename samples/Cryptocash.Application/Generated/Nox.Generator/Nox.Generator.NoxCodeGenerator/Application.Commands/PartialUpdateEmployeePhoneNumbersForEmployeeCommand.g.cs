﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Nox.Application.Factories;
using Nox.Exceptions;
using Nox.Domain;

using Cryptocash.Domain;
using Cryptocash.Application.Dto;
using Dto = Cryptocash.Application.Dto;
using EmployeePhoneNumberEntity = Cryptocash.Domain.EmployeePhoneNumber;

namespace Cryptocash.Application.Commands;
public partial record PartialUpdateEmployeePhoneNumbersForEmployeeCommand(EmployeeKeyDto ParentKeyDto, EmployeePhoneNumberKeyDto EntityKeyDto, Dictionary<string, dynamic> UpdatedProperties, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest <EmployeePhoneNumberKeyDto>;
internal partial class PartialUpdateEmployeePhoneNumbersForEmployeeCommandHandler: PartialUpdateEmployeePhoneNumbersForEmployeeCommandHandlerBase
{
	public PartialUpdateEmployeePhoneNumbersForEmployeeCommandHandler(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<EmployeePhoneNumberEntity, EmployeePhoneNumberUpsertDto, EmployeePhoneNumberUpsertDto> entityFactory)
		: base(repository, noxSolution, entityFactory)
	{
	}
}
internal abstract class PartialUpdateEmployeePhoneNumbersForEmployeeCommandHandlerBase: CommandBase<PartialUpdateEmployeePhoneNumbersForEmployeeCommand, EmployeePhoneNumberEntity>, IRequestHandler <PartialUpdateEmployeePhoneNumbersForEmployeeCommand, EmployeePhoneNumberKeyDto>
{
	protected readonly IRepository Repository;
	protected readonly IEntityFactory<EmployeePhoneNumberEntity, EmployeePhoneNumberUpsertDto, EmployeePhoneNumberUpsertDto> EntityFactory;
	
	protected PartialUpdateEmployeePhoneNumbersForEmployeeCommandHandlerBase(
		IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<EmployeePhoneNumberEntity, EmployeePhoneNumberUpsertDto, EmployeePhoneNumberUpsertDto> entityFactory)
		: base(noxSolution)
	{
		Repository = repository;
		EntityFactory = entityFactory;
	}

	public virtual async Task<EmployeePhoneNumberKeyDto> Handle(PartialUpdateEmployeePhoneNumbersForEmployeeCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);

		var keys = new List<object?>(1);
		keys.Add(Dto.EmployeeMetadata.CreateId(request.ParentKeyDto.keyId));

		var parentEntity = await Repository.FindAndIncludeAsync<Employee>(keys.ToArray(),e => e.EmployeePhoneNumbers, cancellationToken);
		if (parentEntity == null)
		{
			throw new EntityNotFoundException("Employee",  "keyId");
		}
		var ownedId = Dto.EmployeePhoneNumberMetadata.CreateId(request.EntityKeyDto.keyId);
		var entity = parentEntity.EmployeePhoneNumbers.SingleOrDefault(x => x.Id == ownedId);
		if (entity == null)
		{
			throw new EntityNotFoundException("Employee.EmployeePhoneNumbers", $"ownedId");
		}

		await EntityFactory.PartialUpdateEntityAsync(entity, request.UpdatedProperties, request.CultureCode);
		parentEntity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;
		Repository.Update(entity);
		await OnCompletedAsync(request, entity);
		await Repository.SaveChangesAsync();		

		return new EmployeePhoneNumberKeyDto(entity.Id.Value);
	}
}