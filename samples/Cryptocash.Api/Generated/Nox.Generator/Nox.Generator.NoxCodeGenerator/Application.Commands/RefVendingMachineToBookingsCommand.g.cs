
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

public abstract record RefVendingMachineToBookingsCommand(VendingMachineKeyDto EntityKeyDto, BookingKeyDto? RelatedEntityKeyDto) : IRequest <bool>;

public record CreateRefVendingMachineToBookingsCommand(VendingMachineKeyDto EntityKeyDto, BookingKeyDto RelatedEntityKeyDto)
	: RefVendingMachineToBookingsCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class CreateRefVendingMachineToBookingsCommandHandler
	: RefVendingMachineToBookingsCommandHandlerBase<CreateRefVendingMachineToBookingsCommand>
{
	public CreateRefVendingMachineToBookingsCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Create)
	{ }
}

public record DeleteRefVendingMachineToBookingsCommand(VendingMachineKeyDto EntityKeyDto, BookingKeyDto RelatedEntityKeyDto)
	: RefVendingMachineToBookingsCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class DeleteRefVendingMachineToBookingsCommandHandler
	: RefVendingMachineToBookingsCommandHandlerBase<DeleteRefVendingMachineToBookingsCommand>
{
	public DeleteRefVendingMachineToBookingsCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Delete)
	{ }
}

public record DeleteAllRefVendingMachineToBookingsCommand(VendingMachineKeyDto EntityKeyDto)
	: RefVendingMachineToBookingsCommand(EntityKeyDto, null);

internal partial class DeleteAllRefVendingMachineToBookingsCommandHandler
	: RefVendingMachineToBookingsCommandHandlerBase<DeleteAllRefVendingMachineToBookingsCommand>
{
	public DeleteAllRefVendingMachineToBookingsCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.DeleteAll)
	{ }
}

internal abstract class RefVendingMachineToBookingsCommandHandlerBase<TRequest> : CommandBase<TRequest, VendingMachineEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefVendingMachineToBookingsCommand
{
	public AppDbContext DbContext { get; }

	public RelationshipAction Action { get; }

	public enum RelationshipAction { Create, Delete, DeleteAll };

	public RefVendingMachineToBookingsCommandHandlerBase(
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
				entity.CreateRefToBookings(relatedEntity);
				break;
			case RelationshipAction.Delete:
				entity.DeleteRefToBookings(relatedEntity);
				break;
			case RelationshipAction.DeleteAll:
				await DbContext.Entry(entity).Collection(x => x.Bookings).LoadAsync();
				entity.DeleteAllRefToBookings();
				break;
		}

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}