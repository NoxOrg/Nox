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
using TestEntityTwoRelationshipsManyToManyEntity = TestWebApp.Domain.TestEntityTwoRelationshipsManyToMany;

namespace TestWebApp.Application.Commands;

public partial record PartialUpdateTestEntityTwoRelationshipsManyToManyCommand(System.String keyId, Dictionary<string, dynamic> UpdatedProperties, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest <TestEntityTwoRelationshipsManyToManyKeyDto>;

internal partial class PartialUpdateTestEntityTwoRelationshipsManyToManyCommandHandler : PartialUpdateTestEntityTwoRelationshipsManyToManyCommandHandlerBase
{
	public PartialUpdateTestEntityTwoRelationshipsManyToManyCommandHandler(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityTwoRelationshipsManyToManyEntity, TestEntityTwoRelationshipsManyToManyCreateDto, TestEntityTwoRelationshipsManyToManyUpdateDto> entityFactory)
		: base(repository,noxSolution, entityFactory)
	{
	}
}
internal abstract class PartialUpdateTestEntityTwoRelationshipsManyToManyCommandHandlerBase : CommandBase<PartialUpdateTestEntityTwoRelationshipsManyToManyCommand, TestEntityTwoRelationshipsManyToManyEntity>, IRequestHandler<PartialUpdateTestEntityTwoRelationshipsManyToManyCommand, TestEntityTwoRelationshipsManyToManyKeyDto>
{
	public IRepository Repository { get; }
	public IEntityFactory<TestEntityTwoRelationshipsManyToManyEntity, TestEntityTwoRelationshipsManyToManyCreateDto, TestEntityTwoRelationshipsManyToManyUpdateDto> EntityFactory { get; }
	
	public PartialUpdateTestEntityTwoRelationshipsManyToManyCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityTwoRelationshipsManyToManyEntity, TestEntityTwoRelationshipsManyToManyCreateDto, TestEntityTwoRelationshipsManyToManyUpdateDto> entityFactory)
		: base(noxSolution)
	{
		Repository = repository;
		EntityFactory = entityFactory;
	}

	public virtual async Task<TestEntityTwoRelationshipsManyToManyKeyDto> Handle(PartialUpdateTestEntityTwoRelationshipsManyToManyCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = Dto.TestEntityTwoRelationshipsManyToManyMetadata.CreateId(request.keyId);

		var entity = await Repository.FindAsync<TestEntityTwoRelationshipsManyToMany>(keyId);
		if (entity == null)
		{
			throw new EntityNotFoundException("TestEntityTwoRelationshipsManyToMany",  $"{keyId.ToString()}");
		}
		await EntityFactory.PartialUpdateEntityAsync(entity, request.UpdatedProperties, request.CultureCode);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;		
		Repository.Update(entity);
		await OnCompletedAsync(request, entity);

		await Repository.SaveChangesAsync();
		return new TestEntityTwoRelationshipsManyToManyKeyDto(entity.Id.Value);
	}
}