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

public class UpdateTransactionCommandHandler: CommandBase<UpdateTransactionCommand, Transaction>, IRequestHandler<UpdateTransactionCommand, TransactionKeyDto?>
{
	public CryptocashDbContext DbContext { get; }
	public IEntityMapper<Transaction> EntityMapper { get; }

	public UpdateTransactionCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityMapper<Transaction> entityMapper): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
		EntityMapper = entityMapper;
	}
	
	public async Task<TransactionKeyDto?> Handle(UpdateTransactionCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = CreateNoxTypeForKey<Transaction,DatabaseNumber>("Id", request.keyId);
	
		var entity = await DbContext.Transactions.FindAsync(keyId);
		if (entity == null)
		{
			return null;
		}

		EntityMapper.MapToEntity(entity, GetEntityDefinition<Transaction>(), request.EntityDto);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

		OnCompleted(entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		if (result < 1)
		{
			return null;
		}

		return new TransactionKeyDto(entity.Id.Value);
	}
}