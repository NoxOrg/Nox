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
using VendingMachineOrder = Cryptocash.Domain.VendingMachineOrder;

namespace Cryptocash.Application.Commands;

public record UpdateVendingMachineOrderCommand(System.Int64 keyId, VendingMachineOrderUpdateDto EntityDto) : IRequest<VendingMachineOrderKeyDto?>;

public class UpdateVendingMachineOrderCommandHandler: CommandBase<UpdateVendingMachineOrderCommand, VendingMachineOrder>, IRequestHandler<UpdateVendingMachineOrderCommand, VendingMachineOrderKeyDto?>
{
	public CryptocashDbContext DbContext { get; }
	public IEntityMapper<VendingMachineOrder> EntityMapper { get; }

	public UpdateVendingMachineOrderCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityMapper<VendingMachineOrder> entityMapper): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
		EntityMapper = entityMapper;
	}
	
	public async Task<VendingMachineOrderKeyDto?> Handle(UpdateVendingMachineOrderCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = CreateNoxTypeForKey<VendingMachineOrder,DatabaseNumber>("Id", request.keyId);
	
		var entity = await DbContext.VendingMachineOrders.FindAsync(keyId);
		if (entity == null)
		{
			return null;
		}
		EntityMapper.MapToEntity(entity, GetEntityDefinition<VendingMachineOrder>(), request.EntityDto);

		OnCompleted(entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		if(result < 1)
			return null;

		return new VendingMachineOrderKeyDto(entity.Id.Value);
	}
}