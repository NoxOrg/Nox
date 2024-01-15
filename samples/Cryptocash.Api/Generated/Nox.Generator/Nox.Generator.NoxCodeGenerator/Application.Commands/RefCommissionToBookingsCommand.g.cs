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
using Nox.Exceptions;

using Cryptocash.Infrastructure.Persistence;
using Cryptocash.Domain;
using Cryptocash.Application.Dto;
using Dto = Cryptocash.Application.Dto;
using CommissionEntity = Cryptocash.Domain.Commission;

namespace Cryptocash.Application.Commands;

public abstract record RefCommissionToBookingsCommand(CommissionKeyDto EntityKeyDto) : IRequest <bool>;

#region CreateRefTo

public partial record CreateRefCommissionToBookingsCommand(CommissionKeyDto EntityKeyDto, BookingKeyDto RelatedEntityKeyDto)
	: RefCommissionToBookingsCommand(EntityKeyDto);

internal partial class CreateRefCommissionToBookingsCommandHandler
	: RefCommissionToBookingsCommandHandlerBase<CreateRefCommissionToBookingsCommand>
{
	public CreateRefCommissionToBookingsCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(CreateRefCommissionToBookingsCommand request)
    {
		var entity = await GetCommission(request.EntityKeyDto);
		if (entity == null)
		{
			throw new EntityNotFoundException("Commission",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetBooking(request.RelatedEntityKeyDto);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("Booking",  $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.CreateRefToBookings(relatedEntity);

		return await SaveChangesAsync(request, entity);
    }
}

#endregion CreateRefTo

#region UpdateRefTo

public partial record UpdateRefCommissionToBookingsCommand(CommissionKeyDto EntityKeyDto, List<BookingKeyDto> RelatedEntitiesKeysDtos)
	: RefCommissionToBookingsCommand(EntityKeyDto);

internal partial class UpdateRefCommissionToBookingsCommandHandler
	: RefCommissionToBookingsCommandHandlerBase<UpdateRefCommissionToBookingsCommand>
{
	public UpdateRefCommissionToBookingsCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(UpdateRefCommissionToBookingsCommand request)
    {
		var entity = await GetCommission(request.EntityKeyDto);
		if (entity == null)
		{
			throw new EntityNotFoundException("Commission",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntities = new List<Cryptocash.Domain.Booking>();
		foreach(var keyDto in request.RelatedEntitiesKeysDtos)
		{
			var relatedEntity = await GetBooking(keyDto);
			if (relatedEntity == null)
			{
				throw new RelatedEntityNotFoundException("Booking", $"{keyDto.keyId.ToString()}");
			}
			relatedEntities.Add(relatedEntity);
		}

		await DbContext.Entry(entity).Collection(x => x.Bookings).LoadAsync();
		entity.UpdateRefToBookings(relatedEntities);

		return await SaveChangesAsync(request, entity);
    }
}

#endregion UpdateRefTo

#region DeleteRefTo

public record DeleteRefCommissionToBookingsCommand(CommissionKeyDto EntityKeyDto, BookingKeyDto RelatedEntityKeyDto)
	: RefCommissionToBookingsCommand(EntityKeyDto);

internal partial class DeleteRefCommissionToBookingsCommandHandler
	: RefCommissionToBookingsCommandHandlerBase<DeleteRefCommissionToBookingsCommand>
{
	public DeleteRefCommissionToBookingsCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(DeleteRefCommissionToBookingsCommand request)
    {
        var entity = await GetCommission(request.EntityKeyDto);
		if (entity == null)
		{
			throw new EntityNotFoundException("Commission",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetBooking(request.RelatedEntityKeyDto);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("Booking", $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.DeleteRefToBookings(relatedEntity);

		return await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteRefTo

#region DeleteAllRefTo

public record DeleteAllRefCommissionToBookingsCommand(CommissionKeyDto EntityKeyDto)
	: RefCommissionToBookingsCommand(EntityKeyDto);

internal partial class DeleteAllRefCommissionToBookingsCommandHandler
	: RefCommissionToBookingsCommandHandlerBase<DeleteAllRefCommissionToBookingsCommand>
{
	public DeleteAllRefCommissionToBookingsCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(DeleteAllRefCommissionToBookingsCommand request)
    {
        var entity = await GetCommission(request.EntityKeyDto);
		if (entity == null)
		{
			throw new EntityNotFoundException("Commission",  $"{request.EntityKeyDto.keyId.ToString()}");
		}
		await DbContext.Entry(entity).Collection(x => x.Bookings).LoadAsync();
		entity.DeleteAllRefToBookings();

		return await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteAllRefTo

internal abstract class RefCommissionToBookingsCommandHandlerBase<TRequest> : CommandBase<TRequest, CommissionEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefCommissionToBookingsCommand
{
	public AppDbContext DbContext { get; }

	public RefCommissionToBookingsCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution)
		: base(noxSolution)
	{
		DbContext = dbContext;
	}

	public virtual async Task<bool> Handle(TRequest request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		return await ExecuteAsync(request);
	}

	protected abstract Task<bool> ExecuteAsync(TRequest request);

	protected async Task<CommissionEntity?> GetCommission(CommissionKeyDto entityKeyDto)
	{
		var keyId = Dto.CommissionMetadata.CreateId(entityKeyDto.keyId);
		return await DbContext.Commissions.FindAsync(keyId);
	}

	protected async Task<Cryptocash.Domain.Booking?> GetBooking(BookingKeyDto relatedEntityKeyDto)
	{
		var relatedKeyId = Dto.BookingMetadata.CreateId(relatedEntityKeyDto.keyId);
		return await DbContext.Bookings.FindAsync(relatedKeyId);
	}

	protected async Task<bool> SaveChangesAsync(TRequest request, CommissionEntity entity)
	{
		await OnCompletedAsync(request, entity);
		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}