﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Nox.Factories;
using Cryptocash.Infrastructure.Persistence;
using Cryptocash.Domain;
using Cryptocash.Application.Dto;
using Transaction = Cryptocash.Domain.Transaction;

namespace Cryptocash.Application.Commands;

public record UpdateTransactionCommand(System.Int64 keyId, TransactionUpdateDto EntityDto, System.Guid? Etag) : IRequest<TransactionKeyDto?>;

internal partial class UpdateTransactionCommandHandler: UpdateTransactionCommandHandlerBase
{
	public UpdateTransactionCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityFactory<Transaction, TransactionCreateDto, TransactionUpdateDto> entityFactory): base(dbContext, noxSolution, serviceProvider, entityFactory)
	{
	}
}

internal abstract class UpdateTransactionCommandHandlerBase: CommandBase<UpdateTransactionCommand, Transaction>, IRequestHandler<UpdateTransactionCommand, TransactionKeyDto?>
{
	public CryptocashDbContext DbContext { get; }
	private readonly IEntityFactory<Transaction, TransactionCreateDto, TransactionUpdateDto> _entityFactory;

	public UpdateTransactionCommandHandlerBase(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityFactory<Transaction, TransactionCreateDto, TransactionUpdateDto> entityFactory): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
		_entityFactory = entityFactory;
	}

	public virtual async Task<TransactionKeyDto?> Handle(UpdateTransactionCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = CreateNoxTypeForKey<Transaction,Nox.Types.AutoNumber>("Id", request.keyId);

		var entity = await DbContext.Transactions.FindAsync(keyId);
		if (entity == null)
		{
			return null;
		}

		_entityFactory.UpdateEntity(entity, request.EntityDto);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

		OnCompleted(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		if (result < 1)
		{
			return null;
		}

		return new TransactionKeyDto(entity.Id.Value);
	}
}