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

using ClientApi.Infrastructure.Persistence;
using ClientApi.Domain;
using ClientApi.Application.Dto;
using CountryEntity = ClientApi.Domain.Country;

namespace ClientApi.Application.Commands;

public record CreateCountryCommand(CountryCreateDto EntityDto, Nox.Types.CultureCode CultureCode) : IRequest<CountryKeyDto>;

internal partial class CreateCountryCommandHandler : CreateCountryCommandHandlerBase
{
	public CreateCountryCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<ClientApi.Domain.Workplace, WorkplaceCreateDto, WorkplaceUpdateDto> WorkplaceFactory,
		IEntityFactory<CountryEntity, CountryCreateDto, CountryUpdateDto> entityFactory)
		: base(dbContext, noxSolution,WorkplaceFactory, entityFactory)
	{
	}
}


internal abstract class CreateCountryCommandHandlerBase : CommandBase<CreateCountryCommand,CountryEntity>, IRequestHandler <CreateCountryCommand, CountryKeyDto>
{
	protected readonly AppDbContext DbContext;
	protected readonly IEntityFactory<CountryEntity, CountryCreateDto, CountryUpdateDto> EntityFactory;
	protected readonly IEntityFactory<ClientApi.Domain.Workplace, WorkplaceCreateDto, WorkplaceUpdateDto> WorkplaceFactory;

	public CreateCountryCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<ClientApi.Domain.Workplace, WorkplaceCreateDto, WorkplaceUpdateDto> WorkplaceFactory,
		IEntityFactory<CountryEntity, CountryCreateDto, CountryUpdateDto> entityFactory)
		: base(noxSolution)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
		this.WorkplaceFactory = WorkplaceFactory;
	}

	public virtual async Task<CountryKeyDto> Handle(CreateCountryCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);

		var entityToCreate = EntityFactory.CreateEntity(request.EntityDto);
		if(request.EntityDto.WorkplacesId.Any())
		{
			foreach(var relatedId in request.EntityDto.WorkplacesId)
			{
				var relatedKey = ClientApi.Domain.WorkplaceMetadata.CreateId(relatedId);
				var relatedEntity = await DbContext.Workplaces.FindAsync(relatedKey);

				if(relatedEntity is not null)
					entityToCreate.CreateRefToWorkplaces(relatedEntity);
				else
					throw new RelatedEntityNotFoundException("Workplaces", relatedId.ToString());
			}
		}
		else
		{
			foreach(var relatedCreateDto in request.EntityDto.Workplaces)
			{
				var relatedEntity = WorkplaceFactory.CreateEntity(relatedCreateDto);
				entityToCreate.CreateRefToWorkplaces(relatedEntity);
			}
		}

		await OnCompletedAsync(request, entityToCreate);
		DbContext.Countries.Add(entityToCreate);
		await DbContext.SaveChangesAsync();
		return new CountryKeyDto(entityToCreate.Id.Value);
	}
}