﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Nox.Application.Factories;
using Nox.Exceptions;

using ClientApi.Infrastructure.Persistence;
using ClientApi.Domain;
using ClientApi.Application.Dto;
using TenantContactEntity = ClientApi.Domain.TenantContact;

namespace ClientApi.Application.Commands;
public partial record PartialUpdateTenantContactForTenantCommand(TenantKeyDto ParentKeyDto, Dictionary<string, dynamic> UpdatedProperties, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest <TenantContactKeyDto>;

internal partial class PartialUpdateTenantContactForTenantCommandHandler: PartialUpdateTenantContactForTenantCommandHandlerBase
{
	public PartialUpdateTenantContactForTenantCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TenantContactEntity, TenantContactUpsertDto, TenantContactUpsertDto> entityFactory,
		IEntityLocalizedFactory<TenantContactLocalized, TenantContactEntity, TenantContactUpsertDto> entityLocalizedFactory)
		: base(dbContext, noxSolution, entityFactory, entityLocalizedFactory)
	{
	}
}
internal abstract class PartialUpdateTenantContactForTenantCommandHandlerBase: CommandBase<PartialUpdateTenantContactForTenantCommand, TenantContactEntity>, IRequestHandler <PartialUpdateTenantContactForTenantCommand, TenantContactKeyDto>
{
	private readonly AppDbContext _dbContext;
	private readonly IEntityFactory<TenantContactEntity, TenantContactUpsertDto, TenantContactUpsertDto> _entityFactory;
	protected readonly IEntityLocalizedFactory<TenantContactLocalized, TenantContactEntity, TenantContactUpsertDto> _entityLocalizedFactory;

	protected PartialUpdateTenantContactForTenantCommandHandlerBase(
		AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TenantContactEntity, TenantContactUpsertDto, TenantContactUpsertDto> entityFactory,
		IEntityLocalizedFactory<TenantContactLocalized, TenantContactEntity, TenantContactUpsertDto> entityLocalizedFactory)
		: base(noxSolution)
	{
		_dbContext = dbContext;
		_entityFactory = entityFactory; 
		_entityLocalizedFactory = entityLocalizedFactory;
	}

	public virtual async Task<TenantContactKeyDto> Handle(PartialUpdateTenantContactForTenantCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = ClientApi.Domain.TenantMetadata.CreateId(request.ParentKeyDto.keyId);

		var parentEntity = await _dbContext.Tenants.FindAsync(keyId);
		if (parentEntity == null)
		{
			throw new EntityNotFoundException("Tenant",  $"{keyId.ToString()}");
		}
		await _dbContext.Entry(parentEntity).Reference(e => e.TenantContact).LoadAsync(cancellationToken);
		var entity = parentEntity.TenantContact;
		
		if (entity == null)
		{
			throw new EntityNotFoundException("Tenant.TenantContact", String.Empty);
		}

		_entityFactory.PartialUpdateEntity(entity, request.UpdatedProperties, request.CultureCode);
		parentEntity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

		await OnCompletedAsync(request, entity);

		_dbContext.Entry(entity).State = EntityState.Modified;
		await PartiallyUpdateLocalizedEntityAsync(entity, request.UpdatedProperties, request.CultureCode);
		var result = await _dbContext.SaveChangesAsync();

		return new TenantContactKeyDto();
	}

	private async Task PartiallyUpdateLocalizedEntityAsync(TenantContactEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
	{
		var entityLocalized = await _dbContext.TenantContactsLocalized.FirstOrDefaultAsync(x => x.TenantId == entity.TenantId && x.CultureCode == cultureCode);
		if(entityLocalized is null)
		{
			entityLocalized = _entityLocalizedFactory.CreateLocalizedEntity(entity, cultureCode, copyEntityAttributes: false);
			_dbContext.TenantContactsLocalized.Add(entityLocalized);
		}
		else
		{
			_dbContext.Entry(entityLocalized).State = EntityState.Modified;
		}

		_entityLocalizedFactory.PartialUpdateLocalizedEntity(entityLocalized, updatedProperties);
	}
}