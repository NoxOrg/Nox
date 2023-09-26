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

public record PartialUpdateVendingMachineCommand(System.Guid keyId, Dictionary<string, dynamic> UpdatedProperties, System.Guid? Etag) : IRequest <VendingMachineKeyDto?>;

internal class PartialUpdateVendingMachineCommandHandler: PartialUpdateVendingMachineCommandHandlerBase
{
	public PartialUpdateVendingMachineCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityFactory<VendingMachine, VendingMachineCreateDto, VendingMachineUpdateDto> entityFactory) : base(dbContext,noxSolution, serviceProvider, entityFactory)
	{
	}
}
internal class PartialUpdateVendingMachineCommandHandlerBase: CommandBase<PartialUpdateVendingMachineCommand, VendingMachine>, IRequestHandler<PartialUpdateVendingMachineCommand, VendingMachineKeyDto?>
{
	public CryptocashDbContext DbContext { get; }
	public IEntityFactory<VendingMachine, VendingMachineCreateDto, VendingMachineUpdateDto> EntityFactory { get; }

	public PartialUpdateVendingMachineCommandHandlerBase(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityFactory<VendingMachine, VendingMachineCreateDto, VendingMachineUpdateDto> entityFactory) : base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
	}

	public virtual async Task<VendingMachineKeyDto?> Handle(PartialUpdateVendingMachineCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = CreateNoxTypeForKey<VendingMachine,Nox.Types.Guid>("Id", request.keyId);

		var entity = await DbContext.VendingMachines.FindAsync(keyId);
		if (entity == null)
		{
			return null;
		}
		EntityFactory.PartialUpdateEntity(entity, request.UpdatedProperties);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

		OnCompleted(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return new VendingMachineKeyDto(entity.Id.Value);
	}
}