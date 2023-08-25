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
public record CreateVendingMachineOrderCommand(VendingMachineOrderCreateDto EntityDto) : IRequest<VendingMachineOrderKeyDto>;

public partial class CreateVendingMachineOrderCommandHandler: CommandBase<CreateVendingMachineOrderCommand,VendingMachineOrder>, IRequestHandler <CreateVendingMachineOrderCommand, VendingMachineOrderKeyDto>
{
	public CryptocashApiDbContext DbContext { get; }
	public IEntityFactory<VendingMachineOrderCreateDto,VendingMachineOrder> EntityFactory { get; }

	public CreateVendingMachineOrderCommandHandler(
		CryptocashApiDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityFactory<VendingMachineOrderCreateDto,VendingMachineOrder> entityFactory): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
	}

	public async Task<VendingMachineOrderKeyDto> Handle(CreateVendingMachineOrderCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);

		var entityToCreate = EntityFactory.CreateEntity(request.EntityDto);
	
		OnCompleted(entityToCreate);
		DbContext.VendingMachineOrders.Add(entityToCreate);
		await DbContext.SaveChangesAsync();
		return new VendingMachineOrderKeyDto(entityToCreate.Id.Value);
	}
}