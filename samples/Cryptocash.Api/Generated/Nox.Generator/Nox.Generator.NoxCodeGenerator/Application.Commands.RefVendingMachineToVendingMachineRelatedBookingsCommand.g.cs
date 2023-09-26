
// Generated

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

public abstract record RefVendingMachineToVendingMachineRelatedBookingsCommand(VendingMachineKeyDto EntityKeyDto, BookingKeyDto? RelatedEntityKeyDto) : IRequest <bool>;

public record CreateRefVendingMachineToVendingMachineRelatedBookingsCommand(VendingMachineKeyDto EntityKeyDto, BookingKeyDto RelatedEntityKeyDto)
	: RefVendingMachineToVendingMachineRelatedBookingsCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class CreateRefVendingMachineToVendingMachineRelatedBookingsCommandHandler
	: RefVendingMachineToVendingMachineRelatedBookingsCommandHandlerBase<CreateRefVendingMachineToVendingMachineRelatedBookingsCommand>
{
	public CreateRefVendingMachineToVendingMachineRelatedBookingsCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider
		)
		: base(dbContext, noxSolution, serviceProvider, RelationshipAction.Create)
	{ }
}

public record DeleteRefVendingMachineToVendingMachineRelatedBookingsCommand(VendingMachineKeyDto EntityKeyDto, BookingKeyDto RelatedEntityKeyDto)
	: RefVendingMachineToVendingMachineRelatedBookingsCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class DeleteRefVendingMachineToVendingMachineRelatedBookingsCommandHandler
	: RefVendingMachineToVendingMachineRelatedBookingsCommandHandlerBase<DeleteRefVendingMachineToVendingMachineRelatedBookingsCommand>
{
	public DeleteRefVendingMachineToVendingMachineRelatedBookingsCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider
		)
		: base(dbContext, noxSolution, serviceProvider, RelationshipAction.Delete)
	{ }
}

public record DeleteAllRefVendingMachineToVendingMachineRelatedBookingsCommand(VendingMachineKeyDto EntityKeyDto)
	: RefVendingMachineToVendingMachineRelatedBookingsCommand(EntityKeyDto, null);

internal partial class DeleteAllRefVendingMachineToVendingMachineRelatedBookingsCommandHandler
	: RefVendingMachineToVendingMachineRelatedBookingsCommandHandlerBase<DeleteAllRefVendingMachineToVendingMachineRelatedBookingsCommand>
{
	public DeleteAllRefVendingMachineToVendingMachineRelatedBookingsCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider
		)
		: base(dbContext, noxSolution, serviceProvider, RelationshipAction.DeleteAll)
	{ }
}

internal abstract class RefVendingMachineToVendingMachineRelatedBookingsCommandHandlerBase<TRequest> : CommandBase<TRequest, VendingMachine>,
	IRequestHandler <TRequest, bool> where TRequest : RefVendingMachineToVendingMachineRelatedBookingsCommand
{
	public CryptocashDbContext DbContext { get; }

	public RelationshipAction Action { get; }

	public enum RelationshipAction { Create, Delete, DeleteAll };

	public RefVendingMachineToVendingMachineRelatedBookingsCommandHandlerBase(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		RelationshipAction action)
		: base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
		Action = action;
	}

	public virtual async Task<bool> Handle(TRequest request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = CreateNoxTypeForKey<VendingMachine, Nox.Types.Guid>("Id", request.EntityKeyDto.keyId);
		var entity = await DbContext.VendingMachines.FindAsync(keyId);
		if (entity == null)
		{
			return false;
		}

		Booking? relatedEntity = null!;
		if(request.RelatedEntityKeyDto is not null)
		{
			var relatedKeyId = CreateNoxTypeForKey<Booking, Nox.Types.Guid>("Id", request.RelatedEntityKeyDto.keyId);
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

		OnCompleted(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}