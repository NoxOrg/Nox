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
using StoreEntity = ClientApi.Domain.Store;

namespace ClientApi.Application.Commands;

public partial record PartialUpdateStoreCommand(System.Guid keyId, Dictionary<string, dynamic> UpdatedProperties, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest <StoreKeyDto>;

internal partial class PartialUpdateStoreCommandHandler : PartialUpdateStoreCommandHandlerBase
{
	public PartialUpdateStoreCommandHandler(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<StoreEntity, StoreCreateDto, StoreUpdateDto> entityFactory)
		: base(repository,noxSolution, entityFactory)
	{
	}
}
internal abstract class PartialUpdateStoreCommandHandlerBase : CommandBase<PartialUpdateStoreCommand, StoreEntity>, IRequestHandler<PartialUpdateStoreCommand, StoreKeyDto>
{
	public IRepository Repository { get; }
	public IEntityFactory<StoreEntity, StoreCreateDto, StoreUpdateDto> EntityFactory { get; }
	
	public PartialUpdateStoreCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<StoreEntity, StoreCreateDto, StoreUpdateDto> entityFactory)
		: base(noxSolution)
	{
		Repository = repository;
		EntityFactory = entityFactory;
	}

	public virtual async Task<StoreKeyDto> Handle(PartialUpdateStoreCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = Dto.StoreMetadata.CreateId(request.keyId);

		var entity = await Repository.FindAsync<Store>(keyId);
		if (entity == null)
		{
			throw new EntityNotFoundException("Store",  $"{keyId.ToString()}");
		}
		await EntityFactory.PartialUpdateEntityAsync(entity, request.UpdatedProperties, request.CultureCode);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;		
		Repository.SetStateModified(entity);
		await OnCompletedAsync(request, entity);

		await Repository.SaveChangesAsync();
		return new StoreKeyDto(entity.Id.Value);
	}
}