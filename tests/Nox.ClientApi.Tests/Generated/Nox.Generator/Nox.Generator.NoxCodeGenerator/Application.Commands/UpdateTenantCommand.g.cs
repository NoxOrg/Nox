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
using FluentValidation;
using ClientApi.Infrastructure.Persistence;
using ClientApi.Domain;
using ClientApi.Application.Dto;
using TenantEntity = ClientApi.Domain.Tenant;

namespace ClientApi.Application.Commands;

public partial record UpdateTenantCommand(System.UInt32 keyId, TenantUpdateDto EntityDto, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest<TenantKeyDto?>;

internal partial class UpdateTenantCommandHandler : UpdateTenantCommandHandlerBase
{
	public UpdateTenantCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TenantEntity, TenantCreateDto, TenantUpdateDto> entityFactory,
		IEntityLocalizedFactory<TenantBrandLocalized, ClientApi.Domain.TenantBrand, TenantBrandUpsertDto> TenantBrandLocalizedFactory,
		IEntityLocalizedFactory<TenantContactLocalized, ClientApi.Domain.TenantContact, TenantContactUpsertDto> TenantContactLocalizedFactory)
		: base(dbContext, noxSolution,entityFactory, TenantBrandLocalizedFactory, TenantContactLocalizedFactory)
	{
	}
}

internal abstract class UpdateTenantCommandHandlerBase : CommandBase<UpdateTenantCommand, TenantEntity>, IRequestHandler<UpdateTenantCommand, TenantKeyDto?>
{
	public AppDbContext DbContext { get; }
	private readonly IEntityFactory<TenantEntity, TenantCreateDto, TenantUpdateDto> _entityFactory;
	protected readonly IEntityLocalizedFactory<TenantBrandLocalized, ClientApi.Domain.TenantBrand, TenantBrandUpsertDto> TenantBrandLocalizedFactory;
	protected readonly IEntityLocalizedFactory<TenantContactLocalized, ClientApi.Domain.TenantContact, TenantContactUpsertDto> TenantContactLocalizedFactory;

	protected UpdateTenantCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TenantEntity, TenantCreateDto, TenantUpdateDto> entityFactory,
		IEntityLocalizedFactory<TenantBrandLocalized, ClientApi.Domain.TenantBrand, TenantBrandUpsertDto> TenantBrandLocalizedFactory,
		IEntityLocalizedFactory<TenantContactLocalized, ClientApi.Domain.TenantContact, TenantContactUpsertDto> TenantContactLocalizedFactory)
		: base(noxSolution)
	{
		DbContext = dbContext;
		_entityFactory = entityFactory;
		this.TenantBrandLocalizedFactory = TenantBrandLocalizedFactory;
		this.TenantContactLocalizedFactory = TenantContactLocalizedFactory;
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
		await DbContext.Entry(entity).Collection(x => x.TenantBrands).LoadAsync();
		await DbContext.Entry(entity).Reference(x => x.TenantContact).LoadAsync();

		await _entityFactory.UpdateEntityAsync(entity, request.EntityDto, request.CultureCode);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;
		await UpdateLocalizationsAsync(entity, request.EntityDto, request.CultureCode);

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		if (result < 1)
		{
			return null;
		}

		return new TenantKeyDto(entity.Id.Value);
	}

	private async Task UpdateLocalizationsAsync(TenantEntity entity, TenantUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
	{
        await UpdateTenantBrandsLocalizationAsync(entity.TenantBrands, updateDto.TenantBrands, cultureCode);
        await UpdateTenantContactLocalizationAsync(entity.TenantContact, updateDto.TenantContact, cultureCode);
	}
	
	private async Task UpdateTenantBrandsLocalizationAsync(List<ClientApi.Domain.TenantBrand> entities, List<ClientApi.Application.Dto.TenantBrandUpsertDto> updateDtos, Nox.Types.CultureCode cultureCode)
	{
		for(int i = 0; i < updateDtos.Count; i++)
		{
			var updateDto = updateDtos[i];
			var entity = entities.Where(e => e.Id is not null).SingleOrDefault(e => e.Id.Value == updateDto.Id);
			if (entity is null) continue;

			await UpdateTenantBrandsLocalizationAsync(entity, updateDto, cultureCode);
		}
	}

	private async Task UpdateTenantBrandsLocalizationAsync(ClientApi.Domain.TenantBrand entity, ClientApi.Application.Dto.TenantBrandUpsertDto updateDto, Nox.Types.CultureCode cultureCode)
	{
		var entityLocalized = await DbContext.TenantBrandsLocalized.FirstOrDefaultAsync(x => x.Id == entity.Id && x.CultureCode == cultureCode);
		if(entityLocalized is null)
		{
			entityLocalized = TenantBrandLocalizedFactory.CreateLocalizedEntity(entity, cultureCode);
			DbContext.TenantBrandsLocalized.Add(entityLocalized);
		}
		else
		{
			DbContext.Entry(entityLocalized).State = EntityState.Modified;
		}

		TenantBrandLocalizedFactory.UpdateLocalizedEntity(entityLocalized, updateDto);
	}
	
	private async Task UpdateTenantContactLocalizationAsync(ClientApi.Domain.TenantContact? entity, ClientApi.Application.Dto.TenantContactUpsertDto? updateDto, Nox.Types.CultureCode cultureCode)
	{
		if(entity is null || updateDto is null) return;
		var entityLocalized = await DbContext.TenantContactsLocalized.FirstOrDefaultAsync(x => x.TenantId == entity.TenantId && x.CultureCode == cultureCode);
		if(entityLocalized is null)
		{
			entityLocalized = TenantContactLocalizedFactory.CreateLocalizedEntity(entity, cultureCode);
			DbContext.TenantContactsLocalized.Add(entityLocalized);
		}
		else
		{
			DbContext.Entry(entityLocalized).State = EntityState.Modified;
		}

		TenantContactLocalizedFactory.UpdateLocalizedEntity(entityLocalized, updateDto);
	}	
	
}

public class UpdateTenantValidator : AbstractValidator<UpdateTenantCommand>
{
    public UpdateTenantValidator()
    {
    }
}