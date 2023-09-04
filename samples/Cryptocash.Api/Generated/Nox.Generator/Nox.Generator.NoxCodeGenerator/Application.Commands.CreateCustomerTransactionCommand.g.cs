﻿// Generated

#nullable enable

using MediatR;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nox.Abstractions;
using Nox.Application;
using Nox.Application.Commands;
using Nox.Factories;
using Nox.Solution;

using Cryptocash.Infrastructure.Persistence;
using Cryptocash.Domain;
using Cryptocash.Application.Dto;
using CustomerTransaction = Cryptocash.Domain.CustomerTransaction;

namespace Cryptocash.Application.Commands;
public record CreateCustomerTransactionCommand(CustomerTransactionCreateDto EntityDto) : IRequest<CustomerTransactionKeyDto>;

public partial class CreateCustomerTransactionCommandHandler: CommandBase<CreateCustomerTransactionCommand,CustomerTransaction>, IRequestHandler <CreateCustomerTransactionCommand, CustomerTransactionKeyDto>
{
	public CryptocashDbContext DbContext { get; }

	public CreateCustomerTransactionCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
	}

	public async Task<CustomerTransactionKeyDto> Handle(CreateCustomerTransactionCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);

		var entityToCreate = request.EntityDto.ToEntity();
	
		OnCompleted(entityToCreate);
		DbContext.CustomerTransactions.Add(entityToCreate);
		await DbContext.SaveChangesAsync();
		return new CustomerTransactionKeyDto(entityToCreate.Id.Value);
	}
}