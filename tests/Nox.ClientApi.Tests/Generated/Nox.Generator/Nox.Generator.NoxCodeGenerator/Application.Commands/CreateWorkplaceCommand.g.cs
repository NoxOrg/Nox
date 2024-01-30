﻿// Generated

#nullable enable

using MediatR;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FluentValidation;
using Microsoft.Extensions.Logging;

using Nox.Abstractions;
using Nox.Application;
using Nox.Application.Commands;
using Nox.Exceptions;
using Nox.Extensions;
using Nox.Application.Factories;
using Nox.Solution;
using Nox.Domain;

using ClientApi.Domain;
using ClientApi.Application.Dto;
using Dto = ClientApi.Application.Dto;
using WorkplaceEntity = ClientApi.Domain.Workplace;

namespace ClientApi.Application.Commands;

public partial record CreateWorkplaceCommand(WorkplaceCreateDto EntityDto, Nox.Types.CultureCode CultureCode) : IRequest<WorkplaceKeyDto>;

internal partial class CreateWorkplaceCommandHandler : CreateWorkplaceCommandHandlerBase
{
	public CreateWorkplaceCommandHandler(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<ClientApi.Domain.Country, CountryCreateDto, CountryUpdateDto> CountryFactory,
		IEntityFactory<ClientApi.Domain.Tenant, TenantCreateDto, TenantUpdateDto> TenantFactory,
		IEntityFactory<WorkplaceEntity, WorkplaceCreateDto, WorkplaceUpdateDto> entityFactory)
		: base(repository, noxSolution,CountryFactory, TenantFactory, entityFactory)
	{
	}
}


internal abstract class CreateWorkplaceCommandHandlerBase : CommandBase<CreateWorkplaceCommand,WorkplaceEntity>, IRequestHandler <CreateWorkplaceCommand, WorkplaceKeyDto>
{
	protected readonly IRepository Repository;
	protected readonly IEntityFactory<WorkplaceEntity, WorkplaceCreateDto, WorkplaceUpdateDto> EntityFactory;
	protected readonly IEntityFactory<ClientApi.Domain.Country, CountryCreateDto, CountryUpdateDto> CountryFactory;
	protected readonly IEntityFactory<ClientApi.Domain.Tenant, TenantCreateDto, TenantUpdateDto> TenantFactory;

	protected CreateWorkplaceCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<ClientApi.Domain.Country, CountryCreateDto, CountryUpdateDto> CountryFactory,
		IEntityFactory<ClientApi.Domain.Tenant, TenantCreateDto, TenantUpdateDto> TenantFactory,
		IEntityFactory<WorkplaceEntity, WorkplaceCreateDto, WorkplaceUpdateDto> entityFactory)
	: base(noxSolution)
	{
		Repository = repository;
		EntityFactory = entityFactory;
		this.CountryFactory = CountryFactory;
		this.TenantFactory = TenantFactory;
	}

	public virtual async Task<WorkplaceKeyDto> Handle(CreateWorkplaceCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);

		var entityToCreate = await EntityFactory.CreateEntityAsync(request.EntityDto, request.CultureCode);
		if(request.EntityDto.CountryId is not null)
		{
			var relatedKey = Dto.CountryMetadata.CreateId(request.EntityDto.CountryId.NonNullValue<System.Int64>());
			var relatedEntity = await Repository.FindAsync<Country>(relatedKey);
			if(relatedEntity is not null)
				entityToCreate.CreateRefToCountry(relatedEntity);
			else
				throw new RelatedEntityNotFoundException("Country", request.EntityDto.CountryId.NonNullValue<System.Int64>().ToString());
		}
		else if(request.EntityDto.Country is not null)
		{
			var relatedEntity = await CountryFactory.CreateEntityAsync(request.EntityDto.Country, request.CultureCode);
			entityToCreate.CreateRefToCountry(relatedEntity);
		}
		if(request.EntityDto.TenantsId.Any())
		{
			foreach(var relatedId in request.EntityDto.TenantsId)
			{
				var relatedKey = Dto.TenantMetadata.CreateId(relatedId);
				var relatedEntity = await Repository.FindAsync<Tenant>(relatedKey);

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
				var relatedEntity = await TenantFactory.CreateEntityAsync(relatedCreateDto, request.CultureCode);
				entityToCreate.CreateRefToTenants(relatedEntity);
			}
		}

		await OnCompletedAsync(request, entityToCreate);
		await Repository.AddAsync<Workplace>(entityToCreate);
		await Repository.SaveChangesAsync();
		return new WorkplaceKeyDto(entityToCreate.Id.Value);
	}
}