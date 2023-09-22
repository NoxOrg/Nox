
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

public abstract record RefBookingToBookingRelatedVendingMachineCommand(BookingKeyDto EntityKeyDto, VendingMachineKeyDto? RelatedEntityKeyDto) : IRequest <bool>;

public record CreateRefBookingToBookingRelatedVendingMachineCommand(BookingKeyDto EntityKeyDto, VendingMachineKeyDto RelatedEntityKeyDto)
	: RefBookingToBookingRelatedVendingMachineCommand(EntityKeyDto, RelatedEntityKeyDto);

public partial class CreateRefBookingToBookingRelatedVendingMachineCommandHandler
	: RefBookingToBookingRelatedVendingMachineCommandHandlerBase<CreateRefBookingToBookingRelatedVendingMachineCommand>
{
	public CreateRefBookingToBookingRelatedVendingMachineCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider
		)
		: base(dbContext, noxSolution, serviceProvider, RelationshipAction.Create)
	{ }
}

public record DeleteRefBookingToBookingRelatedVendingMachineCommand(BookingKeyDto EntityKeyDto, VendingMachineKeyDto RelatedEntityKeyDto)
	: RefBookingToBookingRelatedVendingMachineCommand(EntityKeyDto, RelatedEntityKeyDto);

public partial class DeleteRefBookingToBookingRelatedVendingMachineCommandHandler
	: RefBookingToBookingRelatedVendingMachineCommandHandlerBase<DeleteRefBookingToBookingRelatedVendingMachineCommand>
{
	public DeleteRefBookingToBookingRelatedVendingMachineCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider
		)
		: base(dbContext, noxSolution, serviceProvider, RelationshipAction.Delete)
	{ }
}

public record DeleteAllRefBookingToBookingRelatedVendingMachineCommand(BookingKeyDto EntityKeyDto)
	: RefBookingToBookingRelatedVendingMachineCommand(EntityKeyDto, null);

public partial class DeleteAllRefBookingToBookingRelatedVendingMachineCommandHandler
	: RefBookingToBookingRelatedVendingMachineCommandHandlerBase<DeleteAllRefBookingToBookingRelatedVendingMachineCommand>
{
	public DeleteAllRefBookingToBookingRelatedVendingMachineCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider
		)
		: base(dbContext, noxSolution, serviceProvider, RelationshipAction.DeleteAll)
	{ }
}

public abstract class RefBookingToBookingRelatedVendingMachineCommandHandlerBase<TRequest>: CommandBase<TRequest, Booking>, 
	IRequestHandler <TRequest, bool> where TRequest : RefBookingToBookingRelatedVendingMachineCommand
{
	public CryptocashDbContext DbContext { get; }

	public RelationshipAction Action { get; }

    public enum RelationshipAction { Create, Delete, DeleteAll };

	public RefBookingToBookingRelatedVendingMachineCommandHandlerBase(
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
		var keyId = CreateNoxTypeForKey<Booking, Nox.Types.Guid>("Id", request.EntityKeyDto.keyId);
		var entity = await DbContext.Bookings.FindAsync(keyId);
		if (entity == null)
		{
			return false;
		}

		VendingMachine? relatedEntity = null!;
		if(request.RelatedEntityKeyDto is not null)
		{
			var relatedKeyId = CreateNoxTypeForKey<VendingMachine, Nox.Types.Guid>("Id", request.RelatedEntityKeyDto.keyId);
			relatedEntity = await DbContext.VendingMachines.FindAsync(relatedKeyId);
			if (relatedEntity == null)
			{
				return false;
			}
		}
		
		switch (Action)
        {
            case RelationshipAction.Create:
                entity.CreateRefToBookingRelatedVendingMachine(relatedEntity);
                break;
            case RelationshipAction.Delete:
                entity.DeleteRefToBookingRelatedVendingMachine(relatedEntity);
                break;
            case RelationshipAction.DeleteAll:
                entity.DeleteAllRefToBookingRelatedVendingMachine();
                break;
        }

		OnCompleted(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}