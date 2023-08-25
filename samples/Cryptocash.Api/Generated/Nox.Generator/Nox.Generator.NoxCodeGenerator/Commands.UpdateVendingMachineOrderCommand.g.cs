﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Nox.Factories;
using CryptocashApi.Infrastructure.Persistence;
using CryptocashApi.Domain;
using CryptocashApi.Application.Dto;

namespace CryptocashApi.Application.Commands;

public record UpdateVendingMachineOrderCommand(System.Int64 keyId, VendingMachineOrderUpdateDto EntityDto) : IRequest<VendingMachineOrderKeyDto?>;

public class UpdateVendingMachineOrderCommandHandler: CommandBase<UpdateVendingMachineOrderCommand>, IRequestHandler<UpdateVendingMachineOrderCommand, VendingMachineOrderKeyDto?>
{
	public CryptocashApiDbContext DbContext { get; }
	public IEntityMapper<VendingMachineOrder> EntityMapper { get; }

	public UpdateVendingMachineOrderCommandHandler(
		CryptocashApiDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityMapper<VendingMachineOrder> entityMapper): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
		EntityMapper = entityMapper;
	}
	
	public async Task<VendingMachineOrderKeyDto?> Handle(UpdateVendingMachineOrderCommand request, CancellationToken cancellationToken)
	{
		OnExecuting(request, cancellationToken);
		var keyId = CreateNoxTypeForKey<VendingMachineOrder,DatabaseNumber>("Id", request.keyId);
	
		var entity = await DbContext.VendingMachineOrders.FindAsync(keyId);
		if (entity == null)
		{
			return null;
		}
		EntityMapper.MapToEntity(entity, GetEntityDefinition<VendingMachineOrder>(), request.EntityDto);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		if(result < 1)
			return null;

		return new VendingMachineOrderKeyDto(entity.Id.Value);
	}
}