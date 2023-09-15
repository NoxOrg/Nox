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

public partial class CreateLandLordCommandHandler: CommandBase<CreateLandLordCommand,LandLord>, IRequestHandler <CreateLandLordCommand, LandLordKeyDto>
{
	private readonly CryptocashDbContext _dbContext;
	private readonly IEntityFactory<LandLord,LandLordCreateDto> _entityFactory;
    private readonly IEntityFactory<VendingMachine,VendingMachineCreateDto> _vendingmachinefactory;

	public CreateLandLordCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
        IEntityFactory<VendingMachine,VendingMachineCreateDto> vendingmachinefactory,
        IEntityFactory<LandLord,LandLordCreateDto> entityFactory,
		IServiceProvider serviceProvider): base(noxSolution, serviceProvider)
	{
		_dbContext = dbContext;
		_entityFactory = entityFactory;        
        _vendingmachinefactory = vendingmachinefactory;
	}

	public async Task<LandLordKeyDto> Handle(CreateLandLordCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);

		var entityToCreate = _entityFactory.CreateEntity(request.EntityDto);
		foreach(var relatedCreateDto in request.EntityDto.ContractedAreasForVendingMachines)
		{
			var relatedEntity = _vendingmachinefactory.CreateEntity(relatedCreateDto);
			entityToCreate.CreateRefToVendingMachine(relatedEntity);
		}
					
		OnCompleted(request, entityToCreate);
		_dbContext.LandLords.Add(entityToCreate);
		await _dbContext.SaveChangesAsync();
		return new LandLordKeyDto(entityToCreate.Id.Value);
	}
}