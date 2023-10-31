
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
using VendingMachineEntity = Cryptocash.Domain.VendingMachine;

namespace Cryptocash.Application.Commands;

public abstract record RefVendingMachineToVendingMachineRelatedBookingsCommand(VendingMachineKeyDto EntityKeyDto, BookingKeyDto? RelatedEntityKeyDto) : IRequest <bool>;

public record CreateRefVendingMachineToVendingMachineRelatedBookingsCommand(VendingMachineKeyDto EntityKeyDto, BookingKeyDto RelatedEntityKeyDto)
	: RefVendingMachineToVendingMachineRelatedBookingsCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class CreateRefVendingMachineToVendingMachineRelatedBookingsCommandHandler
	: RefVendingMachineToVendingMachineRelatedBookingsCommandHandlerBase<CreateRefVendingMachineToVendingMachineRelatedBookingsCommand>
{
	public CreateRefVendingMachineToVendingMachineRelatedBookingsCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Create)
	{ }
}

public record DeleteRefVendingMachineToVendingMachineRelatedBookingsCommand(VendingMachineKeyDto EntityKeyDto, BookingKeyDto RelatedEntityKeyDto)
	: RefVendingMachineToVendingMachineRelatedBookingsCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class DeleteRefVendingMachineToVendingMachineRelatedBookingsCommandHandler
	: RefVendingMachineToVendingMachineRelatedBookingsCommandHandlerBase<DeleteRefVendingMachineToVendingMachineRelatedBookingsCommand>
{
	public DeleteRefVendingMachineToVendingMachineRelatedBookingsCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Delete)
	{ }
}

public record DeleteAllRefVendingMachineToVendingMachineRelatedBookingsCommand(VendingMachineKeyDto EntityKeyDto)
	: RefVendingMachineToVendingMachineRelatedBookingsCommand(EntityKeyDto, null);

internal partial class DeleteAllRefVendingMachineToVendingMachineRelatedBookingsCommandHandler
	: RefVendingMachineToVendingMachineRelatedBookingsCommandHandlerBase<DeleteAllRefVendingMachineToVendingMachineRelatedBookingsCommand>
{
	public DeleteAllRefVendingMachineToVendingMachineRelatedBookingsCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.DeleteAll)
	{ }
}

internal abstract class RefVendingMachineToVendingMachineRelatedBookingsCommandHandlerBase<TRequest> : CommandBase<TRequest, VendingMachineEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefVendingMachineToVendingMachineRelatedBookingsCommand
{
	public AppDbContext DbContext { get; }

	public RelationshipAction Action { get; }

	public enum RelationshipAction { Create, Delete, DeleteAll };

	public RefVendingMachineToVendingMachineRelatedBookingsCommandHandlerBase(
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
		var keyId = Cryptocash.Domain.VendingMachineMetadata.CreateId(request.EntityKeyDto.keyId);
		var entity = await DbContext.VendingMachines.FindAsync(keyId);
		if (entity == null)
		{
			return false;
		}

		Cryptocash.Domain.Booking? relatedEntity = null!;
		if(request.RelatedEntityKeyDto is not null)
		{
			var relatedKeyId = Cryptocash.Domain.BookingMetadata.CreateId(request.RelatedEntityKeyDto.keyId);
			relatedEntity = await DbContext.Bookings.FindAsync(relatedKeyId);
			if (relatedEntity == null)
			{
				return false;
			}
		}

		switch (Action)
		{
			case RelationshipAction.Create:
				entity.CreateRefToVendingMachineRelatedBookings(relatedEntity);
				break;
			case RelationshipAction.Delete:
				entity.DeleteRefToVendingMachineRelatedBookings(relatedEntity);
				break;
			case RelationshipAction.DeleteAll:
				await DbContext.Entry(entity).Collection(x => x.VendingMachineRelatedBookings).LoadAsync();
				entity.DeleteAllRefToVendingMachineRelatedBookings();
				break;
		}

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}