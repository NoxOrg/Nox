
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

public record CreateRefBookingToBookingRelatedTransactionCommand(BookingKeyDto EntityKeyDto, TransactionKeyDto RelatedEntityKeyDto) : IRequest <bool>;

public partial class CreateRefBookingToBookingRelatedTransactionCommandHandler: CreateRefBookingToBookingRelatedTransactionCommandHandlerBase
{
	public CreateRefBookingToBookingRelatedTransactionCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider
		)
		: base(dbContext, noxSolution, serviceProvider)
	{ }
}

public abstract class CreateRefBookingToBookingRelatedTransactionCommandHandlerBase: CommandBase<CreateRefBookingToBookingRelatedTransactionCommand, Booking>, 
	IRequestHandler <CreateRefBookingToBookingRelatedTransactionCommand, bool>
{
	public CryptocashDbContext DbContext { get; }

	public CreateRefBookingToBookingRelatedTransactionCommandHandlerBase(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
	}

	public virtual async Task<bool> Handle(CreateRefBookingToBookingRelatedTransactionCommand request, CancellationToken cancellationToken)
	{
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

		entity.CreateRefToTransactionBookingRelatedTransaction(relatedEntity);

		OnCompleted(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}