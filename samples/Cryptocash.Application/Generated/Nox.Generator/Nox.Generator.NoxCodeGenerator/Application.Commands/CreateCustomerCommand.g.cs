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
using FluentValidation;
using Microsoft.Extensions.Logging;

using Cryptocash.Infrastructure.Persistence;
using Cryptocash.Domain;
using Cryptocash.Application.Dto;
using Dto = Cryptocash.Application.Dto;
using CustomerEntity = Cryptocash.Domain.Customer;

namespace Cryptocash.Application.Commands;

public partial record CreateCustomerCommand(CustomerCreateDto EntityDto, Nox.Types.CultureCode CultureCode) : IRequest<CustomerKeyDto>;

internal partial class CreateCustomerCommandHandler : CreateCustomerCommandHandlerBase
{
	public CreateCustomerCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<Cryptocash.Domain.PaymentDetail, PaymentDetailCreateDto, PaymentDetailUpdateDto> PaymentDetailFactory,
		IEntityFactory<Cryptocash.Domain.Booking, BookingCreateDto, BookingUpdateDto> BookingFactory,
		IEntityFactory<Cryptocash.Domain.Transaction, TransactionCreateDto, TransactionUpdateDto> TransactionFactory,
		IEntityFactory<Cryptocash.Domain.Country, CountryCreateDto, CountryUpdateDto> CountryFactory,
		IEntityFactory<CustomerEntity, CustomerCreateDto, CustomerUpdateDto> entityFactory)
		: base(dbContext, noxSolution,PaymentDetailFactory, BookingFactory, TransactionFactory, CountryFactory, entityFactory)
	{
	}
}


internal abstract class CreateCustomerCommandHandlerBase : CommandBase<CreateCustomerCommand,CustomerEntity>, IRequestHandler <CreateCustomerCommand, CustomerKeyDto>
{
	protected readonly AppDbContext DbContext;
	protected readonly IEntityFactory<CustomerEntity, CustomerCreateDto, CustomerUpdateDto> EntityFactory;
	protected readonly IEntityFactory<Cryptocash.Domain.PaymentDetail, PaymentDetailCreateDto, PaymentDetailUpdateDto> PaymentDetailFactory;
	protected readonly IEntityFactory<Cryptocash.Domain.Booking, BookingCreateDto, BookingUpdateDto> BookingFactory;
	protected readonly IEntityFactory<Cryptocash.Domain.Transaction, TransactionCreateDto, TransactionUpdateDto> TransactionFactory;
	protected readonly IEntityFactory<Cryptocash.Domain.Country, CountryCreateDto, CountryUpdateDto> CountryFactory;

	protected CreateCustomerCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<Cryptocash.Domain.PaymentDetail, PaymentDetailCreateDto, PaymentDetailUpdateDto> PaymentDetailFactory,
		IEntityFactory<Cryptocash.Domain.Booking, BookingCreateDto, BookingUpdateDto> BookingFactory,
		IEntityFactory<Cryptocash.Domain.Transaction, TransactionCreateDto, TransactionUpdateDto> TransactionFactory,
		IEntityFactory<Cryptocash.Domain.Country, CountryCreateDto, CountryUpdateDto> CountryFactory,
		IEntityFactory<CustomerEntity, CustomerCreateDto, CustomerUpdateDto> entityFactory)
	: base(noxSolution)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
		this.PaymentDetailFactory = PaymentDetailFactory;
		this.BookingFactory = BookingFactory;
		this.TransactionFactory = TransactionFactory;
		this.CountryFactory = CountryFactory;
	}

	public virtual async Task<CustomerKeyDto> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);

		var entityToCreate = await EntityFactory.CreateEntityAsync(request.EntityDto, request.CultureCode);
		if(request.EntityDto.PaymentDetailsId.Any())
		{
			foreach(var relatedId in request.EntityDto.PaymentDetailsId)
			{
				var relatedKey = Dto.PaymentDetailMetadata.CreateId(relatedId);
				var relatedEntity = await DbContext.PaymentDetails.FindAsync(relatedKey);

				if(relatedEntity is not null)
					entityToCreate.CreateRefToPaymentDetails(relatedEntity);
				else
					throw new RelatedEntityNotFoundException("PaymentDetails", relatedId.ToString());
			}
		}
		else
		{
			foreach(var relatedCreateDto in request.EntityDto.PaymentDetails)
			{
				var relatedEntity = await PaymentDetailFactory.CreateEntityAsync(relatedCreateDto, request.CultureCode);
				entityToCreate.CreateRefToPaymentDetails(relatedEntity);
			}
		}
		if(request.EntityDto.BookingsId.Any())
		{
			foreach(var relatedId in request.EntityDto.BookingsId)
			{
				var relatedKey = Dto.BookingMetadata.CreateId(relatedId);
				var relatedEntity = await DbContext.Bookings.FindAsync(relatedKey);

				if(relatedEntity is not null)
					entityToCreate.CreateRefToBookings(relatedEntity);
				else
					throw new RelatedEntityNotFoundException("Bookings", relatedId.ToString());
			}
		}
		else
		{
			foreach(var relatedCreateDto in request.EntityDto.Bookings)
			{
				var relatedEntity = await BookingFactory.CreateEntityAsync(relatedCreateDto, request.CultureCode);
				entityToCreate.CreateRefToBookings(relatedEntity);
			}
		}
		if(request.EntityDto.TransactionsId.Any())
		{
			foreach(var relatedId in request.EntityDto.TransactionsId)
			{
				var relatedKey = Dto.TransactionMetadata.CreateId(relatedId);
				var relatedEntity = await DbContext.Transactions.FindAsync(relatedKey);

				if(relatedEntity is not null)
					entityToCreate.CreateRefToTransactions(relatedEntity);
				else
					throw new RelatedEntityNotFoundException("Transactions", relatedId.ToString());
			}
		}
		else
		{
			foreach(var relatedCreateDto in request.EntityDto.Transactions)
			{
				var relatedEntity = await TransactionFactory.CreateEntityAsync(relatedCreateDto, request.CultureCode);
				entityToCreate.CreateRefToTransactions(relatedEntity);
			}
		}
		if(request.EntityDto.CountryId is not null)
		{
			var relatedKey = Dto.CountryMetadata.CreateId(request.EntityDto.CountryId.NonNullValue<System.String>());
			var relatedEntity = await DbContext.Countries.FindAsync(relatedKey);
			if(relatedEntity is not null)
				entityToCreate.CreateRefToCountry(relatedEntity);
			else
				throw new RelatedEntityNotFoundException("Country", request.EntityDto.CountryId.NonNullValue<System.String>().ToString());
		}
		else if(request.EntityDto.Country is not null)
		{
			var relatedEntity = await CountryFactory.CreateEntityAsync(request.EntityDto.Country, request.CultureCode);
			entityToCreate.CreateRefToCountry(relatedEntity);
		}

		await OnCompletedAsync(request, entityToCreate);
		DbContext.Customers.Add(entityToCreate);
		await DbContext.SaveChangesAsync();
		return new CustomerKeyDto(entityToCreate.Id.Value);
	}
}