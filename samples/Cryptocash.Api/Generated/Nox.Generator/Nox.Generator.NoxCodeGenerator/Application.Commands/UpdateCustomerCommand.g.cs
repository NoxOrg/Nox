﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Nox.Application.Factories;
using Nox.Exceptions;
using Nox.Extensions;
using Cryptocash.Infrastructure.Persistence;
using Cryptocash.Domain;
using Cryptocash.Application.Dto;
using CustomerEntity = Cryptocash.Domain.Customer;

namespace Cryptocash.Application.Commands;

public partial record UpdateCustomerCommand(System.Int64 keyId, CustomerUpdateDto EntityDto, System.Guid? Etag) : IRequest<CustomerKeyDto?>;

internal partial class UpdateCustomerCommandHandler : UpdateCustomerCommandHandlerBase
{
	public UpdateCustomerCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<CustomerEntity, CustomerCreateDto, CustomerUpdateDto> entityFactory) : base(dbContext, noxSolution, entityFactory)
	{
	}
}

internal abstract class UpdateCustomerCommandHandlerBase : CommandBase<UpdateCustomerCommand, CustomerEntity>, IRequestHandler<UpdateCustomerCommand, CustomerKeyDto?>
{
	public AppDbContext DbContext { get; }
	private readonly IEntityFactory<CustomerEntity, CustomerCreateDto, CustomerUpdateDto> _entityFactory;

	public UpdateCustomerCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<CustomerEntity, CustomerCreateDto, CustomerUpdateDto> entityFactory) : base(noxSolution)
	{
		DbContext = dbContext;
		_entityFactory = entityFactory;
	}

	public virtual async Task<CustomerKeyDto?> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = Cryptocash.Domain.CustomerMetadata.CreateId(request.keyId);

		var entity = await DbContext.Customers.FindAsync(keyId);
		if (entity == null)
		{
			return null;
		}

		await DbContext.Entry(entity).Collection(x => x.PaymentDetails).LoadAsync();
		var paymentDetailsEntities = new List<PaymentDetail>();
		foreach(var relatedEntityId in request.EntityDto.PaymentDetailsId)
		{
			var relatedKey = Cryptocash.Domain.PaymentDetailMetadata.CreateId(relatedEntityId);
			var relatedEntity = await DbContext.PaymentDetails.FindAsync(relatedKey);
						
			if(relatedEntity is not null)
				paymentDetailsEntities.Add(relatedEntity);
			else
				throw new RelatedEntityNotFoundException("PaymentDetails", relatedEntityId.ToString());
		}
		entity.UpdateRefToPaymentDetails(paymentDetailsEntities);

		await DbContext.Entry(entity).Collection(x => x.Bookings).LoadAsync();
		var bookingsEntities = new List<Booking>();
		foreach(var relatedEntityId in request.EntityDto.BookingsId)
		{
			var relatedKey = Cryptocash.Domain.BookingMetadata.CreateId(relatedEntityId);
			var relatedEntity = await DbContext.Bookings.FindAsync(relatedKey);
						
			if(relatedEntity is not null)
				bookingsEntities.Add(relatedEntity);
			else
				throw new RelatedEntityNotFoundException("Bookings", relatedEntityId.ToString());
		}
		entity.UpdateRefToBookings(bookingsEntities);

		await DbContext.Entry(entity).Collection(x => x.Transactions).LoadAsync();
		var transactionsEntities = new List<Transaction>();
		foreach(var relatedEntityId in request.EntityDto.TransactionsId)
		{
			var relatedKey = Cryptocash.Domain.TransactionMetadata.CreateId(relatedEntityId);
			var relatedEntity = await DbContext.Transactions.FindAsync(relatedKey);
						
			if(relatedEntity is not null)
				transactionsEntities.Add(relatedEntity);
			else
				throw new RelatedEntityNotFoundException("Transactions", relatedEntityId.ToString());
		}
		entity.UpdateRefToTransactions(transactionsEntities);

		var countryKey = Cryptocash.Domain.CountryMetadata.CreateId(request.EntityDto.CountryId);
		var countryEntity = await DbContext.Countries.FindAsync(countryKey);
						
		if(countryEntity is not null)
			entity.CreateRefToCountry(countryEntity);
		else
			throw new RelatedEntityNotFoundException("Country", request.EntityDto.CountryId.ToString());

		_entityFactory.UpdateEntity(entity, request.EntityDto);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		if (result < 1)
		{
			return null;
		}

		return new CustomerKeyDto(entity.Id.Value);
	}
}