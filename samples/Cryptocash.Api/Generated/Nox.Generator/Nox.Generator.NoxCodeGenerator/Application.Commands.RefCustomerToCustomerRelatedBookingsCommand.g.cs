
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

public abstract record RefCustomerToCustomerRelatedBookingsCommand(CustomerKeyDto EntityKeyDto, BookingKeyDto? RelatedEntityKeyDto) : IRequest <bool>;

public record CreateRefCustomerToCustomerRelatedBookingsCommand(CustomerKeyDto EntityKeyDto, BookingKeyDto RelatedEntityKeyDto)
	: RefCustomerToCustomerRelatedBookingsCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class CreateRefCustomerToCustomerRelatedBookingsCommandHandler
	: RefCustomerToCustomerRelatedBookingsCommandHandlerBase<CreateRefCustomerToCustomerRelatedBookingsCommand>
{
	public CreateRefCustomerToCustomerRelatedBookingsCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider
		)
		: base(dbContext, noxSolution, serviceProvider, RelationshipAction.Create)
	{ }
}

public record DeleteRefCustomerToCustomerRelatedBookingsCommand(CustomerKeyDto EntityKeyDto, BookingKeyDto RelatedEntityKeyDto)
	: RefCustomerToCustomerRelatedBookingsCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class DeleteRefCustomerToCustomerRelatedBookingsCommandHandler
	: RefCustomerToCustomerRelatedBookingsCommandHandlerBase<DeleteRefCustomerToCustomerRelatedBookingsCommand>
{
	public DeleteRefCustomerToCustomerRelatedBookingsCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider
		)
		: base(dbContext, noxSolution, serviceProvider, RelationshipAction.Delete)
	{ }
}

public record DeleteAllRefCustomerToCustomerRelatedBookingsCommand(CustomerKeyDto EntityKeyDto)
	: RefCustomerToCustomerRelatedBookingsCommand(EntityKeyDto, null);

internal partial class DeleteAllRefCustomerToCustomerRelatedBookingsCommandHandler
	: RefCustomerToCustomerRelatedBookingsCommandHandlerBase<DeleteAllRefCustomerToCustomerRelatedBookingsCommand>
{
	public DeleteAllRefCustomerToCustomerRelatedBookingsCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider
		)
		: base(dbContext, noxSolution, serviceProvider, RelationshipAction.DeleteAll)
	{ }
}

internal abstract class RefCustomerToCustomerRelatedBookingsCommandHandlerBase<TRequest>: CommandBase<TRequest, Customer>, 
	IRequestHandler <TRequest, bool> where TRequest : RefCustomerToCustomerRelatedBookingsCommand
{
	public CryptocashDbContext DbContext { get; }

	public RelationshipAction Action { get; }

    public enum RelationshipAction { Create, Delete, DeleteAll };

	public RefCustomerToCustomerRelatedBookingsCommandHandlerBase(
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
		var keyId = CreateNoxTypeForKey<Customer, Nox.Types.AutoNumber>("Id", request.EntityKeyDto.keyId);
		var entity = await DbContext.Customers.FindAsync(keyId);
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