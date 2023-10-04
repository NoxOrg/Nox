﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Nox.Factories;
using ClientApi.Infrastructure.Persistence;
using ClientApi.Domain;
using ClientApi.Application.Dto;
using StoreLicenseEntity = ClientApi.Domain.StoreLicense;

namespace ClientApi.Application.Commands;

public record UpdateStoreLicenseCommand(System.Int64 keyId, StoreLicenseUpdateDto EntityDto, System.Guid? Etag) : IRequest<StoreLicenseKeyDto?>;

internal partial class UpdateStoreLicenseCommandHandler : UpdateStoreLicenseCommandHandlerBase
{
	public UpdateStoreLicenseCommandHandler(
		ClientApiDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<StoreLicenseEntity, StoreLicenseCreateDto, StoreLicenseUpdateDto> entityFactory): base(dbContext, noxSolution, entityFactory)
	{
	}
}

internal abstract class UpdateStoreLicenseCommandHandlerBase : CommandBase<UpdateStoreLicenseCommand, StoreLicenseEntity>, IRequestHandler<UpdateStoreLicenseCommand, StoreLicenseKeyDto?>
{
	public ClientApiDbContext DbContext { get; }
	private readonly IEntityFactory<StoreLicenseEntity, StoreLicenseCreateDto, StoreLicenseUpdateDto> _entityFactory;

	public UpdateStoreLicenseCommandHandlerBase(
		ClientApiDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<StoreLicenseEntity, StoreLicenseCreateDto, StoreLicenseUpdateDto> entityFactory): base(noxSolution)
	{
		DbContext = dbContext;
		_entityFactory = entityFactory;
	}

	public virtual async Task<StoreLicenseKeyDto?> Handle(UpdateStoreLicenseCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = ClientApi.Domain.StoreLicenseMetadata.CreateId(request.keyId);

		var entity = await DbContext.StoreLicenses.FindAsync(keyId);
		if (entity == null)
		{
			return null;
		}

		_entityFactory.UpdateEntity(entity, request.EntityDto);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

		OnCompleted(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		if (result < 1)
		{
			return null;
		}

		return new StoreLicenseKeyDto(entity.Id.Value);
	}
}