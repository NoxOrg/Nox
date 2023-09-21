
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

public abstract record RefTransactionToTransactionForBookingCommand(TransactionKeyDto EntityKeyDto, BookingKeyDto RelatedEntityKeyDto) : IRequest <bool>;

public record CreateRefTransactionToTransactionForBookingCommand(TransactionKeyDto EntityKeyDto, BookingKeyDto RelatedEntityKeyDto)
	: RefTransactionToTransactionForBookingCommand(EntityKeyDto, RelatedEntityKeyDto);

public partial class CreateRefTransactionToTransactionForBookingCommandHandler: RefTransactionToTransactionForBookingCommandHandlerBase<CreateRefTransactionToTransactionForBookingCommand>
{
	public CreateRefTransactionToTransactionForBookingCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider
		)
		: base(dbContext, noxSolution, serviceProvider, RelationshipAction.Create)
	{ }
}

public record DeleteRefTransactionToTransactionForBookingCommand(TransactionKeyDto EntityKeyDto, BookingKeyDto RelatedEntityKeyDto)
	: RefTransactionToTransactionForBookingCommand(EntityKeyDto, RelatedEntityKeyDto);

public partial class DeleteRefTransactionToTransactionForBookingCommandHandler: RefTransactionToTransactionForBookingCommandHandlerBase<DeleteRefTransactionToTransactionForBookingCommand>
{
	public DeleteRefTransactionToTransactionForBookingCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider
		)
		: base(dbContext, noxSolution, serviceProvider, RelationshipAction.Delete)
	{ }
}

public abstract class RefTransactionToTransactionForBookingCommandHandlerBase<TRequest>: CommandBase<TRequest, Transaction>, 
	IRequestHandler <TRequest, bool> where TRequest : RefTransactionToTransactionForBookingCommand
{
	public CryptocashDbContext DbContext { get; }

	public RelationshipAction Action { get; }

    public enum RelationshipAction { Create, Delete };

	public RefTransactionToTransactionForBookingCommandHandlerBase(
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
		var keyId = CreateNoxTypeForKey<Transaction, Nox.Types.AutoNumber>("Id", request.EntityKeyDto.keyId);
		var entity = await DbContext.Transactions.FindAsync(keyId);
		if (entity == null)
		{
			return false;
		}
		var relatedKeyId = CreateNoxTypeForKey<Booking, Nox.Types.Guid>("Id", request.RelatedEntityKeyDto.keyId);
		var relatedEntity = await DbContext.Bookings.FindAsync(relatedKeyId);
		if (relatedEntity == null)
		{
			return false;
		}
		
		switch (Action)
        {
            case RelationshipAction.Create:
                entity.CreateRefToTransactionForBooking(relatedEntity);
                break;
            case RelationshipAction.Delete:
                entity.DeleteRefToTransactionForBooking(relatedEntity);
                break;
        }

		OnCompleted(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}