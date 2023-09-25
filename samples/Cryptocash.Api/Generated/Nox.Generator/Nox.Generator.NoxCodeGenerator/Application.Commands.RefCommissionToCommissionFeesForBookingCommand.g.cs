
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

public abstract record RefCommissionToCommissionFeesForBookingCommand(CommissionKeyDto EntityKeyDto, BookingKeyDto? RelatedEntityKeyDto) : IRequest <bool>;

public record CreateRefCommissionToCommissionFeesForBookingCommand(CommissionKeyDto EntityKeyDto, BookingKeyDto RelatedEntityKeyDto)
	: RefCommissionToCommissionFeesForBookingCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class CreateRefCommissionToCommissionFeesForBookingCommandHandler
	: RefCommissionToCommissionFeesForBookingCommandHandlerBase<CreateRefCommissionToCommissionFeesForBookingCommand>
{
	public CreateRefCommissionToCommissionFeesForBookingCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider
		)
		: base(dbContext, noxSolution, serviceProvider, RelationshipAction.Create)
	{ }
}

public record DeleteRefCommissionToCommissionFeesForBookingCommand(CommissionKeyDto EntityKeyDto, BookingKeyDto RelatedEntityKeyDto)
	: RefCommissionToCommissionFeesForBookingCommand(EntityKeyDto, RelatedEntityKeyDto);

public partial class DeleteRefCommissionToCommissionFeesForBookingCommandHandler
	: RefCommissionToCommissionFeesForBookingCommandHandlerBase<DeleteRefCommissionToCommissionFeesForBookingCommand>
{
	public DeleteRefCommissionToCommissionFeesForBookingCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider
		)
		: base(dbContext, noxSolution, serviceProvider, RelationshipAction.Delete)
	{ }
}

public record DeleteAllRefCommissionToCommissionFeesForBookingCommand(CommissionKeyDto EntityKeyDto)
	: RefCommissionToCommissionFeesForBookingCommand(EntityKeyDto, null);

public partial class DeleteAllRefCommissionToCommissionFeesForBookingCommandHandler
	: RefCommissionToCommissionFeesForBookingCommandHandlerBase<DeleteAllRefCommissionToCommissionFeesForBookingCommand>
{
	public DeleteAllRefCommissionToCommissionFeesForBookingCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider
		)
		: base(dbContext, noxSolution, serviceProvider, RelationshipAction.DeleteAll)
	{ }
}

public abstract class RefCommissionToCommissionFeesForBookingCommandHandlerBase<TRequest>: CommandBase<TRequest, Commission>, 
	IRequestHandler <TRequest, bool> where TRequest : RefCommissionToCommissionFeesForBookingCommand
{
	public CryptocashDbContext DbContext { get; }

	public RelationshipAction Action { get; }

    public enum RelationshipAction { Create, Delete, DeleteAll };

	public RefCommissionToCommissionFeesForBookingCommandHandlerBase(
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
		var keyId = CreateNoxTypeForKey<Commission, Nox.Types.AutoNumber>("Id", request.EntityKeyDto.keyId);
		var entity = await DbContext.Commissions.FindAsync(keyId);
		if (entity == null)
		{
			return false;
		}

		Booking? relatedEntity = null!;
		if(request.RelatedEntityKeyDto is not null)
		{
			var relatedKeyId = CreateNoxTypeForKey<Booking, Nox.Types.Guid>("Id", request.RelatedEntityKeyDto.keyId);
			relatedEntity = await DbContext.Bookings.FindAsync(relatedKeyId);
			if (relatedEntity == null)
			{
				return false;
			}
		}
		
		switch (Action)
        {
            case RelationshipAction.Create:
                entity.CreateRefToCommissionFeesForBooking(relatedEntity);
                break;
            case RelationshipAction.Delete:
                entity.DeleteRefToCommissionFeesForBooking(relatedEntity);
                break;
            case RelationshipAction.DeleteAll:
				await DbContext.Entry(entity).Collection(x => x.CommissionFeesForBooking).LoadAsync();
                entity.DeleteAllRefToCommissionFeesForBooking();
                break;
        }

		OnCompleted(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}