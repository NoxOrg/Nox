
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
using TransactionEntity = Cryptocash.Domain.Transaction;

namespace Cryptocash.Application.Commands;

public abstract record RefTransactionToTransactionForBookingCommand(TransactionKeyDto EntityKeyDto, BookingKeyDto? RelatedEntityKeyDto) : IRequest <bool>;

public record CreateRefTransactionToTransactionForBookingCommand(TransactionKeyDto EntityKeyDto, BookingKeyDto RelatedEntityKeyDto)
	: RefTransactionToTransactionForBookingCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class CreateRefTransactionToTransactionForBookingCommandHandler
	: RefTransactionToTransactionForBookingCommandHandlerBase<CreateRefTransactionToTransactionForBookingCommand>
{
	public CreateRefTransactionToTransactionForBookingCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Create)
	{ }
}

public record DeleteRefTransactionToTransactionForBookingCommand(TransactionKeyDto EntityKeyDto, BookingKeyDto RelatedEntityKeyDto)
	: RefTransactionToTransactionForBookingCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class DeleteRefTransactionToTransactionForBookingCommandHandler
	: RefTransactionToTransactionForBookingCommandHandlerBase<DeleteRefTransactionToTransactionForBookingCommand>
{
	public DeleteRefTransactionToTransactionForBookingCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Delete)
	{ }
}

public record DeleteAllRefTransactionToTransactionForBookingCommand(TransactionKeyDto EntityKeyDto)
	: RefTransactionToTransactionForBookingCommand(EntityKeyDto, null);

internal partial class DeleteAllRefTransactionToTransactionForBookingCommandHandler
	: RefTransactionToTransactionForBookingCommandHandlerBase<DeleteAllRefTransactionToTransactionForBookingCommand>
{
	public DeleteAllRefTransactionToTransactionForBookingCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.DeleteAll)
	{ }
}

internal abstract class RefTransactionToTransactionForBookingCommandHandlerBase<TRequest> : CommandBase<TRequest, TransactionEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefTransactionToTransactionForBookingCommand
{
	public CryptocashDbContext DbContext { get; }

	public RelationshipAction Action { get; }

	public enum RelationshipAction { Create, Delete, DeleteAll };

	public RefTransactionToTransactionForBookingCommandHandlerBase(
		CryptocashDbContext dbContext,
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
		OnExecuting(request);
		var keyId = Cryptocash.Domain.TransactionMetadata.CreateId(request.EntityKeyDto.keyId);
		var entity = await DbContext.Transactions.FindAsync(keyId);
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
				entity.CreateRefToTransactionForBooking(relatedEntity);
				break;
			case RelationshipAction.Delete:
				entity.DeleteRefToTransactionForBooking(relatedEntity);
				break;
			case RelationshipAction.DeleteAll:
				entity.DeleteAllRefToTransactionForBooking();
				break;
		}

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}