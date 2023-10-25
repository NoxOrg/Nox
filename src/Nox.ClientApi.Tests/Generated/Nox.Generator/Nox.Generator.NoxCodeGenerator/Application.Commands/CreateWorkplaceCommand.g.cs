﻿// Generated

#nullable enable

using MediatR;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nox.Application;
using Nox.Application.Commands;
using Nox.Exceptions;
using Nox.Extensions;
using Nox.Application.Factories;
using Nox.Solution;

using ClientApi.Infrastructure.Persistence;
using ClientApi.Domain;
using ClientApi.Application.Dto;
using WorkplaceEntity = ClientApi.Domain.Workplace;

namespace ClientApi.Application.Commands;

public record CreateWorkplaceCommand(WorkplaceCreateDto EntityDto, System.String CultureCode) : IRequest<WorkplaceKeyDto>;

internal partial class CreateWorkplaceCommandHandler : CreateWorkplaceCommandHandlerBase
{
	public CreateWorkplaceCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<ClientApi.Domain.Country, CountryCreateDto, CountryUpdateDto> CountryFactory,
		IEntityFactory<WorkplaceEntity, WorkplaceCreateDto, WorkplaceUpdateDto> entityFactory)
		: base(dbContext, noxSolution,CountryFactory, entityFactory)
	{
	}
}


internal abstract class CreateWorkplaceCommandHandlerBase : CommandBase<CreateWorkplaceCommand,WorkplaceEntity>, IRequestHandler <CreateWorkplaceCommand, WorkplaceKeyDto>
{
	protected readonly AppDbContext DbContext;
	protected readonly IEntityFactory<WorkplaceEntity, WorkplaceCreateDto, WorkplaceUpdateDto> EntityFactory;
	protected readonly IEntityFactory<ClientApi.Domain.Country, CountryCreateDto, CountryUpdateDto> CountryFactory;

	public CreateWorkplaceCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<ClientApi.Domain.Country, CountryCreateDto, CountryUpdateDto> CountryFactory,
		IEntityFactory<WorkplaceEntity, WorkplaceCreateDto, WorkplaceUpdateDto> entityFactory) : base(noxSolution)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
		this.CountryFactory = CountryFactory;
	}

	public virtual async Task<WorkplaceKeyDto> Handle(CreateWorkplaceCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);

		var entityToCreate = EntityFactory.CreateEntity(request.EntityDto);
		if(request.EntityDto.BelongsToCountryId is not null)
		{
			var relatedKey = ClientApi.Domain.CountryMetadata.CreateId(request.EntityDto.BelongsToCountryId.NonNullValue<System.Int64>());
			var relatedEntity = await DbContext.Countries.FindAsync(relatedKey);
			if(relatedEntity is not null)
				entityToCreate.CreateRefToBelongsToCountry(relatedEntity);
			else
				throw new RelatedEntityNotFoundException("BelongsToCountry", request.EntityDto.BelongsToCountryId.NonNullValue<System.Int64>().ToString());
		}
		else if(request.EntityDto.BelongsToCountry is not null)
		{
			var relatedEntity = CountryFactory.CreateEntity(request.EntityDto.BelongsToCountry);
			entityToCreate.CreateRefToBelongsToCountry(relatedEntity);
		}

		await OnCompletedAsync(request, entityToCreate);
		DbContext.Workplaces.Add(entityToCreate);
		await DbContext.SaveChangesAsync();
		return new WorkplaceKeyDto(entityToCreate.Id.Value);
	}
}