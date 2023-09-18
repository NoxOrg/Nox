
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

public record CreateRefVendingMachineToVendingMachineRelatedBookingsCommand(VendingMachineKeyDto EntityKeyDto, BookingKeyDto RelatedEntityKeyDto) : IRequest <bool>;

public partial class CreateRefVendingMachineToVendingMachineRelatedBookingsCommandHandler: CreateRefVendingMachineToVendingMachineRelatedBookingsCommandHandlerBase
{
	public CreateRefVendingMachineToVendingMachineRelatedBookingsCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider
		)
		: base(dbContext, noxSolution, serviceProvider)
	{ }
}

public abstract class CreateRefVendingMachineToVendingMachineRelatedBookingsCommandHandlerBase: CommandBase<CreateRefVendingMachineToVendingMachineRelatedBookingsCommand, VendingMachine>, 
	IRequestHandler <CreateRefVendingMachineToVendingMachineRelatedBookingsCommand, bool>
{
	public CryptocashDbContext DbContext { get; }

	public CreateRefVendingMachineToVendingMachineRelatedBookingsCommandHandlerBase(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
	}

	public virtual async Task<bool> Handle(CreateRefVendingMachineToVendingMachineRelatedBookingsCommand request, CancellationToken cancellationToken)
	{
		OnExecuting(request);
		var keyId = CreateNoxTypeForKey<VendingMachine, Nox.Types.Guid>("Id", request.EntityKeyDto.keyId);
		var entity = await DbContext.VendingMachines.FindAsync(keyId);
		if (entity == null)
		{
			return false;
		}
		var relatedKeyId = CreateNoxTypeForKey<Booking, Nox.Types.Guid>("Id", request.RelatedEntityKeyDto.keyId);
		var relatedEntity = await DbContext.Bookings.FindAsync(relatedKeyId);
		if (relatedEntity == null)
		{
			return false;
		}

		entity.CreateRefToBookingVendingMachineRelatedBookings(relatedEntity);

		OnCompleted(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}