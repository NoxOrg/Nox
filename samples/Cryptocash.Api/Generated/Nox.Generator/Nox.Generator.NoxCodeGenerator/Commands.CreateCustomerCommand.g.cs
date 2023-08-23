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

public class CreateCustomerCommandHandler: CommandBase, IRequestHandler <CreateCustomerCommand, CustomerKeyDto>
{
	private readonly IUserProvider _userProvider;
	private readonly ISystemProvider _systemProvider;

	public CryptocashApiDbContext DbContext { get; }
	public IEntityFactory<CustomerCreateDto,Customer> EntityFactory { get; }

	public CreateCustomerCommandHandler(
		CryptocashApiDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityFactory<CustomerCreateDto,Customer> entityFactory,
		IUserProvider userProvider,
		ISystemProvider systemProvider): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
		_userProvider = userProvider;
		_systemProvider = systemProvider;
	}

	public async Task<CustomerKeyDto> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
	{
		var entityToCreate = EntityFactory.CreateEntity(request.EntityDto);
		var createdBy = _userProvider.GetUser();
		var createdVia = _systemProvider.GetSystem();
		entityToCreate.Created(createdBy, createdVia);
	
		DbContext.Customers.Add(entityToCreate);
		await DbContext.SaveChangesAsync();
		return new CustomerKeyDto(entityToCreate.Id.Value);
	}
}