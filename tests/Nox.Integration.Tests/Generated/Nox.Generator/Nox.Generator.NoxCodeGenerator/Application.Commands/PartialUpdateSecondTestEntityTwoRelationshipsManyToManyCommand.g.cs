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
using SecondTestEntityTwoRelationshipsManyToManyEntity = TestWebApp.Domain.SecondTestEntityTwoRelationshipsManyToMany;

namespace TestWebApp.Application.Commands;

public partial record PartialUpdateSecondTestEntityTwoRelationshipsManyToManyCommand(System.String keyId, Dictionary<string, dynamic> UpdatedProperties, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest <SecondTestEntityTwoRelationshipsManyToManyKeyDto>;

internal partial class PartialUpdateSecondTestEntityTwoRelationshipsManyToManyCommandHandler : PartialUpdateSecondTestEntityTwoRelationshipsManyToManyCommandHandlerBase
{
	public PartialUpdateSecondTestEntityTwoRelationshipsManyToManyCommandHandler(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<SecondTestEntityTwoRelationshipsManyToManyEntity, SecondTestEntityTwoRelationshipsManyToManyCreateDto, SecondTestEntityTwoRelationshipsManyToManyUpdateDto> entityFactory)
		: base(repository,noxSolution, entityFactory)
	{
	}
}
internal abstract class PartialUpdateSecondTestEntityTwoRelationshipsManyToManyCommandHandlerBase : CommandBase<PartialUpdateSecondTestEntityTwoRelationshipsManyToManyCommand, SecondTestEntityTwoRelationshipsManyToManyEntity>, IRequestHandler<PartialUpdateSecondTestEntityTwoRelationshipsManyToManyCommand, SecondTestEntityTwoRelationshipsManyToManyKeyDto>
{
	public IRepository Repository { get; }
	public IEntityFactory<SecondTestEntityTwoRelationshipsManyToManyEntity, SecondTestEntityTwoRelationshipsManyToManyCreateDto, SecondTestEntityTwoRelationshipsManyToManyUpdateDto> EntityFactory { get; }
	
	public PartialUpdateSecondTestEntityTwoRelationshipsManyToManyCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<SecondTestEntityTwoRelationshipsManyToManyEntity, SecondTestEntityTwoRelationshipsManyToManyCreateDto, SecondTestEntityTwoRelationshipsManyToManyUpdateDto> entityFactory)
		: base(noxSolution)
	{
		Repository = repository;
		EntityFactory = entityFactory;
	}

	public virtual async Task<SecondTestEntityTwoRelationshipsManyToManyKeyDto> Handle(PartialUpdateSecondTestEntityTwoRelationshipsManyToManyCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = Dto.SecondTestEntityTwoRelationshipsManyToManyMetadata.CreateId(request.keyId);

		var entity = await Repository.FindAsync<TestWebApp.Domain.SecondTestEntityTwoRelationshipsManyToMany>(keyId);
		if (entity == null)
		{
			throw new EntityNotFoundException("SecondTestEntityTwoRelationshipsManyToMany",  $"{keyId.ToString()}");
		}
		await EntityFactory.PartialUpdateEntityAsync(entity, request.UpdatedProperties, request.CultureCode);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;		
		Repository.Update(entity);
		await OnCompletedAsync(request, entity);

		await Repository.SaveChangesAsync();
		return new SecondTestEntityTwoRelationshipsManyToManyKeyDto(entity.Id.Value);
	}
}