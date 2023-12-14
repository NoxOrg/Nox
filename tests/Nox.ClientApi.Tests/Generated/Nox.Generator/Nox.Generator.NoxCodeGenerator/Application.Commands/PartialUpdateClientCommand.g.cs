﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Application.Factories;
using Nox.Solution;
using Nox.Types;

using ClientApi.Infrastructure.Persistence;
using ClientApi.Domain;
using ClientApi.Application.Dto;
using ClientEntity = ClientApi.Domain.Client;

namespace ClientApi.Application.Commands;

public partial record PartialUpdateClientCommand(System.Guid keyId, Dictionary<string, dynamic> UpdatedProperties, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest <ClientKeyDto?>;

internal partial class PartialUpdateClientCommandHandler : PartialUpdateClientCommandHandlerBase
{
	public PartialUpdateClientCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<ClientEntity, ClientCreateDto, ClientUpdateDto> entityFactory)
		: base(dbContext,noxSolution, entityFactory)
	{
	}
}
internal abstract class PartialUpdateClientCommandHandlerBase : CommandBase<PartialUpdateClientCommand, ClientEntity>, IRequestHandler<PartialUpdateClientCommand, ClientKeyDto?>
{
	public AppDbContext DbContext { get; }
	public IEntityFactory<ClientEntity, ClientCreateDto, ClientUpdateDto> EntityFactory { get; }

	public PartialUpdateClientCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<ClientEntity, ClientCreateDto, ClientUpdateDto> entityFactory)
		: base(noxSolution)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
	}

	public virtual async Task<ClientKeyDto?> Handle(PartialUpdateClientCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = ClientApi.Domain.ClientMetadata.CreateId(request.keyId);

		var entity = await DbContext.Clients.FindAsync(keyId);
		if (entity == null)
		{
			return null;
		}
		EntityFactory.PartialUpdateEntity(entity, request.UpdatedProperties, request.CultureCode);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return new ClientKeyDto(entity.Id.Value);
	}
}