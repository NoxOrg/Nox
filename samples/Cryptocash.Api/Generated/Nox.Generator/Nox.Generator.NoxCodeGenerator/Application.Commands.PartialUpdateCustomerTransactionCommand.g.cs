﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Factories;
using Nox.Solution;
using Nox.Types;

using CryptocashApi.Infrastructure.Persistence;
using CryptocashApi.Domain;
using CryptocashApi.Application.Dto;
using CustomerTransaction = CryptocashApi.Domain.CustomerTransaction;

namespace CryptocashApi.Application.Commands;

public record PartialUpdateCustomerTransactionCommand(System.Int64 keyId, Dictionary<string, dynamic> UpdatedProperties) : IRequest <CustomerTransactionKeyDto?>;

public class PartialUpdateCustomerTransactionCommandHandler: CommandBase<PartialUpdateCustomerTransactionCommand, CustomerTransaction>, IRequestHandler<PartialUpdateCustomerTransactionCommand, CustomerTransactionKeyDto?>
{
	public CryptocashApiDbContext DbContext { get; }
	public IEntityMapper<CustomerTransaction> EntityMapper { get; }

	public PartialUpdateCustomerTransactionCommandHandler(
		CryptocashApiDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityMapper<CustomerTransaction> entityMapper): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
		EntityMapper = entityMapper;
	}

	public async Task<CustomerTransactionKeyDto?> Handle(PartialUpdateCustomerTransactionCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = CreateNoxTypeForKey<CustomerTransaction,DatabaseNumber>("Id", request.keyId);

		var entity = await DbContext.CustomerTransactions.FindAsync(keyId);
		if (entity == null)
		{
			return null;
		}
		EntityMapper.PartialMapToEntity(entity, GetEntityDefinition<CustomerTransaction>(), request.UpdatedProperties);

		OnCompleted(entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return new CustomerTransactionKeyDto(entity.Id.Value);
	}
}