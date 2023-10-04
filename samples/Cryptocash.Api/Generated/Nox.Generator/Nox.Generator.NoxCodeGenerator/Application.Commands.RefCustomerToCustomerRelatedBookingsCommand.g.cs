
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
using CustomerEntity = Cryptocash.Domain.Customer;

namespace Cryptocash.Application.Commands;

public abstract record RefCustomerToCustomerRelatedBookingsCommand(CustomerKeyDto EntityKeyDto, BookingKeyDto? RelatedEntityKeyDto) : IRequest <bool>;

public record CreateRefCustomerToCustomerRelatedBookingsCommand(CustomerKeyDto EntityKeyDto, BookingKeyDto RelatedEntityKeyDto)
	: RefCustomerToCustomerRelatedBookingsCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class CreateRefCustomerToCustomerRelatedBookingsCommandHandler
	: RefCustomerToCustomerRelatedBookingsCommandHandlerBase<CreateRefCustomerToCustomerRelatedBookingsCommand>
{
	public CreateRefCustomerToCustomerRelatedBookingsCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Create)
	{ }
}

public record DeleteRefCustomerToCustomerRelatedBookingsCommand(CustomerKeyDto EntityKeyDto, BookingKeyDto RelatedEntityKeyDto)
	: RefCustomerToCustomerRelatedBookingsCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class DeleteRefCustomerToCustomerRelatedBookingsCommandHandler
	: RefCustomerToCustomerRelatedBookingsCommandHandlerBase<DeleteRefCustomerToCustomerRelatedBookingsCommand>
{
	public DeleteRefCustomerToCustomerRelatedBookingsCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Delete)
	{ }
}

public record DeleteAllRefCustomerToCustomerRelatedBookingsCommand(CustomerKeyDto EntityKeyDto)
	: RefCustomerToCustomerRelatedBookingsCommand(EntityKeyDto, null);

internal partial class DeleteAllRefCustomerToCustomerRelatedBookingsCommandHandler
	: RefCustomerToCustomerRelatedBookingsCommandHandlerBase<DeleteAllRefCustomerToCustomerRelatedBookingsCommand>
{
	public DeleteAllRefCustomerToCustomerRelatedBookingsCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.DeleteAll)
	{ }
}

internal abstract class RefCustomerToCustomerRelatedBookingsCommandHandlerBase<TRequest> : CommandBase<TRequest, CustomerEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefCustomerToCustomerRelatedBookingsCommand
{
	public CryptocashDbContext DbContext { get; }

	public RelationshipAction Action { get; }

	public enum RelationshipAction { Create, Delete, DeleteAll };

	public RefCustomerToCustomerRelatedBookingsCommandHandlerBase(
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
		var keyId = Cryptocash.Domain.CustomerMetadata.CreateId(request.EntityKeyDto.keyId);
		var entity = await DbContext.Customers.FindAsync(keyId);
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
				entity.CreateRefToCustomerRelatedBookings(relatedEntity);
				break;
			case RelationshipAction.Delete:
				entity.DeleteRefToCustomerRelatedBookings(relatedEntity);
				break;
			case RelationshipAction.DeleteAll:
				await DbContext.Entry(entity).Collection(x => x.CustomerRelatedBookings).LoadAsync();
				entity.DeleteAllRefToCustomerRelatedBookings();
				break;
		}

		OnCompleted(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}