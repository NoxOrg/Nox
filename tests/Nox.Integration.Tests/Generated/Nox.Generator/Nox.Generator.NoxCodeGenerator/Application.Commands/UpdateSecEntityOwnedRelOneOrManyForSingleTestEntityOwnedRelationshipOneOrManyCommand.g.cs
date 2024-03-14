﻿﻿﻿// Generated

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

public partial record UpdateSecEntityOwnedRelOneOrManyForSingleTestEntityOwnedRelationshipOneOrManyCommand(TestEntityOwnedRelationshipOneOrManyKeyDto ParentKeyDto, SecEntityOwnedRelOneOrManyUpsertDto EntityDto, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest <SecEntityOwnedRelOneOrManyKeyDto>;

internal partial class UpdateSecEntityOwnedRelOneOrManyForSingleTestEntityOwnedRelationshipOneOrManyCommandHandler : UpdateSecEntityOwnedRelOneOrManyForSingleTestEntityOwnedRelationshipOneOrManyCommandHandlerBase
{
	public UpdateSecEntityOwnedRelOneOrManyForSingleTestEntityOwnedRelationshipOneOrManyCommandHandler(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<SecEntityOwnedRelOneOrManyEntity, SecEntityOwnedRelOneOrManyUpsertDto, SecEntityOwnedRelOneOrManyUpsertDto> entityFactory)
		: base(repository, noxSolution, entityFactory)
	{
	}
}

internal partial class UpdateSecEntityOwnedRelOneOrManyForSingleTestEntityOwnedRelationshipOneOrManyCommandHandlerBase : CommandBase<UpdateSecEntityOwnedRelOneOrManyForSingleTestEntityOwnedRelationshipOneOrManyCommand, SecEntityOwnedRelOneOrManyEntity>, IRequestHandler <UpdateSecEntityOwnedRelOneOrManyForSingleTestEntityOwnedRelationshipOneOrManyCommand, SecEntityOwnedRelOneOrManyKeyDto>
{
	private readonly IRepository _repository;
	private readonly IEntityFactory<SecEntityOwnedRelOneOrManyEntity, SecEntityOwnedRelOneOrManyUpsertDto, SecEntityOwnedRelOneOrManyUpsertDto> _entityFactory;

	protected UpdateSecEntityOwnedRelOneOrManyForSingleTestEntityOwnedRelationshipOneOrManyCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<SecEntityOwnedRelOneOrManyEntity, SecEntityOwnedRelOneOrManyUpsertDto, SecEntityOwnedRelOneOrManyUpsertDto> entityFactory)
		: base(noxSolution)
	{
		_repository = repository;
		_entityFactory = entityFactory;
	}

	public virtual async Task<SecEntityOwnedRelOneOrManyKeyDto> Handle(UpdateSecEntityOwnedRelOneOrManyForSingleTestEntityOwnedRelationshipOneOrManyCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);

		var keys = new List<object?>(1);
		keys.Add(Dto.TestEntityOwnedRelationshipOneOrManyMetadata.CreateId(request.ParentKeyDto.keyId));

		var parentEntity = await _repository.FindAndIncludeAsync<TestWebApp.Domain.TestEntityOwnedRelationshipOneOrMany>(keys.ToArray(),e => e.SecEntityOwnedRelOneOrManies, cancellationToken);
		EntityNotFoundException.ThrowIfNull(parentEntity, "TestEntityOwnedRelationshipOneOrMany",  "keyId");
		var entity = parentEntity.SecEntityOwnedRelOneOrManies.Find(e => e.Id == Dto.SecEntityOwnedRelOneOrManyMetadata.CreateId(request.EntityDto.Id! )); 
		EntityNotFoundException.ThrowIfNull(entity, "SecEntityOwnedRelOneOrMany",  "keyId");
		await _entityFactory.UpdateEntityAsync(entity, request.EntityDto, request.CultureCode);

		parentEntity.Etag = request.Etag ?? System.Guid.Empty;		
		_repository.Update(parentEntity);
		await OnCompletedAsync(request, entity!);
		await _repository.SaveChangesAsync();

		return new SecEntityOwnedRelOneOrManyKeyDto(entity.Id.Value);
	}
}

public class UpdateSecEntityOwnedRelOneOrManyForSingleTestEntityOwnedRelationshipOneOrManyCommandValidator : AbstractValidator<UpdateSecEntityOwnedRelOneOrManyForSingleTestEntityOwnedRelationshipOneOrManyCommand>
{
    public UpdateSecEntityOwnedRelOneOrManyForSingleTestEntityOwnedRelationshipOneOrManyCommandValidator()
    {		
		RuleFor(x => x.EntityDto.Id).NotNull().WithMessage("Id is required.");
    }
}