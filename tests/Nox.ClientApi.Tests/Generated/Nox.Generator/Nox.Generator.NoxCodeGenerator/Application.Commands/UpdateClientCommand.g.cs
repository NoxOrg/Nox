﻿﻿
// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using FluentValidation;

using Nox.Application.Commands;
using Nox.Domain;
using Nox.Solution;
using Nox.Types;
using Nox.Application.Factories;
using Nox.Exceptions;
using Nox.Extensions;


using ClientApi.Domain;
using ClientApi.Application.Dto;
using Dto = ClientApi.Application.Dto;
using ClientEntity = ClientApi.Domain.Client;

namespace ClientApi.Application.Commands;

public partial record UpdateClientCommand(System.Guid keyId, ClientUpdateDto EntityDto, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest<ClientKeyDto>;

internal partial class UpdateClientCommandHandler : UpdateClientCommandHandlerBase
{
	public UpdateClientCommandHandler(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<ClientEntity, ClientCreateDto, ClientUpdateDto> entityFactory)
		: base(repository, noxSolution, entityFactory)
	{
	}
}

internal abstract class UpdateClientCommandHandlerBase : CommandBase<UpdateClientCommand, ClientEntity>, IRequestHandler<UpdateClientCommand, ClientKeyDto>
{
	protected IRepository Repository { get; }
	protected IEntityFactory<ClientEntity, ClientCreateDto, ClientUpdateDto> EntityFactory { get; }
	protected UpdateClientCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<ClientEntity, ClientCreateDto, ClientUpdateDto> entityFactory)
		: base(noxSolution)
	{
		Repository = repository;
		EntityFactory = entityFactory;
	}

	public virtual async Task<ClientKeyDto> Handle(UpdateClientCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);

		var entity = Repository.Query<Client>()
            .Where(x => x.Id == Dto.ClientMetadata.CreateId(request.keyId))
			.SingleOrDefault();
		
		if (entity == null)
		{
			throw new EntityNotFoundException("Client",  "keyId");
		}

		await EntityFactory.UpdateEntityAsync(entity, request.EntityDto, request.CultureCode);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

		//Repository.SetStateModified(entity);
		await OnCompletedAsync(request, entity);		
		await Repository.SaveChangesAsync();

		return new ClientKeyDto(entity.Id.Value);
	}
}