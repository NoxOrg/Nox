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
using ReferenceNumberEntityEntity = ClientApi.Domain.ReferenceNumberEntity;

namespace ClientApi.Application.Commands;

public partial record PartialUpdateReferenceNumberEntityCommand(System.String keyId, Dictionary<string, dynamic> UpdatedProperties, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest <ReferenceNumberEntityKeyDto>;

internal partial class PartialUpdateReferenceNumberEntityCommandHandler : PartialUpdateReferenceNumberEntityCommandHandlerBase
{
	public PartialUpdateReferenceNumberEntityCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<ReferenceNumberEntityEntity, ReferenceNumberEntityCreateDto, ReferenceNumberEntityUpdateDto> entityFactory)
		: base(dbContext,noxSolution, entityFactory)
	{
	}
}
internal abstract class PartialUpdateReferenceNumberEntityCommandHandlerBase : CommandBase<PartialUpdateReferenceNumberEntityCommand, ReferenceNumberEntityEntity>, IRequestHandler<PartialUpdateReferenceNumberEntityCommand, ReferenceNumberEntityKeyDto>
{
	public AppDbContext DbContext { get; }
	public IEntityFactory<ReferenceNumberEntityEntity, ReferenceNumberEntityCreateDto, ReferenceNumberEntityUpdateDto> EntityFactory { get; }

	public PartialUpdateReferenceNumberEntityCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<ReferenceNumberEntityEntity, ReferenceNumberEntityCreateDto, ReferenceNumberEntityUpdateDto> entityFactory)
		: base(noxSolution)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
	}

	public virtual async Task<ReferenceNumberEntityKeyDto> Handle(PartialUpdateReferenceNumberEntityCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = ClientApi.Domain.ReferenceNumberEntityMetadata.CreateId(request.keyId);

		var entity = await DbContext.ReferenceNumberEntities.FindAsync(keyId);
		if (entity == null)
		{
			throw new EntityNotFoundException("ReferenceNumberEntity",  $"{keyId.ToString()}");
		}
		EntityFactory.PartialUpdateEntity(entity, request.UpdatedProperties, request.CultureCode);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return new ReferenceNumberEntityKeyDto(entity.Id.Value);
	}
}