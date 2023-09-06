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
public record PartialUpdateEmployeePhoneNumberCommand(EmployeeKeyDto ParentKeyDto, Dictionary<string, dynamic> UpdatedProperties, System.Guid? Etag) : IRequest <EmployeePhoneNumberKeyDto?>;

public partial class PartialUpdateEmployeePhoneNumberCommandHandler: CommandBase<PartialUpdateEmployeePhoneNumberCommand, EmployeePhoneNumber>, IRequestHandler <PartialUpdateEmployeePhoneNumberCommand, EmployeePhoneNumberKeyDto?>
{
	public CryptocashDbContext DbContext { get; }
	public IEntityMapper<EmployeePhoneNumber> EntityMapper { get; }

	public PartialUpdateEmployeePhoneNumberCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityMapper<EmployeePhoneNumber> entityMapper): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
		EntityMapper = entityMapper;
	}

	public async Task<EmployeePhoneNumberKeyDto?> Handle(PartialUpdateEmployeePhoneNumberCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = CreateNoxTypeForKey<Employee,DatabaseNumber>("Id", request.ParentKeyDto.keyId);

		var parentEntity = await DbContext.Employees.FindAsync(keyId);
		if (parentEntity == null)
		{
			return null;
		}
		var ownedId = CreateNoxTypeForKey<EmployeePhoneNumber,DatabaseNumber>("Id", request.UpdatedProperties["Id"]);
		var entity = parentEntity.EmployeePhoneNumbers.SingleOrDefault(x => x.Id == ownedId);
		if (entity == null)
		{
			return null;
		}

		EntityMapper.PartialMapToEntity(entity, GetEntityDefinition<EmployeePhoneNumber>(), request.UpdatedProperties);
		parentEntity.Etag = request.Etag.HasValue ? Nox.Types.Guid.From(request.Etag.Value) : Nox.Types.Guid.Empty;

		OnCompleted(entity);
	
		DbContext.Entry(parentEntity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		if (result < 1)
		{
			return null;
		}

		return new EmployeePhoneNumberKeyDto(entity.Id.Value);
	}
}