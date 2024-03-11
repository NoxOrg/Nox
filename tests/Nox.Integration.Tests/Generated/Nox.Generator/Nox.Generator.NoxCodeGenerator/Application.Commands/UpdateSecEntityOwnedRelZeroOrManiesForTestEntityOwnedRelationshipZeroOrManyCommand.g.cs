﻿﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using FluentValidation;
using Microsoft.Extensions.Logging;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Domain;
using Nox.Types;
using Nox.Application.Factories;
using Nox.Extensions;
using Nox.Exceptions;

using TestWebApp.Domain;
using TestWebApp.Application.Dto;
using Dto = TestWebApp.Application.Dto;
using SecEntityOwnedRelZeroOrManyEntity = TestWebApp.Domain.SecEntityOwnedRelZeroOrMany;
using TestEntityOwnedRelationshipZeroOrManyEntity = TestWebApp.Domain.TestEntityOwnedRelationshipZeroOrMany;

namespace TestWebApp.Application.Commands;

public partial record UpdateSecEntityOwnedRelZeroOrManiesForTestEntityOwnedRelationshipZeroOrManyCommand(TestEntityOwnedRelationshipZeroOrManyKeyDto ParentKeyDto, IEnumerable<SecEntityOwnedRelZeroOrManyUpsertDto> EntitiesDto, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest<IEnumerable<SecEntityOwnedRelZeroOrManyKeyDto>>;

internal partial class UpdateSecEntityOwnedRelZeroOrManiesForTestEntityOwnedRelationshipZeroOrManyCommandHandler : UpdateSecEntityOwnedRelZeroOrManiesForTestEntityOwnedRelationshipZeroOrManyCommandHandlerBase
{
	public UpdateSecEntityOwnedRelZeroOrManiesForTestEntityOwnedRelationshipZeroOrManyCommandHandler(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<SecEntityOwnedRelZeroOrManyEntity, SecEntityOwnedRelZeroOrManyUpsertDto, SecEntityOwnedRelZeroOrManyUpsertDto> entityFactory)
		: base(repository, noxSolution, entityFactory)
	{
	}
}

internal partial class UpdateSecEntityOwnedRelZeroOrManiesForTestEntityOwnedRelationshipZeroOrManyCommandHandlerBase : CommandCollectionBase<UpdateSecEntityOwnedRelZeroOrManiesForTestEntityOwnedRelationshipZeroOrManyCommand, SecEntityOwnedRelZeroOrManyEntity>, IRequestHandler <UpdateSecEntityOwnedRelZeroOrManiesForTestEntityOwnedRelationshipZeroOrManyCommand, IEnumerable<SecEntityOwnedRelZeroOrManyKeyDto>>
{
	private readonly IRepository _repository;
	private readonly IEntityFactory<SecEntityOwnedRelZeroOrManyEntity, SecEntityOwnedRelZeroOrManyUpsertDto, SecEntityOwnedRelZeroOrManyUpsertDto> _entityFactory;

	protected UpdateSecEntityOwnedRelZeroOrManiesForTestEntityOwnedRelationshipZeroOrManyCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<SecEntityOwnedRelZeroOrManyEntity, SecEntityOwnedRelZeroOrManyUpsertDto, SecEntityOwnedRelZeroOrManyUpsertDto> entityFactory)
		: base(noxSolution)
	{
		_repository = repository;
		_entityFactory = entityFactory;
	}

	public virtual async Task<IEnumerable<SecEntityOwnedRelZeroOrManyKeyDto>> Handle(UpdateSecEntityOwnedRelZeroOrManiesForTestEntityOwnedRelationshipZeroOrManyCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);

		var keys = new List<object?>(1);
		keys.Add(Dto.TestEntityOwnedRelationshipZeroOrManyMetadata.CreateId(request.ParentKeyDto.keyId));

		var parentEntity = await _repository.FindAndIncludeAsync<TestWebApp.Domain.TestEntityOwnedRelationshipZeroOrMany>(keys.ToArray(),e => e.SecEntityOwnedRelZeroOrManies, cancellationToken);
		EntityNotFoundException.ThrowIfNull(parentEntity, "TestEntityOwnedRelationshipZeroOrMany",  "keyId");				
		List<SecEntityOwnedRelZeroOrManyEntity> entities = new(request.EntitiesDto.Count());
		foreach(var entityDto in request.EntitiesDto)
		{
			SecEntityOwnedRelZeroOrManyEntity? entity;
			if(entityDto.Id is null)
			{
				entity = await CreateEntityAsync(entityDto, parentEntity, request.CultureCode);
				parentEntity.CreateRefToSecEntityOwnedRelZeroOrManies(entity);
			}
			else
			{
				var ownedId = Dto.SecEntityOwnedRelZeroOrManyMetadata.CreateId(entityDto.Id.NonNullValue<System.String>());
				entity = parentEntity.SecEntityOwnedRelZeroOrManies.SingleOrDefault(x => x.Id == ownedId);
				if (entity is null)
				{
					entity = await CreateEntityAsync(entityDto, parentEntity, request.CultureCode);
					parentEntity.CreateRefToSecEntityOwnedRelZeroOrManies(entity);
				}
				else
				{
					await _entityFactory.UpdateEntityAsync(entity, entityDto, request.CultureCode);
				}
			}

			entities.Add(entity);
		}

		parentEntity.Etag = request.Etag ?? System.Guid.Empty;		
		_repository.Update(parentEntity);
		await OnCompletedAsync(request, entities!);
		await _repository.SaveChangesAsync();

		return entities.Select(entity => new SecEntityOwnedRelZeroOrManyKeyDto(entity.Id.Value));
	}
	
	private async Task<SecEntityOwnedRelZeroOrManyEntity> CreateEntityAsync(SecEntityOwnedRelZeroOrManyUpsertDto upsertDto, TestEntityOwnedRelationshipZeroOrManyEntity parent, Nox.Types.CultureCode cultureCode)
	{
		var entity = await _entityFactory.CreateEntityAsync(upsertDto, cultureCode);
		parent.CreateRefToSecEntityOwnedRelZeroOrManies(entity);
		return entity;
	}
}

public class UpdateSecEntityOwnedRelZeroOrManiesForTestEntityOwnedRelationshipZeroOrManyCommandValidator : AbstractValidator<UpdateSecEntityOwnedRelZeroOrManiesForTestEntityOwnedRelationshipZeroOrManyCommand>
{
    public UpdateSecEntityOwnedRelZeroOrManiesForTestEntityOwnedRelationshipZeroOrManyCommandValidator()
    {		
		RuleForEach(x => x.EntitiesDto).Must(x => x.Id is not null).WithMessage("Id is required.");
    }
}