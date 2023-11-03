
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
using CommissionEntity = Cryptocash.Domain.Commission;

namespace Cryptocash.Application.Commands;

public abstract record RefCommissionToBookingsCommand(CommissionKeyDto EntityKeyDto, BookingKeyDto? RelatedEntityKeyDto) : IRequest <bool>;

public record CreateRefCommissionToBookingsCommand(CommissionKeyDto EntityKeyDto, BookingKeyDto RelatedEntityKeyDto)
	: RefCommissionToBookingsCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class CreateRefCommissionToBookingsCommandHandler
	: RefCommissionToBookingsCommandHandlerBase<CreateRefCommissionToBookingsCommand>
{
	public CreateRefCommissionToBookingsCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Create)
	{ }
}

public record DeleteRefCommissionToBookingsCommand(CommissionKeyDto EntityKeyDto, BookingKeyDto RelatedEntityKeyDto)
	: RefCommissionToBookingsCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class DeleteRefCommissionToBookingsCommandHandler
	: RefCommissionToBookingsCommandHandlerBase<DeleteRefCommissionToBookingsCommand>
{
	public DeleteRefCommissionToBookingsCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Delete)
	{ }
}

public record DeleteAllRefCommissionToBookingsCommand(CommissionKeyDto EntityKeyDto)
	: RefCommissionToBookingsCommand(EntityKeyDto, null);

internal partial class DeleteAllRefCommissionToBookingsCommandHandler
	: RefCommissionToBookingsCommandHandlerBase<DeleteAllRefCommissionToBookingsCommand>
{
	public DeleteAllRefCommissionToBookingsCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.DeleteAll)
	{ }
}

internal abstract class RefCommissionToBookingsCommandHandlerBase<TRequest> : CommandBase<TRequest, CommissionEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefCommissionToBookingsCommand
{
	public AppDbContext DbContext { get; }

	public RelationshipAction Action { get; }

	public enum RelationshipAction { Create, Delete, DeleteAll };

	public RefCommissionToBookingsCommandHandlerBase(
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
		var keyId = Cryptocash.Domain.CommissionMetadata.CreateId(request.EntityKeyDto.keyId);
		var entity = await DbContext.Commissions.FindAsync(keyId);
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