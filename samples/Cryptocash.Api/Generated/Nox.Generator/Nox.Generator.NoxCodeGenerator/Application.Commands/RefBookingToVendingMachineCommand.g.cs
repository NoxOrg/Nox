
// Generated

#nullable enable

using MediatR;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nox.Application;
using Nox.Application.Commands;
using Nox.Application.Factories;
using Nox.Solution;
using Nox.Types;

using Cryptocash.Infrastructure.Persistence;
using Cryptocash.Domain;
using Cryptocash.Application.Dto;
using BookingEntity = Cryptocash.Domain.Booking;

namespace Cryptocash.Application.Commands;

public abstract record RefBookingToVendingMachineCommand(BookingKeyDto EntityKeyDto, VendingMachineKeyDto? RelatedEntityKeyDto) : IRequest <bool>;

public record CreateRefBookingToVendingMachineCommand(BookingKeyDto EntityKeyDto, VendingMachineKeyDto RelatedEntityKeyDto)
	: RefBookingToVendingMachineCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class CreateRefBookingToVendingMachineCommandHandler
	: RefBookingToVendingMachineCommandHandlerBase<CreateRefBookingToVendingMachineCommand>
{
	public CreateRefBookingToVendingMachineCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Create)
	{ }
}

public record DeleteRefBookingToVendingMachineCommand(BookingKeyDto EntityKeyDto, VendingMachineKeyDto RelatedEntityKeyDto)
	: RefBookingToVendingMachineCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class DeleteRefBookingToVendingMachineCommandHandler
	: RefBookingToVendingMachineCommandHandlerBase<DeleteRefBookingToVendingMachineCommand>
{
	public DeleteRefBookingToVendingMachineCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Delete)
	{ }
}

public record DeleteAllRefBookingToVendingMachineCommand(BookingKeyDto EntityKeyDto)
	: RefBookingToVendingMachineCommand(EntityKeyDto, null);

internal partial class DeleteAllRefBookingToVendingMachineCommandHandler
	: RefBookingToVendingMachineCommandHandlerBase<DeleteAllRefBookingToVendingMachineCommand>
{
	public DeleteAllRefBookingToVendingMachineCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.DeleteAll)
	{ }
}

internal abstract class RefBookingToVendingMachineCommandHandlerBase<TRequest> : CommandBase<TRequest, BookingEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefBookingToVendingMachineCommand
{
	public AppDbContext DbContext { get; }

	public RelationshipAction Action { get; }

	public enum RelationshipAction { Create, Delete, DeleteAll };

	public RefBookingToVendingMachineCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		RelationshipAction action)
		: base(noxSolution)
	{
		DbContext = dbContext;
		Action = action;
	}

	public virtual async Task<bool> Handle(TRequest request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = Cryptocash.Domain.BookingMetadata.CreateId(request.EntityKeyDto.keyId);
		var entity = await DbContext.Bookings.FindAsync(keyId);
		if (entity == null)
		{
			return false;
		}

		Cryptocash.Domain.VendingMachine? relatedEntity = null!;
		if(request.RelatedEntityKeyDto is not null)
		{
			var relatedKeyId = Cryptocash.Domain.VendingMachineMetadata.CreateId(request.RelatedEntityKeyDto.keyId);
			relatedEntity = await DbContext.VendingMachines.FindAsync(relatedKeyId);
			if (relatedEntity == null)
			{
				return false;
			}
		}

		switch (Action)
		{
			case RelationshipAction.Create:
				entity.CreateRefToVendingMachine(relatedEntity);
				break;
			case RelationshipAction.Delete:
				entity.DeleteRefToVendingMachine(relatedEntity);
				break;
			case RelationshipAction.DeleteAll:
				entity.DeleteAllRefToVendingMachine();
				break;
		}

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}