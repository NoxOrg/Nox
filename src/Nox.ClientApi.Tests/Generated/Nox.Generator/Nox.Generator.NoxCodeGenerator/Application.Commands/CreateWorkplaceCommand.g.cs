﻿// Generated

#nullable enable

using MediatR;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nox.Application;
using Nox.Application.Commands;
using Nox.Exceptions;
using Nox.Extensions;
using Nox.Factories;
using Nox.Solution;

using ClientApi.Infrastructure.Persistence;
using ClientApi.Domain;
using ClientApi.Application.Dto;
using WorkplaceEntity = ClientApi.Domain.Workplace;

namespace ClientApi.Application.Commands;

public record CreateWorkplaceCommand(WorkplaceCreateDto EntityDto) : IRequest<WorkplaceKeyDto>;

internal partial class CreateWorkplaceCommandHandler : CreateWorkplaceCommandHandlerBase
{
	public CreateWorkplaceCommandHandler(
		ClientApiDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<ClientApi.Domain.Country, CountryCreateDto, CountryUpdateDto> countryfactory,
		IEntityFactory<WorkplaceEntity, WorkplaceCreateDto, WorkplaceUpdateDto> entityFactory)
		: base(dbContext, noxSolution,countryfactory, entityFactory)
	{
	}
}


internal abstract class CreateWorkplaceCommandHandlerBase : CommandBase<CreateWorkplaceCommand,WorkplaceEntity>, IRequestHandler <CreateWorkplaceCommand, WorkplaceKeyDto>
{
	private readonly ClientApiDbContext _dbContext;
	private readonly IEntityFactory<WorkplaceEntity, WorkplaceCreateDto, WorkplaceUpdateDto> _entityFactory;
	private readonly IEntityFactory<ClientApi.Domain.Country, CountryCreateDto, CountryUpdateDto> _countryfactory;

	public CreateWorkplaceCommandHandlerBase(
		ClientApiDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<ClientApi.Domain.Country, CountryCreateDto, CountryUpdateDto> countryfactory,
		IEntityFactory<WorkplaceEntity, WorkplaceCreateDto, WorkplaceUpdateDto> entityFactory) : base(noxSolution)
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
			var relatedKey = ClientApi.Domain.CountryMetadata.CreateId(request.EntityDto.BelongsToCountryId.NonNullValue<System.Int64>());
			var relatedEntity = await _dbContext.Countries.FindAsync(relatedKey);
			if(relatedEntity is not null)
				entityToCreate.CreateRefToBelongsToCountry(relatedEntity);
			else
				throw new RelatedEntityNotFoundException("BelongsToCountry", request.EntityDto.BelongsToCountryId.NonNullValue<System.Int64>().ToString());
		}
		else if(request.EntityDto.BelongsToCountry is not null)
		{
			var relatedEntity = _countryfactory.CreateEntity(request.EntityDto.BelongsToCountry);
			entityToCreate.CreateRefToBelongsToCountry(relatedEntity);
		}

		await OnCompletedAsync(request, entityToCreate);
		_dbContext.Workplaces.Add(entityToCreate);
		await _dbContext.SaveChangesAsync();
		return new WorkplaceKeyDto(entityToCreate.Id.Value);
	}
}