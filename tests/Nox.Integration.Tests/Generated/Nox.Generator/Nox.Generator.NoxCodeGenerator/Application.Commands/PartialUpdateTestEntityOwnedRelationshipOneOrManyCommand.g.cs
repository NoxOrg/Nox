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
using TestEntityOwnedRelationshipOneOrManyEntity = TestWebApp.Domain.TestEntityOwnedRelationshipOneOrMany;

namespace TestWebApp.Application.Commands;

public partial record PartialUpdateTestEntityOwnedRelationshipOneOrManyCommand(System.String keyId, Dictionary<string, dynamic> UpdatedProperties, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest <TestEntityOwnedRelationshipOneOrManyKeyDto>;

internal partial class PartialUpdateTestEntityOwnedRelationshipOneOrManyCommandHandler : PartialUpdateTestEntityOwnedRelationshipOneOrManyCommandHandlerBase
{
	public PartialUpdateTestEntityOwnedRelationshipOneOrManyCommandHandler(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityOwnedRelationshipOneOrManyEntity, TestEntityOwnedRelationshipOneOrManyCreateDto, TestEntityOwnedRelationshipOneOrManyUpdateDto> entityFactory)
		: base(repository,noxSolution, entityFactory)
	{
	}
}
internal abstract class PartialUpdateTestEntityOwnedRelationshipOneOrManyCommandHandlerBase : CommandBase<PartialUpdateTestEntityOwnedRelationshipOneOrManyCommand, TestEntityOwnedRelationshipOneOrManyEntity>, IRequestHandler<PartialUpdateTestEntityOwnedRelationshipOneOrManyCommand, TestEntityOwnedRelationshipOneOrManyKeyDto>
{
	public IRepository Repository { get; }
	public IEntityFactory<TestEntityOwnedRelationshipOneOrManyEntity, TestEntityOwnedRelationshipOneOrManyCreateDto, TestEntityOwnedRelationshipOneOrManyUpdateDto> EntityFactory { get; }
	
	public PartialUpdateTestEntityOwnedRelationshipOneOrManyCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityOwnedRelationshipOneOrManyEntity, TestEntityOwnedRelationshipOneOrManyCreateDto, TestEntityOwnedRelationshipOneOrManyUpdateDto> entityFactory)
		: base(noxSolution)
	{
		Repository = repository;
		EntityFactory = entityFactory;
	}

	public virtual async Task<TestEntityOwnedRelationshipOneOrManyKeyDto> Handle(PartialUpdateTestEntityOwnedRelationshipOneOrManyCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = Dto.TestEntityOwnedRelationshipOneOrManyMetadata.CreateId(request.keyId);

		var entity = await Repository.FindAsync<TestWebApp.Domain.TestEntityOwnedRelationshipOneOrMany>(keyId);
		if (entity == null)
		{
			throw new EntityNotFoundException("TestEntityOwnedRelationshipOneOrMany",  $"{keyId.ToString()}");
		}
		await EntityFactory.PartialUpdateEntityAsync(entity, request.UpdatedProperties, request.CultureCode);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;		
		Repository.Update(entity);
		await OnCompletedAsync(request, entity);

		await Repository.SaveChangesAsync();
		return new TestEntityOwnedRelationshipOneOrManyKeyDto(entity.Id.Value);
	}
}