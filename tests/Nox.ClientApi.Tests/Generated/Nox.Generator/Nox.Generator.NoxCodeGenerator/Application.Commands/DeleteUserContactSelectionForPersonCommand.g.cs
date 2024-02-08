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
using ClientApi.Domain;
using ClientApi.Application.Dto;
using Dto = ClientApi.Application.Dto;
using UserContactSelectionEntity = ClientApi.Domain.UserContactSelection;

namespace ClientApi.Application.Commands;
public partial record DeleteUserContactSelectionForPersonCommand(PersonKeyDto ParentKeyDto) : IRequest <bool>;


internal partial class DeleteUserContactSelectionForPersonCommandHandler : DeleteUserContactSelectionForPersonCommandHandlerBase
{
	public DeleteUserContactSelectionForPersonCommandHandler(
        IRepository repository,
		NoxSolution noxSolution)
		: base(repository, noxSolution)
	{
	}
}

internal partial class DeleteUserContactSelectionForPersonCommandHandlerBase : CommandBase<DeleteUserContactSelectionForPersonCommand, UserContactSelectionEntity>, IRequestHandler <DeleteUserContactSelectionForPersonCommand, bool>
{
	public IRepository Repository { get; }

	public DeleteUserContactSelectionForPersonCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution) : base(noxSolution)
	{
		Repository = repository;
	}

	public virtual async Task<bool> Handle(DeleteUserContactSelectionForPersonCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		
		var keys = new List<object?>(1);
		keys.Add(Dto.PersonMetadata.CreateId(request.ParentKeyDto.keyId));
		var parentEntity = await Repository.FindAndIncludeAsync<ClientApi.Domain.Person>(keys.ToArray(), p => p.UserContactSelection, cancellationToken);
		if (parentEntity == null)
		{
			throw new EntityNotFoundException("Person",  "keyId");
		}				
		var entity = parentEntity.UserContactSelection;
		if (entity == null)
		{
			throw new EntityNotFoundException("Person.UserContactSelection",  String.Empty);
		}

		parentEntity.DeleteRefToUserContactSelection(entity);
		
		
		
		await OnCompletedAsync(request, entity);
		Repository.Delete(entity);
		await Repository.SaveChangesAsync(cancellationToken);

		return true;
	}
}