﻿﻿
// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Nox.Application.Factories;
using Nox.Exceptions;
using Nox.Extensions;
using FluentValidation;
using ClientApi.Infrastructure.Persistence;
using ClientApi.Domain;
using ClientApi.Application.Dto;
using ClientEntity = ClientApi.Domain.Client;

namespace ClientApi.Application.Commands;

public partial record UpdateClientCommand(System.Guid keyId, ClientUpdateDto EntityDto, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest<ClientKeyDto>;

internal partial class UpdateClientCommandHandler : UpdateClientCommandHandlerBase
{
	public UpdateClientCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<ClientEntity, ClientCreateDto, ClientUpdateDto> entityFactory)
		: base(dbContext, noxSolution,entityFactory)
	{
	}
}

internal abstract class UpdateClientCommandHandlerBase : CommandBase<UpdateClientCommand, ClientEntity>, IRequestHandler<UpdateClientCommand, ClientKeyDto>
{
	public AppDbContext DbContext { get; }
	private readonly IEntityFactory<ClientEntity, ClientCreateDto, ClientUpdateDto> _entityFactory;

	protected UpdateClientCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<ClientEntity, ClientCreateDto, ClientUpdateDto> entityFactory)
		: base(noxSolution)
	{
		DbContext = dbContext;
		_entityFactory = entityFactory;
	}

	public virtual async Task<ClientKeyDto> Handle(UpdateClientCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = ClientApi.Domain.ClientMetadata.CreateId(request.keyId);

		var entity = await DbContext.Clients.FindAsync(keyId);
		if (entity == null)
		{
			throw new EntityNotFoundException("Client",  $"{keyId.ToString()}");
		}

		await _entityFactory.UpdateEntityAsync(entity, request.EntityDto, request.CultureCode);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		if (result < 1)
		{
			throw new DatabaseSaveException();
		}

		return new ClientKeyDto(entity.Id.Value);
	}
}