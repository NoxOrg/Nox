﻿
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

public abstract record RefBookingToBookingRelatedTransactionCommand(BookingKeyDto EntityKeyDto, TransactionKeyDto RelatedEntityKeyDto) : IRequest <bool>;

public record CreateRefBookingToBookingRelatedTransactionCommand(BookingKeyDto EntityKeyDto, TransactionKeyDto RelatedEntityKeyDto)
	: RefBookingToBookingRelatedTransactionCommand(EntityKeyDto, RelatedEntityKeyDto);

public partial class CreateRefBookingToBookingRelatedTransactionCommandHandler: RefBookingToBookingRelatedTransactionCommandHandlerBase<CreateRefBookingToBookingRelatedTransactionCommand>
{
	public CreateRefBookingToBookingRelatedTransactionCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider
		)
		: base(dbContext, noxSolution, serviceProvider, RelationshipAction.Create)
	{ }
}

public record DeleteRefBookingToBookingRelatedTransactionCommand(BookingKeyDto EntityKeyDto, TransactionKeyDto RelatedEntityKeyDto)
	: RefBookingToBookingRelatedTransactionCommand(EntityKeyDto, RelatedEntityKeyDto);

public partial class DeleteRefBookingToBookingRelatedTransactionCommandHandler: RefBookingToBookingRelatedTransactionCommandHandlerBase<DeleteRefBookingToBookingRelatedTransactionCommand>
{
	public DeleteRefBookingToBookingRelatedTransactionCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider
		)
		: base(dbContext, noxSolution, serviceProvider, RelationshipAction.Delete)
	{ }
}

public abstract class RefBookingToBookingRelatedTransactionCommandHandlerBase<TRequest>: CommandBase<TRequest, Booking>, 
	IRequestHandler <TRequest, bool> where TRequest : RefBookingToBookingRelatedTransactionCommand
{
	public CryptocashDbContext DbContext { get; }

	public RelationshipAction Action { get; }

    public enum RelationshipAction { Create, Delete };

	public RefBookingToBookingRelatedTransactionCommandHandlerBase(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		RelationshipAction action)
		: base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
		Action = action;
	}

	public virtual async Task<bool> Handle(TRequest request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = CreateNoxTypeForKey<Booking, Nox.Types.Guid>("Id", request.EntityKeyDto.keyId);
		var entity = await DbContext.Bookings.FindAsync(keyId);
		if (entity == null)
		{
			return false;
		}
		var relatedKeyId = CreateNoxTypeForKey<Transaction, Nox.Types.AutoNumber>("Id", request.RelatedEntityKeyDto.keyId);
		var relatedEntity = await DbContext.Transactions.FindAsync(relatedKeyId);
		if (relatedEntity == null)
		{
			return false;
		}
		
		switch (Action)
        {
            case RelationshipAction.Create:
                entity.CreateRefToBookingRelatedTransaction(relatedEntity);
                break;
            case RelationshipAction.Delete:
                entity.DeleteRefToBookingRelatedTransaction(relatedEntity);
                break;
        }

		OnCompleted(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}