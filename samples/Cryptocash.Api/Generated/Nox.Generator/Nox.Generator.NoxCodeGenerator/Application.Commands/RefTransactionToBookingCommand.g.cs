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
using TransactionEntity = Cryptocash.Domain.Transaction;

namespace Cryptocash.Application.Commands;

public abstract record RefTransactionToBookingCommand(TransactionKeyDto EntityKeyDto) : IRequest <bool>;

#region CreateRefTo

public partial record CreateRefTransactionToBookingCommand(TransactionKeyDto EntityKeyDto, BookingKeyDto RelatedEntityKeyDto)
	: RefTransactionToBookingCommand(EntityKeyDto);

internal partial class CreateRefTransactionToBookingCommandHandler
	: RefTransactionToBookingCommandHandlerBase<CreateRefTransactionToBookingCommand>
{
	public CreateRefTransactionToBookingCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(CreateRefTransactionToBookingCommand request)
    {
		var entity = await GetTransaction(request.EntityKeyDto);
		if (entity == null)
		{
			throw new EntityNotFoundException("Transaction",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetBooking(request.RelatedEntityKeyDto);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("Booking",  $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.CreateRefToBooking(relatedEntity);

		return await SaveChangesAsync(request, entity);
    }
}

#endregion CreateRefTo

#region DeleteRefTo

public record DeleteRefTransactionToBookingCommand(TransactionKeyDto EntityKeyDto, BookingKeyDto RelatedEntityKeyDto)
	: RefTransactionToBookingCommand(EntityKeyDto);

internal partial class DeleteRefTransactionToBookingCommandHandler
	: RefTransactionToBookingCommandHandlerBase<DeleteRefTransactionToBookingCommand>
{
	public DeleteRefTransactionToBookingCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(DeleteRefTransactionToBookingCommand request)
    {
        var entity = await GetTransaction(request.EntityKeyDto);
		if (entity == null)
		{
			throw new EntityNotFoundException("Transaction",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetBooking(request.RelatedEntityKeyDto);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("Booking", $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.DeleteRefToBooking(relatedEntity);

		return await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteRefTo

#region DeleteAllRefTo

public record DeleteAllRefTransactionToBookingCommand(TransactionKeyDto EntityKeyDto)
	: RefTransactionToBookingCommand(EntityKeyDto);

internal partial class DeleteAllRefTransactionToBookingCommandHandler
	: RefTransactionToBookingCommandHandlerBase<DeleteAllRefTransactionToBookingCommand>
{
	public DeleteAllRefTransactionToBookingCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(DeleteAllRefTransactionToBookingCommand request)
    {
        var entity = await GetTransaction(request.EntityKeyDto);
		if (entity == null)
		{
			throw new EntityNotFoundException("Transaction",  $"{request.EntityKeyDto.keyId.ToString()}");
		}
		entity.DeleteAllRefToBooking();

		return await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteAllRefTo

internal abstract class RefTransactionToBookingCommandHandlerBase<TRequest> : CommandBase<TRequest, TransactionEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefTransactionToBookingCommand
{
	public AppDbContext DbContext { get; }

	public RefTransactionToBookingCommandHandlerBase(
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

	protected async Task<TransactionEntity?> GetTransaction(TransactionKeyDto entityKeyDto)
	{
		var keyId = Cryptocash.Domain.TransactionMetadata.CreateId(entityKeyDto.keyId);
		return await DbContext.Transactions.FindAsync(keyId);
	}

	protected async Task<Cryptocash.Domain.Booking?> GetBooking(BookingKeyDto relatedEntityKeyDto)
	{
		var relatedKeyId = Cryptocash.Domain.BookingMetadata.CreateId(relatedEntityKeyDto.keyId);
		return await DbContext.Bookings.FindAsync(relatedKeyId);
	}

	protected async Task<bool> SaveChangesAsync(TRequest request, TransactionEntity entity)
	{
		await OnCompletedAsync(request, entity);
		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}