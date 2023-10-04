
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
using BookingEntity = Cryptocash.Domain.Booking;

namespace Cryptocash.Application.Commands;

public abstract record RefBookingToBookingRelatedTransactionCommand(BookingKeyDto EntityKeyDto, TransactionKeyDto? RelatedEntityKeyDto) : IRequest <bool>;

public record CreateRefBookingToBookingRelatedTransactionCommand(BookingKeyDto EntityKeyDto, TransactionKeyDto RelatedEntityKeyDto)
	: RefBookingToBookingRelatedTransactionCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class CreateRefBookingToBookingRelatedTransactionCommandHandler
	: RefBookingToBookingRelatedTransactionCommandHandlerBase<CreateRefBookingToBookingRelatedTransactionCommand>
{
	public CreateRefBookingToBookingRelatedTransactionCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Create)
	{ }
}

public record DeleteRefBookingToBookingRelatedTransactionCommand(BookingKeyDto EntityKeyDto, TransactionKeyDto RelatedEntityKeyDto)
	: RefBookingToBookingRelatedTransactionCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class DeleteRefBookingToBookingRelatedTransactionCommandHandler
	: RefBookingToBookingRelatedTransactionCommandHandlerBase<DeleteRefBookingToBookingRelatedTransactionCommand>
{
	public DeleteRefBookingToBookingRelatedTransactionCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Delete)
	{ }
}

public record DeleteAllRefBookingToBookingRelatedTransactionCommand(BookingKeyDto EntityKeyDto)
	: RefBookingToBookingRelatedTransactionCommand(EntityKeyDto, null);

internal partial class DeleteAllRefBookingToBookingRelatedTransactionCommandHandler
	: RefBookingToBookingRelatedTransactionCommandHandlerBase<DeleteAllRefBookingToBookingRelatedTransactionCommand>
{
	public DeleteAllRefBookingToBookingRelatedTransactionCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.DeleteAll)
	{ }
}

internal abstract class RefBookingToBookingRelatedTransactionCommandHandlerBase<TRequest> : CommandBase<TRequest, BookingEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefBookingToBookingRelatedTransactionCommand
{
	public CryptocashDbContext DbContext { get; }

	public RelationshipAction Action { get; }

	public enum RelationshipAction { Create, Delete, DeleteAll };

	public RefBookingToBookingRelatedTransactionCommandHandlerBase(
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
		var keyId = Cryptocash.Domain.BookingMetadata.CreateId(request.EntityKeyDto.keyId);
		var entity = await DbContext.Bookings.FindAsync(keyId);
		if (entity == null)
		{
			return false;
		}

		Cryptocash.Domain.Transaction? relatedEntity = null!;
		if(request.RelatedEntityKeyDto is not null)
		{
			var relatedKeyId = Cryptocash.Domain.TransactionMetadata.CreateId(request.RelatedEntityKeyDto.keyId);
			relatedEntity = await DbContext.Transactions.FindAsync(relatedKeyId);
			if (relatedEntity == null)
			{
				return false;
			}
		}

		switch (Action)
		{
			case RelationshipAction.Create:
				entity.CreateRefToBookingRelatedTransaction(relatedEntity);
				break;
			case RelationshipAction.Delete:
				entity.DeleteRefToBookingRelatedTransaction(relatedEntity);
				break;
			case RelationshipAction.DeleteAll:
				entity.DeleteAllRefToBookingRelatedTransaction();
				break;
		}

		OnCompleted(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}