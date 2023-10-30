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
using CustomerEntity = Cryptocash.Domain.Customer;

namespace Cryptocash.Application.Commands;

public record CreateCustomerCommand(CustomerCreateDto EntityDto) : IRequest<CustomerKeyDto>;

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

	public CreateCustomerCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<Cryptocash.Domain.PaymentDetail, PaymentDetailCreateDto, PaymentDetailUpdateDto> PaymentDetailFactory,
		IEntityFactory<Cryptocash.Domain.Booking, BookingCreateDto, BookingUpdateDto> BookingFactory,
		IEntityFactory<Cryptocash.Domain.Transaction, TransactionCreateDto, TransactionUpdateDto> TransactionFactory,
		IEntityFactory<Cryptocash.Domain.Country, CountryCreateDto, CountryUpdateDto> CountryFactory,
		IEntityFactory<CustomerEntity, CustomerCreateDto, CustomerUpdateDto> entityFactory) : base(noxSolution)
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

		var entityToCreate = EntityFactory.CreateEntity(request.EntityDto);
		foreach(var relatedCreateDto in request.EntityDto.CustomerRelatedPaymentDetails)
		{
			var relatedEntity = PaymentDetailFactory.CreateEntity(relatedCreateDto);
			entityToCreate.CreateRefToCustomerRelatedPaymentDetails(relatedEntity);
		}
		foreach(var relatedCreateDto in request.EntityDto.CustomerRelatedBookings)
		{
			var relatedEntity = BookingFactory.CreateEntity(relatedCreateDto);
			entityToCreate.CreateRefToCustomerRelatedBookings(relatedEntity);
		}
		foreach(var relatedCreateDto in request.EntityDto.CustomerRelatedTransactions)
		{
			var relatedEntity = TransactionFactory.CreateEntity(relatedCreateDto);
			entityToCreate.CreateRefToCustomerRelatedTransactions(relatedEntity);
		}
		if(request.EntityDto.CustomerBaseCountryId is not null)
		{
			var relatedKey = Cryptocash.Domain.CountryMetadata.CreateId(request.EntityDto.CustomerBaseCountryId.NonNullValue<System.String>());
			var relatedEntity = await DbContext.Countries.FindAsync(relatedKey);
			if(relatedEntity is not null)
				entityToCreate.CreateRefToCustomerBaseCountry(relatedEntity);
			else
				throw new RelatedEntityNotFoundException("CustomerBaseCountry", request.EntityDto.CustomerBaseCountryId.NonNullValue<System.String>().ToString());
		}
		else if(request.EntityDto.CustomerBaseCountry is not null)
		{
			var relatedEntity = CountryFactory.CreateEntity(request.EntityDto.CustomerBaseCountry);
			entityToCreate.CreateRefToCustomerBaseCountry(relatedEntity);
		}

		await OnCompletedAsync(request, entityToCreate);
		DbContext.Customers.Add(entityToCreate);
		await DbContext.SaveChangesAsync();
		return new CustomerKeyDto(entityToCreate.Id.Value);
	}
}