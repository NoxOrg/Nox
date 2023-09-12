﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Factories;
using Nox.Solution;
using Nox.Types;

using Cryptocash.Infrastructure.Persistence;
using Cryptocash.Domain;
using Cryptocash.Application.Dto;
using VendingMachine = Cryptocash.Domain.VendingMachine;

namespace Cryptocash.Application.Commands;

public record PartialUpdateVendingMachineCommand(System.Guid keyId, Dictionary<string, dynamic> UpdatedProperties) : IRequest <VendingMachineKeyDto?>;

public class PartialUpdateVendingMachineCommandHandler: CommandBase<PartialUpdateVendingMachineCommand, VendingMachine>, IRequestHandler<PartialUpdateVendingMachineCommand, VendingMachineKeyDto?>
{
	public CryptocashDbContext DbContext { get; }
	public IEntityMapper<VendingMachine> EntityMapper { get; }

	public PartialUpdateVendingMachineCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityMapper<VendingMachine> entityMapper): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
		EntityMapper = entityMapper;
	}

	public async Task<VendingMachineKeyDto?> Handle(PartialUpdateVendingMachineCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = CreateNoxTypeForKey<VendingMachine,Nox.Types.Guid>("Id", request.keyId);

		var entity = await DbContext.VendingMachines.FindAsync(keyId);
		if (entity == null)
		{
			return null;
		}
		EntityMapper.PartialMapToEntity(entity, GetEntityDefinition<VendingMachine>(), request.UpdatedProperties);

		OnCompleted(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return new VendingMachineKeyDto(entity.Id.Value);
	}
}