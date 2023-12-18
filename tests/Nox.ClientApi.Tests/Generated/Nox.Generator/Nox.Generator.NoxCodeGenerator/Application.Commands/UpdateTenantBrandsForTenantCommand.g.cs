﻿﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Nox.Application.Factories;
using Nox.Extensions;
using Nox.Exceptions;
using FluentValidation;
using Microsoft.Extensions.Logging;
using ClientApi.Infrastructure.Persistence;
using ClientApi.Domain;
using ClientApi.Application.Dto;
using TenantBrandEntity = ClientApi.Domain.TenantBrand;
using TenantEntity = ClientApi.Domain.Tenant;

namespace ClientApi.Application.Commands;

public partial record UpdateTenantBrandsForTenantCommand(TenantKeyDto ParentKeyDto, TenantBrandUpsertDto EntityDto, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest <TenantBrandKeyDto>;

internal partial class UpdateTenantBrandsForTenantCommandHandler : UpdateTenantBrandsForTenantCommandHandlerBase
{
	public UpdateTenantBrandsForTenantCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TenantBrandEntity, TenantBrandUpsertDto, TenantBrandUpsertDto> entityFactory,
		IEntityLocalizedFactory<TenantBrandLocalized, TenantBrandEntity, TenantBrandUpsertDto> entityLocalizedFactory)
		: base(dbContext, noxSolution, entityFactory, entityLocalizedFactory)
	{
	}
}

internal partial class UpdateTenantBrandsForTenantCommandHandlerBase : CommandBase<UpdateTenantBrandsForTenantCommand, TenantBrandEntity>, IRequestHandler <UpdateTenantBrandsForTenantCommand, TenantBrandKeyDto>
{
	private readonly AppDbContext _dbContext;
	private readonly IEntityFactory<TenantBrandEntity, TenantBrandUpsertDto, TenantBrandUpsertDto> _entityFactory;
	protected readonly IEntityLocalizedFactory<TenantBrandLocalized, TenantBrandEntity, TenantBrandUpsertDto> _entityLocalizedFactory;

	protected UpdateTenantBrandsForTenantCommandHandlerBase(
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

	public virtual async Task<TenantBrandKeyDto> Handle(UpdateTenantBrandsForTenantCommand request, CancellationToken cancellationToken)
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
		
		TenantBrandEntity? entity;
		if(request.EntityDto.Id is null)
		{
			entity = await CreateEntityAsync(request.EntityDto, parentEntity, request.CultureCode);
		}
		else
		{
			var ownedId = ClientApi.Domain.TenantBrandMetadata.CreateId(request.EntityDto.Id.NonNullValue<System.Int64>());
			entity = parentEntity.TenantBrands.SingleOrDefault(x => x.Id == ownedId);
			if (entity is null)
				throw new EntityNotFoundException("TenantBrand",  $"{ownedId.ToString()}");
			else
				await _entityFactory.UpdateEntityAsync(entity, request.EntityDto, request.CultureCode);
		}

		parentEntity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;
		await OnCompletedAsync(request, entity!);

		_dbContext.Entry(parentEntity).State = EntityState.Modified;
		await UpdateLocalizedEntityAsync(entity, request.EntityDto, request.CultureCode);


		var result = await _dbContext.SaveChangesAsync();

		return new TenantBrandKeyDto(entity.Id.Value);
	}
	
	private async Task<TenantBrandEntity> CreateEntityAsync(TenantBrandUpsertDto upsertDto, TenantEntity parent, Nox.Types.CultureCode cultureCode)
	{
		var entity = await _entityFactory.CreateEntityAsync(upsertDto, cultureCode);
		parent.CreateRefToTenantBrands(entity);
		return entity;
	}

	private async Task UpdateLocalizedEntityAsync(TenantBrandEntity entity, TenantBrandUpsertDto updateDto, Nox.Types.CultureCode cultureCode)
	{
		var entityLocalized = await _dbContext.TenantBrandsLocalized.FirstOrDefaultAsync(x => x.Id == entity.Id && x.CultureCode == cultureCode);
		if(entityLocalized is null)
		{
			entityLocalized = await _entityLocalizedFactory.CreateLocalizedEntityAsync(entity, cultureCode);
			_dbContext.TenantBrandsLocalized.Add(entityLocalized);
		}
		else
		{
			_dbContext.Entry(entityLocalized).State = EntityState.Modified;
		}

		await _entityLocalizedFactory.UpdateLocalizedEntityAsync(entity, updateDto, cultureCode);
	}
}

public class UpdateTenantBrandsForTenantValidator : AbstractValidator<UpdateTenantBrandsForTenantCommand>
{
    public UpdateTenantBrandsForTenantValidator()
    {
    }
}