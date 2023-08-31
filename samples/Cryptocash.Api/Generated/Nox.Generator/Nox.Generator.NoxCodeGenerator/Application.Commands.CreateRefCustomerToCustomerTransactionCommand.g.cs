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

using CryptocashApi.Infrastructure.Persistence;
using CryptocashApi.Domain;
using CryptocashApi.Application.Dto;

namespace CryptocashApi.Application.Commands;
public record CreateRefCustomerToCustomerTransactionCommand(CustomerKeyDto EntityKeyDto, CustomerTransactionKeyDto RelatedEntityKeyDto) : IRequest <bool>;

public partial class CreateRefCustomerToCustomerTransactionCommandHandler: CommandBase<CreateRefCustomerToCustomerTransactionCommand, Customer>, 
	IRequestHandler <CreateRefCustomerToCustomerTransactionCommand, bool>
{
	public CryptocashApiDbContext DbContext { get; }

	public CreateRefCustomerToCustomerTransactionCommandHandler(
		CryptocashApiDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
	}

	public async Task<bool> Handle(CreateRefCustomerToCustomerTransactionCommand request, CancellationToken cancellationToken)
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
		entity.CustomerTransactions.Add(relatedEntity);

		OnCompleted(entity);
	
		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}