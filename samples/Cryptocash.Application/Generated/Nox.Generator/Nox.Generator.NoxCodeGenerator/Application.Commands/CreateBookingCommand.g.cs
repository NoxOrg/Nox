﻿﻿// Generated

#nullable enable

using MediatR;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FluentValidation;
using Microsoft.Extensions.Logging;

using Nox.Abstractions;
using Nox.Application;
using Nox.Application.Commands;
using Nox.Exceptions;
using Nox.Extensions;
using Nox.Application.Factories;
using Nox.Solution;
using Nox.Domain;

using Cryptocash.Domain;
using Cryptocash.Application.Dto;
using Dto = Cryptocash.Application.Dto;
using BookingEntity = Cryptocash.Domain.Booking;

namespace Cryptocash.Application.Commands;

public partial record CreateBookingCommand(BookingCreateDto EntityDto, Nox.Types.CultureCode CultureCode) : IRequest<BookingKeyDto>;

internal partial class CreateBookingCommandHandler : CreateBookingCommandHandlerBase
{
	public CreateBookingCommandHandler(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<Cryptocash.Domain.Customer, CustomerCreateDto, CustomerUpdateDto> CustomerFactory,
		IEntityFactory<Cryptocash.Domain.VendingMachine, VendingMachineCreateDto, VendingMachineUpdateDto> VendingMachineFactory,
		IEntityFactory<Cryptocash.Domain.Commission, CommissionCreateDto, CommissionUpdateDto> CommissionFactory,
		IEntityFactory<Cryptocash.Domain.Transaction, TransactionCreateDto, TransactionUpdateDto> TransactionFactory,
		IEntityFactory<BookingEntity, BookingCreateDto, BookingUpdateDto> entityFactory)
		: base(repository, noxSolution,CustomerFactory, VendingMachineFactory, CommissionFactory, TransactionFactory, entityFactory)
	{
	}
}


internal abstract class CreateBookingCommandHandlerBase : CommandBase<CreateBookingCommand,BookingEntity>, IRequestHandler <CreateBookingCommand, BookingKeyDto>
{
	protected readonly IRepository Repository;
	protected readonly IEntityFactory<BookingEntity, BookingCreateDto, BookingUpdateDto> EntityFactory;
	protected readonly IEntityFactory<Cryptocash.Domain.Customer, CustomerCreateDto, CustomerUpdateDto> CustomerFactory;
	protected readonly IEntityFactory<Cryptocash.Domain.VendingMachine, VendingMachineCreateDto, VendingMachineUpdateDto> VendingMachineFactory;
	protected readonly IEntityFactory<Cryptocash.Domain.Commission, CommissionCreateDto, CommissionUpdateDto> CommissionFactory;
	protected readonly IEntityFactory<Cryptocash.Domain.Transaction, TransactionCreateDto, TransactionUpdateDto> TransactionFactory;

	protected CreateBookingCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<Cryptocash.Domain.Customer, CustomerCreateDto, CustomerUpdateDto> CustomerFactory,
		IEntityFactory<Cryptocash.Domain.VendingMachine, VendingMachineCreateDto, VendingMachineUpdateDto> VendingMachineFactory,
		IEntityFactory<Cryptocash.Domain.Commission, CommissionCreateDto, CommissionUpdateDto> CommissionFactory,
		IEntityFactory<Cryptocash.Domain.Transaction, TransactionCreateDto, TransactionUpdateDto> TransactionFactory,
		IEntityFactory<BookingEntity, BookingCreateDto, BookingUpdateDto> entityFactory)
	: base(noxSolution)
	{
		Repository = repository;
		EntityFactory = entityFactory;
		this.CustomerFactory = CustomerFactory;
		this.VendingMachineFactory = VendingMachineFactory;
		this.CommissionFactory = CommissionFactory;
		this.TransactionFactory = TransactionFactory;
	}

	public virtual async Task<BookingKeyDto> Handle(CreateBookingCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);

		var entityToCreate = await EntityFactory.CreateEntityAsync(request.EntityDto, request.CultureCode);
		if(request.EntityDto.CustomerId is not null)
		{
			var relatedKey = Dto.CustomerMetadata.CreateId(request.EntityDto.CustomerId.NonNullValue<System.Guid>());
			var relatedEntity = await Repository.FindAsync<Cryptocash.Domain.Customer>(relatedKey);
			if(relatedEntity is not null)
				entityToCreate.CreateRefToCustomer(relatedEntity);
			else
				throw new RelatedEntityNotFoundException("Customer", request.EntityDto.CustomerId.NonNullValue<System.Guid>().ToString());
		}
		else if(request.EntityDto.Customer is not null)
		{
			var relatedEntity = await CustomerFactory.CreateEntityAsync(request.EntityDto.Customer, request.CultureCode);
			entityToCreate.CreateRefToCustomer(relatedEntity);
		}
		if(request.EntityDto.VendingMachineId is not null)
		{
			var relatedKey = Dto.VendingMachineMetadata.CreateId(request.EntityDto.VendingMachineId.NonNullValue<System.Guid>());
			var relatedEntity = await Repository.FindAsync<Cryptocash.Domain.VendingMachine>(relatedKey);
			if(relatedEntity is not null)
				entityToCreate.CreateRefToVendingMachine(relatedEntity);
			else
				throw new RelatedEntityNotFoundException("VendingMachine", request.EntityDto.VendingMachineId.NonNullValue<System.Guid>().ToString());
		}
		else if(request.EntityDto.VendingMachine is not null)
		{
			var relatedEntity = await VendingMachineFactory.CreateEntityAsync(request.EntityDto.VendingMachine, request.CultureCode);
			entityToCreate.CreateRefToVendingMachine(relatedEntity);
		}
		if(request.EntityDto.CommissionId is not null)
		{
			var relatedKey = Dto.CommissionMetadata.CreateId(request.EntityDto.CommissionId.NonNullValue<System.Guid>());
			var relatedEntity = await Repository.FindAsync<Cryptocash.Domain.Commission>(relatedKey);
			if(relatedEntity is not null)
				entityToCreate.CreateRefToCommission(relatedEntity);
			else
				throw new RelatedEntityNotFoundException("Commission", request.EntityDto.CommissionId.NonNullValue<System.Guid>().ToString());
		}
		else if(request.EntityDto.Commission is not null)
		{
			var relatedEntity = await CommissionFactory.CreateEntityAsync(request.EntityDto.Commission, request.CultureCode);
			entityToCreate.CreateRefToCommission(relatedEntity);
		}
		if(request.EntityDto.TransactionId is not null)
		{
			var relatedKey = Dto.TransactionMetadata.CreateId(request.EntityDto.TransactionId.NonNullValue<System.Guid>());
			var relatedEntity = await Repository.FindAsync<Cryptocash.Domain.Transaction>(relatedKey);
			if(relatedEntity is not null)
				entityToCreate.CreateRefToTransaction(relatedEntity);
			else
				throw new RelatedEntityNotFoundException("Transaction", request.EntityDto.TransactionId.NonNullValue<System.Guid>().ToString());
		}
		else if(request.EntityDto.Transaction is not null)
		{
			var relatedEntity = await TransactionFactory.CreateEntityAsync(request.EntityDto.Transaction, request.CultureCode);
			entityToCreate.CreateRefToTransaction(relatedEntity);
		}

		await OnCompletedAsync(request, entityToCreate);
		await Repository.AddAsync<Cryptocash.Domain.Booking>(entityToCreate);
		await Repository.SaveChangesAsync();
		return new BookingKeyDto(entityToCreate.Id.Value);
	}
}