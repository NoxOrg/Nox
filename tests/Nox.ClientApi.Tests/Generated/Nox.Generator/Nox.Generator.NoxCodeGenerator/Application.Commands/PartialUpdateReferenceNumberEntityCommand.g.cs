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
using ReferenceNumberEntityEntity = ClientApi.Domain.ReferenceNumberEntity;

namespace ClientApi.Application.Commands;

public partial record PartialUpdateReferenceNumberEntityCommand(System.String keyId, Dictionary<string, dynamic> UpdatedProperties, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest <ReferenceNumberEntityKeyDto>;

internal partial class PartialUpdateReferenceNumberEntityCommandHandler : PartialUpdateReferenceNumberEntityCommandHandlerBase
{
	public PartialUpdateReferenceNumberEntityCommandHandler(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<ReferenceNumberEntityEntity, ReferenceNumberEntityCreateDto, ReferenceNumberEntityUpdateDto> entityFactory)
		: base(repository,noxSolution, entityFactory)
	{
	}
}
internal abstract class PartialUpdateReferenceNumberEntityCommandHandlerBase : CommandBase<PartialUpdateReferenceNumberEntityCommand, ReferenceNumberEntityEntity>, IRequestHandler<PartialUpdateReferenceNumberEntityCommand, ReferenceNumberEntityKeyDto>
{
	public IRepository Repository { get; }
	public IEntityFactory<ReferenceNumberEntityEntity, ReferenceNumberEntityCreateDto, ReferenceNumberEntityUpdateDto> EntityFactory { get; }
	
	public PartialUpdateReferenceNumberEntityCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<ReferenceNumberEntityEntity, ReferenceNumberEntityCreateDto, ReferenceNumberEntityUpdateDto> entityFactory)
		: base(noxSolution)
	{
		Repository = repository;
		EntityFactory = entityFactory;
	}

	public virtual async Task<ReferenceNumberEntityKeyDto> Handle(PartialUpdateReferenceNumberEntityCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = Dto.ReferenceNumberEntityMetadata.CreateId(request.keyId);

		var entity = await Repository.FindAsync<ReferenceNumberEntity>(keyId);
		if (entity == null)
		{
			throw new EntityNotFoundException("ReferenceNumberEntity",  $"{keyId.ToString()}");
		}
		await EntityFactory.PartialUpdateEntityAsync(entity, request.UpdatedProperties, request.CultureCode);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;		
		Repository.Update(entity);
		await OnCompletedAsync(request, entity);

		await Repository.SaveChangesAsync();
		return new ReferenceNumberEntityKeyDto(entity.Id.Value);
	}
}