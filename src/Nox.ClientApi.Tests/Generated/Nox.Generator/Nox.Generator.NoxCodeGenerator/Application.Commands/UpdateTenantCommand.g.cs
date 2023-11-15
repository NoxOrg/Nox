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
using TenantEntity = ClientApi.Domain.Tenant;

namespace ClientApi.Application.Commands;

public record UpdateTenantCommand(System.UInt32 keyId, TenantUpdateDto EntityDto, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest<TenantKeyDto?>;

internal partial class UpdateTenantCommandHandler : UpdateTenantCommandHandlerBase
{
	public UpdateTenantCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TenantEntity, TenantCreateDto, TenantUpdateDto> entityFactory) 
		: base(dbContext, noxSolution, entityFactory)
	{
	}
}

internal abstract class UpdateTenantCommandHandlerBase : CommandBase<UpdateTenantCommand, TenantEntity>, IRequestHandler<UpdateTenantCommand, TenantKeyDto?>
{
	public AppDbContext DbContext { get; }
	private readonly IEntityFactory<TenantEntity, TenantCreateDto, TenantUpdateDto> _entityFactory;

	public UpdateTenantCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TenantEntity, TenantCreateDto, TenantUpdateDto> entityFactory)
		: base(noxSolution)
	{
		DbContext = dbContext;
		_entityFactory = entityFactory;
	}

	public virtual async Task<TenantKeyDto?> Handle(UpdateTenantCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = ClientApi.Domain.TenantMetadata.CreateId(request.keyId);

		var entity = await DbContext.Tenants.FindAsync(keyId);
		if (entity == null)
		{
			return null;
		}

		await DbContext.Entry(entity).Collection(x => x.Workplaces).LoadAsync();
		var workplacesEntities = new List<ClientApi.Domain.Workplace>();
		foreach(var relatedEntityId in request.EntityDto.WorkplacesId)
		{
			var relatedKey = ClientApi.Domain.WorkplaceMetadata.CreateId(relatedEntityId);
			var relatedEntity = await DbContext.Workplaces.FindAsync(relatedKey);
						
			if(relatedEntity is not null)
				workplacesEntities.Add(relatedEntity);
			else
				throw new RelatedEntityNotFoundException("Workplaces", relatedEntityId.ToString());
		}
		entity.UpdateRefToWorkplaces(workplacesEntities);

		_entityFactory.UpdateEntity(entity, request.EntityDto, request.CultureCode);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		if (result < 1)
		{
			return null;
		}

		return new TenantKeyDto(entity.Id.Value);
	}
}