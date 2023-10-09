
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

public abstract record RefBookingToBookingForCustomerCommand(BookingKeyDto EntityKeyDto, CustomerKeyDto? RelatedEntityKeyDto) : IRequest <bool>;

public record CreateRefBookingToBookingForCustomerCommand(BookingKeyDto EntityKeyDto, CustomerKeyDto RelatedEntityKeyDto)
	: RefBookingToBookingForCustomerCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class CreateRefBookingToBookingForCustomerCommandHandler
	: RefBookingToBookingForCustomerCommandHandlerBase<CreateRefBookingToBookingForCustomerCommand>
{
	public CreateRefBookingToBookingForCustomerCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Create)
	{ }
}

public record DeleteRefBookingToBookingForCustomerCommand(BookingKeyDto EntityKeyDto, CustomerKeyDto RelatedEntityKeyDto)
	: RefBookingToBookingForCustomerCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class DeleteRefBookingToBookingForCustomerCommandHandler
	: RefBookingToBookingForCustomerCommandHandlerBase<DeleteRefBookingToBookingForCustomerCommand>
{
	public DeleteRefBookingToBookingForCustomerCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Delete)
	{ }
}

public record DeleteAllRefBookingToBookingForCustomerCommand(BookingKeyDto EntityKeyDto)
	: RefBookingToBookingForCustomerCommand(EntityKeyDto, null);

internal partial class DeleteAllRefBookingToBookingForCustomerCommandHandler
	: RefBookingToBookingForCustomerCommandHandlerBase<DeleteAllRefBookingToBookingForCustomerCommand>
{
	public DeleteAllRefBookingToBookingForCustomerCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.DeleteAll)
	{ }
}

internal abstract class RefBookingToBookingForCustomerCommandHandlerBase<TRequest> : CommandBase<TRequest, BookingEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefBookingToBookingForCustomerCommand
{
	public CryptocashDbContext DbContext { get; }

	public RelationshipAction Action { get; }

	public enum RelationshipAction { Create, Delete, DeleteAll };

	public RefBookingToBookingForCustomerCommandHandlerBase(
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

		Cryptocash.Domain.Customer? relatedEntity = null!;
		if(request.RelatedEntityKeyDto is not null)
		{
			var relatedKeyId = Cryptocash.Domain.CustomerMetadata.CreateId(request.RelatedEntityKeyDto.keyId);
			relatedEntity = await DbContext.Customers.FindAsync(relatedKeyId);
			if (relatedEntity == null)
			{
				return false;
			}
		}

		switch (Action)
		{
			case RelationshipAction.Create:
				entity.CreateRefToBookingForCustomer(relatedEntity);
				break;
			case RelationshipAction.Delete:
				entity.DeleteRefToBookingForCustomer(relatedEntity);
				break;
			case RelationshipAction.DeleteAll:
				entity.DeleteAllRefToBookingForCustomer();
				break;
		}

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}