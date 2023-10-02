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
using LandLord = Cryptocash.Domain.LandLord;

namespace Cryptocash.Application.Commands;

public record CreateLandLordCommand(LandLordCreateDto EntityDto) : IRequest<LandLordKeyDto>;

internal partial class CreateLandLordCommandHandler: CreateLandLordCommandHandlerBase
{
	public CreateLandLordCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<VendingMachine, VendingMachineCreateDto, VendingMachineUpdateDto> vendingmachinefactory,
		IEntityFactory<LandLord, LandLordCreateDto, LandLordUpdateDto> entityFactory)
		: base(dbContext, noxSolution,vendingmachinefactory, entityFactory)
	{
	}
}


internal abstract class CreateLandLordCommandHandlerBase: CommandBase<CreateLandLordCommand,LandLord>, IRequestHandler <CreateLandLordCommand, LandLordKeyDto>
{
	private readonly CryptocashDbContext _dbContext;
	private readonly IEntityFactory<LandLord, LandLordCreateDto, LandLordUpdateDto> _entityFactory;
	private readonly IEntityFactory<VendingMachine, VendingMachineCreateDto, VendingMachineUpdateDto> _vendingmachinefactory;

	public CreateLandLordCommandHandlerBase(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<VendingMachine, VendingMachineCreateDto, VendingMachineUpdateDto> vendingmachinefactory,
		IEntityFactory<LandLord, LandLordCreateDto, LandLordUpdateDto> entityFactory): base(noxSolution)
	{
		_dbContext = dbContext;
		_entityFactory = entityFactory;
		_vendingmachinefactory = vendingmachinefactory;
	}

	public virtual async Task<LandLordKeyDto> Handle(CreateLandLordCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);

		var entityToCreate = _entityFactory.CreateEntity(request.EntityDto);
		foreach(var relatedCreateDto in request.EntityDto.ContractedAreasForVendingMachines)
		{
			var relatedEntity = _vendingmachinefactory.CreateEntity(relatedCreateDto);
			entityToCreate.CreateRefToContractedAreasForVendingMachines(relatedEntity);
		}

		OnCompleted(request, entityToCreate);
		_dbContext.LandLords.Add(entityToCreate);
		await _dbContext.SaveChangesAsync();
		return new LandLordKeyDto(entityToCreate.Id.Value);
	}
}