﻿﻿﻿﻿// Generated

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
using TenantContactEntity = ClientApi.Domain.TenantContact;
using TenantEntity = ClientApi.Domain.Tenant;

namespace ClientApi.Application.Commands;

public partial record UpdateTenantContactForSingleTenantCommand(TenantKeyDto ParentKeyDto, TenantContactUpsertDto EntityDto, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest <TenantContactKeyDto>;

internal partial class UpdateTenantContactForSingleTenantCommandHandler : UpdateTenantContactForSingleTenantCommandHandlerBase
{
	public UpdateTenantContactForSingleTenantCommandHandler(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<TenantContactEntity, TenantContactUpsertDto, TenantContactUpsertDto> entityFactory)
		: base(repository, noxSolution, entityFactory)
	{
	}
}

internal partial class UpdateTenantContactForSingleTenantCommandHandlerBase : CommandBase<UpdateTenantContactForSingleTenantCommand, TenantContactEntity>, IRequestHandler <UpdateTenantContactForSingleTenantCommand, TenantContactKeyDto>
{
	private readonly IRepository _repository;
	private readonly IEntityFactory<TenantContactEntity, TenantContactUpsertDto, TenantContactUpsertDto> _entityFactory;

	protected UpdateTenantContactForSingleTenantCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<TenantContactEntity, TenantContactUpsertDto, TenantContactUpsertDto> entityFactory)
		: base(noxSolution)
	{
		_repository = repository;
		_entityFactory = entityFactory;
	}

	public virtual async Task<TenantContactKeyDto> Handle(UpdateTenantContactForSingleTenantCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);

		var keys = new List<object?>(1);
		keys.Add(Dto.TenantMetadata.CreateId(request.ParentKeyDto.keyId));

		var parentEntity = await _repository.FindAndIncludeAsync<ClientApi.Domain.Tenant>(keys.ToArray(),e => e.TenantContact, cancellationToken);
		EntityNotFoundException.ThrowIfNull(parentEntity, "Tenant",  "keyId");		
		var entity = parentEntity.TenantContact;
		if (entity is null)
			entity = await CreateEntityAsync(request.EntityDto, parentEntity, request.CultureCode);
		else
			await _entityFactory.UpdateEntityAsync(entity, request.EntityDto, request.CultureCode);

		parentEntity.Etag = request.Etag ?? System.Guid.Empty;		
		_repository.Update(parentEntity);
		await OnCompletedAsync(request, entity!);
		await _repository.SaveChangesAsync();

		return new TenantContactKeyDto();
	}
	
	private async Task<TenantContactEntity> CreateEntityAsync(TenantContactUpsertDto upsertDto, TenantEntity parent, Nox.Types.CultureCode cultureCode)
	{
		var entity = await _entityFactory.CreateEntityAsync(upsertDto, cultureCode);
		parent.CreateTenantContact(entity);
		return entity;
	}
}