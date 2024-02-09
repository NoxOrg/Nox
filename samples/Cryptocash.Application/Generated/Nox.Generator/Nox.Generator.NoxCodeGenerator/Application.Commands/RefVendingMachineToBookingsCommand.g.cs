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
using VendingMachineEntity = Cryptocash.Domain.VendingMachine;

namespace Cryptocash.Application.Commands;

public abstract record RefVendingMachineToBookingsCommand(VendingMachineKeyDto EntityKeyDto) : IRequest <bool>;

#region CreateRefTo

public partial record CreateRefVendingMachineToBookingsCommand(VendingMachineKeyDto EntityKeyDto, BookingKeyDto RelatedEntityKeyDto)
	: RefVendingMachineToBookingsCommand(EntityKeyDto);

internal partial class CreateRefVendingMachineToBookingsCommandHandler
	: RefVendingMachineToBookingsCommandHandlerBase<CreateRefVendingMachineToBookingsCommand>
{
	public CreateRefVendingMachineToBookingsCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(CreateRefVendingMachineToBookingsCommand request, CancellationToken cancellationToken)
    {
		var entity = await GetVendingMachine(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("VendingMachine",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetVendingMachineRelatedBookings(request.RelatedEntityKeyDto, cancellationToken);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("Booking",  $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.CreateRefToBookings(relatedEntity);

		await SaveChangesAsync(request, entity);
    }
}

#endregion CreateRefTo

#region UpdateRefTo

public partial record UpdateRefVendingMachineToBookingsCommand(VendingMachineKeyDto EntityKeyDto, List<BookingKeyDto> RelatedEntitiesKeysDtos)
	: RefVendingMachineToBookingsCommand(EntityKeyDto);

internal partial class UpdateRefVendingMachineToBookingsCommandHandler
	: RefVendingMachineToBookingsCommandHandlerBase<UpdateRefVendingMachineToBookingsCommand>
{
	public UpdateRefVendingMachineToBookingsCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(UpdateRefVendingMachineToBookingsCommand request, CancellationToken cancellationToken)
    {
		var entity = await GetVendingMachine(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("VendingMachine",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntities = new List<Cryptocash.Domain.Booking>();
		foreach(var keyDto in request.RelatedEntitiesKeysDtos)
		{
			var relatedEntity = await GetVendingMachineRelatedBookings(keyDto, cancellationToken);
			if (relatedEntity == null)
			{
				throw new RelatedEntityNotFoundException("Booking", $"{keyDto.keyId.ToString()}");
			}
			relatedEntities.Add(relatedEntity);
		}

		entity.UpdateRefToBookings(relatedEntities);

		await SaveChangesAsync(request, entity);
    }
}

#endregion UpdateRefTo

#region DeleteRefTo

public record DeleteRefVendingMachineToBookingsCommand(VendingMachineKeyDto EntityKeyDto, BookingKeyDto RelatedEntityKeyDto)
	: RefVendingMachineToBookingsCommand(EntityKeyDto);

internal partial class DeleteRefVendingMachineToBookingsCommandHandler
	: RefVendingMachineToBookingsCommandHandlerBase<DeleteRefVendingMachineToBookingsCommand>
{
	public DeleteRefVendingMachineToBookingsCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(DeleteRefVendingMachineToBookingsCommand request, CancellationToken cancellationToken)
    {
        var entity = await GetVendingMachine(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("VendingMachine",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetVendingMachineRelatedBookings(request.RelatedEntityKeyDto, cancellationToken);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("Booking", $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.DeleteRefToBookings(relatedEntity);

		await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteRefTo

#region DeleteAllRefTo

public record DeleteAllRefVendingMachineToBookingsCommand(VendingMachineKeyDto EntityKeyDto)
	: RefVendingMachineToBookingsCommand(EntityKeyDto);

internal partial class DeleteAllRefVendingMachineToBookingsCommandHandler
	: RefVendingMachineToBookingsCommandHandlerBase<DeleteAllRefVendingMachineToBookingsCommand>
{
	public DeleteAllRefVendingMachineToBookingsCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(DeleteAllRefVendingMachineToBookingsCommand request, CancellationToken cancellationToken)
    {
        var entity = await GetVendingMachine(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("VendingMachine",  $"{request.EntityKeyDto.keyId.ToString()}");
		}
		entity.DeleteAllRefToBookings();

		await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteAllRefTo

internal abstract class RefVendingMachineToBookingsCommandHandlerBase<TRequest> : CommandBase<TRequest, VendingMachineEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefVendingMachineToBookingsCommand
{
	public IRepository Repository { get; }

	public RefVendingMachineToBookingsCommandHandlerBase(
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

	protected async Task<VendingMachineEntity?> GetVendingMachine(VendingMachineKeyDto entityKeyDto, CancellationToken cancellationToken)
	{
		var keys = new List<object?>(1);
		keys.Add(Dto.VendingMachineMetadata.CreateId(entityKeyDto.keyId));
		return await Repository.FindAndIncludeAsync<Cryptocash.Domain.VendingMachine>(keys.ToArray(), x => x.Bookings, cancellationToken);
	}

	protected async Task<Cryptocash.Domain.Booking?> GetVendingMachineRelatedBookings(BookingKeyDto relatedEntityKeyDto, CancellationToken cancellationToken)
	{
		var keys = new List<object?>(1);
		keys.Add(Dto.BookingMetadata.CreateId(relatedEntityKeyDto.keyId));
		return await Repository.FindAsync<Cryptocash.Domain.Booking>(keys.ToArray(), cancellationToken);
	}

	protected async Task SaveChangesAsync(TRequest request, VendingMachineEntity entity)
	{
		Repository.Update(entity);
		await OnCompletedAsync(request, entity);		
		await Repository.SaveChangesAsync();
	}
}