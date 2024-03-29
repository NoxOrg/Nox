﻿﻿﻿﻿// Generated

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

public partial record UpdateSecEntityOwnedRelZeroOrManyForSingleTestEntityOwnedRelationshipZeroOrManyCommand(TestEntityOwnedRelationshipZeroOrManyKeyDto ParentKeyDto, SecEntityOwnedRelZeroOrManyUpsertDto EntityDto, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest <SecEntityOwnedRelZeroOrManyKeyDto>;

internal partial class UpdateSecEntityOwnedRelZeroOrManyForSingleTestEntityOwnedRelationshipZeroOrManyCommandHandler : UpdateSecEntityOwnedRelZeroOrManyForSingleTestEntityOwnedRelationshipZeroOrManyCommandHandlerBase
{
	public UpdateSecEntityOwnedRelZeroOrManyForSingleTestEntityOwnedRelationshipZeroOrManyCommandHandler(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<SecEntityOwnedRelZeroOrManyEntity, SecEntityOwnedRelZeroOrManyUpsertDto, SecEntityOwnedRelZeroOrManyUpsertDto> entityFactory)
		: base(repository, noxSolution, entityFactory)
	{
	}
}

internal partial class UpdateSecEntityOwnedRelZeroOrManyForSingleTestEntityOwnedRelationshipZeroOrManyCommandHandlerBase : CommandBase<UpdateSecEntityOwnedRelZeroOrManyForSingleTestEntityOwnedRelationshipZeroOrManyCommand, SecEntityOwnedRelZeroOrManyEntity>, IRequestHandler <UpdateSecEntityOwnedRelZeroOrManyForSingleTestEntityOwnedRelationshipZeroOrManyCommand, SecEntityOwnedRelZeroOrManyKeyDto>
{
	private readonly IRepository _repository;
	private readonly IEntityFactory<SecEntityOwnedRelZeroOrManyEntity, SecEntityOwnedRelZeroOrManyUpsertDto, SecEntityOwnedRelZeroOrManyUpsertDto> _entityFactory;

	protected UpdateSecEntityOwnedRelZeroOrManyForSingleTestEntityOwnedRelationshipZeroOrManyCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<SecEntityOwnedRelZeroOrManyEntity, SecEntityOwnedRelZeroOrManyUpsertDto, SecEntityOwnedRelZeroOrManyUpsertDto> entityFactory)
		: base(noxSolution)
	{
		_repository = repository;
		_entityFactory = entityFactory;
	}

	public virtual async Task<SecEntityOwnedRelZeroOrManyKeyDto> Handle(UpdateSecEntityOwnedRelZeroOrManyForSingleTestEntityOwnedRelationshipZeroOrManyCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);

		var keys = new List<object?>(1);
		keys.Add(Dto.TestEntityOwnedRelationshipZeroOrManyMetadata.CreateId(request.ParentKeyDto.keyId));

		var parentEntity = await _repository.FindAndIncludeAsync<TestWebApp.Domain.TestEntityOwnedRelationshipZeroOrMany>(keys.ToArray(),e => e.SecEntityOwnedRelZeroOrManies, cancellationToken);
		EntityNotFoundException.ThrowIfNull(parentEntity, "TestEntityOwnedRelationshipZeroOrMany",  "keyId");
		var entity = parentEntity.SecEntityOwnedRelZeroOrManies.Find(e => e.Id == Dto.SecEntityOwnedRelZeroOrManyMetadata.CreateId(request.EntityDto.Id! )); 
		EntityNotFoundException.ThrowIfNull(entity, "SecEntityOwnedRelZeroOrMany",  "keyId");
		await _entityFactory.UpdateEntityAsync(entity, request.EntityDto, request.CultureCode);

		parentEntity.Etag = request.Etag ?? System.Guid.Empty;		
		_repository.Update(parentEntity);
		await OnCompletedAsync(request, entity!);
		await _repository.SaveChangesAsync();

		return new SecEntityOwnedRelZeroOrManyKeyDto(entity.Id.Value);
	}
}

public class UpdateSecEntityOwnedRelZeroOrManyForSingleTestEntityOwnedRelationshipZeroOrManyCommandValidator : AbstractValidator<UpdateSecEntityOwnedRelZeroOrManyForSingleTestEntityOwnedRelationshipZeroOrManyCommand>
{
    public UpdateSecEntityOwnedRelZeroOrManyForSingleTestEntityOwnedRelationshipZeroOrManyCommandValidator()
    {		
		RuleFor(x => x.EntityDto.Id).NotNull().WithMessage("Id is required.");
    }
}