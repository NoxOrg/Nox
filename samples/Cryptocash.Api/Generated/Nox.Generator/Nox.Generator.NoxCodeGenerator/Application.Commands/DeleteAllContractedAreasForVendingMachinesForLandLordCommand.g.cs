﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Nox.Application.Factories;
using Cryptocash.Infrastructure.Persistence;
using Cryptocash.Domain;
using Cryptocash.Application.Dto;
using VendingMachineEntity = Cryptocash.Domain.VendingMachine;

namespace Cryptocash.Application.Commands;

public partial record DeleteAllContractedAreasForVendingMachinesForLandLordCommand(LandLordKeyDto ParentKeyDto) : IRequest <bool>;


internal partial class DeleteAllContractedAreasForVendingMachinesForLandLordCommandHandler : DeleteAllContractedAreasForVendingMachinesForLandLordCommandHandlerBase
{
	public DeleteAllContractedAreasForVendingMachinesForLandLordCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution)
		: base(dbContext, noxSolution)
	{
	}
}

internal partial class DeleteAllContractedAreasForVendingMachinesForLandLordCommandHandlerBase : CommandBase<DeleteAllContractedAreasForVendingMachinesForLandLordCommand, VendingMachineEntity>, IRequestHandler <DeleteAllContractedAreasForVendingMachinesForLandLordCommand, bool>
{
	public AppDbContext DbContext { get; }

	public DeleteAllContractedAreasForVendingMachinesForLandLordCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(noxSolution)
	{
		DbContext = dbContext;
	}

	public virtual async Task<bool> Handle(DeleteAllContractedAreasForVendingMachinesForLandLordCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = Cryptocash.Domain.LandLordMetadata.CreateId(request.ParentKeyDto.keyId);
		
		using var trx = DbContext.Database.BeginTransaction();
		
		try
		{
			var parentEntity = await DbContext.LandLords.FindAsync(keyId);
			if (parentEntity == null)
			{
				return false;
			}
			var related = parentEntity.VendingMachines;
			if (related == null)
			{
				return false;
			}
			
			foreach(var relatedEntity in related)
			{
				DbContext.VendingMachines.Remove(relatedEntity);
				await OnCompletedAsync(request, relatedEntity);
			}
			
			await trx.CommitAsync();
			
			var result = await DbContext.SaveChangesAsync(cancellationToken);
			if (result < 1)
			{
				return false;
			}

			return true;
		}
		catch
		{
			await trx.RollbackAsync();
			return false;
		}
	}
}