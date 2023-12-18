// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Application.Factories;
using Nox.Solution;
using Nox.Types;
using Nox.Exceptions;

using ClientApi.Infrastructure.Persistence;
using ClientApi.Domain;
using ClientApi.Application.Dto;
using StoreOwnerEntity = ClientApi.Domain.StoreOwner;

namespace ClientApi.Application.Commands;

public partial record PartialUpdateStoreOwnerCommand(System.String keyId, Dictionary<string, dynamic> UpdatedProperties, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest <StoreOwnerKeyDto>;

internal partial class PartialUpdateStoreOwnerCommandHandler : PartialUpdateStoreOwnerCommandHandlerBase
{
	public PartialUpdateStoreOwnerCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<StoreOwnerEntity, StoreOwnerCreateDto, StoreOwnerUpdateDto> entityFactory)
		: base(dbContext,noxSolution, entityFactory)
	{
	}
}
internal abstract class PartialUpdateStoreOwnerCommandHandlerBase : CommandBase<PartialUpdateStoreOwnerCommand, StoreOwnerEntity>, IRequestHandler<PartialUpdateStoreOwnerCommand, StoreOwnerKeyDto>
{
	public AppDbContext DbContext { get; }
	public IEntityFactory<StoreOwnerEntity, StoreOwnerCreateDto, StoreOwnerUpdateDto> EntityFactory { get; }

	public PartialUpdateStoreOwnerCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<StoreOwnerEntity, StoreOwnerCreateDto, StoreOwnerUpdateDto> entityFactory)
		: base(noxSolution)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
	}

	public virtual async Task<StoreOwnerKeyDto> Handle(PartialUpdateStoreOwnerCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = ClientApi.Domain.StoreOwnerMetadata.CreateId(request.keyId);

		var entity = await DbContext.StoreOwners.FindAsync(keyId);
		if (entity == null)
		{
			throw new EntityNotFoundException("StoreOwner",  $"{keyId.ToString()}");
		}
		await EntityFactory.PartialUpdateEntityAsync(entity, request.UpdatedProperties, request.CultureCode);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return new StoreOwnerKeyDto(entity.Id.Value);
	}
}