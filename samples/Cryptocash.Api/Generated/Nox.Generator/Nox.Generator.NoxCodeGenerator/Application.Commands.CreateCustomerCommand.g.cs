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
using Customer = Cryptocash.Domain.Customer;

namespace Cryptocash.Application.Commands;

public record CreateCustomerCommand(CustomerCreateDto EntityDto) : IRequest<CustomerKeyDto>;

public partial class CreateCustomerCommandHandler: CommandBase<CreateCustomerCommand,Customer>, IRequestHandler <CreateCustomerCommand, CustomerKeyDto>
{
	private readonly CryptocashDbContext _dbContext;
	private readonly IEntityFactory<CustomerCreateDto,Customer> _entityFactory;

	public CreateCustomerCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
        IEntityFactory<CustomerCreateDto,Customer> entityFactory,
		IServiceProvider serviceProvider): base(noxSolution, serviceProvider)
	{
		_dbContext = dbContext;
		_entityFactory = entityFactory;
	}

	public async Task<CustomerKeyDto> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);

		var entityToCreate = _entityFactory.CreateEntity(request.EntityDto);		
	
		OnCompleted(entityToCreate);
		_dbContext.Customers.Add(entityToCreate);
		await _dbContext.SaveChangesAsync();
		return new CustomerKeyDto(entityToCreate.Id.Value);
	}
}