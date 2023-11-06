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

public partial record Update CustomerCommand(System.Int64 keyId, CustomerUpdateDto EntityDto, System.Guid? Etag) : IRequest<CustomerKeyDto?>;

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

		await DbContext.Entry(entity).Collection(x => x.CustomerRelatedPaymentDetails).LoadAsync();
		var customerRelatedPaymentDetailsEntities = new List<PaymentDetail>();
		foreach(var relatedEntityId in request.EntityDto.CustomerRelatedPaymentDetailsId)
		{
			var relatedKey = Cryptocash.Domain.PaymentDetailMetadata.CreateId(relatedEntityId);
			var relatedEntity = await DbContext.PaymentDetails.FindAsync(relatedKey);
						
			if(relatedEntity is not null)
				customerRelatedPaymentDetailsEntities.Add(relatedEntity);
			else
				throw new RelatedEntityNotFoundException("CustomerRelatedPaymentDetails", relatedEntityId.ToString());
		}
		entity.UpdateRefToCustomerRelatedPaymentDetails(customerRelatedPaymentDetailsEntities);

		await DbContext.Entry(entity).Collection(x => x.CustomerRelatedBookings).LoadAsync();
		var customerRelatedBookingsEntities = new List<Booking>();
		foreach(var relatedEntityId in request.EntityDto.CustomerRelatedBookingsId)
		{
			var relatedKey = Cryptocash.Domain.BookingMetadata.CreateId(relatedEntityId);
			var relatedEntity = await DbContext.Bookings.FindAsync(relatedKey);
						
			if(relatedEntity is not null)
				customerRelatedBookingsEntities.Add(relatedEntity);
			else
				throw new RelatedEntityNotFoundException("CustomerRelatedBookings", relatedEntityId.ToString());
		}
		entity.UpdateRefToCustomerRelatedBookings(customerRelatedBookingsEntities);

		await DbContext.Entry(entity).Collection(x => x.CustomerRelatedTransactions).LoadAsync();
		var customerRelatedTransactionsEntities = new List<Transaction>();
		foreach(var relatedEntityId in request.EntityDto.CustomerRelatedTransactionsId)
		{
			var relatedKey = Cryptocash.Domain.TransactionMetadata.CreateId(relatedEntityId);
			var relatedEntity = await DbContext.Transactions.FindAsync(relatedKey);
						
			if(relatedEntity is not null)
				customerRelatedTransactionsEntities.Add(relatedEntity);
			else
				throw new RelatedEntityNotFoundException("CustomerRelatedTransactions", relatedEntityId.ToString());
		}
		entity.UpdateRefToCustomerRelatedTransactions(customerRelatedTransactionsEntities);

		var customerBaseCountryKey = Cryptocash.Domain.CountryMetadata.CreateId(request.EntityDto.CustomerBaseCountryId);
		var customerBaseCountryEntity = await DbContext.Countries.FindAsync(customerBaseCountryKey);
						
		if(customerBaseCountryEntity is not null)
			entity.CreateRefToCustomerBaseCountry(customerBaseCountryEntity);
		else
			throw new RelatedEntityNotFoundException("CustomerBaseCountry", request.EntityDto.CustomerBaseCountryId.ToString());

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