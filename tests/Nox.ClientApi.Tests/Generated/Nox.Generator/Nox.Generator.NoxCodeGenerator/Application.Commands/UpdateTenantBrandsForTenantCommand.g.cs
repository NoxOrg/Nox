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

public partial record UpdateTenantBrandsForTenantCommand(TenantKeyDto ParentKeyDto, IEnumerable<TenantBrandUpsertDto> EntitiesDto, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest<IEnumerable<TenantBrandKeyDto>>;

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

internal partial class UpdateTenantBrandsForTenantCommandHandlerBase : CommandCollectionBase<UpdateTenantBrandsForTenantCommand, TenantBrandEntity>, IRequestHandler <UpdateTenantBrandsForTenantCommand, IEnumerable<TenantBrandKeyDto>>
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

	public virtual async Task<IEnumerable<TenantBrandKeyDto>> Handle(UpdateTenantBrandsForTenantCommand request, CancellationToken cancellationToken)
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
				parentEntity.CreateTenantBrands(entity);
			}
			else
			{
				var ownedId = Dto.TenantBrandMetadata.CreateId(entityDto.Id.NonNullValue<System.Int64>());
				entity = parentEntity.TenantBrands.SingleOrDefault(x => x.Id == ownedId);
				if (entity is null)
				{
					throw new EntityNotFoundException("TenantBrand",  $"ownedId");
				}
				else
				{
					await _entityFactory.UpdateEntityAsync(entity, entityDto, request.CultureCode);
				}
			}

			entities.Add(entity);
		}

		parentEntity.Etag = request.Etag ?? System.Guid.Empty;		
		_repository.Update(parentEntity);
		await OnCompletedAsync(request, entities!);
		await _repository.SaveChangesAsync();

		return entities.Select(entity => new TenantBrandKeyDto(entity.Id.Value));
	}
	
	private async Task<TenantBrandEntity> CreateEntityAsync(TenantBrandUpsertDto upsertDto, TenantEntity parent, Nox.Types.CultureCode cultureCode)
	{
		var entity = await _entityFactory.CreateEntityAsync(upsertDto, cultureCode);
		parent.CreateTenantBrands(entity);
		return entity;
	}
}

public class UpdateTenantBrandsForTenantCommandValidator : AbstractValidator<UpdateTenantBrandsForTenantCommand>
{
    public UpdateTenantBrandsForTenantCommandValidator()
    {
    }
}