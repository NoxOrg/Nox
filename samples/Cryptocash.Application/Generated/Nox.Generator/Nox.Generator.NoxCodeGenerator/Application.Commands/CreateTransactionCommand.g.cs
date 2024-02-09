﻿// Generated

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
using TransactionEntity = Cryptocash.Domain.Transaction;

namespace Cryptocash.Application.Commands;

public partial record CreateTransactionCommand(TransactionCreateDto EntityDto, Nox.Types.CultureCode CultureCode) : IRequest<TransactionKeyDto>;

internal partial class CreateTransactionCommandHandler : CreateTransactionCommandHandlerBase
{
	public CreateTransactionCommandHandler(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<Cryptocash.Domain.Customer, CustomerCreateDto, CustomerUpdateDto> CustomerFactory,
		IEntityFactory<Cryptocash.Domain.Booking, BookingCreateDto, BookingUpdateDto> BookingFactory,
		IEntityFactory<TransactionEntity, TransactionCreateDto, TransactionUpdateDto> entityFactory)
		: base(repository, noxSolution,CustomerFactory, BookingFactory, entityFactory)
	{
	}
}


internal abstract class CreateTransactionCommandHandlerBase : CommandBase<CreateTransactionCommand,TransactionEntity>, IRequestHandler <CreateTransactionCommand, TransactionKeyDto>
{
	protected readonly IRepository Repository;
	protected readonly IEntityFactory<TransactionEntity, TransactionCreateDto, TransactionUpdateDto> EntityFactory;
	protected readonly IEntityFactory<Cryptocash.Domain.Customer, CustomerCreateDto, CustomerUpdateDto> CustomerFactory;
	protected readonly IEntityFactory<Cryptocash.Domain.Booking, BookingCreateDto, BookingUpdateDto> BookingFactory;

	protected CreateTransactionCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<Cryptocash.Domain.Customer, CustomerCreateDto, CustomerUpdateDto> CustomerFactory,
		IEntityFactory<Cryptocash.Domain.Booking, BookingCreateDto, BookingUpdateDto> BookingFactory,
		IEntityFactory<TransactionEntity, TransactionCreateDto, TransactionUpdateDto> entityFactory)
	: base(noxSolution)
	{
		Repository = repository;
		EntityFactory = entityFactory;
		this.CustomerFactory = CustomerFactory;
		this.BookingFactory = BookingFactory;
	}

	public virtual async Task<TransactionKeyDto> Handle(CreateTransactionCommand request, CancellationToken cancellationToken)
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
		if(request.EntityDto.BookingId is not null)
		{
			var relatedKey = Dto.BookingMetadata.CreateId(request.EntityDto.BookingId.NonNullValue<System.Guid>());
			var relatedEntity = await Repository.FindAsync<Cryptocash.Domain.Booking>(relatedKey);
			if(relatedEntity is not null)
				entityToCreate.CreateRefToBooking(relatedEntity);
			else
				throw new RelatedEntityNotFoundException("Booking", request.EntityDto.BookingId.NonNullValue<System.Guid>().ToString());
		}
		else if(request.EntityDto.Booking is not null)
		{
			var relatedEntity = await BookingFactory.CreateEntityAsync(request.EntityDto.Booking, request.CultureCode);
			entityToCreate.CreateRefToBooking(relatedEntity);
		}

		await OnCompletedAsync(request, entityToCreate);
		await Repository.AddAsync<Cryptocash.Domain.Transaction>(entityToCreate);
		await Repository.SaveChangesAsync();
		return new TransactionKeyDto(entityToCreate.Id.Value);
	}
}