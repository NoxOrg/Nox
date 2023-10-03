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
using VendingMachine = Cryptocash.Domain.VendingMachine;

namespace Cryptocash.Application.Commands;

public record UpdateVendingMachineCommand(System.Guid keyId, VendingMachineUpdateDto EntityDto, System.Guid? Etag) : IRequest<VendingMachineKeyDto?>;

internal partial class UpdateVendingMachineCommandHandler: UpdateVendingMachineCommandHandlerBase
{
	public UpdateVendingMachineCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<VendingMachine, VendingMachineCreateDto, VendingMachineUpdateDto> entityFactory): base(dbContext, noxSolution, entityFactory)
	{
	}
}

internal abstract class UpdateVendingMachineCommandHandlerBase: CommandBase<UpdateVendingMachineCommand, VendingMachine>, IRequestHandler<UpdateVendingMachineCommand, VendingMachineKeyDto?>
{
	public CryptocashDbContext DbContext { get; }
	private readonly IEntityFactory<VendingMachine, VendingMachineCreateDto, VendingMachineUpdateDto> _entityFactory;

	public UpdateVendingMachineCommandHandlerBase(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<VendingMachine, VendingMachineCreateDto, VendingMachineUpdateDto> entityFactory): base(noxSolution)
	{
		DbContext = dbContext;
		_entityFactory = entityFactory;
	}

	public virtual async Task<VendingMachineKeyDto?> Handle(UpdateVendingMachineCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = Cryptocash.Domain.VendingMachineMetadata.CreateId(request.keyId);

		var entity = await DbContext.VendingMachines.FindAsync(keyId);
		if (entity == null)
		{
			return null;
		}

		_entityFactory.UpdateEntity(entity, request.EntityDto);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

		OnCompleted(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		if (result < 1)
		{
			return null;
		}

		return new VendingMachineKeyDto(entity.Id.Value);
	}
}