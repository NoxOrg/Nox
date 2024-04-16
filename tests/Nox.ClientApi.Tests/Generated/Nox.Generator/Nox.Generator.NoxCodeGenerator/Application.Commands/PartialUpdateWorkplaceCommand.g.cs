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
using WorkplaceEntity = ClientApi.Domain.Workplace;

namespace ClientApi.Application.Commands;

public partial record PartialUpdateWorkplaceCommand(System.Int64 keyId, Dictionary<string, dynamic> UpdatedProperties, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest <WorkplaceKeyDto>;

internal partial class PartialUpdateWorkplaceCommandHandler : PartialUpdateWorkplaceCommandHandlerBase
{
	public PartialUpdateWorkplaceCommandHandler(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<WorkplaceEntity, WorkplaceCreateDto, WorkplaceUpdateDto> entityFactory)
		: base(repository,noxSolution, entityFactory)
	{
	}
}
internal abstract class PartialUpdateWorkplaceCommandHandlerBase : CommandBase<PartialUpdateWorkplaceCommand, WorkplaceEntity>, IRequestHandler<PartialUpdateWorkplaceCommand, WorkplaceKeyDto>
{
	public IRepository Repository { get; }
	public IEntityFactory<WorkplaceEntity, WorkplaceCreateDto, WorkplaceUpdateDto> EntityFactory { get; }
	
	public PartialUpdateWorkplaceCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<WorkplaceEntity, WorkplaceCreateDto, WorkplaceUpdateDto> entityFactory)
		: base(noxSolution)
	{
		Repository = repository;
		EntityFactory = entityFactory;
	}

	public virtual async Task<WorkplaceKeyDto> Handle(PartialUpdateWorkplaceCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = Dto.WorkplaceMetadata.CreateId(request.keyId);

		var entity = await Repository.FindAsync<ClientApi.Domain.Workplace>(keyId);
		if (entity == null)
		{
			throw new EntityNotFoundException("Workplace",  $"{keyId.ToString()}");
		}
		await EntityFactory.PartialUpdateEntityAsync(entity, request.UpdatedProperties, request.CultureCode);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;		
		Repository.Update(entity);
		await OnCompletedAsync(request, entity);

		await Repository.SaveChangesAsync();
		return new WorkplaceKeyDto(entity.Id.Value);
	}
}