
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
using TransactionEntity = Cryptocash.Domain.Transaction;

namespace Cryptocash.Application.Commands;

public abstract record RefTransactionToBookingCommand(TransactionKeyDto EntityKeyDto, BookingKeyDto? RelatedEntityKeyDto) : IRequest <bool>;

public record CreateRefTransactionToBookingCommand(TransactionKeyDto EntityKeyDto, BookingKeyDto RelatedEntityKeyDto)
	: RefTransactionToBookingCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class CreateRefTransactionToBookingCommandHandler
	: RefTransactionToBookingCommandHandlerBase<CreateRefTransactionToBookingCommand>
{
	public CreateRefTransactionToBookingCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Create)
	{ }
}

public record DeleteRefTransactionToBookingCommand(TransactionKeyDto EntityKeyDto, BookingKeyDto RelatedEntityKeyDto)
	: RefTransactionToBookingCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class DeleteRefTransactionToBookingCommandHandler
	: RefTransactionToBookingCommandHandlerBase<DeleteRefTransactionToBookingCommand>
{
	public DeleteRefTransactionToBookingCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Delete)
	{ }
}

public record DeleteAllRefTransactionToBookingCommand(TransactionKeyDto EntityKeyDto)
	: RefTransactionToBookingCommand(EntityKeyDto, null);

internal partial class DeleteAllRefTransactionToBookingCommandHandler
	: RefTransactionToBookingCommandHandlerBase<DeleteAllRefTransactionToBookingCommand>
{
	public DeleteAllRefTransactionToBookingCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.DeleteAll)
	{ }
}

internal abstract class RefTransactionToBookingCommandHandlerBase<TRequest> : CommandBase<TRequest, TransactionEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefTransactionToBookingCommand
{
	public AppDbContext DbContext { get; }

	public RelationshipAction Action { get; }

	public enum RelationshipAction { Create, Delete, DeleteAll };

	public RefTransactionToBookingCommandHandlerBase(
        AppDbContext dbContext,
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
		await OnExecutingAsync(request);
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
				entity.CreateRefToBooking(relatedEntity);
				break;
			case RelationshipAction.Delete:
				entity.DeleteRefToBooking(relatedEntity);
				break;
			case RelationshipAction.DeleteAll:
				entity.DeleteAllRefToBooking();
				break;
		}

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}