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
using BookingEntity = Cryptocash.Domain.Booking;

namespace Cryptocash.Application.Commands;

public abstract record RefBookingToCommissionCommand(BookingKeyDto EntityKeyDto) : IRequest <bool>;

#region CreateRefTo

public partial record CreateRefBookingToCommissionCommand(BookingKeyDto EntityKeyDto, CommissionKeyDto RelatedEntityKeyDto)
	: RefBookingToCommissionCommand(EntityKeyDto);

internal partial class CreateRefBookingToCommissionCommandHandler
	: RefBookingToCommissionCommandHandlerBase<CreateRefBookingToCommissionCommand>
{
	public CreateRefBookingToCommissionCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(CreateRefBookingToCommissionCommand request)
    {
		var entity = await GetBooking(request.EntityKeyDto);
		if (entity == null)
		{
			throw new EntityNotFoundException("Booking",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetCommission(request.RelatedEntityKeyDto);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("Commission",  $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.CreateRefToCommission(relatedEntity);

		return await SaveChangesAsync(request, entity);
    }
}

#endregion CreateRefTo

#region DeleteRefTo

public record DeleteRefBookingToCommissionCommand(BookingKeyDto EntityKeyDto, CommissionKeyDto RelatedEntityKeyDto)
	: RefBookingToCommissionCommand(EntityKeyDto);

internal partial class DeleteRefBookingToCommissionCommandHandler
	: RefBookingToCommissionCommandHandlerBase<DeleteRefBookingToCommissionCommand>
{
	public DeleteRefBookingToCommissionCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(DeleteRefBookingToCommissionCommand request)
    {
        var entity = await GetBooking(request.EntityKeyDto);
		if (entity == null)
		{
			throw new EntityNotFoundException("Booking",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetCommission(request.RelatedEntityKeyDto);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("Commission", $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.DeleteRefToCommission(relatedEntity);

		return await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteRefTo

#region DeleteAllRefTo

public record DeleteAllRefBookingToCommissionCommand(BookingKeyDto EntityKeyDto)
	: RefBookingToCommissionCommand(EntityKeyDto);

internal partial class DeleteAllRefBookingToCommissionCommandHandler
	: RefBookingToCommissionCommandHandlerBase<DeleteAllRefBookingToCommissionCommand>
{
	public DeleteAllRefBookingToCommissionCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(DeleteAllRefBookingToCommissionCommand request)
    {
        var entity = await GetBooking(request.EntityKeyDto);
		if (entity == null)
		{
			throw new EntityNotFoundException("Booking",  $"{request.EntityKeyDto.keyId.ToString()}");
		}
		entity.DeleteAllRefToCommission();

		return await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteAllRefTo

internal abstract class RefBookingToCommissionCommandHandlerBase<TRequest> : CommandBase<TRequest, BookingEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefBookingToCommissionCommand
{
	public AppDbContext DbContext { get; }

	public RefBookingToCommissionCommandHandlerBase(
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

	protected async Task<BookingEntity?> GetBooking(BookingKeyDto entityKeyDto)
	{
		var keyId = Cryptocash.Domain.BookingMetadata.CreateId(entityKeyDto.keyId);
		return await DbContext.Bookings.FindAsync(keyId);
	}

	protected async Task<Cryptocash.Domain.Commission?> GetCommission(CommissionKeyDto relatedEntityKeyDto)
	{
		var relatedKeyId = Cryptocash.Domain.CommissionMetadata.CreateId(relatedEntityKeyDto.keyId);
		return await DbContext.Commissions.FindAsync(relatedKeyId);
	}

	protected async Task<bool> SaveChangesAsync(TRequest request, BookingEntity entity)
	{
		await OnCompletedAsync(request, entity);
		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}