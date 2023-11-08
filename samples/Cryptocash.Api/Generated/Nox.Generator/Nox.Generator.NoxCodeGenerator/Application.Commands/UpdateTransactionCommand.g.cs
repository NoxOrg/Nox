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
using TransactionEntity = Cryptocash.Domain.Transaction;

namespace Cryptocash.Application.Commands;

public record UpdateTransactionCommand(System.Int64 keyId, TransactionUpdateDto EntityDto, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest<TransactionKeyDto?>;

internal partial class UpdateTransactionCommandHandler : UpdateTransactionCommandHandlerBase
{
	public UpdateTransactionCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TransactionEntity, TransactionCreateDto, TransactionUpdateDto> entityFactory) 
		: base(dbContext, noxSolution, entityFactory)
	{
	}
}

internal abstract class UpdateTransactionCommandHandlerBase : CommandBase<UpdateTransactionCommand, TransactionEntity>, IRequestHandler<UpdateTransactionCommand, TransactionKeyDto?>
{
	public AppDbContext DbContext { get; }
	private readonly IEntityFactory<TransactionEntity, TransactionCreateDto, TransactionUpdateDto> _entityFactory;

	public UpdateTransactionCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TransactionEntity, TransactionCreateDto, TransactionUpdateDto> entityFactory)
		: base(noxSolution)
	{
		DbContext = dbContext;
		_entityFactory = entityFactory;
	}

	public virtual async Task<TransactionKeyDto?> Handle(UpdateTransactionCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = Cryptocash.Domain.TransactionMetadata.CreateId(request.keyId);

		var entity = await DbContext.Transactions.FindAsync(keyId);
		if (entity == null)
		{
			return null;
		}

		var customerKey = Cryptocash.Domain.CustomerMetadata.CreateId(request.EntityDto.CustomerId);
		var customerEntity = await DbContext.Customers.FindAsync(customerKey);
						
		if(customerEntity is not null)
			entity.CreateRefToCustomer(customerEntity);
		else
			throw new RelatedEntityNotFoundException("Customer", request.EntityDto.CustomerId.ToString());

		var bookingKey = Cryptocash.Domain.BookingMetadata.CreateId(request.EntityDto.BookingId);
		var bookingEntity = await DbContext.Bookings.FindAsync(bookingKey);
						
		if(bookingEntity is not null)
			entity.CreateRefToBooking(bookingEntity);
		else
			throw new RelatedEntityNotFoundException("Booking", request.EntityDto.BookingId.ToString());

		_entityFactory.UpdateEntity(entity, request.EntityDto, request.CultureCode);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		if (result < 1)
		{
			return null;
		}

		return new TransactionKeyDto(entity.Id.Value);
	}
}