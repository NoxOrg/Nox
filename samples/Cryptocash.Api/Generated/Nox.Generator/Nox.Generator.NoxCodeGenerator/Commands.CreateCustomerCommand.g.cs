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

using CryptocashApi.Infrastructure.Persistence;
using CryptocashApi.Domain;
using CryptocashApi.Application.Dto;

namespace CryptocashApi.Application.Commands;
public record CreateCustomerCommand(CustomerCreateDto EntityDto) : IRequest<CustomerKeyDto>;

public partial class CreateCustomerCommandHandler: CommandBase<CreateCustomerCommand>, IRequestHandler <CreateCustomerCommand, CustomerKeyDto>
{
	public CryptocashApiDbContext DbContext { get; }
	public IEntityFactory<CustomerCreateDto,Customer> EntityFactory { get; }

	public CreateCustomerCommandHandler(
		CryptocashApiDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityFactory<CustomerCreateDto,Customer> entityFactory): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
	}

	public async Task<CustomerKeyDto> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
	{
		OnExecuting(request, cancellationToken);

		var entityToCreate = EntityFactory.CreateEntity(request.EntityDto);
	
		DbContext.Customers.Add(entityToCreate);
		await DbContext.SaveChangesAsync();
		return new CustomerKeyDto(entityToCreate.Id.Value);
	}
}