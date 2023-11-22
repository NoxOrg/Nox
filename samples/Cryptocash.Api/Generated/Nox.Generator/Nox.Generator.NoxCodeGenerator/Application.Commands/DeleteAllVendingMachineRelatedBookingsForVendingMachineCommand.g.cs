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
using BookingEntity = Cryptocash.Domain.Booking;

namespace Cryptocash.Application.Commands;

public partial record DeleteAllVendingMachineRelatedBookingsForVendingMachineCommand(VendingMachineKeyDto ParentKeyDto) : IRequest <bool>;


internal partial class DeleteAllVendingMachineRelatedBookingsForVendingMachineCommandHandler : DeleteAllVendingMachineRelatedBookingsForVendingMachineCommandHandlerBase
{
	public DeleteAllVendingMachineRelatedBookingsForVendingMachineCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution)
		: base(dbContext, noxSolution)
	{
	}
}

internal partial class DeleteAllVendingMachineRelatedBookingsForVendingMachineCommandHandlerBase : CommandBase<DeleteAllVendingMachineRelatedBookingsForVendingMachineCommand, BookingEntity>, IRequestHandler <DeleteAllVendingMachineRelatedBookingsForVendingMachineCommand, bool>
{
	public AppDbContext DbContext { get; }

	public DeleteAllVendingMachineRelatedBookingsForVendingMachineCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(noxSolution)
	{
		DbContext = dbContext;
	}

	public virtual async Task<bool> Handle(DeleteAllVendingMachineRelatedBookingsForVendingMachineCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = Cryptocash.Domain.VendingMachineMetadata.CreateId(request.ParentKeyDto.keyId);
		
		using var trx = DbContext.Database.BeginTransaction();
		
		try
		{
			var parentEntity = await DbContext.VendingMachines.FindAsync(keyId);
			if (parentEntity == null)
			{
				return false;
			}
			var related = parentEntity.Bookings;
			if (related == null)
			{
				return false;
			}
			
			foreach(var relatedEntity in related)
			{
				DbContext.Bookings.Remove(relatedEntity);
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