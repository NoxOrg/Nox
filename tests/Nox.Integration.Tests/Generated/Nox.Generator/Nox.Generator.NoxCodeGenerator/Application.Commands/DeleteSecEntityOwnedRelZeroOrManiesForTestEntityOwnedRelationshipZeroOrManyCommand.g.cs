﻿﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Domain;
using Nox.Types;
using Nox.Application.Factories;
using Nox.Exceptions;
using TestWebApp.Domain;
using TestWebApp.Application.Dto;
using Dto = TestWebApp.Application.Dto;
using SecEntityOwnedRelZeroOrManyEntity = TestWebApp.Domain.SecEntityOwnedRelZeroOrMany;

namespace TestWebApp.Application.Commands;
public partial record DeleteSecEntityOwnedRelZeroOrManiesForTestEntityOwnedRelationshipZeroOrManyCommand(TestEntityOwnedRelationshipZeroOrManyKeyDto ParentKeyDto, SecEntityOwnedRelZeroOrManyKeyDto EntityKeyDto) : IRequest <bool>;

internal partial class DeleteSecEntityOwnedRelZeroOrManiesForTestEntityOwnedRelationshipZeroOrManyCommandHandler : DeleteSecEntityOwnedRelZeroOrManiesForTestEntityOwnedRelationshipZeroOrManyCommandHandlerBase
{
	public DeleteSecEntityOwnedRelZeroOrManiesForTestEntityOwnedRelationshipZeroOrManyCommandHandler(
        IRepository repository,
		NoxSolution noxSolution)
		: base(repository, noxSolution)
	{
	}
}

internal partial class DeleteSecEntityOwnedRelZeroOrManiesForTestEntityOwnedRelationshipZeroOrManyCommandHandlerBase : CommandBase<DeleteSecEntityOwnedRelZeroOrManiesForTestEntityOwnedRelationshipZeroOrManyCommand, SecEntityOwnedRelZeroOrManyEntity>, IRequestHandler <DeleteSecEntityOwnedRelZeroOrManiesForTestEntityOwnedRelationshipZeroOrManyCommand, bool>
{
	public IRepository Repository { get; }

	public DeleteSecEntityOwnedRelZeroOrManiesForTestEntityOwnedRelationshipZeroOrManyCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution) : base(noxSolution)
	{
		Repository = repository;
	}

	public virtual async Task<bool> Handle(DeleteSecEntityOwnedRelZeroOrManiesForTestEntityOwnedRelationshipZeroOrManyCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		
		var keys = new List<object?>(1);
		keys.Add(Dto.TestEntityOwnedRelationshipZeroOrManyMetadata.CreateId(request.ParentKeyDto.keyId));
		var parentEntity = await Repository.FindAndIncludeAsync<TestEntityOwnedRelationshipZeroOrMany>(keys.ToArray(), p => p.SecEntityOwnedRelZeroOrManies, cancellationToken);
		if (parentEntity == null)
		{
			throw new EntityNotFoundException("TestEntityOwnedRelationshipZeroOrMany",  "keyId");
		}
		var ownedId = Dto.SecEntityOwnedRelZeroOrManyMetadata.CreateId(request.EntityKeyDto.keyId);
		var entity = parentEntity.SecEntityOwnedRelZeroOrManies.SingleOrDefault(x => x.Id == ownedId);
		if (entity == null)
		{
			throw new EntityNotFoundException("SecEntityOwnedRelZeroOrMany.SecEntityOwnedRelZeroOrManies",  $"ownedId");
		}
		parentEntity.SecEntityOwnedRelZeroOrManies.Remove(entity);
		
		await OnCompletedAsync(request, entity);
		Repository.Delete(entity);
		await Repository.SaveChangesAsync(cancellationToken);

		return true;
	}
}