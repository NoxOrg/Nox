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

public record PartialUpdateVendingMachineCommand(System.Guid keyId, Dictionary<string, dynamic> UpdatedProperties) : IRequest <VendingMachineKeyDto?>;

public class PartialUpdateVendingMachineCommandHandler: CommandBase<PartialUpdateVendingMachineCommand>, IRequestHandler<PartialUpdateVendingMachineCommand, VendingMachineKeyDto?>
{
	public CryptocashApiDbContext DbContext { get; }
	public IEntityMapper<VendingMachine> EntityMapper { get; }

	public PartialUpdateVendingMachineCommandHandler(
		CryptocashApiDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityMapper<VendingMachine> entityMapper): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
		EntityMapper = entityMapper;
	}

	public async Task<VendingMachineKeyDto?> Handle(PartialUpdateVendingMachineCommand request, CancellationToken cancellationToken)
	{
		OnExecuting(request, cancellationToken);
		var keyId = CreateNoxTypeForKey<VendingMachine,DatabaseGuid>("Id", request.keyId);

		var entity = await DbContext.VendingMachines.FindAsync(keyId);
		if (entity == null)
		{
			return null;
		}
		EntityMapper.PartialMapToEntity(entity, GetEntityDefinition<VendingMachine>(), request.UpdatedProperties);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return new VendingMachineKeyDto(entity.Id.Value);
	}
}