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

using TestWebApp.Domain;
using TestWebApp.Application.Dto;
using Dto = TestWebApp.Application.Dto;
using EntityUniqueConstraintsWithForeignKeyEntity = TestWebApp.Domain.EntityUniqueConstraintsWithForeignKey;

namespace TestWebApp.Application.Commands;

public partial record PartialUpdateEntityUniqueConstraintsWithForeignKeyCommand(System.Guid keyId, Dictionary<string, dynamic> UpdatedProperties, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest <EntityUniqueConstraintsWithForeignKeyKeyDto>;

internal partial class PartialUpdateEntityUniqueConstraintsWithForeignKeyCommandHandler : PartialUpdateEntityUniqueConstraintsWithForeignKeyCommandHandlerBase
{
	public PartialUpdateEntityUniqueConstraintsWithForeignKeyCommandHandler(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<EntityUniqueConstraintsWithForeignKeyEntity, EntityUniqueConstraintsWithForeignKeyCreateDto, EntityUniqueConstraintsWithForeignKeyUpdateDto> entityFactory)
		: base(repository,noxSolution, entityFactory)
	{
	}
}
internal abstract class PartialUpdateEntityUniqueConstraintsWithForeignKeyCommandHandlerBase : CommandBase<PartialUpdateEntityUniqueConstraintsWithForeignKeyCommand, EntityUniqueConstraintsWithForeignKeyEntity>, IRequestHandler<PartialUpdateEntityUniqueConstraintsWithForeignKeyCommand, EntityUniqueConstraintsWithForeignKeyKeyDto>
{
	public IRepository Repository { get; }
	public IEntityFactory<EntityUniqueConstraintsWithForeignKeyEntity, EntityUniqueConstraintsWithForeignKeyCreateDto, EntityUniqueConstraintsWithForeignKeyUpdateDto> EntityFactory { get; }
	
	public PartialUpdateEntityUniqueConstraintsWithForeignKeyCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<EntityUniqueConstraintsWithForeignKeyEntity, EntityUniqueConstraintsWithForeignKeyCreateDto, EntityUniqueConstraintsWithForeignKeyUpdateDto> entityFactory)
		: base(noxSolution)
	{
		Repository = repository;
		EntityFactory = entityFactory;
	}

	public virtual async Task<EntityUniqueConstraintsWithForeignKeyKeyDto> Handle(PartialUpdateEntityUniqueConstraintsWithForeignKeyCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = Dto.EntityUniqueConstraintsWithForeignKeyMetadata.CreateId(request.keyId);

		var entity = await Repository.FindAsync<EntityUniqueConstraintsWithForeignKey>(keyId);
		if (entity == null)
		{
			throw new EntityNotFoundException("EntityUniqueConstraintsWithForeignKey",  $"{keyId.ToString()}");
		}
		await EntityFactory.PartialUpdateEntityAsync(entity, request.UpdatedProperties, request.CultureCode);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;		
		Repository.Update(entity);
		await OnCompletedAsync(request, entity);

		await Repository.SaveChangesAsync();
		return new EntityUniqueConstraintsWithForeignKeyKeyDto(entity.Id.Value);
	}
}