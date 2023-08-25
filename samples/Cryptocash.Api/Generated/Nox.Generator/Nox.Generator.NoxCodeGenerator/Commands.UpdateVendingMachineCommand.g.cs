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

public record UpdateVendingMachineCommand(System.Guid keyId, VendingMachineUpdateDto EntityDto) : IRequest<VendingMachineKeyDto?>;

public class UpdateVendingMachineCommandHandler: CommandBase<UpdateVendingMachineCommand, VendingMachine>, IRequestHandler<UpdateVendingMachineCommand, VendingMachineKeyDto?>
{
	public CryptocashApiDbContext DbContext { get; }
	public IEntityMapper<VendingMachine> EntityMapper { get; }

	public UpdateVendingMachineCommandHandler(
		CryptocashApiDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityMapper<VendingMachine> entityMapper): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
		EntityMapper = entityMapper;
	}
	
	public async Task<VendingMachineKeyDto?> Handle(UpdateVendingMachineCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = CreateNoxTypeForKey<VendingMachine,DatabaseGuid>("Id", request.keyId);
	
		var entity = await DbContext.VendingMachines.FindAsync(keyId);
		if (entity == null)
		{
			return null;
		}
		EntityMapper.MapToEntity(entity, GetEntityDefinition<VendingMachine>(), request.EntityDto);

		OnCompleted(entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		if(result < 1)
			return null;

		return new VendingMachineKeyDto(entity.Id.Value);
	}
}