﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Nox.Application.Factories;
using Nox.Exceptions;
using Nox.Domain;

using ClientApi.Domain;
using ClientApi.Application.Dto;
using Dto = ClientApi.Application.Dto;
using TenantBrandEntity = ClientApi.Domain.TenantBrand;

namespace ClientApi.Application.Commands;
public partial record PartialUpdateTenantBrandsForTenantCommand(TenantKeyDto ParentKeyDto, TenantBrandKeyDto EntityKeyDto, Dictionary<string, dynamic> UpdatedProperties, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest <TenantBrandKeyDto>;
internal partial class PartialUpdateTenantBrandsForTenantCommandHandler: PartialUpdateTenantBrandsForTenantCommandHandlerBase
{
	public PartialUpdateTenantBrandsForTenantCommandHandler(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<TenantBrandEntity, TenantBrandUpsertDto, TenantBrandUpsertDto> entityFactory)
		: base(repository, noxSolution, entityFactory)
	{
	}
}
internal abstract class PartialUpdateTenantBrandsForTenantCommandHandlerBase: CommandBase<PartialUpdateTenantBrandsForTenantCommand, TenantBrandEntity>, IRequestHandler <PartialUpdateTenantBrandsForTenantCommand, TenantBrandKeyDto>
{
	protected readonly IRepository Repository;
	protected readonly IEntityFactory<TenantBrandEntity, TenantBrandUpsertDto, TenantBrandUpsertDto> EntityFactory;
	
	protected PartialUpdateTenantBrandsForTenantCommandHandlerBase(
		IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<TenantBrandEntity, TenantBrandUpsertDto, TenantBrandUpsertDto> entityFactory)
		: base(noxSolution)
	{
		Repository = repository;
		EntityFactory = entityFactory;
	}

	public virtual async Task<TenantBrandKeyDto> Handle(PartialUpdateTenantBrandsForTenantCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);

		var keys = new List<object?>(1);
		keys.Add(Dto.TenantMetadata.CreateId(request.ParentKeyDto.keyId));

		var parentEntity = await Repository.FindAndIncludeAsync<Tenant>(keys.ToArray(),e => e.TenantBrands, cancellationToken);
		if (parentEntity == null)
		{
			throw new EntityNotFoundException("Tenant",  "keyId");
		}
		var ownedId = Dto.TenantBrandMetadata.CreateId(request.EntityKeyDto.keyId);
		var entity = parentEntity.TenantBrands.SingleOrDefault(x => x.Id == ownedId);
		if (entity == null)
		{
			throw new EntityNotFoundException("Tenant.TenantBrands", $"ownedId");
		}

		await EntityFactory.PartialUpdateEntityAsync(entity, request.UpdatedProperties, request.CultureCode);
		parentEntity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;
		Repository.Update(entity);
		await OnCompletedAsync(request, entity);
		await Repository.SaveChangesAsync();		

		return new TenantBrandKeyDto(entity.Id.Value);
	}
}