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

public abstract record RefBookingToCustomerCommand(BookingKeyDto EntityKeyDto) : IRequest <bool>;

#region CreateRefTo

public partial record CreateRefBookingToCustomerCommand(BookingKeyDto EntityKeyDto, CustomerKeyDto RelatedEntityKeyDto)
	: RefBookingToCustomerCommand(EntityKeyDto);

internal partial class CreateRefBookingToCustomerCommandHandler
	: RefBookingToCustomerCommandHandlerBase<CreateRefBookingToCustomerCommand>
{
	public CreateRefBookingToCustomerCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(CreateRefBookingToCustomerCommand request)
    {
		var entity = await GetBooking(request.EntityKeyDto);
		if (entity == null)
		{
			throw new EntityNotFoundException("Booking",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetCustomer(request.RelatedEntityKeyDto);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("Customer",  $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.CreateRefToCustomer(relatedEntity);

		return await SaveChangesAsync(request, entity);
    }
}

#endregion CreateRefTo

#region DeleteRefTo

public record DeleteRefBookingToCustomerCommand(BookingKeyDto EntityKeyDto, CustomerKeyDto RelatedEntityKeyDto)
	: RefBookingToCustomerCommand(EntityKeyDto);

internal partial class DeleteRefBookingToCustomerCommandHandler
	: RefBookingToCustomerCommandHandlerBase<DeleteRefBookingToCustomerCommand>
{
	public DeleteRefBookingToCustomerCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(DeleteRefBookingToCustomerCommand request)
    {
        var entity = await GetBooking(request.EntityKeyDto);
		if (entity == null)
		{
			throw new EntityNotFoundException("Booking",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetCustomer(request.RelatedEntityKeyDto);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("Customer", $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.DeleteRefToCustomer(relatedEntity);

		return await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteRefTo

#region DeleteAllRefTo

public record DeleteAllRefBookingToCustomerCommand(BookingKeyDto EntityKeyDto)
	: RefBookingToCustomerCommand(EntityKeyDto);

internal partial class DeleteAllRefBookingToCustomerCommandHandler
	: RefBookingToCustomerCommandHandlerBase<DeleteAllRefBookingToCustomerCommand>
{
	public DeleteAllRefBookingToCustomerCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(DeleteAllRefBookingToCustomerCommand request)
    {
        var entity = await GetBooking(request.EntityKeyDto);
		if (entity == null)
		{
			throw new EntityNotFoundException("Booking",  $"{request.EntityKeyDto.keyId.ToString()}");
		}
		entity.DeleteAllRefToCustomer();

		return await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteAllRefTo

internal abstract class RefBookingToCustomerCommandHandlerBase<TRequest> : CommandBase<TRequest, BookingEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefBookingToCustomerCommand
{
	public AppDbContext DbContext { get; }

	public RefBookingToCustomerCommandHandlerBase(
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

	protected async Task<Cryptocash.Domain.Customer?> GetCustomer(CustomerKeyDto relatedEntityKeyDto)
	{
		var relatedKeyId = Cryptocash.Domain.CustomerMetadata.CreateId(relatedEntityKeyDto.keyId);
		return await DbContext.Customers.FindAsync(relatedKeyId);
	}

	protected async Task<bool> SaveChangesAsync(TRequest request, BookingEntity entity)
	{
		await OnCompletedAsync(request, entity);
		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		if (result < 1)
		{
			throw new DatabaseSaveException();
		}
		return true;
	}
}