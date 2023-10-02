﻿// Generated

#nullable enable

using MediatR;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nox.Application;
using Nox.Application.Commands;
using Nox.Factories;
using Nox.Solution;

using ClientApi.Infrastructure.Persistence;
using ClientApi.Domain;
using ClientApi.Application.Dto;
using Workplace = ClientApi.Domain.Workplace;

namespace ClientApi.Application.Commands;

public record CreateWorkplaceCommand(WorkplaceCreateDto EntityDto) : IRequest<WorkplaceKeyDto>;

internal partial class CreateWorkplaceCommandHandler: CreateWorkplaceCommandHandlerBase
{
	public CreateWorkplaceCommandHandler(
		ClientApiDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<Country, CountryCreateDto, CountryUpdateDto> countryfactory,
		IEntityFactory<Workplace, WorkplaceCreateDto, WorkplaceUpdateDto> entityFactory)
		: base(dbContext, noxSolution,countryfactory, entityFactory)
	{
	}
}


internal abstract class CreateWorkplaceCommandHandlerBase: CommandBase<CreateWorkplaceCommand,Workplace>, IRequestHandler <CreateWorkplaceCommand, WorkplaceKeyDto>
{
	private readonly ClientApiDbContext _dbContext;
	private readonly IEntityFactory<Workplace, WorkplaceCreateDto, WorkplaceUpdateDto> _entityFactory;
	private readonly IEntityFactory<Country, CountryCreateDto, CountryUpdateDto> _countryfactory;

	public CreateWorkplaceCommandHandlerBase(
		ClientApiDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<Country, CountryCreateDto, CountryUpdateDto> countryfactory,
		IEntityFactory<Workplace, WorkplaceCreateDto, WorkplaceUpdateDto> entityFactory): base(noxSolution)
	{
		_dbContext = dbContext;
		_entityFactory = entityFactory;
		_countryfactory = countryfactory;
	}

	public virtual async Task<WorkplaceKeyDto> Handle(CreateWorkplaceCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);

		var entityToCreate = _entityFactory.CreateEntity(request.EntityDto);
		if(request.EntityDto.BelongsToCountryId is not null)
		{
			var relatedKey = CreateNoxTypeForKey<Country, Nox.Types.AutoNumber>("Id", request.EntityDto.BelongsToCountryId);
			var relatedEntity = await _dbContext.Countries.FindAsync(relatedKey);
			if(relatedEntity is not null && relatedEntity.DeletedAtUtc == null)
				entityToCreate.CreateRefToBelongsToCountry(relatedEntity);
		}
		else if(request.EntityDto.BelongsToCountry is not null)
		{
			var relatedEntity = _countryfactory.CreateEntity(request.EntityDto.BelongsToCountry);
			entityToCreate.CreateRefToBelongsToCountry(relatedEntity);
		}

		OnCompleted(request, entityToCreate);
		_dbContext.Workplaces.Add(entityToCreate);
		await _dbContext.SaveChangesAsync();
		return new WorkplaceKeyDto(entityToCreate.Id.Value);
	}
}