﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Factories;
using Nox.Solution;
using Nox.Types;

using CryptocashApi.Infrastructure.Persistence;
using CryptocashApi.Domain;
using CryptocashApi.Application.Dto;

namespace CryptocashApi.Application.Commands;

public record PartialUpdateEmployeePhoneNumberCommand(System.Int64 keyId, Dictionary<string, dynamic> UpdatedProperties) : IRequest <EmployeePhoneNumberKeyDto?>;

public class PartialUpdateEmployeePhoneNumberCommandHandler: CommandBase<PartialUpdateEmployeePhoneNumberCommand>, IRequestHandler<PartialUpdateEmployeePhoneNumberCommand, EmployeePhoneNumberKeyDto?>
{
	public CryptocashApiDbContext DbContext { get; }
	public IEntityMapper<EmployeePhoneNumber> EntityMapper { get; }

	public PartialUpdateEmployeePhoneNumberCommandHandler(
		CryptocashApiDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityMapper<EmployeePhoneNumber> entityMapper): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
		EntityMapper = entityMapper;
	}

	public async Task<EmployeePhoneNumberKeyDto?> Handle(PartialUpdateEmployeePhoneNumberCommand request, CancellationToken cancellationToken)
	{
		OnExecuting(request, cancellationToken);
		var keyId = CreateNoxTypeForKey<EmployeePhoneNumber,DatabaseNumber>("Id", request.keyId);

		var entity = await DbContext.EmployeePhoneNumbers.FindAsync(keyId);
		if (entity == null)
		{
			return null;
		}
		EntityMapper.PartialMapToEntity(entity, GetEntityDefinition<EmployeePhoneNumber>(), request.UpdatedProperties);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return new EmployeePhoneNumberKeyDto(entity.Id.Value);
	}
}