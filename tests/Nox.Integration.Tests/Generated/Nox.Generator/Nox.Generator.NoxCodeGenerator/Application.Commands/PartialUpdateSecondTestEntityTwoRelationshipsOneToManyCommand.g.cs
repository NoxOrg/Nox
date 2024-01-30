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
using SecondTestEntityTwoRelationshipsOneToManyEntity = TestWebApp.Domain.SecondTestEntityTwoRelationshipsOneToMany;

namespace TestWebApp.Application.Commands;

public partial record PartialUpdateSecondTestEntityTwoRelationshipsOneToManyCommand(System.String keyId, Dictionary<string, dynamic> UpdatedProperties, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest <SecondTestEntityTwoRelationshipsOneToManyKeyDto>;

internal partial class PartialUpdateSecondTestEntityTwoRelationshipsOneToManyCommandHandler : PartialUpdateSecondTestEntityTwoRelationshipsOneToManyCommandHandlerBase
{
	public PartialUpdateSecondTestEntityTwoRelationshipsOneToManyCommandHandler(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<SecondTestEntityTwoRelationshipsOneToManyEntity, SecondTestEntityTwoRelationshipsOneToManyCreateDto, SecondTestEntityTwoRelationshipsOneToManyUpdateDto> entityFactory)
		: base(repository,noxSolution, entityFactory)
	{
	}
}
internal abstract class PartialUpdateSecondTestEntityTwoRelationshipsOneToManyCommandHandlerBase : CommandBase<PartialUpdateSecondTestEntityTwoRelationshipsOneToManyCommand, SecondTestEntityTwoRelationshipsOneToManyEntity>, IRequestHandler<PartialUpdateSecondTestEntityTwoRelationshipsOneToManyCommand, SecondTestEntityTwoRelationshipsOneToManyKeyDto>
{
	public IRepository Repository { get; }
	public IEntityFactory<SecondTestEntityTwoRelationshipsOneToManyEntity, SecondTestEntityTwoRelationshipsOneToManyCreateDto, SecondTestEntityTwoRelationshipsOneToManyUpdateDto> EntityFactory { get; }
	
	public PartialUpdateSecondTestEntityTwoRelationshipsOneToManyCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<SecondTestEntityTwoRelationshipsOneToManyEntity, SecondTestEntityTwoRelationshipsOneToManyCreateDto, SecondTestEntityTwoRelationshipsOneToManyUpdateDto> entityFactory)
		: base(noxSolution)
	{
		Repository = repository;
		EntityFactory = entityFactory;
	}

	public virtual async Task<SecondTestEntityTwoRelationshipsOneToManyKeyDto> Handle(PartialUpdateSecondTestEntityTwoRelationshipsOneToManyCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = Dto.SecondTestEntityTwoRelationshipsOneToManyMetadata.CreateId(request.keyId);

		var entity = await Repository.FindAsync<SecondTestEntityTwoRelationshipsOneToMany>(keyId);
		if (entity == null)
		{
			throw new EntityNotFoundException("SecondTestEntityTwoRelationshipsOneToMany",  $"{keyId.ToString()}");
		}
		await EntityFactory.PartialUpdateEntityAsync(entity, request.UpdatedProperties, request.CultureCode);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;		
		Repository.Update(entity);
		await OnCompletedAsync(request, entity);

		await Repository.SaveChangesAsync();
		return new SecondTestEntityTwoRelationshipsOneToManyKeyDto(entity.Id.Value);
	}
}