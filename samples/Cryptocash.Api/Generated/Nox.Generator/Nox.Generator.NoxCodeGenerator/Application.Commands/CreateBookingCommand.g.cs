﻿// Generated

#nullable enable

using MediatR;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nox.Abstractions;
using Nox.Application;
using Nox.Application.Commands;
using Nox.Exceptions;
using Nox.Extensions;
using Nox.Application.Factories;
using Nox.Solution;

using Cryptocash.Infrastructure.Persistence;
using Cryptocash.Domain;
using Cryptocash.Application.Dto;
using BookingEntity = Cryptocash.Domain.Booking;

namespace Cryptocash.Application.Commands;

public record CreateBookingCommand(BookingCreateDto EntityDto) : IRequest<BookingKeyDto>;

internal partial class CreateBookingCommandHandler : CreateBookingCommandHandlerBase
{
	public CreateBookingCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<Cryptocash.Domain.Customer, CustomerCreateDto, CustomerUpdateDto> CustomerFactory,
		IEntityFactory<Cryptocash.Domain.VendingMachine, VendingMachineCreateDto, VendingMachineUpdateDto> VendingMachineFactory,
		IEntityFactory<Cryptocash.Domain.Commission, CommissionCreateDto, CommissionUpdateDto> CommissionFactory,
		IEntityFactory<Cryptocash.Domain.Transaction, TransactionCreateDto, TransactionUpdateDto> TransactionFactory,
		IEntityFactory<BookingEntity, BookingCreateDto, BookingUpdateDto> entityFactory)
		: base(dbContext, noxSolution,CustomerFactory, VendingMachineFactory, CommissionFactory, TransactionFactory, entityFactory)
	{
	}
}


internal abstract class CreateBookingCommandHandlerBase : CommandBase<CreateBookingCommand,BookingEntity>, IRequestHandler <CreateBookingCommand, BookingKeyDto>
{
	protected readonly CryptocashDbContext DbContext;
	protected readonly IEntityFactory<BookingEntity, BookingCreateDto, BookingUpdateDto> EntityFactory;
	protected readonly IEntityFactory<Cryptocash.Domain.Customer, CustomerCreateDto, CustomerUpdateDto> CustomerFactory;
	protected readonly IEntityFactory<Cryptocash.Domain.VendingMachine, VendingMachineCreateDto, VendingMachineUpdateDto> VendingMachineFactory;
	protected readonly IEntityFactory<Cryptocash.Domain.Commission, CommissionCreateDto, CommissionUpdateDto> CommissionFactory;
	protected readonly IEntityFactory<Cryptocash.Domain.Transaction, TransactionCreateDto, TransactionUpdateDto> TransactionFactory;

	public CreateBookingCommandHandlerBase(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<Cryptocash.Domain.Customer, CustomerCreateDto, CustomerUpdateDto> CustomerFactory,
		IEntityFactory<Cryptocash.Domain.VendingMachine, VendingMachineCreateDto, VendingMachineUpdateDto> VendingMachineFactory,
		IEntityFactory<Cryptocash.Domain.Commission, CommissionCreateDto, CommissionUpdateDto> CommissionFactory,
		IEntityFactory<Cryptocash.Domain.Transaction, TransactionCreateDto, TransactionUpdateDto> TransactionFactory,
		IEntityFactory<BookingEntity, BookingCreateDto, BookingUpdateDto> entityFactory) : base(noxSolution)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
		this.CustomerFactory = CustomerFactory;
		this.VendingMachineFactory = VendingMachineFactory;
		this.CommissionFactory = CommissionFactory;
		this.TransactionFactory = TransactionFactory;
	}

	public virtual async Task<BookingKeyDto> Handle(CreateBookingCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);

		var entityToCreate = EntityFactory.CreateEntity(request.EntityDto);
		if(request.EntityDto.BookingForCustomerId is not null)
		{
			var relatedKey = Cryptocash.Domain.CustomerMetadata.CreateId(request.EntityDto.BookingForCustomerId.NonNullValue<System.Int64>());
			var relatedEntity = await DbContext.Customers.FindAsync(relatedKey);
			if(relatedEntity is not null)
				entityToCreate.CreateRefToBookingForCustomer(relatedEntity);
			else
				throw new RelatedEntityNotFoundException("BookingForCustomer", request.EntityDto.BookingForCustomerId.NonNullValue<System.Int64>().ToString());
		}
		else if(request.EntityDto.BookingForCustomer is not null)
		{
			var relatedEntity = CustomerFactory.CreateEntity(request.EntityDto.BookingForCustomer);
			entityToCreate.CreateRefToBookingForCustomer(relatedEntity);
		}
		if(request.EntityDto.BookingRelatedVendingMachineId is not null)
		{
			var relatedKey = Cryptocash.Domain.VendingMachineMetadata.CreateId(request.EntityDto.BookingRelatedVendingMachineId.NonNullValue<System.Guid>());
			var relatedEntity = await DbContext.VendingMachines.FindAsync(relatedKey);
			if(relatedEntity is not null)
				entityToCreate.CreateRefToBookingRelatedVendingMachine(relatedEntity);
			else
				throw new RelatedEntityNotFoundException("BookingRelatedVendingMachine", request.EntityDto.BookingRelatedVendingMachineId.NonNullValue<System.Guid>().ToString());
		}
		else if(request.EntityDto.BookingRelatedVendingMachine is not null)
		{
			var relatedEntity = VendingMachineFactory.CreateEntity(request.EntityDto.BookingRelatedVendingMachine);
			entityToCreate.CreateRefToBookingRelatedVendingMachine(relatedEntity);
		}
		if(request.EntityDto.BookingFeesForCommissionId is not null)
		{
			var relatedKey = Cryptocash.Domain.CommissionMetadata.CreateId(request.EntityDto.BookingFeesForCommissionId.NonNullValue<System.Int64>());
			var relatedEntity = await DbContext.Commissions.FindAsync(relatedKey);
			if(relatedEntity is not null)
				entityToCreate.CreateRefToBookingFeesForCommission(relatedEntity);
			else
				throw new RelatedEntityNotFoundException("BookingFeesForCommission", request.EntityDto.BookingFeesForCommissionId.NonNullValue<System.Int64>().ToString());
		}
		else if(request.EntityDto.BookingFeesForCommission is not null)
		{
			var relatedEntity = CommissionFactory.CreateEntity(request.EntityDto.BookingFeesForCommission);
			entityToCreate.CreateRefToBookingFeesForCommission(relatedEntity);
		}
		if(request.EntityDto.BookingRelatedTransactionId is not null)
		{
			var relatedKey = Cryptocash.Domain.TransactionMetadata.CreateId(request.EntityDto.BookingRelatedTransactionId.NonNullValue<System.Int64>());
			var relatedEntity = await DbContext.Transactions.FindAsync(relatedKey);
			if(relatedEntity is not null)
				entityToCreate.CreateRefToBookingRelatedTransaction(relatedEntity);
			else
				throw new RelatedEntityNotFoundException("BookingRelatedTransaction", request.EntityDto.BookingRelatedTransactionId.NonNullValue<System.Int64>().ToString());
		}
		else if(request.EntityDto.BookingRelatedTransaction is not null)
		{
			var relatedEntity = TransactionFactory.CreateEntity(request.EntityDto.BookingRelatedTransaction);
			entityToCreate.CreateRefToBookingRelatedTransaction(relatedEntity);
		}

		await OnCompletedAsync(request, entityToCreate);
		DbContext.Bookings.Add(entityToCreate);
		await DbContext.SaveChangesAsync();
		return new BookingKeyDto(entityToCreate.Id.Value);
	}
}