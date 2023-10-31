﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Nox.Application.Factories;
using Nox.Exceptions;
using Nox.Extensions;
using Cryptocash.Infrastructure.Persistence;
using Cryptocash.Domain;
using Cryptocash.Application.Dto;
using BookingEntity = Cryptocash.Domain.Booking;

namespace Cryptocash.Application.Commands;

public record UpdateBookingCommand(System.Guid keyId, BookingUpdateDto EntityDto, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest<BookingKeyDto?>;

internal partial class UpdateBookingCommandHandler : UpdateBookingCommandHandlerBase
{
	public UpdateBookingCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<BookingEntity, BookingCreateDto, BookingUpdateDto> entityFactory) 
		: base(dbContext, noxSolution, entityFactory)
	{
	}
}

internal abstract class UpdateBookingCommandHandlerBase : CommandBase<UpdateBookingCommand, BookingEntity>, IRequestHandler<UpdateBookingCommand, BookingKeyDto?>
{
	public AppDbContext DbContext { get; }
	private readonly IEntityFactory<BookingEntity, BookingCreateDto, BookingUpdateDto> _entityFactory;

	public UpdateBookingCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<BookingEntity, BookingCreateDto, BookingUpdateDto> entityFactory)
		: base(noxSolution)
	{
		DbContext = dbContext;
		_entityFactory = entityFactory;
	}

	public virtual async Task<BookingKeyDto?> Handle(UpdateBookingCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = Cryptocash.Domain.BookingMetadata.CreateId(request.keyId);

		var entity = await DbContext.Bookings.FindAsync(keyId);
		if (entity == null)
		{
			return null;
		}

		var bookingForCustomerKey = Cryptocash.Domain.CustomerMetadata.CreateId(request.EntityDto.BookingForCustomerId);
		var bookingForCustomerEntity = await DbContext.Customers.FindAsync(bookingForCustomerKey);
						
		if(bookingForCustomerEntity is not null)
			entity.CreateRefToBookingForCustomer(bookingForCustomerEntity);
		else
			throw new RelatedEntityNotFoundException("BookingForCustomer", request.EntityDto.BookingForCustomerId.ToString());

		var bookingRelatedVendingMachineKey = Cryptocash.Domain.VendingMachineMetadata.CreateId(request.EntityDto.BookingRelatedVendingMachineId);
		var bookingRelatedVendingMachineEntity = await DbContext.VendingMachines.FindAsync(bookingRelatedVendingMachineKey);
						
		if(bookingRelatedVendingMachineEntity is not null)
			entity.CreateRefToBookingRelatedVendingMachine(bookingRelatedVendingMachineEntity);
		else
			throw new RelatedEntityNotFoundException("BookingRelatedVendingMachine", request.EntityDto.BookingRelatedVendingMachineId.ToString());

		var bookingFeesForCommissionKey = Cryptocash.Domain.CommissionMetadata.CreateId(request.EntityDto.BookingFeesForCommissionId);
		var bookingFeesForCommissionEntity = await DbContext.Commissions.FindAsync(bookingFeesForCommissionKey);
						
		if(bookingFeesForCommissionEntity is not null)
			entity.CreateRefToBookingFeesForCommission(bookingFeesForCommissionEntity);
		else
			throw new RelatedEntityNotFoundException("BookingFeesForCommission", request.EntityDto.BookingFeesForCommissionId.ToString());

		var bookingRelatedTransactionKey = Cryptocash.Domain.TransactionMetadata.CreateId(request.EntityDto.BookingRelatedTransactionId);
		var bookingRelatedTransactionEntity = await DbContext.Transactions.FindAsync(bookingRelatedTransactionKey);
						
		if(bookingRelatedTransactionEntity is not null)
			entity.CreateRefToBookingRelatedTransaction(bookingRelatedTransactionEntity);
		else
			throw new RelatedEntityNotFoundException("BookingRelatedTransaction", request.EntityDto.BookingRelatedTransactionId.ToString());

		_entityFactory.UpdateEntity(entity, request.EntityDto, request.CultureCode);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		if (result < 1)
		{
			return null;
		}

		return new BookingKeyDto(entity.Id.Value);
	}
}