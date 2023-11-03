﻿// Generated

#nullable enable

using MediatR;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nox.Abstractions;
using Nox.Application;
using Nox.Application.Commands;
using Nox.Exceptions;
using Nox.Extensions;
using Nox.Application.Factories;
using Nox.Solution;

using Cryptocash.Infrastructure.Persistence;
using Cryptocash.Domain;
using Cryptocash.Application.Dto;
using LandLordEntity = Cryptocash.Domain.LandLord;

namespace Cryptocash.Application.Commands;

public record CreateLandLordCommand(LandLordCreateDto EntityDto, Nox.Types.CultureCode CultureCode) : IRequest<LandLordKeyDto>;

internal partial class CreateLandLordCommandHandler : CreateLandLordCommandHandlerBase
{
	public CreateLandLordCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<Cryptocash.Domain.VendingMachine, VendingMachineCreateDto, VendingMachineUpdateDto> VendingMachineFactory,
		IEntityFactory<LandLordEntity, LandLordCreateDto, LandLordUpdateDto> entityFactory)
		: base(dbContext, noxSolution,VendingMachineFactory, entityFactory)
	{
	}
}


internal abstract class CreateLandLordCommandHandlerBase : CommandBase<CreateLandLordCommand,LandLordEntity>, IRequestHandler <CreateLandLordCommand, LandLordKeyDto>
{
	protected readonly AppDbContext DbContext;
	protected readonly IEntityFactory<LandLordEntity, LandLordCreateDto, LandLordUpdateDto> EntityFactory;
	protected readonly IEntityFactory<Cryptocash.Domain.VendingMachine, VendingMachineCreateDto, VendingMachineUpdateDto> VendingMachineFactory;

	public CreateLandLordCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<Cryptocash.Domain.VendingMachine, VendingMachineCreateDto, VendingMachineUpdateDto> VendingMachineFactory,
		IEntityFactory<LandLordEntity, LandLordCreateDto, LandLordUpdateDto> entityFactory)
		: base(noxSolution)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
		this.VendingMachineFactory = VendingMachineFactory;
	}

	public virtual async Task<LandLordKeyDto> Handle(CreateLandLordCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);

		var entityToCreate = EntityFactory.CreateEntity(request.EntityDto);
		if(request.EntityDto.VendingMachinesId.Any())
		{
			foreach(var relatedId in request.EntityDto.VendingMachinesId)
			{
				var relatedKey = Cryptocash.Domain.VendingMachineMetadata.CreateId(relatedId);
				var relatedEntity = await DbContext.VendingMachines.FindAsync(relatedKey);

				if(relatedEntity is not null)
					entityToCreate.CreateRefToVendingMachines(relatedEntity);
				else
					throw new RelatedEntityNotFoundException("VendingMachines", relatedId.ToString());
			}
		}
		else
		{
			foreach(var relatedCreateDto in request.EntityDto.VendingMachines)
			{
				var relatedEntity = VendingMachineFactory.CreateEntity(relatedCreateDto);
				entityToCreate.CreateRefToVendingMachines(relatedEntity);
			}
		}

		await OnCompletedAsync(request, entityToCreate);
		DbContext.LandLords.Add(entityToCreate);
		await DbContext.SaveChangesAsync();
		return new LandLordKeyDto(entityToCreate.Id.Value);
	}
}