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
using VendingMachine = Cryptocash.Domain.VendingMachine;

namespace Cryptocash.Application.Commands;

public record CreateVendingMachineCommand(VendingMachineCreateDto EntityDto) : IRequest<VendingMachineKeyDto>;

public partial class CreateVendingMachineCommandHandler: CommandBase<CreateVendingMachineCommand,VendingMachine>, IRequestHandler <CreateVendingMachineCommand, VendingMachineKeyDto>
{
	private readonly CryptocashDbContext _dbContext;
	private readonly IEntityFactory<VendingMachineCreateDto,VendingMachine> _entityFactory;

	public CreateVendingMachineCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
        IEntityFactory<VendingMachineCreateDto,VendingMachine> entityFactory,
		IServiceProvider serviceProvider): base(noxSolution, serviceProvider)
	{
		_dbContext = dbContext;
		_entityFactory = entityFactory;
	}

	public async Task<VendingMachineKeyDto> Handle(CreateVendingMachineCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);

		var entityToCreate = _entityFactory.CreateEntity(request.EntityDto);		
	
		OnCompleted(entityToCreate);
		_dbContext.VendingMachines.Add(entityToCreate);
		await _dbContext.SaveChangesAsync();
		return new VendingMachineKeyDto(entityToCreate.Id.Value);
	}
}