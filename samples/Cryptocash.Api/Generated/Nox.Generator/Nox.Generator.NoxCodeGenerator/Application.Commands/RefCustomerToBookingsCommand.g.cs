
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
using CustomerEntity = Cryptocash.Domain.Customer;

namespace Cryptocash.Application.Commands;

public abstract record RefCustomerToBookingsCommand(CustomerKeyDto EntityKeyDto, BookingKeyDto? RelatedEntityKeyDto) : IRequest <bool>;

public partial record CreateRefCustomerToBookingsCommand(CustomerKeyDto EntityKeyDto, BookingKeyDto RelatedEntityKeyDto)
	: RefCustomerToBookingsCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class CreateRefCustomerToBookingsCommandHandler
	: RefCustomerToBookingsCommandHandlerBase<CreateRefCustomerToBookingsCommand>
{
	public CreateRefCustomerToBookingsCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Create)
	{ }
}

public record DeleteRefCustomerToBookingsCommand(CustomerKeyDto EntityKeyDto, BookingKeyDto RelatedEntityKeyDto)
	: RefCustomerToBookingsCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class DeleteRefCustomerToBookingsCommandHandler
	: RefCustomerToBookingsCommandHandlerBase<DeleteRefCustomerToBookingsCommand>
{
	public DeleteRefCustomerToBookingsCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Delete)
	{ }
}

public record DeleteAllRefCustomerToBookingsCommand(CustomerKeyDto EntityKeyDto)
	: RefCustomerToBookingsCommand(EntityKeyDto, null);

internal partial class DeleteAllRefCustomerToBookingsCommandHandler
	: RefCustomerToBookingsCommandHandlerBase<DeleteAllRefCustomerToBookingsCommand>
{
	public DeleteAllRefCustomerToBookingsCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.DeleteAll)
	{ }
}

internal abstract class RefCustomerToBookingsCommandHandlerBase<TRequest> : CommandBase<TRequest, CustomerEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefCustomerToBookingsCommand
{
	public AppDbContext DbContext { get; }

	public RelationshipAction Action { get; }

	public enum RelationshipAction { Create, Delete, DeleteAll };

	public RefCustomerToBookingsCommandHandlerBase(
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
				entity.CreateRefToBookings(relatedEntity);
				break;
			case RelationshipAction.Delete:
				entity.DeleteRefToBookings(relatedEntity);
				break;
			case RelationshipAction.DeleteAll:
				await DbContext.Entry(entity).Collection(x => x.Bookings).LoadAsync();
				entity.DeleteAllRefToBookings();
				break;
		}

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}