﻿// Generated

#nullable enable

using MediatR;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nox.Application;
using Nox.Application.Commands;
using Nox.Factories;
using Nox.Solution;
using Nox.Types;

using Cryptocash.Infrastructure.Persistence;
using Cryptocash.Domain;
using Cryptocash.Application.Dto;

namespace Cryptocash.Application.Commands;
public record DeleteRefCustomerToCustomerTransactionCommand(CustomerKeyDto EntityKeyDto, CustomerTransactionKeyDto RelatedEntityKeyDto) : IRequest <bool>;

public partial class DeleteRefCustomerToCustomerTransactionCommandHandler: CommandBase<DeleteRefCustomerToCustomerTransactionCommand, Customer>, 
	IRequestHandler <DeleteRefCustomerToCustomerTransactionCommand, bool>
{
	public CryptocashDbContext DbContext { get; }

	public DeleteRefCustomerToCustomerTransactionCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
	}

	public async Task<bool> Handle(DeleteRefCustomerToCustomerTransactionCommand request, CancellationToken cancellationToken)
	{
		OnExecuting(request);
		var keyId = CreateNoxTypeForKey<Customer,DatabaseNumber>("Id", request.EntityKeyDto.keyId);

		var entity = await DbContext.Customers.FindAsync(keyId);
		if (entity == null)
		{
			return false;
		}
		var relatedKeyId = CreateNoxTypeForKey<CustomerTransaction,DatabaseNumber>("Id", request.RelatedEntityKeyDto.keyId);
		var relatedEntity = await DbContext.CustomerTransactions.FindAsync(relatedKeyId);
		if (relatedEntity == null)
		{
			return false;
		}
		entity.CustomerTransactions.Remove(relatedEntity);

		OnCompleted(entity);
	
		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}