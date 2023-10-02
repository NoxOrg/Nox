﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Factories;
using Nox.Solution;
using Nox.Types;

using Cryptocash.Infrastructure.Persistence;
using Cryptocash.Domain;
using Cryptocash.Application.Dto;
using Transaction = Cryptocash.Domain.Transaction;

namespace Cryptocash.Application.Commands;

public record PartialUpdateTransactionCommand(System.Int64 keyId, Dictionary<string, dynamic> UpdatedProperties, System.Guid? Etag) : IRequest <TransactionKeyDto?>;

internal class PartialUpdateTransactionCommandHandler: PartialUpdateTransactionCommandHandlerBase
{
	public PartialUpdateTransactionCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<Transaction, TransactionCreateDto, TransactionUpdateDto> entityFactory) : base(dbContext,noxSolution, entityFactory)
	{
	}
}
internal class PartialUpdateTransactionCommandHandlerBase: CommandBase<PartialUpdateTransactionCommand, Transaction>, IRequestHandler<PartialUpdateTransactionCommand, TransactionKeyDto?>
{
	public CryptocashDbContext DbContext { get; }
	public IEntityFactory<Transaction, TransactionCreateDto, TransactionUpdateDto> EntityFactory { get; }

	public PartialUpdateTransactionCommandHandlerBase(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<Transaction, TransactionCreateDto, TransactionUpdateDto> entityFactory) : base(noxSolution)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
	}

	public virtual async Task<TransactionKeyDto?> Handle(PartialUpdateTransactionCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = Cryptocash.Domain.TransactionMetadata.CreateId(request.keyId);

		var entity = await DbContext.Transactions.FindAsync(keyId);
		if (entity == null)
		{
			return null;
		}
		EntityFactory.PartialUpdateEntity(entity, request.UpdatedProperties);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

		OnCompleted(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return new TransactionKeyDto(entity.Id.Value);
	}
}