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
using BookingEntity = Cryptocash.Domain.Booking;

namespace Cryptocash.Application.Commands;

public abstract record RefBookingToTransactionCommand(BookingKeyDto EntityKeyDto) : IRequest <bool>;

#region CreateRefTo

public partial record CreateRefBookingToTransactionCommand(BookingKeyDto EntityKeyDto, TransactionKeyDto RelatedEntityKeyDto)
	: RefBookingToTransactionCommand(EntityKeyDto);

internal partial class CreateRefBookingToTransactionCommandHandler
	: RefBookingToTransactionCommandHandlerBase<CreateRefBookingToTransactionCommand>
{
	public CreateRefBookingToTransactionCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(CreateRefBookingToTransactionCommand request)
    {
		var entity = await GetBooking(request.EntityKeyDto);
		if (entity == null)
		{
			throw new EntityNotFoundException("Booking",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetBookingRelatedTransaction(request.RelatedEntityKeyDto);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("Transaction",  $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.CreateRefToTransaction(relatedEntity);

		return await SaveChangesAsync(request, entity);
    }
}

#endregion CreateRefTo

#region DeleteRefTo

public record DeleteRefBookingToTransactionCommand(BookingKeyDto EntityKeyDto, TransactionKeyDto RelatedEntityKeyDto)
	: RefBookingToTransactionCommand(EntityKeyDto);

internal partial class DeleteRefBookingToTransactionCommandHandler
	: RefBookingToTransactionCommandHandlerBase<DeleteRefBookingToTransactionCommand>
{
	public DeleteRefBookingToTransactionCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(DeleteRefBookingToTransactionCommand request)
    {
        var entity = await GetBooking(request.EntityKeyDto);
		if (entity == null)
		{
			throw new EntityNotFoundException("Booking",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetBookingRelatedTransaction(request.RelatedEntityKeyDto);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("Transaction", $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.DeleteRefToTransaction(relatedEntity);

		return await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteRefTo

#region DeleteAllRefTo

public record DeleteAllRefBookingToTransactionCommand(BookingKeyDto EntityKeyDto)
	: RefBookingToTransactionCommand(EntityKeyDto);

internal partial class DeleteAllRefBookingToTransactionCommandHandler
	: RefBookingToTransactionCommandHandlerBase<DeleteAllRefBookingToTransactionCommand>
{
	public DeleteAllRefBookingToTransactionCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(DeleteAllRefBookingToTransactionCommand request)
    {
        var entity = await GetBooking(request.EntityKeyDto);
		if (entity == null)
		{
			throw new EntityNotFoundException("Booking",  $"{request.EntityKeyDto.keyId.ToString()}");
		}
		entity.DeleteAllRefToTransaction();

		return await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteAllRefTo

internal abstract class RefBookingToTransactionCommandHandlerBase<TRequest> : CommandBase<TRequest, BookingEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefBookingToTransactionCommand
{
	public AppDbContext DbContext { get; }

	public RefBookingToTransactionCommandHandlerBase(
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
		var keyId = Dto.BookingMetadata.CreateId(entityKeyDto.keyId);
		return await DbContext.Bookings.FindAsync(keyId);
	}

	protected async Task<Cryptocash.Domain.Transaction?> GetBookingRelatedTransaction(TransactionKeyDto relatedEntityKeyDto)
	{
		var relatedKeyId = Dto.TransactionMetadata.CreateId(relatedEntityKeyDto.keyId);
		return await DbContext.Transactions.FindAsync(relatedKeyId);
	}

	protected async Task<bool> SaveChangesAsync(TRequest request, BookingEntity entity)
	{
		await OnCompletedAsync(request, entity);
		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}