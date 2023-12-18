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
using TenantBrandEntity = ClientApi.Domain.TenantBrand;

namespace ClientApi.Application.Commands;
public partial record PartialUpdateTenantBrandsForTenantCommand(TenantKeyDto ParentKeyDto, TenantBrandKeyDto EntityKeyDto, Dictionary<string, dynamic> UpdatedProperties, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest <TenantBrandKeyDto>;
internal partial class PartialUpdateTenantBrandsForTenantCommandHandler: PartialUpdateTenantBrandsForTenantCommandHandlerBase
{
	public PartialUpdateTenantBrandsForTenantCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TenantBrandEntity, TenantBrandUpsertDto, TenantBrandUpsertDto> entityFactory,
		IEntityLocalizedFactory<TenantBrandLocalized, TenantBrandEntity, TenantBrandUpsertDto> entityLocalizedFactory)
		: base(dbContext, noxSolution, entityFactory, entityLocalizedFactory)
	{
	}
}
internal abstract class PartialUpdateTenantBrandsForTenantCommandHandlerBase: CommandBase<PartialUpdateTenantBrandsForTenantCommand, TenantBrandEntity>, IRequestHandler <PartialUpdateTenantBrandsForTenantCommand, TenantBrandKeyDto>
{
	private readonly AppDbContext _dbContext;
	private readonly IEntityFactory<TenantBrandEntity, TenantBrandUpsertDto, TenantBrandUpsertDto> _entityFactory;
	protected readonly IEntityLocalizedFactory<TenantBrandLocalized, TenantBrandEntity, TenantBrandUpsertDto> _entityLocalizedFactory;

	protected PartialUpdateTenantBrandsForTenantCommandHandlerBase(
		AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TenantBrandEntity, TenantBrandUpsertDto, TenantBrandUpsertDto> entityFactory,
		IEntityLocalizedFactory<TenantBrandLocalized, TenantBrandEntity, TenantBrandUpsertDto> entityLocalizedFactory)
		: base(noxSolution)
	{
		_dbContext = dbContext;
		_entityFactory = entityFactory; 
		_entityLocalizedFactory = entityLocalizedFactory;
	}

	public virtual async Task<TenantBrandKeyDto> Handle(PartialUpdateTenantBrandsForTenantCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = ClientApi.Domain.TenantMetadata.CreateId(request.ParentKeyDto.keyId);

		var parentEntity = await _dbContext.Tenants.FindAsync(keyId);
		if (parentEntity == null)
		{
			throw new EntityNotFoundException("Tenant",  $"{keyId.ToString()}");
		}
		await _dbContext.Entry(parentEntity).Collection(p => p.TenantBrands).LoadAsync(cancellationToken);
		var ownedId = ClientApi.Domain.TenantBrandMetadata.CreateId(request.EntityKeyDto.keyId);
		var entity = parentEntity.TenantBrands.SingleOrDefault(x => x.Id == ownedId);
		if (entity == null)
		{
			throw new EntityNotFoundException("Tenant.TenantBrands", $"{ownedId.ToString()}");
		}

		await _entityFactory.PartialUpdateEntityAsync(entity, request.UpdatedProperties, request.CultureCode);
		parentEntity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

		await OnCompletedAsync(request, entity);

		_dbContext.Entry(entity).State = EntityState.Modified;
		await PartiallyUpdateLocalizedEntityAsync(entity, request.UpdatedProperties, request.CultureCode);
		var result = await _dbContext.SaveChangesAsync();

		return new TenantBrandKeyDto(entity.Id.Value);
	}

	private async Task PartiallyUpdateLocalizedEntityAsync(TenantBrandEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
	{
		var entityLocalized = await _dbContext.TenantBrandsLocalized.FirstOrDefaultAsync(x => x.Id == entity.Id && x.CultureCode == cultureCode);
		if(entityLocalized is null)
		{
			entityLocalized = await _entityLocalizedFactory.CreateLocalizedEntityAsync(entity, cultureCode, copyEntityAttributes: false);
			_dbContext.TenantBrandsLocalized.Add(entityLocalized);
		}
		else
		{
			_dbContext.Entry(entityLocalized).State = EntityState.Modified;
		}

		await _entityLocalizedFactory.PartialUpdateLocalizedEntityAsync(entity, updatedProperties, cultureCode);
	}
}