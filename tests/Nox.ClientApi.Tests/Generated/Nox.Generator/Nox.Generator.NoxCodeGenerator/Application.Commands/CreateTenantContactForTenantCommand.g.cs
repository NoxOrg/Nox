﻿// Generated

#nullable enable

using MediatR;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nox.Application;
using Nox.Application.Commands;
using Nox.Application.Factories;
using Nox.Solution;
using Nox.Types;
using Nox.Exceptions;
using FluentValidation;
using Microsoft.Extensions.Logging;

using ClientApi.Infrastructure.Persistence;
using ClientApi.Domain;
using ClientApi.Application.Dto;
using TenantContactEntity = ClientApi.Domain.TenantContact;

namespace ClientApi.Application.Commands;
public partial record CreateTenantContactForTenantCommand(TenantKeyDto ParentKeyDto, TenantContactUpsertDto EntityDto, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest <TenantContactKeyDto>;

internal partial class CreateTenantContactForTenantCommandHandler : CreateTenantContactForTenantCommandHandlerBase
{
	public CreateTenantContactForTenantCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TenantContactEntity, TenantContactUpsertDto, TenantContactUpsertDto> entityFactory,
		IEntityLocalizedFactory<TenantContactLocalized, TenantContactEntity, TenantContactUpsertDto> entityLocalizedFactory)
		: base(dbContext, noxSolution, entityFactory, entityLocalizedFactory)
	{
	}
}
internal abstract class CreateTenantContactForTenantCommandHandlerBase : CommandBase<CreateTenantContactForTenantCommand, TenantContactEntity>, IRequestHandler<CreateTenantContactForTenantCommand, TenantContactKeyDto?>
{
	private readonly AppDbContext _dbContext;
	private readonly IEntityFactory<TenantContactEntity, TenantContactUpsertDto, TenantContactUpsertDto> _entityFactory;
	protected readonly IEntityLocalizedFactory<TenantContactLocalized, TenantContactEntity, TenantContactUpsertDto> _entityLocalizedFactory;

	protected CreateTenantContactForTenantCommandHandlerBase(
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

	public virtual  async Task<TenantContactKeyDto?> Handle(CreateTenantContactForTenantCommand request, CancellationToken cancellationToken)
	{
		await OnExecutingAsync(request);
		var keyId = ClientApi.Domain.TenantMetadata.CreateId(request.ParentKeyDto.keyId);

		var parentEntity = await _dbContext.Tenants.FindAsync(keyId);
		if (parentEntity == null)
		{
			throw new EntityNotFoundException("Tenant",  $"{keyId.ToString()}");
		}

		var entity = await _entityFactory.CreateEntityAsync(request.EntityDto);
		parentEntity.CreateRefToTenantContact(entity);
		parentEntity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;
		await OnCompletedAsync(request, entity);

		_dbContext.Entry(parentEntity).State = EntityState.Modified;
		var entityLocalized = _entityLocalizedFactory.CreateLocalizedEntity(entity, request.CultureCode);
		_dbContext.TenantContactsLocalized.Add(entityLocalized);

		var result = await _dbContext.SaveChangesAsync();
		if (result < 1)
		{
			throw new DatabaseSaveException();
		}

		return new TenantContactKeyDto();
	}
}