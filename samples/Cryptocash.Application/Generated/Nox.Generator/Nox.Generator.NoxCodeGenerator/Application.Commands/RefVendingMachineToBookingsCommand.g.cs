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
using Nox.Exceptions;

using Cryptocash.Infrastructure.Persistence;
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
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(CreateRefVendingMachineToBookingsCommand request)
    {
		var entity = await GetVendingMachine(request.EntityKeyDto);
		if (entity == null)
		{
			throw new EntityNotFoundException("VendingMachine",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetBooking(request.RelatedEntityKeyDto);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("Booking",  $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.CreateRefToBookings(relatedEntity);

		return await SaveChangesAsync(request, entity);
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
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(UpdateRefVendingMachineToBookingsCommand request)
    {
		var entity = await GetVendingMachine(request.EntityKeyDto);
		if (entity == null)
		{
			throw new EntityNotFoundException("VendingMachine",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntities = new List<Cryptocash.Domain.Booking>();
		foreach(var keyDto in request.RelatedEntitiesKeysDtos)
		{
			var relatedEntity = await GetBooking(keyDto);
			if (relatedEntity == null)
			{
				throw new RelatedEntityNotFoundException("Booking", $"{keyDto.keyId.ToString()}");
			}
			relatedEntities.Add(relatedEntity);
		}

		await DbContext.Entry(entity).Collection(x => x.Bookings).LoadAsync();
		entity.UpdateRefToBookings(relatedEntities);

		return await SaveChangesAsync(request, entity);
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
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(DeleteRefVendingMachineToBookingsCommand request)
    {
        var entity = await GetVendingMachine(request.EntityKeyDto);
		if (entity == null)
		{
			throw new EntityNotFoundException("VendingMachine",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetBooking(request.RelatedEntityKeyDto);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("Booking", $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.DeleteRefToBookings(relatedEntity);

		return await SaveChangesAsync(request, entity);
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
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(DeleteAllRefVendingMachineToBookingsCommand request)
    {
        var entity = await GetVendingMachine(request.EntityKeyDto);
		if (entity == null)
		{
			throw new EntityNotFoundException("VendingMachine",  $"{request.EntityKeyDto.keyId.ToString()}");
		}
		await DbContext.Entry(entity).Collection(x => x.Bookings).LoadAsync();
		entity.DeleteAllRefToBookings();

		return await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteAllRefTo

internal abstract class RefVendingMachineToBookingsCommandHandlerBase<TRequest> : CommandBase<TRequest, VendingMachineEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefVendingMachineToBookingsCommand
{
	public AppDbContext DbContext { get; }

	public RefVendingMachineToBookingsCommandHandlerBase(
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

	protected async Task<VendingMachineEntity?> GetVendingMachine(VendingMachineKeyDto entityKeyDto)
	{
		var keyId = Dto.VendingMachineMetadata.CreateId(entityKeyDto.keyId);
		return await DbContext.VendingMachines.FindAsync(keyId);
	}

	protected async Task<Cryptocash.Domain.Booking?> GetBooking(BookingKeyDto relatedEntityKeyDto)
	{
		var relatedKeyId = Dto.BookingMetadata.CreateId(relatedEntityKeyDto.keyId);
		return await DbContext.Bookings.FindAsync(relatedKeyId);
	}

	protected async Task<bool> SaveChangesAsync(TRequest request, VendingMachineEntity entity)
	{
		await OnCompletedAsync(request, entity);
		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}