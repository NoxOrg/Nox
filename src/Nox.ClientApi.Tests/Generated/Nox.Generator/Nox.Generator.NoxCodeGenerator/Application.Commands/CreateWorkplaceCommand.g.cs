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
using FluentValidation;
using Microsoft.Extensions.Logging;

using ClientApi.Infrastructure.Persistence;
using ClientApi.Domain;
using ClientApi.Application.Dto;
using WorkplaceEntity = ClientApi.Domain.Workplace;

namespace ClientApi.Application.Commands;

public partial record CreateWorkplaceCommand(WorkplaceCreateDto EntityDto, Nox.Types.CultureCode CultureCode) : IRequest<WorkplaceKeyDto>;

internal partial class CreateWorkplaceCommandHandler : CreateWorkplaceCommandHandlerBase
{
	public CreateWorkplaceCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<ClientApi.Domain.Country, CountryCreateDto, CountryUpdateDto> CountryFactory,
		IEntityFactory<ClientApi.Domain.Tenant, TenantCreateDto, TenantUpdateDto> TenantFactory,
		IEntityFactory<WorkplaceEntity, WorkplaceCreateDto, WorkplaceUpdateDto> entityFactory,
		IEntityLocalizedFactory<WorkplaceLocalized, WorkplaceEntity, WorkplaceUpdateDto> entityLocalizedFactory)
		: base(dbContext, noxSolution,CountryFactory, TenantFactory, entityFactory, entityLocalizedFactory)
	{
	}
}


internal abstract class CreateWorkplaceCommandHandlerBase : CommandBase<CreateWorkplaceCommand,WorkplaceEntity>, IRequestHandler <CreateWorkplaceCommand, WorkplaceKeyDto>
{
	protected readonly AppDbContext DbContext;
	protected readonly IEntityFactory<WorkplaceEntity, WorkplaceCreateDto, WorkplaceUpdateDto> EntityFactory;
	protected readonly IEntityLocalizedFactory<WorkplaceLocalized, WorkplaceEntity, WorkplaceUpdateDto> EntityLocalizedFactory;
	protected readonly IEntityFactory<ClientApi.Domain.Country, CountryCreateDto, CountryUpdateDto> CountryFactory;
	protected readonly IEntityFactory<ClientApi.Domain.Tenant, TenantCreateDto, TenantUpdateDto> TenantFactory;

	protected CreateWorkplaceCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<ClientApi.Domain.Country, CountryCreateDto, CountryUpdateDto> CountryFactory,
		IEntityFactory<ClientApi.Domain.Tenant, TenantCreateDto, TenantUpdateDto> TenantFactory,
		IEntityFactory<WorkplaceEntity, WorkplaceCreateDto, WorkplaceUpdateDto> entityFactory,
		IEntityLocalizedFactory<WorkplaceLocalized, WorkplaceEntity, WorkplaceUpdateDto> entityLocalizedFactory)
		: base(noxSolution)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory; 
		EntityLocalizedFactory = entityLocalizedFactory;
		this.CountryFactory = CountryFactory;
		this.TenantFactory = TenantFactory;
	}

	public virtual async Task<WorkplaceKeyDto> Handle(CreateWorkplaceCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);

		var entityToCreate = await EntityFactory.CreateEntityAsync(request.EntityDto);
		if(request.EntityDto.CountryId is not null)
		{
			var relatedKey = ClientApi.Domain.CountryMetadata.CreateId(request.EntityDto.CountryId.NonNullValue<System.Int64>());
			var relatedEntity = await DbContext.Countries.FindAsync(relatedKey);
			if(relatedEntity is not null)
				entityToCreate.CreateRefToCountry(relatedEntity);
			else
				throw new RelatedEntityNotFoundException("Country", request.EntityDto.CountryId.NonNullValue<System.Int64>().ToString());
		}
		else if(request.EntityDto.Country is not null)
		{
			var relatedEntity = await CountryFactory.CreateEntityAsync(request.EntityDto.Country);
			entityToCreate.CreateRefToCountry(relatedEntity);
		}
		if(request.EntityDto.TenantsId.Any())
		{
			foreach(var relatedId in request.EntityDto.TenantsId)
			{
				var relatedKey = ClientApi.Domain.TenantMetadata.CreateId(relatedId);
				var relatedEntity = await DbContext.Tenants.FindAsync(relatedKey);

				if(relatedEntity is not null)
					entityToCreate.CreateRefToTenants(relatedEntity);
				else
					throw new RelatedEntityNotFoundException("Tenants", relatedId.ToString());
			}
		}
		else
		{
			foreach(var relatedCreateDto in request.EntityDto.Tenants)
			{
				var relatedEntity = await TenantFactory.CreateEntityAsync(relatedCreateDto);
				entityToCreate.CreateRefToTenants(relatedEntity);
			}
		}

		await OnCompletedAsync(request, entityToCreate);
		DbContext.Workplaces.Add(entityToCreate);
        CreateLocalizations(entityToCreate, request.CultureCode);
		await DbContext.SaveChangesAsync();
		return new WorkplaceKeyDto(entityToCreate.Id.Value);
	}

	private void CreateLocalizations(WorkplaceEntity entity, Nox.Types.CultureCode cultureCode)
	{
		CreateWorkplaceLocalization(entity, cultureCode);
	}

	private void CreateWorkplaceLocalization(WorkplaceEntity entity, Nox.Types.CultureCode cultureCode)
	{
		var entityLocalized = EntityLocalizedFactory.CreateLocalizedEntity(entity, cultureCode);
		DbContext.WorkplacesLocalized.Add(entityLocalized);
	}
}