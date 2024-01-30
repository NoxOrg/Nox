// Generated

#nullable enable

using MediatR;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nox.Application;
using Nox.Application.Commands;
using Nox.Application.Factories;
using Nox.Solution;
using Nox.Domain;
using Nox.Types;
using Nox.Exceptions;

using Cryptocash.Domain;
using Cryptocash.Application.Dto;
using Dto = Cryptocash.Application.Dto;
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
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(CreateRefBookingToVendingMachineCommand request, CancellationToken cancellationToken)
    {
		var entity = await GetBooking(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("Booking",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetBookingRelatedVendingMachine(request.RelatedEntityKeyDto, cancellationToken);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("VendingMachine",  $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.CreateRefToVendingMachine(relatedEntity);

		await SaveChangesAsync(request, entity);
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
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(DeleteRefBookingToVendingMachineCommand request, CancellationToken cancellationToken)
    {
        var entity = await GetBooking(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("Booking",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetBookingRelatedVendingMachine(request.RelatedEntityKeyDto, cancellationToken);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("VendingMachine", $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.DeleteRefToVendingMachine(relatedEntity);

		await SaveChangesAsync(request, entity);
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
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(DeleteAllRefBookingToVendingMachineCommand request, CancellationToken cancellationToken)
    {
        var entity = await GetBooking(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("Booking",  $"{request.EntityKeyDto.keyId.ToString()}");
		}
		entity.DeleteAllRefToVendingMachine();

		await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteAllRefTo

internal abstract class RefBookingToVendingMachineCommandHandlerBase<TRequest> : CommandBase<TRequest, BookingEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefBookingToVendingMachineCommand
{
	public IRepository Repository { get; }

	public RefBookingToVendingMachineCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution)
		: base(noxSolution)
	{
		Repository = repository;
	}

	public virtual async Task<bool> Handle(TRequest request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		await ExecuteAsync(request, cancellationToken);
		return true;
	}

	protected abstract Task ExecuteAsync(TRequest request, CancellationToken cancellationToken);

	protected async Task<BookingEntity?> GetBooking(BookingKeyDto entityKeyDto, CancellationToken cancellationToken)
	{
		var keys = new List<object?>(1);
		keys.Add(Dto.BookingMetadata.CreateId(entityKeyDto.keyId));		
		return await Repository.FindAsync<Booking>(keys.ToArray(), cancellationToken);
	}

	protected async Task<Cryptocash.Domain.VendingMachine?> GetBookingRelatedVendingMachine(VendingMachineKeyDto relatedEntityKeyDto, CancellationToken cancellationToken)
	{
		var keys = new List<object?>(1);
		keys.Add(Dto.VendingMachineMetadata.CreateId(relatedEntityKeyDto.keyId));
		return await Repository.FindAsync<VendingMachine>(keys.ToArray(), cancellationToken);
	}

	protected async Task SaveChangesAsync(TRequest request, BookingEntity entity)
	{
		Repository.Update(entity);
		await OnCompletedAsync(request, entity);		
		await Repository.SaveChangesAsync();
	}
}