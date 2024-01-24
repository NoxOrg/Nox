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
using SecEntityOwnedRelExactlyOneEntity = TestWebApp.Domain.SecEntityOwnedRelExactlyOne;

namespace TestWebApp.Application.Commands;
public partial record DeleteSecEntityOwnedRelExactlyOneForTestEntityOwnedRelationshipExactlyOneCommand(TestEntityOwnedRelationshipExactlyOneKeyDto ParentKeyDto) : IRequest <bool>;


internal partial class DeleteSecEntityOwnedRelExactlyOneForTestEntityOwnedRelationshipExactlyOneCommandHandler : DeleteSecEntityOwnedRelExactlyOneForTestEntityOwnedRelationshipExactlyOneCommandHandlerBase
{
	public DeleteSecEntityOwnedRelExactlyOneForTestEntityOwnedRelationshipExactlyOneCommandHandler(
        IRepository repository,
		NoxSolution noxSolution)
		: base(repository, noxSolution)
	{
	}
}

internal partial class DeleteSecEntityOwnedRelExactlyOneForTestEntityOwnedRelationshipExactlyOneCommandHandlerBase : CommandBase<DeleteSecEntityOwnedRelExactlyOneForTestEntityOwnedRelationshipExactlyOneCommand, SecEntityOwnedRelExactlyOneEntity>, IRequestHandler <DeleteSecEntityOwnedRelExactlyOneForTestEntityOwnedRelationshipExactlyOneCommand, bool>
{
	public IRepository Repository { get; }

	public DeleteSecEntityOwnedRelExactlyOneForTestEntityOwnedRelationshipExactlyOneCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution) : base(noxSolution)
	{
		Repository = repository;
	}

	public virtual async Task<bool> Handle(DeleteSecEntityOwnedRelExactlyOneForTestEntityOwnedRelationshipExactlyOneCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		
		var keys = new List<object?>(1);
		keys.Add(Dto.TestEntityOwnedRelationshipExactlyOneMetadata.CreateId(request.ParentKeyDto.keyId));
		var parentEntity = await Repository.FindAndIncludeAsync<TestEntityOwnedRelationshipExactlyOne>(keys.ToArray(), p => p.SecEntityOwnedRelExactlyOne, cancellationToken);
		if (parentEntity == null)
		{
			throw new EntityNotFoundException("TestEntityOwnedRelationshipExactlyOne",  "keyId");
		}				
		var entity = parentEntity.SecEntityOwnedRelExactlyOne;
		if (entity == null)
		{
			throw new EntityNotFoundException("TestEntityOwnedRelationshipExactlyOne.SecEntityOwnedRelExactlyOne",  String.Empty);
		}

		parentEntity.DeleteRefToSecEntityOwnedRelExactlyOne(entity);
		
		
		
		await OnCompletedAsync(request, entity);
		Repository.Delete(entity);
		await Repository.SaveChangesAsync(cancellationToken);

		return true;
	}
}