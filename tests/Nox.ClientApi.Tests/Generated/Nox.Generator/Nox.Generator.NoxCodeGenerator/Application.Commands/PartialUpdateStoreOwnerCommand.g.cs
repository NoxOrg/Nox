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
using StoreOwnerEntity = ClientApi.Domain.StoreOwner;

namespace ClientApi.Application.Commands;

public partial record PartialUpdateStoreOwnerCommand(System.String keyId, Dictionary<string, dynamic> UpdatedProperties, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest <StoreOwnerKeyDto>;

internal partial class PartialUpdateStoreOwnerCommandHandler : PartialUpdateStoreOwnerCommandHandlerBase
{
	public PartialUpdateStoreOwnerCommandHandler(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<StoreOwnerEntity, StoreOwnerCreateDto, StoreOwnerUpdateDto> entityFactory)
		: base(repository,noxSolution, entityFactory)
	{
	}
}
internal abstract class PartialUpdateStoreOwnerCommandHandlerBase : CommandBase<PartialUpdateStoreOwnerCommand, StoreOwnerEntity>, IRequestHandler<PartialUpdateStoreOwnerCommand, StoreOwnerKeyDto>
{
	public IRepository Repository { get; }
	public IEntityFactory<StoreOwnerEntity, StoreOwnerCreateDto, StoreOwnerUpdateDto> EntityFactory { get; }
	
	public PartialUpdateStoreOwnerCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<StoreOwnerEntity, StoreOwnerCreateDto, StoreOwnerUpdateDto> entityFactory)
		: base(noxSolution)
	{
		Repository = repository;
		EntityFactory = entityFactory;
	}

	public virtual async Task<StoreOwnerKeyDto> Handle(PartialUpdateStoreOwnerCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = Dto.StoreOwnerMetadata.CreateId(request.keyId);

		var entity = await Repository.FindAsync<StoreOwner>(keyId);
		if (entity == null)
		{
			throw new EntityNotFoundException("StoreOwner",  $"{keyId.ToString()}");
		}
		await EntityFactory.PartialUpdateEntityAsync(entity, request.UpdatedProperties, request.CultureCode);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;		
		Repository.SetStateModified(entity);
		await OnCompletedAsync(request, entity);

		await Repository.SaveChangesAsync();
		return new StoreOwnerKeyDto(entity.Id.Value);
	}
}