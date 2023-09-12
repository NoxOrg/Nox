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

public record PartialUpdateTransactionCommand(System.Int64 keyId, Dictionary<string, dynamic> UpdatedProperties) : IRequest <TransactionKeyDto?>;

public class PartialUpdateTransactionCommandHandler: CommandBase<PartialUpdateTransactionCommand, Transaction>, IRequestHandler<PartialUpdateTransactionCommand, TransactionKeyDto?>
{
	public CryptocashDbContext DbContext { get; }
	public IEntityMapper<Transaction> EntityMapper { get; }

	public PartialUpdateTransactionCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityMapper<Transaction> entityMapper): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
		EntityMapper = entityMapper;
	}

	public async Task<TransactionKeyDto?> Handle(PartialUpdateTransactionCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = CreateNoxTypeForKey<Transaction,Nox.Types.AutoNumber>("Id", request.keyId);

		var entity = await DbContext.Transactions.FindAsync(keyId);
		if (entity == null)
		{
			return null;
		}
		EntityMapper.PartialMapToEntity(entity, GetEntityDefinition<Transaction>(), request.UpdatedProperties);

		OnCompleted(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return new TransactionKeyDto(entity.Id.Value);
	}
}