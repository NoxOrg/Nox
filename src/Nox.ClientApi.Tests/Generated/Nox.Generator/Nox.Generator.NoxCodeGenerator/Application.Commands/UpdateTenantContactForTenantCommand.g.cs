﻿﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Nox.Application.Factories;
using Nox.Extensions;
using FluentValidation;
using Microsoft.Extensions.Logging;
using ClientApi.Infrastructure.Persistence;
using ClientApi.Domain;
using ClientApi.Application.Dto;
using TenantContactEntity = ClientApi.Domain.TenantContact;

namespace ClientApi.Application.Commands;

public partial record UpdateTenantContactForTenantCommand(TenantKeyDto ParentKeyDto, TenantContactUpsertDto EntityDto, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest <TenantContactKeyDto?>;

internal partial class UpdateTenantContactForTenantCommandHandler : UpdateTenantContactForTenantCommandHandlerBase
{
	public UpdateTenantContactForTenantCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TenantContactEntity, TenantContactUpsertDto, TenantContactUpsertDto> entityFactory,
		IEntityLocalizedFactory<TenantContactLocalized, TenantContactEntity, TenantContactUpsertDto> entityLocalizedFactory)
		: base(dbContext, noxSolution, entityFactory, entityLocalizedFactory)
	{
	}
}

internal partial class UpdateTenantContactForTenantCommandHandlerBase : CommandBase<UpdateTenantContactForTenantCommand, TenantContactEntity>, IRequestHandler <UpdateTenantContactForTenantCommand, TenantContactKeyDto?>
{
	private readonly AppDbContext _dbContext;
	private readonly IEntityFactory<TenantContactEntity, TenantContactUpsertDto, TenantContactUpsertDto> _entityFactory;
	protected readonly IEntityLocalizedFactory<TenantContactLocalized, TenantContactEntity, TenantContactUpsertDto> _entityLocalizedFactory;

	protected UpdateTenantContactForTenantCommandHandlerBase(
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

	public virtual async Task<TenantContactKeyDto?> Handle(UpdateTenantContactForTenantCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = ClientApi.Domain.TenantMetadata.CreateId(request.ParentKeyDto.keyId);
		var parentEntity = await _dbContext.Tenants.FindAsync(keyId);
		if (parentEntity == null)
		{
			return null;
		}
		await _dbContext.Entry(parentEntity).Reference(e => e.TenantContact).LoadAsync(cancellationToken);
		var entity = parentEntity.TenantContact;
		
		if (entity == null)
		{
			return null;
		}

		await _entityFactory.UpdateEntityAsync(entity, request.EntityDto, request.CultureCode);
		parentEntity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;
		await OnCompletedAsync(request, entity);

		_dbContext.Entry(parentEntity).State = EntityState.Modified;
		await UpdateLocalizedEntityAsync(entity, request.EntityDto, request.CultureCode);


		var result = await _dbContext.SaveChangesAsync();
		if (result < 1)
		{
			return null;
		}

		return new TenantContactKeyDto();
	}

	private async Task UpdateLocalizedEntityAsync(TenantContactEntity entity, TenantContactUpsertDto updateDto, Nox.Types.CultureCode cultureCode)
	{
		var entityLocalized = await _dbContext.TenantContactsLocalized.FirstOrDefaultAsync(x => x.TenantId == entity.TenantId && x.CultureCode == cultureCode);
		if(entityLocalized is null)
		{
			entityLocalized = _entityLocalizedFactory.CreateLocalizedEntity(entity, cultureCode);
			_dbContext.TenantContactsLocalized.Add(entityLocalized);
		}
		else
		{
			_dbContext.Entry(entityLocalized).State = EntityState.Modified;
		}

		_entityLocalizedFactory.UpdateLocalizedEntity(entityLocalized, updateDto);
	}
}