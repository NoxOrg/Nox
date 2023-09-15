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
using Transaction = Cryptocash.Domain.Transaction;

namespace Cryptocash.Application.Commands;

public record CreateTransactionCommand(TransactionCreateDto EntityDto) : IRequest<TransactionKeyDto>;

public partial class CreateTransactionCommandHandler: CreateTransactionCommandHandlerBase
{
	public CreateTransactionCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
        IEntityFactory<Customer,CustomerCreateDto> customerfactory,
        IEntityFactory<Booking,BookingCreateDto> bookingfactory,
        IEntityFactory<Transaction,TransactionCreateDto> entityFactory,
		IServiceProvider serviceProvider): base(dbContext, noxSolution,customerfactory,bookingfactory,entityFactory, serviceProvider)
	{
	}
}


public partial class CreateTransactionCommandHandlerBase: CommandBase<CreateTransactionCommand,Transaction>, IRequestHandler <CreateTransactionCommand, TransactionKeyDto>
{
	private readonly CryptocashDbContext _dbContext;
	private readonly IEntityFactory<Transaction,TransactionCreateDto> _entityFactory;
    private readonly IEntityFactory<Customer,CustomerCreateDto> _customerfactory;
    private readonly IEntityFactory<Booking,BookingCreateDto> _bookingfactory;

	public CreateTransactionCommandHandlerBase(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
        IEntityFactory<Customer,CustomerCreateDto> customerfactory,
        IEntityFactory<Booking,BookingCreateDto> bookingfactory,
        IEntityFactory<Transaction,TransactionCreateDto> entityFactory,
		IServiceProvider serviceProvider): base(noxSolution, serviceProvider)
	{
		_dbContext = dbContext;
		_entityFactory = entityFactory;        
        _customerfactory = customerfactory;        
        _bookingfactory = bookingfactory;
	}

	public async Task<TransactionKeyDto> Handle(CreateTransactionCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);

		var entityToCreate = _entityFactory.CreateEntity(request.EntityDto);
		if(request.EntityDto.TransactionForCustomer is not null)
		{ 
			var relatedEntity = _customerfactory.CreateEntity(request.EntityDto.TransactionForCustomer);
			entityToCreate.CreateRefToCustomerTransactionForCustomer(relatedEntity);
		}
		if(request.EntityDto.TransactionForBooking is not null)
		{ 
			var relatedEntity = _bookingfactory.CreateEntity(request.EntityDto.TransactionForBooking);
			entityToCreate.CreateRefToBookingTransactionForBooking(relatedEntity);
		}
					
		OnCompleted(request, entityToCreate);
		_dbContext.Transactions.Add(entityToCreate);
		await _dbContext.SaveChangesAsync();
		return new TransactionKeyDto(entityToCreate.Id.Value);
	}
}