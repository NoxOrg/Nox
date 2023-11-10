﻿﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Nox.Application.Factories;
using Nox.Exceptions;
using Nox.Extensions;
using ClientApi.Infrastructure.Persistence;
using ClientApi.Domain;
using ClientApi.Application.Dto;
using WorkplaceEntity = ClientApi.Domain.Workplace;

namespace ClientApi.Application.Commands;

public record UpdateWorkplaceCommand(System.UInt32 keyId, WorkplaceUpdateDto EntityDto, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest<WorkplaceKeyDto?>;

internal partial class UpdateWorkplaceCommandHandler : UpdateWorkplaceCommandHandlerBase
{
	public UpdateWorkplaceCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<WorkplaceEntity, WorkplaceCreateDto, WorkplaceUpdateDto> entityFactory,
		IEntityLocalizedFactory<WorkplaceLocalized, WorkplaceEntity, WorkplaceUpdateDto> entityLocalizedFactory) 
		: base(dbContext, noxSolution, entityFactory, entityLocalizedFactory)
	{
	}
}

internal abstract class UpdateWorkplaceCommandHandlerBase : CommandBase<UpdateWorkplaceCommand, WorkplaceEntity>, IRequestHandler<UpdateWorkplaceCommand, WorkplaceKeyDto?>
{
	public AppDbContext DbContext { get; }
	private readonly IEntityFactory<WorkplaceEntity, WorkplaceCreateDto, WorkplaceUpdateDto> _entityFactory;
	private readonly IEntityLocalizedFactory<WorkplaceLocalized, WorkplaceEntity, WorkplaceUpdateDto> _entityLocalizedFactory;

	public UpdateWorkplaceCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<WorkplaceEntity, WorkplaceCreateDto, WorkplaceUpdateDto> entityFactory,
		IEntityLocalizedFactory<WorkplaceLocalized, WorkplaceEntity, WorkplaceUpdateDto> entityLocalizedFactory)
		: base(noxSolution)
	{
		DbContext = dbContext;
		_entityFactory = entityFactory; 
		_entityLocalizedFactory = entityLocalizedFactory;
	}

	public virtual async Task<WorkplaceKeyDto?> Handle(UpdateWorkplaceCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = ClientApi.Domain.WorkplaceMetadata.CreateId(request.keyId);

		var entity = await DbContext.Workplaces.FindAsync(keyId);
		if (entity == null)
		{
			return null;
		}

		if(request.EntityDto.CountryId is not null)
		{
			var countryKey = ClientApi.Domain.CountryMetadata.CreateId(request.EntityDto.CountryId.NonNullValue<System.Int64>());
			var countryEntity = await DbContext.Countries.FindAsync(countryKey);
						
			if(countryEntity is not null)
				entity.CreateRefToCountry(countryEntity);
			else
				throw new RelatedEntityNotFoundException("Country", request.EntityDto.CountryId.NonNullValue<System.Int64>().ToString());
		}
		else
		{
			entity.DeleteAllRefToCountry();
		}

		await DbContext.Entry(entity).Collection(x => x.Tenants).LoadAsync();
		var tenantsEntities = new List<ClientApi.Domain.Tenant>();
		foreach(var relatedEntityId in request.EntityDto.TenantsId)
		{
			var relatedKey = ClientApi.Domain.TenantMetadata.CreateId(relatedEntityId);
			var relatedEntity = await DbContext.Tenants.FindAsync(relatedKey);
						
			if(relatedEntity is not null)
				tenantsEntities.Add(relatedEntity);
			else
				throw new RelatedEntityNotFoundException("Tenants", relatedEntityId.ToString());
		}
		entity.UpdateRefToTenants(tenantsEntities);

		_entityFactory.UpdateEntity(entity, request.EntityDto, request.CultureCode);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;
		await UpdateLocalizedEntityAsync(entity, request.EntityDto, request.CultureCode);

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		if (result < 1)
		{
			return null;
		}

		return new WorkplaceKeyDto(entity.Id.Value);
	}

	private async Task UpdateLocalizedEntityAsync(WorkplaceEntity entity, WorkplaceUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
	{
		var entityLocalized = await DbContext.WorkplacesLocalized.FirstOrDefaultAsync(x => x.Id == entity.Id && x.CultureCode == cultureCode);
		if(entityLocalized is null)
		{
			entityLocalized = _entityLocalizedFactory.CreateLocalizedEntity(entity, cultureCode);
			DbContext.WorkplacesLocalized.Add(entityLocalized);
		}
		else
		{
			DbContext.Entry(entityLocalized).State = EntityState.Modified;
		}

		_entityLocalizedFactory.UpdateLocalizedEntity(entityLocalized, updateDto);
	}
}