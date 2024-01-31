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
using TenantContactEntity = ClientApi.Domain.TenantContact;

namespace ClientApi.Application.Commands;
public partial record PartialUpdateTenantContactForTenantCommand(TenantKeyDto ParentKeyDto, Dictionary<string, dynamic> UpdatedProperties, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest <TenantContactKeyDto>;

internal partial class PartialUpdateTenantContactForTenantCommandHandler: PartialUpdateTenantContactForTenantCommandHandlerBase
{
	public PartialUpdateTenantContactForTenantCommandHandler(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<TenantContactEntity, TenantContactUpsertDto, TenantContactUpsertDto> entityFactory)
		: base(repository, noxSolution, entityFactory)
	{
	}
}
internal abstract class PartialUpdateTenantContactForTenantCommandHandlerBase: CommandBase<PartialUpdateTenantContactForTenantCommand, TenantContactEntity>, IRequestHandler <PartialUpdateTenantContactForTenantCommand, TenantContactKeyDto>
{
	protected readonly IRepository Repository;
	protected readonly IEntityFactory<TenantContactEntity, TenantContactUpsertDto, TenantContactUpsertDto> EntityFactory;
	
	protected PartialUpdateTenantContactForTenantCommandHandlerBase(
		IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<TenantContactEntity, TenantContactUpsertDto, TenantContactUpsertDto> entityFactory)
		: base(noxSolution)
	{
		Repository = repository;
		EntityFactory = entityFactory;
	}

	public virtual async Task<TenantContactKeyDto> Handle(PartialUpdateTenantContactForTenantCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);

		var keys = new List<object?>(1);
		keys.Add(Dto.TenantMetadata.CreateId(request.ParentKeyDto.keyId));

		var parentEntity = await Repository.FindAndIncludeAsync<Tenant>(keys.ToArray(),e => e.TenantContact, cancellationToken);
		if (parentEntity == null)
		{
			throw new EntityNotFoundException("Tenant",  "keyId");
		}
		var entity = parentEntity.TenantContact;
		
		if (entity == null)
		{
			throw new EntityNotFoundException("Tenant.TenantContact", String.Empty);
		}

		await EntityFactory.PartialUpdateEntityAsync(entity, request.UpdatedProperties, request.CultureCode);
		parentEntity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;
		Repository.Update(entity);
		await OnCompletedAsync(request, entity);
		await Repository.SaveChangesAsync();		

		return new TenantContactKeyDto();
	}
}