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
using SecEntityOwnedRelOneOrManyEntity = TestWebApp.Domain.SecEntityOwnedRelOneOrMany;
using TestEntityOwnedRelationshipOneOrManyEntity = TestWebApp.Domain.TestEntityOwnedRelationshipOneOrMany;

namespace TestWebApp.Application.Commands;

public partial record UpdateSecEntityOwnedRelOneOrManiesForTestEntityOwnedRelationshipOneOrManyCommand(TestEntityOwnedRelationshipOneOrManyKeyDto ParentKeyDto, IEnumerable<SecEntityOwnedRelOneOrManyUpsertDto> EntitiesDto, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest<bool>;

internal partial class UpdateSecEntityOwnedRelOneOrManiesForTestEntityOwnedRelationshipOneOrManyCommandHandler : UpdateSecEntityOwnedRelOneOrManiesForTestEntityOwnedRelationshipOneOrManyCommandHandlerBase
{
	public UpdateSecEntityOwnedRelOneOrManiesForTestEntityOwnedRelationshipOneOrManyCommandHandler(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<SecEntityOwnedRelOneOrManyEntity, SecEntityOwnedRelOneOrManyUpsertDto, SecEntityOwnedRelOneOrManyUpsertDto> entityFactory)
		: base(repository, noxSolution, entityFactory)
	{
	}
}

internal partial class UpdateSecEntityOwnedRelOneOrManiesForTestEntityOwnedRelationshipOneOrManyCommandHandlerBase : CommandBase<UpdateSecEntityOwnedRelOneOrManiesForTestEntityOwnedRelationshipOneOrManyCommand, SecEntityOwnedRelOneOrManyEntity>, IRequestHandler <UpdateSecEntityOwnedRelOneOrManiesForTestEntityOwnedRelationshipOneOrManyCommand, bool>
{
	private readonly IRepository _repository;
	private readonly IEntityFactory<SecEntityOwnedRelOneOrManyEntity, SecEntityOwnedRelOneOrManyUpsertDto, SecEntityOwnedRelOneOrManyUpsertDto> _entityFactory;

	protected UpdateSecEntityOwnedRelOneOrManiesForTestEntityOwnedRelationshipOneOrManyCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<SecEntityOwnedRelOneOrManyEntity, SecEntityOwnedRelOneOrManyUpsertDto, SecEntityOwnedRelOneOrManyUpsertDto> entityFactory)
		: base(noxSolution)
	{
		_repository = repository;
		_entityFactory = entityFactory;
	}

	public virtual async Task<bool> Handle(UpdateSecEntityOwnedRelOneOrManiesForTestEntityOwnedRelationshipOneOrManyCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);

		var keys = new List<object?>(1);
		keys.Add(Dto.TestEntityOwnedRelationshipOneOrManyMetadata.CreateId(request.ParentKeyDto.keyId));

		var parentEntity = await _repository.FindAndIncludeAsync<TestWebApp.Domain.TestEntityOwnedRelationshipOneOrMany>(keys.ToArray(),e => e.SecEntityOwnedRelOneOrManies, cancellationToken);
		EntityNotFoundException.ThrowIfNull(parentEntity, "TestEntityOwnedRelationshipOneOrMany",  "keyId");				
		List<SecEntityOwnedRelOneOrManyEntity> entities = new(); // count
		foreach(var entityDto in request.EntitiesDto)
		{
			SecEntityOwnedRelOneOrManyEntity? entity;
			if(entityDto.Id is null)
			{
				entity = await CreateEntityAsync(entityDto, parentEntity, request.CultureCode);
			}
			else
			{
				var ownedId = Dto.SecEntityOwnedRelOneOrManyMetadata.CreateId(entityDto.Id.NonNullValue<System.String>());
				entity = parentEntity.SecEntityOwnedRelOneOrManies.SingleOrDefault(x => x.Id == ownedId);
				if (entity is null)
					entity = await CreateEntityAsync(entityDto, parentEntity, request.CultureCode);
				else
					await _entityFactory.UpdateEntityAsync(entity, entityDto, request.CultureCode);
			}

			entities.Add(entity);
		}

		parentEntity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;		
		_repository.Update(parentEntity);
		//await OnCompletedAsync(request, entity!); // fix
		await _repository.SaveChangesAsync();

		return true;
	}
	
	private async Task<SecEntityOwnedRelOneOrManyEntity> CreateEntityAsync(SecEntityOwnedRelOneOrManyUpsertDto upsertDto, TestEntityOwnedRelationshipOneOrManyEntity parent, Nox.Types.CultureCode cultureCode)
	{
		var entity = await _entityFactory.CreateEntityAsync(upsertDto, cultureCode);
		parent.CreateRefToSecEntityOwnedRelOneOrManies(entity);
		return entity;
	}
}

public class UpdateSecEntityOwnedRelOneOrManiesForTestEntityOwnedRelationshipOneOrManyValidator : AbstractValidator<UpdateSecEntityOwnedRelOneOrManiesForTestEntityOwnedRelationshipOneOrManyCommand>
{
    public UpdateSecEntityOwnedRelOneOrManiesForTestEntityOwnedRelationshipOneOrManyValidator()
    {		
		RuleForEach(x => x.EntitiesDto).Must(x => x.Id is not null).WithMessage("Id is required.");
    }
}