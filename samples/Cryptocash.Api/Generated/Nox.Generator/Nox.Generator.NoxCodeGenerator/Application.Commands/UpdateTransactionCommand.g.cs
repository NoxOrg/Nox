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

public partial record UpdateTransactionCommand(System.Int64 keyId, TransactionUpdateDto EntityDto, System.Guid? Etag) : IRequest<TransactionKeyDto?>;

internal partial class UpdateTransactionCommandHandler : UpdateTransactionCommandHandlerBase
{
	public UpdateTransactionCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TransactionEntity, TransactionCreateDto, TransactionUpdateDto> entityFactory) : base(dbContext, noxSolution, entityFactory)
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
		IEntityFactory<TransactionEntity, TransactionCreateDto, TransactionUpdateDto> entityFactory) : base(noxSolution)
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

		var transactionForCustomerKey = Cryptocash.Domain.CustomerMetadata.CreateId(request.EntityDto.TransactionForCustomerId);
		var transactionForCustomerEntity = await DbContext.Customers.FindAsync(transactionForCustomerKey);
						
		if(transactionForCustomerEntity is not null)
			entity.CreateRefToTransactionForCustomer(transactionForCustomerEntity);
		else
			throw new RelatedEntityNotFoundException("TransactionForCustomer", request.EntityDto.TransactionForCustomerId.ToString());

		var transactionForBookingKey = Cryptocash.Domain.BookingMetadata.CreateId(request.EntityDto.TransactionForBookingId);
		var transactionForBookingEntity = await DbContext.Bookings.FindAsync(transactionForBookingKey);
						
		if(transactionForBookingEntity is not null)
			entity.CreateRefToTransactionForBooking(transactionForBookingEntity);
		else
			throw new RelatedEntityNotFoundException("TransactionForBooking", request.EntityDto.TransactionForBookingId.ToString());

		_entityFactory.UpdateEntity(entity, request.EntityDto);
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