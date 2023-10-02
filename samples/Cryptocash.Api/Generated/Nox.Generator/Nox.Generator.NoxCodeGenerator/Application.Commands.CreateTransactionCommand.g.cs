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

internal partial class CreateTransactionCommandHandler: CreateTransactionCommandHandlerBase
{
	public CreateTransactionCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<Customer, CustomerCreateDto, CustomerUpdateDto> customerfactory,
		IEntityFactory<Booking, BookingCreateDto, BookingUpdateDto> bookingfactory,
		IEntityFactory<Transaction, TransactionCreateDto, TransactionUpdateDto> entityFactory)
		: base(dbContext, noxSolution,customerfactory, bookingfactory, entityFactory)
	{
	}
}


internal abstract class CreateTransactionCommandHandlerBase: CommandBase<CreateTransactionCommand,Transaction>, IRequestHandler <CreateTransactionCommand, TransactionKeyDto>
{
	private readonly CryptocashDbContext _dbContext;
	private readonly IEntityFactory<Transaction, TransactionCreateDto, TransactionUpdateDto> _entityFactory;
	private readonly IEntityFactory<Customer, CustomerCreateDto, CustomerUpdateDto> _customerfactory;
	private readonly IEntityFactory<Booking, BookingCreateDto, BookingUpdateDto> _bookingfactory;

	public CreateTransactionCommandHandlerBase(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<Customer, CustomerCreateDto, CustomerUpdateDto> customerfactory,
		IEntityFactory<Booking, BookingCreateDto, BookingUpdateDto> bookingfactory,
		IEntityFactory<Transaction, TransactionCreateDto, TransactionUpdateDto> entityFactory): base(noxSolution)
	{
		_dbContext = dbContext;
		_entityFactory = entityFactory;
		_customerfactory = customerfactory;
		_bookingfactory = bookingfactory;
	}

	public virtual async Task<TransactionKeyDto> Handle(CreateTransactionCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);

		var entityToCreate = _entityFactory.CreateEntity(request.EntityDto);
		if(request.EntityDto.TransactionForCustomerId is not null)
		{
			var relatedKey = CreateNoxTypeForKey<Customer, Nox.Types.AutoNumber>("Id", request.EntityDto.TransactionForCustomerId);
			var relatedEntity = await _dbContext.Customers.FindAsync(relatedKey);
			if(relatedEntity is not null && relatedEntity.DeletedAtUtc == null)
				entityToCreate.CreateRefToTransactionForCustomer(relatedEntity);
		}
		else if(request.EntityDto.TransactionForCustomer is not null)
		{
			var relatedEntity = _customerfactory.CreateEntity(request.EntityDto.TransactionForCustomer);
			entityToCreate.CreateRefToTransactionForCustomer(relatedEntity);
		}
		if(request.EntityDto.TransactionForBookingId is not null)
		{
			var relatedKey = CreateNoxTypeForKey<Booking, Nox.Types.Guid>("Id", request.EntityDto.TransactionForBookingId);
			var relatedEntity = await _dbContext.Bookings.FindAsync(relatedKey);
			if(relatedEntity is not null && relatedEntity.DeletedAtUtc == null)
				entityToCreate.CreateRefToTransactionForBooking(relatedEntity);
		}
		else if(request.EntityDto.TransactionForBooking is not null)
		{
			var relatedEntity = _bookingfactory.CreateEntity(request.EntityDto.TransactionForBooking);
			entityToCreate.CreateRefToTransactionForBooking(relatedEntity);
		}

		OnCompleted(request, entityToCreate);
		_dbContext.Transactions.Add(entityToCreate);
		await _dbContext.SaveChangesAsync();
		return new TransactionKeyDto(entityToCreate.Id.Value);
	}
}