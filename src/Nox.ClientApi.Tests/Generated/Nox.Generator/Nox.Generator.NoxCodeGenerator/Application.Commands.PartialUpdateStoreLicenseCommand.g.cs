﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Factories;
using Nox.Solution;
using Nox.Types;

using ClientApi.Infrastructure.Persistence;
using ClientApi.Domain;
using ClientApi.Application.Dto;
using StoreLicense = ClientApi.Domain.StoreLicense;

namespace ClientApi.Application.Commands;

public record PartialUpdateStoreLicenseCommand(System.Int64 keyId, Dictionary<string, dynamic> UpdatedProperties, System.Guid? Etag) : IRequest <StoreLicenseKeyDto?>;

internal class PartialUpdateStoreLicenseCommandHandler: PartialUpdateStoreLicenseCommandHandlerBase
{
	public PartialUpdateStoreLicenseCommandHandler(
		ClientApiDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<StoreLicense, StoreLicenseCreateDto, StoreLicenseUpdateDto> entityFactory) : base(dbContext,noxSolution, entityFactory)
	{
	}
}
internal class PartialUpdateStoreLicenseCommandHandlerBase: CommandBase<PartialUpdateStoreLicenseCommand, StoreLicense>, IRequestHandler<PartialUpdateStoreLicenseCommand, StoreLicenseKeyDto?>
{
	public ClientApiDbContext DbContext { get; }
	public IEntityFactory<StoreLicense, StoreLicenseCreateDto, StoreLicenseUpdateDto> EntityFactory { get; }

	public PartialUpdateStoreLicenseCommandHandlerBase(
		ClientApiDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<StoreLicense, StoreLicenseCreateDto, StoreLicenseUpdateDto> entityFactory) : base(noxSolution)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
	}

	public virtual async Task<StoreLicenseKeyDto?> Handle(PartialUpdateStoreLicenseCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = ClientApi.Domain.StoreLicenseMetadata.CreateId(request.keyId);

		var entity = await DbContext.StoreLicenses.FindAsync(keyId);
		if (entity == null)
		{
			return null;
		}
		EntityFactory.PartialUpdateEntity(entity, request.UpdatedProperties);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

		OnCompleted(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return new StoreLicenseKeyDto(entity.Id.Value);
	}
}