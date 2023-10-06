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
using Nox.Factories;
using Nox.Solution;

using Cryptocash.Infrastructure.Persistence;
using Cryptocash.Domain;
using Cryptocash.Application.Dto;
using CustomerEntity = Cryptocash.Domain.Customer;

namespace Cryptocash.Application.Commands;

public record CreateCustomerCommand(CustomerCreateDto EntityDto) : IRequest<CustomerKeyDto>;

internal partial class CreateCustomerCommandHandler : CreateCustomerCommandHandlerBase
{
	public CreateCustomerCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<Cryptocash.Domain.PaymentDetail, PaymentDetailCreateDto, PaymentDetailUpdateDto> paymentdetailfactory,
		IEntityFactory<Cryptocash.Domain.Booking, BookingCreateDto, BookingUpdateDto> bookingfactory,
		IEntityFactory<Cryptocash.Domain.Transaction, TransactionCreateDto, TransactionUpdateDto> transactionfactory,
		IEntityFactory<Cryptocash.Domain.Country, CountryCreateDto, CountryUpdateDto> countryfactory,
		IEntityFactory<CustomerEntity, CustomerCreateDto, CustomerUpdateDto> entityFactory)
		: base(dbContext, noxSolution,paymentdetailfactory, bookingfactory, transactionfactory, countryfactory, entityFactory)
	{
	}
}


internal abstract class CreateCustomerCommandHandlerBase : CommandBase<CreateCustomerCommand,CustomerEntity>, IRequestHandler <CreateCustomerCommand, CustomerKeyDto>
{
	private readonly CryptocashDbContext _dbContext;
	private readonly IEntityFactory<CustomerEntity, CustomerCreateDto, CustomerUpdateDto> _entityFactory;
	private readonly IEntityFactory<Cryptocash.Domain.PaymentDetail, PaymentDetailCreateDto, PaymentDetailUpdateDto> _paymentdetailfactory;
	private readonly IEntityFactory<Cryptocash.Domain.Booking, BookingCreateDto, BookingUpdateDto> _bookingfactory;
	private readonly IEntityFactory<Cryptocash.Domain.Transaction, TransactionCreateDto, TransactionUpdateDto> _transactionfactory;
	private readonly IEntityFactory<Cryptocash.Domain.Country, CountryCreateDto, CountryUpdateDto> _countryfactory;

	public CreateCustomerCommandHandlerBase(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<Cryptocash.Domain.PaymentDetail, PaymentDetailCreateDto, PaymentDetailUpdateDto> paymentdetailfactory,
		IEntityFactory<Cryptocash.Domain.Booking, BookingCreateDto, BookingUpdateDto> bookingfactory,
		IEntityFactory<Cryptocash.Domain.Transaction, TransactionCreateDto, TransactionUpdateDto> transactionfactory,
		IEntityFactory<Cryptocash.Domain.Country, CountryCreateDto, CountryUpdateDto> countryfactory,
		IEntityFactory<CustomerEntity, CustomerCreateDto, CustomerUpdateDto> entityFactory) : base(noxSolution)
	{
		_dbContext = dbContext;
		_entityFactory = entityFactory;
		_paymentdetailfactory = paymentdetailfactory;
		_bookingfactory = bookingfactory;
		_transactionfactory = transactionfactory;
		_countryfactory = countryfactory;
	}

	public virtual async Task<CustomerKeyDto> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);

		var entityToCreate = _entityFactory.CreateEntity(request.EntityDto);
		foreach(var relatedCreateDto in request.EntityDto.CustomerRelatedPaymentDetails)
		{
			var relatedEntity = _paymentdetailfactory.CreateEntity(relatedCreateDto);
			entityToCreate.CreateRefToCustomerRelatedPaymentDetails(relatedEntity);
		}
		foreach(var relatedCreateDto in request.EntityDto.CustomerRelatedBookings)
		{
			var relatedEntity = _bookingfactory.CreateEntity(relatedCreateDto);
			entityToCreate.CreateRefToCustomerRelatedBookings(relatedEntity);
		}
		foreach(var relatedCreateDto in request.EntityDto.CustomerRelatedTransactions)
		{
			var relatedEntity = _transactionfactory.CreateEntity(relatedCreateDto);
			entityToCreate.CreateRefToCustomerRelatedTransactions(relatedEntity);
		}
		if(request.EntityDto.CustomerBaseCountryId is not null)
		{
			var relatedKey = Cryptocash.Domain.CountryMetadata.CreateId(request.EntityDto.CustomerBaseCountryId.NonNullValue<System.String>());
			var relatedEntity = await _dbContext.Countries.FindAsync(relatedKey);
			if(relatedEntity is not null)
				entityToCreate.CreateRefToCustomerBaseCountry(relatedEntity);
			else
				throw new RelatedEntityNotFoundException("CustomerBaseCountry", request.EntityDto.CustomerBaseCountryId.NonNullValue<System.String>().ToString());
		}
		else if(request.EntityDto.CustomerBaseCountry is not null)
		{
			var relatedEntity = _countryfactory.CreateEntity(request.EntityDto.CustomerBaseCountry);
			entityToCreate.CreateRefToCustomerBaseCountry(relatedEntity);
		}

		OnCompleted(request, entityToCreate);
		_dbContext.Customers.Add(entityToCreate);
		await _dbContext.SaveChangesAsync();
		return new CustomerKeyDto(entityToCreate.Id.Value);
	}
}