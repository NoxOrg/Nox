﻿// Generated

#nullable enable

using MediatR;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nox.Application;
using Nox.Application.Commands;
using Nox.Factories;
using Nox.Solution;
using Nox.Types;

using Cryptocash.Infrastructure.Persistence;
using Cryptocash.Domain;
using Cryptocash.Application.Dto;

namespace Cryptocash.Application.Commands;
public record DeleteRefVendingMachineToVendingMachineOrderCommand(VendingMachineKeyDto EntityKeyDto, VendingMachineOrderKeyDto RelatedEntityKeyDto) : IRequest <bool>;

public partial class DeleteRefVendingMachineToVendingMachineOrderCommandHandler: CommandBase<DeleteRefVendingMachineToVendingMachineOrderCommand, VendingMachine>, 
	IRequestHandler <DeleteRefVendingMachineToVendingMachineOrderCommand, bool>
{
	public CryptocashDbContext DbContext { get; }

	public DeleteRefVendingMachineToVendingMachineOrderCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
	}

	public async Task<bool> Handle(DeleteRefVendingMachineToVendingMachineOrderCommand request, CancellationToken cancellationToken)
	{
		OnExecuting(request);
		var keyId = CreateNoxTypeForKey<VendingMachine,DatabaseGuid>("Id", request.EntityKeyDto.keyId);

		var entity = await DbContext.VendingMachines.FindAsync(keyId);
		if (entity == null)
		{
			return false;
		}
		var relatedKeyId = CreateNoxTypeForKey<VendingMachineOrder,DatabaseNumber>("Id", request.RelatedEntityKeyDto.keyId);
		var relatedEntity = await DbContext.VendingMachineOrders.FindAsync(relatedKeyId);
		if (relatedEntity == null)
		{
			return false;
		}
		entity.VendingMachineOrders.Remove(relatedEntity);

		OnCompleted(entity);
	
		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}