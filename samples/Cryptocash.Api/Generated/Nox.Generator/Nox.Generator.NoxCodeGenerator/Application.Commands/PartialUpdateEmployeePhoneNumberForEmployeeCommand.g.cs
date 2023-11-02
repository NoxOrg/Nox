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
public record PartialUpdateEmployeePhoneNumberForEmployeeCommand(EmployeeKeyDto ParentKeyDto, EmployeePhoneNumberKeyDto EntityKeyDto, Dictionary<string, dynamic> UpdatedProperties, System.Guid? Etag) : IRequest <EmployeePhoneNumberKeyDto?>;
internal partial class PartialUpdateEmployeePhoneNumberForEmployeeCommandHandler: PartialUpdateEmployeePhoneNumberForEmployeeCommandHandlerBase
{
	public PartialUpdateEmployeePhoneNumberForEmployeeCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<EmployeePhoneNumberEntity, EmployeePhoneNumberCreateDto, EmployeePhoneNumberUpdateDto> entityFactory) : base(dbContext, noxSolution, entityFactory)
	{
	}
}
internal abstract class PartialUpdateEmployeePhoneNumberForEmployeeCommandHandlerBase: CommandBase<PartialUpdateEmployeePhoneNumberForEmployeeCommand, EmployeePhoneNumberEntity>, IRequestHandler <PartialUpdateEmployeePhoneNumberForEmployeeCommand, EmployeePhoneNumberKeyDto?>
{
	public AppDbContext DbContext { get; }
	public IEntityFactory<EmployeePhoneNumberEntity, EmployeePhoneNumberCreateDto, EmployeePhoneNumberUpdateDto> EntityFactory { get; }

	public PartialUpdateEmployeePhoneNumberForEmployeeCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<EmployeePhoneNumberEntity, EmployeePhoneNumberCreateDto, EmployeePhoneNumberUpdateDto> entityFactory) : base(noxSolution)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
	}

	public virtual async Task<EmployeePhoneNumberKeyDto?> Handle(PartialUpdateEmployeePhoneNumberForEmployeeCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = Cryptocash.Domain.EmployeeMetadata.CreateId(request.ParentKeyDto.keyId);

		var parentEntity = await DbContext.Employees.FindAsync(keyId);
		if (parentEntity == null)
		{
			return null;
		}
		var ownedId = Cryptocash.Domain.EmployeePhoneNumberMetadata.CreateId(request.EntityKeyDto.keyId);
		var entity = parentEntity.EmployeeContactPhoneNumbers.SingleOrDefault(x => x.Id == ownedId);
		if (entity == null)
		{
			return null;
		}

		EntityFactory.PartialUpdateEntity(entity, request.UpdatedProperties, null!);
		parentEntity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

		await OnCompletedAsync(request, entity);

		DbContext.Entry(parentEntity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		if (result < 1)
		{
			return null;
		}

		return new EmployeePhoneNumberKeyDto(entity.Id.Value);
	}
}