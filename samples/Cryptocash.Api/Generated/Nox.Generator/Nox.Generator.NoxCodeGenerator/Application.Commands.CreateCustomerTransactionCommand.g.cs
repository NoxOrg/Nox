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

namespace Cryptocash.Application.Commands;
public record CreateCustomerTransactionCommand(CustomerTransactionCreateDto EntityDto) : IRequest<CustomerTransactionKeyDto>;

public partial class CreateCustomerTransactionCommandHandler: CommandBase<CreateCustomerTransactionCommand,CustomerTransaction>, IRequestHandler <CreateCustomerTransactionCommand, CustomerTransactionKeyDto>
{
	public CryptocashDbContext DbContext { get; }
	public IEntityFactory<CustomerTransactionCreateDto,CustomerTransaction> EntityFactory { get; }

	public CreateCustomerTransactionCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityFactory<CustomerTransactionCreateDto,CustomerTransaction> entityFactory): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
	}

	public async Task<CustomerTransactionKeyDto> Handle(CreateCustomerTransactionCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);

		var entityToCreate = EntityFactory.CreateEntity(request.EntityDto);
	
		OnCompleted(entityToCreate);
		DbContext.CustomerTransactions.Add(entityToCreate);
		await DbContext.SaveChangesAsync();
		return new CustomerTransactionKeyDto(entityToCreate.Id.Value);
	}
}