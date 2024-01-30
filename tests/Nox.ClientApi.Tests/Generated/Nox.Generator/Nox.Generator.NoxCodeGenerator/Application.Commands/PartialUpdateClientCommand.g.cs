// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Application.Factories;
using Nox.Solution;
using Nox.Domain;
using Nox.Types;
using Nox.Exceptions;

using ClientApi.Domain;
using ClientApi.Application.Dto;
using Dto = ClientApi.Application.Dto;
using ClientEntity = ClientApi.Domain.Client;

namespace ClientApi.Application.Commands;

public partial record PartialUpdateClientCommand(System.Guid keyId, Dictionary<string, dynamic> UpdatedProperties, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest <ClientKeyDto>;

internal partial class PartialUpdateClientCommandHandler : PartialUpdateClientCommandHandlerBase
{
	public PartialUpdateClientCommandHandler(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<ClientEntity, ClientCreateDto, ClientUpdateDto> entityFactory)
		: base(repository,noxSolution, entityFactory)
	{
	}
}
internal abstract class PartialUpdateClientCommandHandlerBase : CommandBase<PartialUpdateClientCommand, ClientEntity>, IRequestHandler<PartialUpdateClientCommand, ClientKeyDto>
{
	public IRepository Repository { get; }
	public IEntityFactory<ClientEntity, ClientCreateDto, ClientUpdateDto> EntityFactory { get; }
	
	public PartialUpdateClientCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<ClientEntity, ClientCreateDto, ClientUpdateDto> entityFactory)
		: base(noxSolution)
	{
		Repository = repository;
		EntityFactory = entityFactory;
	}

	public virtual async Task<ClientKeyDto> Handle(PartialUpdateClientCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = Dto.ClientMetadata.CreateId(request.keyId);

		var entity = await Repository.FindAsync<Client>(keyId);
		if (entity == null)
		{
			throw new EntityNotFoundException("Client",  $"{keyId.ToString()}");
		}
		await EntityFactory.PartialUpdateEntityAsync(entity, request.UpdatedProperties, request.CultureCode);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;		
		Repository.Update(entity);
		await OnCompletedAsync(request, entity);

		await Repository.SaveChangesAsync();
		return new ClientKeyDto(entity.Id.Value);
	}
}