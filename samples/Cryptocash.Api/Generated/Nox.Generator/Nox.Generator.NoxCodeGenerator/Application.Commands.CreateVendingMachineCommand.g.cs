﻿﻿// Generated

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
using VendingMachine = Cryptocash.Domain.VendingMachine;

namespace Cryptocash.Application.Commands;
public record CreateVendingMachineCommand(VendingMachineCreateDto EntityDto) : IRequest<VendingMachineKeyDto>;

public partial class CreateVendingMachineCommandHandler: CommandBase<CreateVendingMachineCommand,VendingMachine>, IRequestHandler <CreateVendingMachineCommand, VendingMachineKeyDto>
{
	public CryptocashDbContext DbContext { get; }
	public IEntityFactory<VendingMachineCreateDto,VendingMachine> EntityFactory { get; }

	public CreateVendingMachineCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityFactory<VendingMachineCreateDto,VendingMachine> entityFactory): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
	}

	public async Task<VendingMachineKeyDto> Handle(CreateVendingMachineCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);

		var entityToCreate = EntityFactory.CreateEntity(request.EntityDto);
	
		OnCompleted(entityToCreate);
		DbContext.VendingMachines.Add(entityToCreate);
		await DbContext.SaveChangesAsync();
		return new VendingMachineKeyDto(entityToCreate.Id.Value);
	}
}