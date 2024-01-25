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
using SecondTestEntityTwoRelationshipsOneToOneEntity = TestWebApp.Domain.SecondTestEntityTwoRelationshipsOneToOne;

namespace TestWebApp.Application.Commands;

public partial record PartialUpdateSecondTestEntityTwoRelationshipsOneToOneCommand(System.String keyId, Dictionary<string, dynamic> UpdatedProperties, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest <SecondTestEntityTwoRelationshipsOneToOneKeyDto>;

internal partial class PartialUpdateSecondTestEntityTwoRelationshipsOneToOneCommandHandler : PartialUpdateSecondTestEntityTwoRelationshipsOneToOneCommandHandlerBase
{
	public PartialUpdateSecondTestEntityTwoRelationshipsOneToOneCommandHandler(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<SecondTestEntityTwoRelationshipsOneToOneEntity, SecondTestEntityTwoRelationshipsOneToOneCreateDto, SecondTestEntityTwoRelationshipsOneToOneUpdateDto> entityFactory)
		: base(repository,noxSolution, entityFactory)
	{
	}
}
internal abstract class PartialUpdateSecondTestEntityTwoRelationshipsOneToOneCommandHandlerBase : CommandBase<PartialUpdateSecondTestEntityTwoRelationshipsOneToOneCommand, SecondTestEntityTwoRelationshipsOneToOneEntity>, IRequestHandler<PartialUpdateSecondTestEntityTwoRelationshipsOneToOneCommand, SecondTestEntityTwoRelationshipsOneToOneKeyDto>
{
	public IRepository Repository { get; }
	public IEntityFactory<SecondTestEntityTwoRelationshipsOneToOneEntity, SecondTestEntityTwoRelationshipsOneToOneCreateDto, SecondTestEntityTwoRelationshipsOneToOneUpdateDto> EntityFactory { get; }
	
	public PartialUpdateSecondTestEntityTwoRelationshipsOneToOneCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<SecondTestEntityTwoRelationshipsOneToOneEntity, SecondTestEntityTwoRelationshipsOneToOneCreateDto, SecondTestEntityTwoRelationshipsOneToOneUpdateDto> entityFactory)
		: base(noxSolution)
	{
		Repository = repository;
		EntityFactory = entityFactory;
	}

	public virtual async Task<SecondTestEntityTwoRelationshipsOneToOneKeyDto> Handle(PartialUpdateSecondTestEntityTwoRelationshipsOneToOneCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = Dto.SecondTestEntityTwoRelationshipsOneToOneMetadata.CreateId(request.keyId);

		var entity = await Repository.FindAsync<SecondTestEntityTwoRelationshipsOneToOne>(keyId);
		if (entity == null)
		{
			throw new EntityNotFoundException("SecondTestEntityTwoRelationshipsOneToOne",  $"{keyId.ToString()}");
		}
		await EntityFactory.PartialUpdateEntityAsync(entity, request.UpdatedProperties, request.CultureCode);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;		
		Repository.SetStateModified(entity);
		await OnCompletedAsync(request, entity);

		await Repository.SaveChangesAsync();
		return new SecondTestEntityTwoRelationshipsOneToOneKeyDto(entity.Id.Value);
	}
}