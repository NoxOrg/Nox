
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
using BookingEntity = Cryptocash.Domain.Booking;

namespace Cryptocash.Application.Commands;

public abstract record RefBookingToCommissionCommand(BookingKeyDto EntityKeyDto, CommissionKeyDto? RelatedEntityKeyDto) : IRequest <bool>;

public partial record CreateRefBookingToCommissionCommand(BookingKeyDto EntityKeyDto, CommissionKeyDto RelatedEntityKeyDto)
	: RefBookingToCommissionCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class CreateRefBookingToCommissionCommandHandler
	: RefBookingToCommissionCommandHandlerBase<CreateRefBookingToCommissionCommand>
{
	public CreateRefBookingToCommissionCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Create)
	{ }
}

public record DeleteRefBookingToCommissionCommand(BookingKeyDto EntityKeyDto, CommissionKeyDto RelatedEntityKeyDto)
	: RefBookingToCommissionCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class DeleteRefBookingToCommissionCommandHandler
	: RefBookingToCommissionCommandHandlerBase<DeleteRefBookingToCommissionCommand>
{
	public DeleteRefBookingToCommissionCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Delete)
	{ }
}

public record DeleteAllRefBookingToCommissionCommand(BookingKeyDto EntityKeyDto)
	: RefBookingToCommissionCommand(EntityKeyDto, null);

internal partial class DeleteAllRefBookingToCommissionCommandHandler
	: RefBookingToCommissionCommandHandlerBase<DeleteAllRefBookingToCommissionCommand>
{
	public DeleteAllRefBookingToCommissionCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.DeleteAll)
	{ }
}

internal abstract class RefBookingToCommissionCommandHandlerBase<TRequest> : CommandBase<TRequest, BookingEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefBookingToCommissionCommand
{
	public AppDbContext DbContext { get; }

	public RelationshipAction Action { get; }

	public enum RelationshipAction { Create, Delete, DeleteAll };

	public RefBookingToCommissionCommandHandlerBase(
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
				entity.CreateRefToCommission(relatedEntity);
				break;
			case RelationshipAction.Delete:
				entity.DeleteRefToCommission(relatedEntity);
				break;
			case RelationshipAction.DeleteAll:
				entity.DeleteAllRefToCommission();
				break;
		}

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}