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
using TransactionEntity = Cryptocash.Domain.Transaction;

namespace Cryptocash.Application.Commands;

public record CreateTransactionCommand(TransactionCreateDto EntityDto) : IRequest<TransactionKeyDto>;

internal partial class CreateTransactionCommandHandler : CreateTransactionCommandHandlerBase
{
	public CreateTransactionCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<Cryptocash.Domain.Customer, CustomerCreateDto, CustomerUpdateDto> customerfactory,
		IEntityFactory<Cryptocash.Domain.Booking, BookingCreateDto, BookingUpdateDto> bookingfactory,
		IEntityFactory<TransactionEntity, TransactionCreateDto, TransactionUpdateDto> entityFactory)
		: base(dbContext, noxSolution,customerfactory, bookingfactory, entityFactory)
	{
	}
}


internal abstract class CreateTransactionCommandHandlerBase : CommandBase<CreateTransactionCommand,TransactionEntity>, IRequestHandler <CreateTransactionCommand, TransactionKeyDto>
{
	private readonly CryptocashDbContext _dbContext;
	private readonly IEntityFactory<TransactionEntity, TransactionCreateDto, TransactionUpdateDto> _entityFactory;
	private readonly IEntityFactory<Cryptocash.Domain.Customer, CustomerCreateDto, CustomerUpdateDto> _customerfactory;
	private readonly IEntityFactory<Cryptocash.Domain.Booking, BookingCreateDto, BookingUpdateDto> _bookingfactory;

	public CreateTransactionCommandHandlerBase(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<Cryptocash.Domain.Customer, CustomerCreateDto, CustomerUpdateDto> customerfactory,
		IEntityFactory<Cryptocash.Domain.Booking, BookingCreateDto, BookingUpdateDto> bookingfactory,
		IEntityFactory<TransactionEntity, TransactionCreateDto, TransactionUpdateDto> entityFactory) : base(noxSolution)
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
			var relatedKey = Cryptocash.Domain.CustomerMetadata.CreateId(request.EntityDto.TransactionForCustomerId.NonNullValue<System.Int64>());
			var relatedEntity = await _dbContext.Customers.FindAsync(relatedKey);
			if(relatedEntity is not null)
				entityToCreate.CreateRefToTransactionForCustomer(relatedEntity);
			else
				throw new RelatedEntityNotFoundException("TransactionForCustomer", request.EntityDto.TransactionForCustomerId.NonNullValue<System.Int64>().ToString());
		}
		else if(request.EntityDto.TransactionForCustomer is not null)
		{
			var relatedEntity = _customerfactory.CreateEntity(request.EntityDto.TransactionForCustomer);
			entityToCreate.CreateRefToTransactionForCustomer(relatedEntity);
		}
		if(request.EntityDto.TransactionForBookingId is not null)
		{
			var relatedKey = Cryptocash.Domain.BookingMetadata.CreateId(request.EntityDto.TransactionForBookingId.NonNullValue<System.Guid>());
			var relatedEntity = await _dbContext.Bookings.FindAsync(relatedKey);
			if(relatedEntity is not null)
				entityToCreate.CreateRefToTransactionForBooking(relatedEntity);
			else
				throw new RelatedEntityNotFoundException("TransactionForBooking", request.EntityDto.TransactionForBookingId.NonNullValue<System.Guid>().ToString());
		}
		else if(request.EntityDto.TransactionForBooking is not null)
		{
			var relatedEntity = _bookingfactory.CreateEntity(request.EntityDto.TransactionForBooking);
			entityToCreate.CreateRefToTransactionForBooking(relatedEntity);
		}

		await OnCompletedAsync(request, entityToCreate);
		_dbContext.Transactions.Add(entityToCreate);
		await _dbContext.SaveChangesAsync();
		return new TransactionKeyDto(entityToCreate.Id.Value);
	}
}