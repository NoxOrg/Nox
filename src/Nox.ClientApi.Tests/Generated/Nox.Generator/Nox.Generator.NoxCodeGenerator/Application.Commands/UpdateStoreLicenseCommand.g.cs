﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Nox.Application.Factories;
using Nox.Exceptions;
using Nox.Extensions;
using ClientApi.Infrastructure.Persistence;
using ClientApi.Domain;
using ClientApi.Application.Dto;
using StoreLicenseEntity = ClientApi.Domain.StoreLicense;

namespace ClientApi.Application.Commands;

public record UpdateStoreLicenseCommand(System.Int64 keyId, StoreLicenseUpdateDto EntityDto, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest<StoreLicenseKeyDto?>;

internal partial class UpdateStoreLicenseCommandHandler : UpdateStoreLicenseCommandHandlerBase
{
	public UpdateStoreLicenseCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<StoreLicenseEntity, StoreLicenseCreateDto, StoreLicenseUpdateDto> entityFactory) 
		: base(dbContext, noxSolution, entityFactory)
	{
	}
}

internal abstract class UpdateStoreLicenseCommandHandlerBase : CommandBase<UpdateStoreLicenseCommand, StoreLicenseEntity>, IRequestHandler<UpdateStoreLicenseCommand, StoreLicenseKeyDto?>
{
	public AppDbContext DbContext { get; }
	private readonly IEntityFactory<StoreLicenseEntity, StoreLicenseCreateDto, StoreLicenseUpdateDto> _entityFactory;

	public UpdateStoreLicenseCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<StoreLicenseEntity, StoreLicenseCreateDto, StoreLicenseUpdateDto> entityFactory)
		: base(noxSolution)
	{
		DbContext = dbContext;
		_entityFactory = entityFactory;
	}

	public virtual async Task<StoreLicenseKeyDto?> Handle(UpdateStoreLicenseCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = ClientApi.Domain.StoreLicenseMetadata.CreateId(request.keyId);

		var entity = await DbContext.StoreLicenses.FindAsync(keyId);
		if (entity == null)
		{
			return null;
		}

		var storeWithLicenseKey = ClientApi.Domain.StoreMetadata.CreateId(request.EntityDto.StoreWithLicenseId);
		var storeWithLicenseEntity = await DbContext.Stores.FindAsync(storeWithLicenseKey);
						
		if(storeWithLicenseEntity is not null)
			entity.CreateRefToStoreWithLicense(storeWithLicenseEntity);
		else
			throw new RelatedEntityNotFoundException("StoreWithLicense", request.EntityDto.StoreWithLicenseId.ToString());

		_entityFactory.UpdateEntity(entity, request.EntityDto, request.CultureCode);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		if (result < 1)
		{
			return null;
		}

		return new StoreLicenseKeyDto(entity.Id.Value);
	}
}