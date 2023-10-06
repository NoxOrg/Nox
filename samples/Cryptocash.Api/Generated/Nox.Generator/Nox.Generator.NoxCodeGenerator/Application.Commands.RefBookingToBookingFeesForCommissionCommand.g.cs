
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

public abstract record RefBookingToBookingFeesForCommissionCommand(BookingKeyDto EntityKeyDto, CommissionKeyDto? RelatedEntityKeyDto) : IRequest <bool>;

public record CreateRefBookingToBookingFeesForCommissionCommand(BookingKeyDto EntityKeyDto, CommissionKeyDto RelatedEntityKeyDto)
	: RefBookingToBookingFeesForCommissionCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class CreateRefBookingToBookingFeesForCommissionCommandHandler
	: RefBookingToBookingFeesForCommissionCommandHandlerBase<CreateRefBookingToBookingFeesForCommissionCommand>
{
	public CreateRefBookingToBookingFeesForCommissionCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Create)
	{ }
}

public record DeleteRefBookingToBookingFeesForCommissionCommand(BookingKeyDto EntityKeyDto, CommissionKeyDto RelatedEntityKeyDto)
	: RefBookingToBookingFeesForCommissionCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class DeleteRefBookingToBookingFeesForCommissionCommandHandler
	: RefBookingToBookingFeesForCommissionCommandHandlerBase<DeleteRefBookingToBookingFeesForCommissionCommand>
{
	public DeleteRefBookingToBookingFeesForCommissionCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Delete)
	{ }
}

public record DeleteAllRefBookingToBookingFeesForCommissionCommand(BookingKeyDto EntityKeyDto)
	: RefBookingToBookingFeesForCommissionCommand(EntityKeyDto, null);

internal partial class DeleteAllRefBookingToBookingFeesForCommissionCommandHandler
	: RefBookingToBookingFeesForCommissionCommandHandlerBase<DeleteAllRefBookingToBookingFeesForCommissionCommand>
{
	public DeleteAllRefBookingToBookingFeesForCommissionCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.DeleteAll)
	{ }
}

internal abstract class RefBookingToBookingFeesForCommissionCommandHandlerBase<TRequest> : CommandBase<TRequest, BookingEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefBookingToBookingFeesForCommissionCommand
{
	public CryptocashDbContext DbContext { get; }

	public RelationshipAction Action { get; }

	public enum RelationshipAction { Create, Delete, DeleteAll };

	public RefBookingToBookingFeesForCommissionCommandHandlerBase(
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

		Cryptocash.Domain.Commission? relatedEntity = null!;
		if(request.RelatedEntityKeyDto is not null)
		{
			var relatedKeyId = Cryptocash.Domain.CommissionMetadata.CreateId(request.RelatedEntityKeyDto.keyId);
			relatedEntity = await DbContext.Commissions.FindAsync(relatedKeyId);
			if (relatedEntity == null)
			{
				return false;
			}
		}

		switch (Action)
		{
			case RelationshipAction.Create:
				entity.CreateRefToBookingFeesForCommission(relatedEntity);
				break;
			case RelationshipAction.Delete:
				entity.DeleteRefToBookingFeesForCommission(relatedEntity);
				break;
			case RelationshipAction.DeleteAll:
				entity.DeleteAllRefToBookingFeesForCommission();
				break;
		}

		OnCompleted(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}