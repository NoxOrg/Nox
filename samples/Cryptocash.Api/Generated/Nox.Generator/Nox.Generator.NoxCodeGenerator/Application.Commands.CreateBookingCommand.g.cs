﻿// Generated

#nullable enable

using MediatR;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nox.Abstractions;
using Nox.Application;
using Nox.Application.Commands;
using Nox.Factories;
using Nox.Solution;

using Cryptocash.Infrastructure.Persistence;
using Cryptocash.Domain;
using Cryptocash.Application.Dto;
using Booking = Cryptocash.Domain.Booking;

namespace Cryptocash.Application.Commands;

public record CreateBookingCommand(BookingCreateDto EntityDto) : IRequest<BookingKeyDto>;

public partial class CreateBookingCommandHandler: CreateBookingCommandHandlerBase
{
	public CreateBookingCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
        IEntityFactory<Customer, CustomerCreateDto, CustomerUpdateDto> customerfactory,
        IEntityFactory<VendingMachine, VendingMachineCreateDto, VendingMachineUpdateDto> vendingmachinefactory,
        IEntityFactory<Commission, CommissionCreateDto, CommissionUpdateDto> commissionfactory,
        IEntityFactory<Transaction, TransactionCreateDto, TransactionUpdateDto> transactionfactory,
        IEntityFactory<Booking, BookingCreateDto, BookingUpdateDto> entityFactory,
		IServiceProvider serviceProvider)
		: base(dbContext, noxSolution,customerfactory, vendingmachinefactory, commissionfactory, transactionfactory, entityFactory, serviceProvider)
	{
	}
}


public abstract class CreateBookingCommandHandlerBase: CommandBase<CreateBookingCommand,Booking>, IRequestHandler <CreateBookingCommand, BookingKeyDto>
{
	private readonly CryptocashDbContext _dbContext;
	private readonly IEntityFactory<Booking, BookingCreateDto, BookingUpdateDto> _entityFactory;
    private readonly IEntityFactory<Customer, CustomerCreateDto, CustomerUpdateDto> _customerfactory;
    private readonly IEntityFactory<VendingMachine, VendingMachineCreateDto, VendingMachineUpdateDto> _vendingmachinefactory;
    private readonly IEntityFactory<Commission, CommissionCreateDto, CommissionUpdateDto> _commissionfactory;
    private readonly IEntityFactory<Transaction, TransactionCreateDto, TransactionUpdateDto> _transactionfactory;

	public CreateBookingCommandHandlerBase(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
        IEntityFactory<Customer, CustomerCreateDto, CustomerUpdateDto> customerfactory,
        IEntityFactory<VendingMachine, VendingMachineCreateDto, VendingMachineUpdateDto> vendingmachinefactory,
        IEntityFactory<Commission, CommissionCreateDto, CommissionUpdateDto> commissionfactory,
        IEntityFactory<Transaction, TransactionCreateDto, TransactionUpdateDto> transactionfactory,
        IEntityFactory<Booking, BookingCreateDto, BookingUpdateDto> entityFactory,
		IServiceProvider serviceProvider): base(noxSolution, serviceProvider)
	{
		_dbContext = dbContext;
		_entityFactory = entityFactory;
        _customerfactory = customerfactory;
        _vendingmachinefactory = vendingmachinefactory;
        _commissionfactory = commissionfactory;
        _transactionfactory = transactionfactory;
	}

	public virtual async Task<BookingKeyDto> Handle(CreateBookingCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);

		var entityToCreate = _entityFactory.CreateEntity(request.EntityDto);
		if(request.EntityDto.BookingForCustomer is not null)
		{
			var relatedEntity = _customerfactory.CreateEntity(request.EntityDto.BookingForCustomer);
			entityToCreate.CreateRefToBookingForCustomer(relatedEntity);
		}
		if(request.EntityDto.BookingRelatedVendingMachine is not null)
		{
			var relatedEntity = _vendingmachinefactory.CreateEntity(request.EntityDto.BookingRelatedVendingMachine);
			entityToCreate.CreateRefToBookingRelatedVendingMachine(relatedEntity);
		}
		if(request.EntityDto.BookingFeesForCommission is not null)
		{
			var relatedEntity = _commissionfactory.CreateEntity(request.EntityDto.BookingFeesForCommission);
			entityToCreate.CreateRefToBookingFeesForCommission(relatedEntity);
		}
		if(request.EntityDto.BookingRelatedTransaction is not null)
		{
			var relatedEntity = _transactionfactory.CreateEntity(request.EntityDto.BookingRelatedTransaction);
			entityToCreate.CreateRefToBookingRelatedTransaction(relatedEntity);
		}

		OnCompleted(request, entityToCreate);
		_dbContext.Bookings.Add(entityToCreate);
		await _dbContext.SaveChangesAsync();
		return new BookingKeyDto(entityToCreate.Id.Value);
	}
}