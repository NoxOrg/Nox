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

public record UpdateBookingCommand(System.Guid keyId, BookingUpdateDto EntityDto, System.Guid? Etag) : IRequest<BookingKeyDto?>;

internal partial class UpdateBookingCommandHandler : UpdateBookingCommandHandlerBase
{
	public UpdateBookingCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<BookingEntity, BookingCreateDto, BookingUpdateDto> entityFactory) : base(dbContext, noxSolution, entityFactory)
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
		IEntityFactory<BookingEntity, BookingCreateDto, BookingUpdateDto> entityFactory) : base(noxSolution)
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

		var customerKey = Cryptocash.Domain.CustomerMetadata.CreateId(request.EntityDto.CustomerId);
		var customerEntity = await DbContext.Customers.FindAsync(customerKey);
						
		if(customerEntity is not null)
			entity.CreateRefToCustomer(customerEntity);
		else
			throw new RelatedEntityNotFoundException("Customer", request.EntityDto.CustomerId.ToString());

		var vendingMachineKey = Cryptocash.Domain.VendingMachineMetadata.CreateId(request.EntityDto.VendingMachineId);
		var vendingMachineEntity = await DbContext.VendingMachines.FindAsync(vendingMachineKey);
						
		if(vendingMachineEntity is not null)
			entity.CreateRefToVendingMachine(vendingMachineEntity);
		else
			throw new RelatedEntityNotFoundException("VendingMachine", request.EntityDto.VendingMachineId.ToString());

		var commissionKey = Cryptocash.Domain.CommissionMetadata.CreateId(request.EntityDto.CommissionId);
		var commissionEntity = await DbContext.Commissions.FindAsync(commissionKey);
						
		if(commissionEntity is not null)
			entity.CreateRefToCommission(commissionEntity);
		else
			throw new RelatedEntityNotFoundException("Commission", request.EntityDto.CommissionId.ToString());

		var transactionKey = Cryptocash.Domain.TransactionMetadata.CreateId(request.EntityDto.TransactionId);
		var transactionEntity = await DbContext.Transactions.FindAsync(transactionKey);
						
		if(transactionEntity is not null)
			entity.CreateRefToTransaction(transactionEntity);
		else
			throw new RelatedEntityNotFoundException("Transaction", request.EntityDto.TransactionId.ToString());

		_entityFactory.UpdateEntity(entity, request.EntityDto);
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