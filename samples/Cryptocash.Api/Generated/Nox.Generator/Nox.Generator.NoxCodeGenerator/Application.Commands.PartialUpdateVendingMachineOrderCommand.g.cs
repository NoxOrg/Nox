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
using VendingMachineOrder = CryptocashApi.Domain.VendingMachineOrder;

namespace CryptocashApi.Application.Commands;

public record PartialUpdateVendingMachineOrderCommand(System.Int64 keyId, Dictionary<string, dynamic> UpdatedProperties) : IRequest <VendingMachineOrderKeyDto?>;

public class PartialUpdateVendingMachineOrderCommandHandler: CommandBase<PartialUpdateVendingMachineOrderCommand, VendingMachineOrder>, IRequestHandler<PartialUpdateVendingMachineOrderCommand, VendingMachineOrderKeyDto?>
{
	public CryptocashApiDbContext DbContext { get; }
	public IEntityMapper<VendingMachineOrder> EntityMapper { get; }

	public PartialUpdateVendingMachineOrderCommandHandler(
		CryptocashApiDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityMapper<VendingMachineOrder> entityMapper): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
		EntityMapper = entityMapper;
	}

	public async Task<VendingMachineOrderKeyDto?> Handle(PartialUpdateVendingMachineOrderCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = CreateNoxTypeForKey<VendingMachineOrder,DatabaseNumber>("Id", request.keyId);

		var entity = await DbContext.VendingMachineOrders.FindAsync(keyId);
		if (entity == null)
		{
			return null;
		}
		EntityMapper.PartialMapToEntity(entity, GetEntityDefinition<VendingMachineOrder>(), request.UpdatedProperties);

		OnCompleted(entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return new VendingMachineOrderKeyDto(entity.Id.Value);
	}
}