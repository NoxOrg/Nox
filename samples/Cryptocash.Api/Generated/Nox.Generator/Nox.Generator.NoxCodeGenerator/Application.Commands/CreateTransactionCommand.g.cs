﻿﻿// Generated

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

public partial record CreateTransactionCommand(TransactionCreateDto EntityDto, Nox.Types.CultureCode CultureCode) : IRequest<TransactionKeyDto>;

internal partial class CreateTransactionCommandHandler : CreateTransactionCommandHandlerBase
{
	public CreateTransactionCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<Cryptocash.Domain.Customer, CustomerCreateDto, CustomerUpdateDto> CustomerFactory,
		IEntityFactory<Cryptocash.Domain.Booking, BookingCreateDto, BookingUpdateDto> BookingFactory,
		IEntityFactory<TransactionEntity, TransactionCreateDto, TransactionUpdateDto> entityFactory)
		: base(dbContext, noxSolution,CustomerFactory, BookingFactory, entityFactory)
	{
	}
}


internal abstract class CreateTransactionCommandHandlerBase : CommandBase<CreateTransactionCommand,TransactionEntity>, IRequestHandler <CreateTransactionCommand, TransactionKeyDto>
{
	protected readonly AppDbContext DbContext;
	protected readonly IEntityFactory<TransactionEntity, TransactionCreateDto, TransactionUpdateDto> EntityFactory;
	protected readonly IEntityFactory<Cryptocash.Domain.Customer, CustomerCreateDto, CustomerUpdateDto> CustomerFactory;
	protected readonly IEntityFactory<Cryptocash.Domain.Booking, BookingCreateDto, BookingUpdateDto> BookingFactory;

	public CreateTransactionCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<Cryptocash.Domain.Customer, CustomerCreateDto, CustomerUpdateDto> CustomerFactory,
		IEntityFactory<Cryptocash.Domain.Booking, BookingCreateDto, BookingUpdateDto> BookingFactory,
		IEntityFactory<TransactionEntity, TransactionCreateDto, TransactionUpdateDto> entityFactory)
		: base(noxSolution)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
		this.CustomerFactory = CustomerFactory;
		this.BookingFactory = BookingFactory;
	}

	public virtual async Task<TransactionKeyDto> Handle(CreateTransactionCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);

		var entityToCreate = EntityFactory.CreateEntity(request.EntityDto);
		if(request.EntityDto.CustomerId is not null)
		{
			var relatedKey = Cryptocash.Domain.CustomerMetadata.CreateId(request.EntityDto.CustomerId.NonNullValue<System.Int64>());
			var relatedEntity = await DbContext.Customers.FindAsync(relatedKey);
			if(relatedEntity is not null)
				entityToCreate.CreateRefToCustomer(relatedEntity);
			else
				throw new RelatedEntityNotFoundException("Customer", request.EntityDto.CustomerId.NonNullValue<System.Int64>().ToString());
		}
		else if(request.EntityDto.Customer is not null)
		{
			var relatedEntity = CustomerFactory.CreateEntity(request.EntityDto.Customer);
			entityToCreate.CreateRefToCustomer(relatedEntity);
		}
		if(request.EntityDto.BookingId is not null)
		{
			var relatedKey = Cryptocash.Domain.BookingMetadata.CreateId(request.EntityDto.BookingId.NonNullValue<System.Guid>());
			var relatedEntity = await DbContext.Bookings.FindAsync(relatedKey);
			if(relatedEntity is not null)
				entityToCreate.CreateRefToBooking(relatedEntity);
			else
				throw new RelatedEntityNotFoundException("Booking", request.EntityDto.BookingId.NonNullValue<System.Guid>().ToString());
		}
		else if(request.EntityDto.Booking is not null)
		{
			var relatedEntity = BookingFactory.CreateEntity(request.EntityDto.Booking);
			entityToCreate.CreateRefToBooking(relatedEntity);
		}

		await OnCompletedAsync(request, entityToCreate);
		DbContext.Transactions.Add(entityToCreate);
		await DbContext.SaveChangesAsync();
		return new TransactionKeyDto(entityToCreate.Id.Value);
	}
}