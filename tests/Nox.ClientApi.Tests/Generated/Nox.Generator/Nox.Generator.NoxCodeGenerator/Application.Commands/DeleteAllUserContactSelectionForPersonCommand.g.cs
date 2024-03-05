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

public partial record DeleteAllUserContactSelectionForPersonCommand(PersonKeyDto ParentKeyDto, System.Guid? Etag) : IRequest <bool>;


internal partial class DeleteAllUserContactSelectionForPersonCommandHandler : DeleteAllUserContactSelectionForPersonCommandHandlerBase
{
	public DeleteAllUserContactSelectionForPersonCommandHandler(
        IRepository repository,
		NoxSolution noxSolution)
		: base(repository, noxSolution)
	{
	}
}

internal partial class DeleteAllUserContactSelectionForPersonCommandHandlerBase : CommandBase<DeleteAllUserContactSelectionForPersonCommand, UserContactSelectionEntity>, IRequestHandler <DeleteAllUserContactSelectionForPersonCommand, bool>
{
	public IRepository Repository { get; }

	public DeleteAllUserContactSelectionForPersonCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution) : base(noxSolution)
	{
		Repository = repository;
	}

	public virtual async Task<bool> Handle(DeleteAllUserContactSelectionForPersonCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		
		var keys = new List<object?>(1);
		keys.Add(Dto.PersonMetadata.CreateId(request.ParentKeyDto.keyId));
		
		var parentEntity = await Repository.FindAndIncludeAsync<ClientApi.Domain.Person>(keys.ToArray(), p => p.UserContactSelection, cancellationToken);
		EntityNotFoundException.ThrowIfNull(parentEntity, "Person", "parentKeyId");
					
		var entity = parentEntity.UserContactSelection;
		EntityNotFoundException.ThrowIfNull(entity, "Person.UserContactSelection",  String.Empty);

		parentEntity.DeleteAllRefToUserContactSelection();
		parentEntity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;
		
		await OnCompletedAsync(request, entity);
		Repository.Delete(entity);
		Repository.Update(parentEntity);
		await Repository.SaveChangesAsync(cancellationToken);

		return true;
	}
}