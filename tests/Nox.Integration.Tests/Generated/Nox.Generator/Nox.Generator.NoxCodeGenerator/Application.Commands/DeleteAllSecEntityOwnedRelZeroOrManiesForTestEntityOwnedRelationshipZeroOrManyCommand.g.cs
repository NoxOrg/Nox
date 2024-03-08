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
using TestEntityOwnedRelationshipZeroOrManyEntity = TestWebApp.Domain.TestEntityOwnedRelationshipZeroOrMany;

namespace TestWebApp.Application.Commands;

public partial record DeleteAllSecEntityOwnedRelZeroOrManiesForTestEntityOwnedRelationshipZeroOrManyCommand(TestEntityOwnedRelationshipZeroOrManyKeyDto ParentKeyDto, System.Guid? Etag) : IRequest <bool>;


internal partial class DeleteAllSecEntityOwnedRelZeroOrManiesForTestEntityOwnedRelationshipZeroOrManyCommandHandler : DeleteAllSecEntityOwnedRelZeroOrManiesForTestEntityOwnedRelationshipZeroOrManyCommandHandlerBase
{
	public DeleteAllSecEntityOwnedRelZeroOrManiesForTestEntityOwnedRelationshipZeroOrManyCommandHandler(
        IRepository repository,
		NoxSolution noxSolution)
		: base(repository, noxSolution)
	{
	}
}

internal partial class DeleteAllSecEntityOwnedRelZeroOrManiesForTestEntityOwnedRelationshipZeroOrManyCommandHandlerBase : CommandBase<DeleteAllSecEntityOwnedRelZeroOrManiesForTestEntityOwnedRelationshipZeroOrManyCommand, TestEntityOwnedRelationshipZeroOrManyEntity>, IRequestHandler <DeleteAllSecEntityOwnedRelZeroOrManiesForTestEntityOwnedRelationshipZeroOrManyCommand, bool>
{
	public IRepository Repository { get; }

	public DeleteAllSecEntityOwnedRelZeroOrManiesForTestEntityOwnedRelationshipZeroOrManyCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution) : base(noxSolution)
	{
		Repository = repository;
	}

	public virtual async Task<bool> Handle(DeleteAllSecEntityOwnedRelZeroOrManiesForTestEntityOwnedRelationshipZeroOrManyCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		
		var keys = new List<object?>(1);
		keys.Add(Dto.TestEntityOwnedRelationshipZeroOrManyMetadata.CreateId(request.ParentKeyDto.keyId));
		var parentEntity = await Repository.FindAndIncludeAsync<TestWebApp.Domain.TestEntityOwnedRelationshipZeroOrMany>(keys.ToArray(), p => p.SecEntityOwnedRelZeroOrManies, cancellationToken);
		EntityNotFoundException.ThrowIfNull(parentEntity, "TestEntityOwnedRelationshipZeroOrMany", "parentKeyId");
		
		Repository.DeleteOwned(parentEntity.SecEntityOwnedRelZeroOrManies);
		
		parentEntity.DeleteAllRefToSecEntityOwnedRelZeroOrManies();
		parentEntity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;
		
		await OnCompletedAsync(request, parentEntity);
		Repository.Update(parentEntity);
		await Repository.SaveChangesAsync(cancellationToken);

		return true;
	}
}