
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

public abstract record RefBookingToVendingMachineCommand(BookingKeyDto EntityKeyDto) : IRequest <bool>;

#region CreateRefTo

public partial record CreateRefBookingToVendingMachineCommand(BookingKeyDto EntityKeyDto, VendingMachineKeyDto RelatedEntityKeyDto)
	: RefBookingToVendingMachineCommand(EntityKeyDto);

internal partial class CreateRefBookingToVendingMachineCommandHandler
	: RefBookingToVendingMachineCommandHandlerBase<CreateRefBookingToVendingMachineCommand>
{
	public CreateRefBookingToVendingMachineCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(CreateRefBookingToVendingMachineCommand request)
    {
		var entity = await GetBooking(request.EntityKeyDto);
		if (entity == null)
		{
			return false;
		}

		var relatedEntity = await GetVendingMachine(request.RelatedEntityKeyDto);
		if (relatedEntity == null)
		{
			return false;
		}

		entity.CreateRefToVendingMachine(relatedEntity);

		return await SaveChangesAsync(request, entity);
    }
}

#endregion CreateRefTo

#region DeleteRefTo

public record DeleteRefBookingToVendingMachineCommand(BookingKeyDto EntityKeyDto, VendingMachineKeyDto RelatedEntityKeyDto)
	: RefBookingToVendingMachineCommand(EntityKeyDto);

internal partial class DeleteRefBookingToVendingMachineCommandHandler
	: RefBookingToVendingMachineCommandHandlerBase<DeleteRefBookingToVendingMachineCommand>
{
	public DeleteRefBookingToVendingMachineCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(DeleteRefBookingToVendingMachineCommand request)
    {
        var entity = await GetBooking(request.EntityKeyDto);
		if (entity == null)
		{
			return false;
		}

		var relatedEntity = await GetVendingMachine(request.RelatedEntityKeyDto);
		if (relatedEntity == null)
		{
			return false;
		}

		entity.DeleteRefToVendingMachine(relatedEntity);

		return await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteRefTo

#region DeleteAllRefTo

public record DeleteAllRefBookingToVendingMachineCommand(BookingKeyDto EntityKeyDto)
	: RefBookingToVendingMachineCommand(EntityKeyDto);

internal partial class DeleteAllRefBookingToVendingMachineCommandHandler
	: RefBookingToVendingMachineCommandHandlerBase<DeleteAllRefBookingToVendingMachineCommand>
{
	public DeleteAllRefBookingToVendingMachineCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(DeleteAllRefBookingToVendingMachineCommand request)
    {
        var entity = await GetBooking(request.EntityKeyDto);
		if (entity == null)
		{
			return false;
		}
		entity.DeleteAllRefToVendingMachine();

		return await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteAllRefTo

internal abstract class RefBookingToVendingMachineCommandHandlerBase<TRequest> : CommandBase<TRequest, BookingEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefBookingToVendingMachineCommand
{
	public AppDbContext DbContext { get; }

	public RefBookingToVendingMachineCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution)
		: base(noxSolution)
	{
		DbContext = dbContext;
	}

	public virtual async Task<bool> Handle(TRequest request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		return await ExecuteAsync(request);
	}

	protected abstract Task<bool> ExecuteAsync(TRequest request);

	protected async Task<BookingEntity?> GetBooking(BookingKeyDto entityKeyDto)
	{
		var keyId = Cryptocash.Domain.BookingMetadata.CreateId(entityKeyDto.keyId);
		return await DbContext.Bookings.FindAsync(keyId);
	}

	protected async Task<Cryptocash.Domain.VendingMachine?> GetVendingMachine(VendingMachineKeyDto relatedEntityKeyDto)
	{
		var relatedKeyId = Cryptocash.Domain.VendingMachineMetadata.CreateId(relatedEntityKeyDto.keyId);
		return await DbContext.VendingMachines.FindAsync(relatedKeyId);
	}

	protected async Task<bool> SaveChangesAsync(TRequest request, BookingEntity entity)
	{
		await OnCompletedAsync(request, entity);
		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		if (result < 1)
		{
			return false;
		}
		return true;
	}
}