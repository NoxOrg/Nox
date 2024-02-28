﻿﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using FluentValidation;
using Microsoft.Extensions.Logging;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Domain;
using Nox.Types;
using Nox.Application.Factories;
using Nox.Extensions;
using Nox.Exceptions;

using ClientApi.Domain;
using ClientApi.Application.Dto;
using Dto = ClientApi.Application.Dto;
using TenantBrandEntity = ClientApi.Domain.TenantBrand;
using TenantEntity = ClientApi.Domain.Tenant;

namespace ClientApi.Application.Commands;

public partial record UpdateTenantBrandsForTenantCommand(TenantKeyDto ParentKeyDto, IEnumerable<TenantBrandUpsertDto> EntitiesDto, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest<bool>;

internal partial class UpdateTenantBrandsForTenantCommandHandler : UpdateTenantBrandsForTenantCommandHandlerBase
{
	public UpdateTenantBrandsForTenantCommandHandler(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<TenantBrandEntity, TenantBrandUpsertDto, TenantBrandUpsertDto> entityFactory)
		: base(repository, noxSolution, entityFactory)
	{
	}
}

internal partial class UpdateTenantBrandsForTenantCommandHandlerBase : CommandBase<UpdateTenantBrandsForTenantCommand, TenantBrandEntity>, IRequestHandler <UpdateTenantBrandsForTenantCommand, bool>
{
	private readonly IRepository _repository;
	private readonly IEntityFactory<TenantBrandEntity, TenantBrandUpsertDto, TenantBrandUpsertDto> _entityFactory;

	protected UpdateTenantBrandsForTenantCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<TenantBrandEntity, TenantBrandUpsertDto, TenantBrandUpsertDto> entityFactory)
		: base(noxSolution)
	{
		_repository = repository;
		_entityFactory = entityFactory;
	}

	public virtual async Task<bool> Handle(UpdateTenantBrandsForTenantCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);

		var keys = new List<object?>(1);
		keys.Add(Dto.TenantMetadata.CreateId(request.ParentKeyDto.keyId));

		var parentEntity = await _repository.FindAndIncludeAsync<ClientApi.Domain.Tenant>(keys.ToArray(),e => e.TenantBrands, cancellationToken);
		EntityNotFoundException.ThrowIfNull(parentEntity, "Tenant",  "keyId");				
		List<TenantBrandEntity> entities = new(request.EntitiesDto.Count());
		foreach(var entityDto in request.EntitiesDto)
		{
			TenantBrandEntity? entity;
			if(entityDto.Id is null)
			{
				entity = await CreateEntityAsync(entityDto, parentEntity, request.CultureCode);
			}
			else
			{
				var ownedId = Dto.TenantBrandMetadata.CreateId(entityDto.Id.NonNullValue<System.Int64>());
				entity = parentEntity.TenantBrands.SingleOrDefault(x => x.Id == ownedId);
				if (entity is null)
					throw new EntityNotFoundException("TenantBrand",  $"ownedId");
				else
					await _entityFactory.UpdateEntityAsync(entity, entityDto, request.CultureCode);
			}

			entities.Add(entity);
		}

		parentEntity.UpdateRefToTenantBrands(entities);
		parentEntity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;		
		_repository.Update(parentEntity);
		_repository.DeleteOwned<TenantBrandEntity>(parentEntity.TenantBrands.Where(oe => !entities.Exists(e => e.Id == oe.Id)).ToList());
		//await OnCompletedAsync(request, entity!); // second parameter of CommandBase must be a IEntity, but we have a collection of entities
		await _repository.SaveChangesAsync();

		return true; // Should we return bool or list of entity ids or parent id?
	}
	
	private async Task<TenantBrandEntity> CreateEntityAsync(TenantBrandUpsertDto upsertDto, TenantEntity parent, Nox.Types.CultureCode cultureCode)
	{
		var entity = await _entityFactory.CreateEntityAsync(upsertDto, cultureCode);
		parent.CreateRefToTenantBrands(entity);
		return entity;
	}
}

public class UpdateTenantBrandsForTenantValidator : AbstractValidator<UpdateTenantBrandsForTenantCommand>
{
    public UpdateTenantBrandsForTenantValidator()
    {
    }
}